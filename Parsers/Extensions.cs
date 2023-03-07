using System;
using System.Collections.Generic;
using System.Text;

namespace ThingNetAU.Parsers
{
    public static class Extensions
    {
        public static IEnumerable<string> SplitToLines(this string input)
        {
            if (input == null)
            {
                yield break;
            }

            using (System.IO.StringReader reader = new System.IO.StringReader(input))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    yield return line;
                }
            }
        }
        public static IEnumerable<string> SplitToRows(this string input)
        {
            if (input == null)
            {
                yield break;
            }

            bool lockread = false;
            string currentread = "";
            foreach (char c in input)
            {
                if (c == ('"'))
                {
                    if (lockread)
                    {
                        lockread = false;
                    }
                    else
                    {
                        lockread = true;
                    }

                }
                if (c.Equals(',') && !lockread)
                {
                    yield return currentread.Trim();
                    currentread = "";
                }
                else
                {
                    currentread += c;
                }

            }
            yield return currentread.Trim();

        }
        public static IEnumerable<string> SplitToRows(this string input, char Qualifier)
        {
            if (input == null)
            {
                yield break;
            }

            bool lockread = false;
            bool LastCharQual = false;
            string currentread = "";
            foreach (char c in input)
            {
                if (c == Qualifier)
                {
                    if (lockread)
                    {
                        lockread = false;
                    }
                    else
                    {
                        lockread = true;
                    }
                    if (!LastCharQual)
                    {
                        LastCharQual = true;
                        continue;
                    }
                }
                if (c.Equals(',') && !lockread)
                {
                    yield return currentread.Trim();
                    currentread = "";
                }
                else
                {
                    currentread += c;
                }

            }
            yield return currentread.Trim();

        }
    }
}
