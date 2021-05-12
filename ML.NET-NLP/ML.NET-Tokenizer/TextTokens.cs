using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML.NET_Tokenizer
{
    public class TextTokens
    {
        public string[] Tokens { get; set; }
    }

    public static class TextTokensExtensions
    {
        public static void ConsolePrint(this TextTokens tokens)
        {
            Console.Write(Environment.NewLine);
            var sb = new StringBuilder();
            foreach (var token in tokens.Tokens)
            {
                sb.AppendLine(token);
            }

            Console.WriteLine(sb.ToString());
        }
    }
}
