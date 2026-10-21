// SPDX-License-Identifier: MPL-2.0
using System;
using System.Text.RegularExpressions;

namespace DetailedTechnologyTooltips
{
    internal static class LayoutPolicy
    {
        internal static int Width(float resourceWidth, int viewportLimit)
        {
            return Math.Min(Math.Max(100, viewportLimit), Math.Max(300, (int)Math.Ceiling(resourceWidth) + 4));
        }
        internal static string BindQuantity(string text)
        {
            return Regex.Replace(text, @" (?=\(x\d+\))", "\u00a0");
        }
    }
}
