using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML.NET_NLP
{
    public class TextNGrams
    {
        public float[] NGrams { get; set; }
    }

    public static class TextNGramsExtensions
    {
        public static void ConsolePrint(this TextNGrams nGrams)
        {
            Console.Write(Environment.NewLine);
            var sb = new StringBuilder();
            foreach (var nGram in nGrams.NGrams)
            {
                sb.AppendLine(nGram.ToString());
            }

            Console.WriteLine(sb.ToString());
        }
    }
}
