// This Source Code Form is subject to the terms of the Mozilla Public
// License, v. 2.0. If a copy of the MPL was not distributed with this
// file, You can obtain one at http://mozilla.org/MPL/2.0/.

using System;
using System.Collections.Generic;

namespace DetailedTechnologyTooltips
{
    internal static class TextFormatting
    {
        internal static string CorrectBigGuyDescription(
            string description)
        {
            if (string.IsNullOrEmpty(description))
                return null;

            const string stale = "+1";
            var starts = new List<int>();

            for (var i = 0; i <= description.Length - stale.Length; i++)
            {
                if (description[i] != '+'
                    || description[i + 1] != '1')
                {
                    continue;
                }

                var after = i + stale.Length;
                if (after < description.Length)
                {
                    var next = description[after];
                    if (char.IsDigit(next)
                        || next == '.'
                        || next == ',')
                    {
                        continue;
                    }
                }

                starts.Add(i);
                i += stale.Length - 1;
            }

            if (starts.Count != 2)
                return null;

            var result = description;
            for (var i = starts.Count - 1; i >= 0; i--)
            {
                result =
                    result.Remove(starts[i], stale.Length)
                          .Insert(starts[i], "+2");
            }

            return result;
        }

        internal static string RepairBrokenQuantityTokens(
            string raw,
            string processed)
        {
            if (string.IsNullOrEmpty(raw) || string.IsNullOrEmpty(processed))
                return raw;

            List<int> brokenOrdinals;
            int processedCount;
            ScanProcessedQuantities(
                processed,
                out processedCount,
                out brokenOrdinals);

            if (brokenOrdinals.Count == 0)
                return raw;

            var rawStarts = FindRawQuantityStarts(raw);
            if (processedCount != rawStarts.Count)
                return raw;

            for (var i = 0; i < brokenOrdinals.Count; i++)
            {
                if (brokenOrdinals[i] < 0
                    || brokenOrdinals[i] >= rawStarts.Count)
                {
                    return raw;
                }
            }

            var repaired = raw;
            for (var i = brokenOrdinals.Count - 1; i >= 0; i--)
            {
                var tokenStart = rawStarts[brokenOrdinals[i]];
                if (tokenStart <= 0)
                    continue;

                var previous = repaired[tokenStart - 1];
                if (previous == '\n')
                    continue;

                if (previous == ' '
                    || previous == '\t'
                    || previous == '\u00A0')
                {
                    repaired =
                        repaired.Remove(tokenStart - 1, 1)
                            .Insert(tokenStart - 1, "\n");
                }
                else
                {
                    repaired = repaired.Insert(tokenStart, "\n");
                }
            }

            return repaired;
        }

        private static void ScanProcessedQuantities(
            string text,
            out int quantityCount,
            out List<int> brokenOrdinals)
        {
            quantityCount = 0;
            brokenOrdinals = new List<int>();

            for (var i = 0; i < text.Length; i++)
            {
                if (text[i] != '(')
                    continue;

                var close = FindCloseParen(text, i);
                if (close < 0)
                    continue;

                var token = text.Substring(i, close - i + 1);
                var compact =
                    token.Replace("\r", string.Empty)
                         .Replace("\n", string.Empty);

                if (!IsQuantityToken(compact))
                    continue;

                if (token.IndexOf('\n') >= 0 || token.IndexOf('\r') >= 0)
                    brokenOrdinals.Add(quantityCount);

                quantityCount++;
                i = close;
            }
        }

        private static List<int> FindRawQuantityStarts(string text)
        {
            var starts = new List<int>();

            for (var i = 0; i < text.Length; i++)
            {
                if (text[i] != '(')
                    continue;

                var close = FindCloseParen(text, i);
                if (close < 0)
                    continue;

                var token = text.Substring(i, close - i + 1);
                if (!IsQuantityToken(token))
                    continue;

                starts.Add(i);
                i = close;
            }

            return starts;
        }

        private static int FindCloseParen(string text, int open)
        {
            var limit = Math.Min(text.Length, open + 24);
            for (var i = open + 1; i < limit; i++)
            {
                if (text[i] == ')')
                    return i;
            }

            return -1;
        }

        private static bool IsQuantityToken(string token)
        {
            if (string.IsNullOrEmpty(token)
                || token.Length < 4
                || token[0] != '('
                || token[1] != 'x'
                || token[token.Length - 1] != ')')
            {
                return false;
            }

            for (var i = 2; i < token.Length - 1; i++)
            {
                if (!char.IsDigit(token[i]))
                    return false;
            }

            return true;
        }
    }
}
