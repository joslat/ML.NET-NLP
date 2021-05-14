using ML.NET_NLP;
using System;

namespace ML.NET_NLP_Test
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("ML.NET NLP playground ;) !");
            string toProcess = "Hey Swiss Life, I am going to play some time with the ML.NET framework to try to make some meaningful NLP processing while having fun!!! - swiss life";

            //// 01 - Tokenization
            //Console.WriteLine("01 - Tokenization:");
            //MLNET_Tokenizer tokenizer = new MLNET_Tokenizer();
            //Console.WriteLine("We are about to Tokenize the follwing string:");
            //Console.WriteLine("String: {0}", toProcess);

            //var tokens = tokenizer.Tokenize(toProcess);

            //Console.WriteLine("The tokenized output is:");
            //tokens.ConsolePrint();


            //// 02 - Removal of Stop Words
            //Console.WriteLine("02 - Removal of Stop Words:");
            //MLNET_StopWordsRemover stopWordsRemover = new MLNET_StopWordsRemover();
            //var tokensWoStopWords = stopWordsRemover.RemoveStopWords(toProcess);
            //Console.WriteLine("The tokenized output is:");
            //tokensWoStopWords.ConsolePrint();


            //// 03 - NGram generation
            //Console.WriteLine("03 - NGram generation:");
            //MLNET_NGrams nGramsGenerator = new MLNET_NGrams();
            //nGramsGenerator.Generate(toProcess);

            // 04 - Bag Of Words generation
            Console.WriteLine("04 - Bag of Words generation:");
            MLNET_BagOfWords bagOfWordsGenerator = new MLNET_BagOfWords();
            bagOfWordsGenerator.Generate(toProcess);



            Console.ReadLine();
        }
    }
}
