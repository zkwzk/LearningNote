using System.Diagnostics;
using System.Text.RegularExpressions;

namespace ConsoleApplication6
{
	class Program
	{
		static void Main(string[] args)
		{
			string pattern = "I'm {0}, {2} years old man, {1}, {2}";
			object[] param = new object[] { "Boyd", "Hello World", 26 };
			string target = string.Format(pattern, param);
			string actual = Format(pattern, param);
			Debug.Assert(string.Equals(target, actual), "Assert Failed");

			param = new object[] { "{2}", "{1}", "{3}" };
			target = string.Format(pattern, param);
			actual = Format(pattern, param);
			Debug.Assert(string.Equals(target, actual), "Assert Failed");
		}

        //static string Format(string pattern, params object[] args)
        //{
        //    string indexPattern = @"(?<=\{)\d(?=\})";
        //    string positionPattern = @"\{\d\}";
        //    Regex positionRegex = new Regex(positionPattern);
        //    MatchCollection matches = positionRegex.Matches(pattern);
        //    if (matches != null && matches.Count > 0)
        //    {
        //        Regex indexRegex = new Regex(indexPattern);
        //        for (int i = 0; i < matches.Count; i++)
        //        {
        //            string position = matches[i].Value;
        //            int index = int.Parse(indexRegex.Match(position).Value);
        //            pattern = pattern.Replace(position, args[index].ToString());
        //        }
        //    }

        //    return pattern;
        //}

		//static string Format(string pattern, params object[] args)
		//{
		//	pattern = pattern.Replace("{", @"\{");
		//	pattern = pattern.Replace("}", @"\}");
		//	string indexPattern = @"(?<=\\\{)\d(?=\\\})";
		//	string positionPattern = @"\\\{\d\\\}";
		//	Regex positionRegex = new Regex(positionPattern);
		//	MatchCollection matches = positionRegex.Matches(pattern);
		//	Regex indexRegex = new Regex(indexPattern);
		//	if (matches != null && matches.Count > 0)
		//	{
		//		for (int i = 0; i < matches.Count; i++)
		//		{
		//			string position = matches[i].Value;
		//			int index = int.Parse(indexRegex.Match(position).Value);
		//			pattern = pattern.Replace(position, args[index].ToString());
		//		}
		//	}

		//	return pattern;
		//}

        static string Format(string pattern, params object[] args)
        {
            string indexPattern = @"\d";
            string positionPattern = @"\{\d\}";
            Regex positionRegex = new Regex(positionPattern);
            pattern = positionRegex.Replace(pattern, (match) =>
                {
                    string position = match.Value;
                    int index = int.Parse(Regex.Match(position, indexPattern).Value);
                    return args[index].ToString();
                });
            return pattern;
        }
	}
}
