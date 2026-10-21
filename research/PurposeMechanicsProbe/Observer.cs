// SPDX-License-Identifier: MPL-2.0
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using BepInEx;
using BepInEx.Bootstrap;
using HarmonyLib;

[BepInPlugin(Id, "Purpose Mechanics Observer", Version)]
public sealed class Observer : BaseUnityPlugin
{
    public const string Id = "nikichmods.research.purposemechanics";
    public const string Version = ThisAssemblyVersion.Value;
    private static Observer instance;
    private static readonly HashSet<string> failures = new HashSet<string>();
    private static readonly List<MethodBase> targets = new List<MethodBase>();
    private static readonly FieldInfo menuCrafts = AccessTools.Field(typeof(BaseCraftGUI), "crafts");
    private static readonly Type generator = typeof(CraftComponent).Assembly.GetType("FlowCanvas.Nodes.Flow_GenerateSoul");
    private static readonly FieldInfo output = generator == null ? null : AccessTools.Field(generator, "out_soul_item_value");
    private static FieldInfo generatorOwner;
    private static int sequence;
    private static bool environmentRecorded;
    [ThreadStatic] private static Sample active;
    public sealed class Sample
    {
        public Sample Previous;
        public int Sequence;
        public WorldGameObject Station;
        public Item Soul;
        public float Before;
        public string Recipe;
        public int Reads, Outputs;
    }

    private void Awake()
    {
        instance = this;
        var harmony = new Harmony(Id);
        Bind(harmony, typeof(BaseCraftGUI), "CommonOpen", new[] { typeof(WorldGameObject), typeof(CraftDefinition.CraftType) }, null, nameof(Menu), null);
        Bind(harmony, typeof(SoulExtractorGUI), "Open", new[] { typeof(WorldGameObject) }, null, nameof(ExtractorOpen), null);
        Bind(harmony, typeof(SoulExtractorGUI), "GetDamageChance", new[] { typeof(WorldGameObject), typeof(bool) }, null, nameof(Chance), null);
        Bind(harmony, typeof(CraftComponent), "ProcessFinishedCraft", Type.EmptyTypes, nameof(Begin), nameof(End), nameof(FinalizeSample));
        Bind(harmony, typeof(CraftComponent).Assembly.GetType("FlowCanvas.Nodes.Flow_GetWGOParam"), "Invoke", new[] { typeof(string), typeof(WorldGameObject) }, null, nameof(Param), null);
        var closure = generator == null ? null : generator.GetNestedType("<>c__DisplayClass1_0", BindingFlags.NonPublic);
        generatorOwner = closure == null ? null : AccessTools.Field(closure, "<>4__this");
        if (generatorOwner != null && output != null)
            Bind(harmony, closure, "<RegisterPorts>b__1", new[] { typeof(FlowCanvas.Flow) }, null, nameof(Generated), null);
        else Log("BIND_MISSING seam=generator-output");
        Log("READY version=" + Version + " host_mvid=" + typeof(CraftComponent).Module.ModuleVersionId + " hooks=" + targets.Count + " synthetic=false");
    }

