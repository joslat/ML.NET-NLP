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
            string toProcess = "Hey Swiss Life, I am going to play some time with the ML.NET framework to try to make some meaningful NLP processing while having fun!!! - swiss life";
            Console.WriteLine("We are about to Tokenize the follwing string:");
            Console.WriteLine("String: {0}", toProcess);

            var tokens = tokenizer.Tokenize(toProcess);

            Console.WriteLine("The tokenized output is:");
            tokens.ConsolePrint();


            // 02 - Removal of Stop Words
            Console.WriteLine("02 - Removal of Stop Words:");
            MLNET_StopWordsRemover stopWordsRemover = new MLNET_StopWordsRemover();
            var tokensWoStopWords = stopWordsRemover.RemoveStopWords(toProcess);
            Console.WriteLine("The tokenized output is:");
            tokensWoStopWords.ConsolePrint();

            Console.ReadLine();
        }
    }
}
