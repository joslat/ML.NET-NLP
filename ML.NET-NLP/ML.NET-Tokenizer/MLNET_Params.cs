using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML.NET_NLP
{
    public static class MLNET_Params
    {
        private static string _outputColumnName = nameof(TextTokens.Tokens); 
        public static string OutputColumnName {
            get
            {
                return _outputColumnName;
            }
        }

        private static string _inputColumnName = nameof(TextData.Text);
        public static string InputColumnName
        {
            get { 
                return _inputColumnName; }
        }

        private static char[] _separators = new[] { ' ', '.', ',' };
        public static char[] Separators
        {
            get
            {
                return _separators;
            }
        }

        private static string[] _customStopWords = new[] { "Swiss", "Life", "some" };
        public static string[] CustomStopWords
        {
            get
            {
                return _customStopWords;
            }
        }

    }
}
