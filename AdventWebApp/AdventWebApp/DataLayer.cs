using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AdventWebApp
{
    public static class DataLayer
    {
        #region Declaration
        static string cancelMatch = "!.";
        static string garbageMatch = "<.*?>";
        static string nonGroupMatch = "[^{}]";
        #endregion

        /// <summary>
        /// Finds pattern match count
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static int FindMatchGroupCount(string input)
        {
            string cleanInput = Regex.Replace(input, cancelMatch, "");
            return ScoreGroups(Regex.Replace(Regex.Replace(input, garbageMatch, ""), nonGroupMatch, "").ToList<char>());
        }

        /// <summary>
        /// Finds garbage match count
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        static int FindGarbageMatchCount(string input)
        {
            return Regex.Matches(input, garbageMatch).Count - 2;
        }

        /// <summary>
        /// Reoccurrsive stream of characters
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="score"></param>
        /// <param name="depth"></param>
        /// <returns></returns>
        static int ScoreGroups(List<char> stream, int score = 0, int depth = 1)
        {
            if (stream == null || stream.Count == 0)
                return score;
            else if (stream.FirstOrDefault().ToString() == "}")
                return ScoreGroups(stream.Skip(1).ToList(), score, depth - 1);
            else
                return ScoreGroups(stream.Skip(1).ToList(), score + depth, depth + 1);
        }
    }
}