    private static void Bind(Harmony harmony, Type type, string name, Type[] args, string prefix, string postfix, string finalizer)
    {
        Guard("bind-" + name, () => {
            var method = type == null ? null : AccessTools.DeclaredMethod(type, name, args);
            if (method == null) throw new MissingMethodException(type == null ? "missing type" : type.FullName, name);
            harmony.Patch(method, Hook(prefix, Priority.First), Hook(postfix, Priority.Last), null, Hook(finalizer, Priority.Last), null);
            targets.Add(method);
        });
    }
    private static HarmonyMethod Hook(string name, int priority) { return name == null ? null : new HarmonyMethod(typeof(Observer), name) { priority = priority }; }
    private static void Log(string text) { instance.Logger.LogInfo("PURPOSE_PROBE " + text); }
    private static string F(float value) { return value.ToString("R", CultureInfo.InvariantCulture); }
    private static bool Press(WorldGameObject w) { return w != null && (w.obj_id == "mf_printing_press" || w.obj_id == "mf_printing_press_2"); }
    private static bool Extractor(WorldGameObject w) { return w != null && (w.obj_id == "soul_extractor" || w.obj_id == "soul_extractor_2" || w.obj_id == "soul_extractor_3"); }
    private static void Guard(string key, Action action)
    {
        if (failures.Contains(key)) return;
        try { action(); }
        catch (Exception e) { failures.Add(key); Log("OBSERVER_DISABLED seam=" + key + " error=" + e.GetType().Name + " detail=" + e.Message.Replace('\n', ' ')); }
    }
    private static void EnvironmentAudit()
    {
        if (environmentRecorded) return;
        environmentRecorded = true;
        foreach (var plugin in Chainloader.PluginInfos.Values.OrderBy(p => p.Metadata.GUID))
            Log("PLUGIN id=" + plugin.Metadata.GUID + " version=" + plugin.Metadata.Version);
        var relevant = Harmony.GetAllPatchedMethods().Where(m => m.DeclaringType != null &&
            (m.DeclaringType.FullName.IndexOf("Soul", StringComparison.OrdinalIgnoreCase) >= 0 ||
             m.DeclaringType == typeof(CraftComponent) || m.DeclaringType == typeof(BaseCraftGUI) ||
             (m.DeclaringType == typeof(WorldGameObject) && m.Name == "GetParam")));
        foreach (var target in targets.Concat(relevant).Distinct())
        {
            var info = Harmony.GetPatchInfo(target);
            Log("PATCH_OWNERS method=" + target.DeclaringType.FullName + "." + target.Name + " owners=" + (info == null ? "none" : string.Join(",", info.Owners)));
        }
    }
    private static void PressAudit()
    {
        EnvironmentAudit();
        foreach (var station in new[] { "mf_printing_press", "mf_printing_press_2" })
            foreach (var craft in GameBalance.me.GetCraftsForObject(station))
                Log("PRESS_CANDIDATE station=" + station + " recipe=" + craft.id + " native_visible=" + MainGame.me.save.IsCraftVisible(craft) + " type=" + craft.craft_type + " hidden=" + craft.hidden + " needs_unlock=" + craft.needs_unlock + " locked=" + craft.IsLocked() + " output=" + string.Join(",", craft.output.Select(i => i.id + ":" + i.value)));
    }
    private static void Menu(BaseCraftGUI __instance, WorldGameObject o)
    {
        if (!Press(o)) return;
        Guard("press-menu", () => {
            PressAudit();
            var crafts = (List<CraftDefinition>)menuCrafts.GetValue(__instance);
            Log("PRESS_MENU station=" + o.obj_id + " recipes=" + string.Join(",", crafts.Select(c => c.id)));
        });
    }
    private static string Params(WorldGameObject w)
    {
        return string.Join(" ", new[] { "min_damage_chance", "max_damage_chance", "min_corruption_chance", "max_corruption_chance" }.Select(k => k + "=" + F(w.GetParam(k, 0f))));
    }
    private static void ExtractorOpen(WorldGameObject craft_obj)
    {
        if (!Extractor(craft_obj)) return;
        Guard("extractor-open", () => { EnvironmentAudit(); Log("EXTRACTOR_OPEN station=" + craft_obj.obj_id + " " + Params(craft_obj)); });
    }
    private static void Chance(WorldGameObject craftery_wgo, bool is_min_chance, float __result)
    {
        if (!Extractor(craftery_wgo)) return;
        Guard("ui-chance", () => Log("UI_CHANCE station=" + craftery_wgo.obj_id + " min=" + is_min_chance + " result=" + F(__result)));
    }
    private static void Begin(CraftComponent __instance, out Sample __state)
    {
        __state = null;
        Sample captured = null;
        Guard("soul-begin", () => {
            var w = __instance.wgo;
            if (!Extractor(w)) return;
            var body = w.GetBodyFromInventory(true);
            var soul = body == null ? null : body.GetItemOfType(ItemDefinition.ItemType.SoulBodyPart, true);
            captured = new Sample { Previous = active, Sequence = ++sequence, Station = w, Soul = soul, Before = soul == null ? 0 : soul.durability, Recipe = __instance.current_craft.id };
            active = captured;
            Log("SOUL_BEGIN seq=" + captured.Sequence + " station=" + w.obj_id + " recipe=" + captured.Recipe + " input=" + (soul == null ? "none" : soul.id) + " durability=" + F(captured.Before) + " " + Params(w));
        });
        __state = captured;
    }
    private static void Param(string param, WorldGameObject wgo, float __result)
    {
        if (!Extractor(wgo) || !(param.Contains("damage") || param.Contains("corruption"))) return;
        Guard("graph-param", () => { if (active != null) active.Reads++; Log("GRAPH_PARAM seq=" + (active == null ? 0 : active.Sequence) + " station=" + wgo.obj_id + " key=" + param + " result=" + F(__result)); });
    }
    private static void Generated(object __instance)
    {
        Guard("generator-output", () => {
            var item = (Item)output.GetValue(generatorOwner.GetValue(__instance));
            if (active != null) active.Outputs++;
            Log("SOUL_OUTPUT seq=" + (active == null ? 0 : active.Sequence) + " item=" + (item == null ? "none" : item.id) + " durability=" + (item == null ? "none" : F(item.durability)) + " same_reference=" + (active != null && ReferenceEquals(active.Soul, item)));
        });
    }
    private static void End(Sample __state)
    {
        if (__state == null) return;
        Guard("soul-end", () => Log("SOUL_END seq=" + __state.Sequence + " station=" + __state.Station.obj_id + " after=" + (__state.Soul == null ? "none" : F(__state.Soul.durability)) + " delta=" + (__state.Soul == null ? "none" : F(__state.Soul.durability - __state.Before)) + " graph_reads=" + __state.Reads + " outputs=" + __state.Outputs + " " + Params(__state.Station)));
    }
    private static void FinalizeSample(Sample __state, Exception __exception)
    {
        if (__state == null) return;
        active = __state.Previous;
        if (__exception != null) Guard("host-exception", () => Log("HOST_EXCEPTION seq=" + __state.Sequence + " error=" + __exception.GetType().Name));
    }
}
