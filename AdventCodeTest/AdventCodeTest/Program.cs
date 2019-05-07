using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AdventCodeTest
{
    public class Program
    {
        #region Declaration
        static string cancelMatch = "!.";
        static string garbageMatch = "<.*?>";
        static string nonGroupMatch = "[^{}]";
        #endregion

        static void Main(string[] args)
        {
            string cleanInput = Regex.Replace(Console.ReadLine(), cancelMatch, "");
            Console.WriteLine("Matches Found {0}", FindMatchGroupCount(cleanInput));
            Console.WriteLine("Garbage Matches Found: {0}", FindGarbageMatchCount(cleanInput).ToString());
            Console.ReadLine();
        }

        /// <summary>
        /// Finds pattern match count
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        static int FindMatchGroupCount(string input)
        {
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

