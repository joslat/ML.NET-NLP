using ML.NET_NLP;
using System;

namespace ML.NET_NLP_Test
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("ML.NET NLP playground ;) !");

            // 01 - Tokenization
            MLNET_Tokenizer tokenizer = new MLNET_Tokenizer();
            var tokens = tokenizer.Tokenize("Hey, I am going to play some time with the ML.NET framework to try to make some meaningful NLP processing while having fun!!!");
            tokens.ConsolePrint();
            Console.ReadLine();

        }
    }
}
