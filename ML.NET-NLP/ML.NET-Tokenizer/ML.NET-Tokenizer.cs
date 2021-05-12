using System;
using System.Collections.Generic;
using Microsoft.ML;

namespace ML.NET_Tokenizer
{
    public class MLNET_Tokenizer
    {
        const string _outputColumnName = "Tokens";
        const string _inputColumnName = "Text";
        private char[] _separators = new[] { ' ', '.', ',' };

        public TextTokens Tokenize(string text)
        {
            var context = new MLContext();
            var emptyData = new List<TextData>();
            var data = context.Data.LoadFromEnumerable(emptyData);
            var tokenization = context.Transforms.Text.TokenizeIntoWords(
                            _outputColumnName,
                            _inputColumnName,
                            _separators);
            var tokenModel = tokenization.Fit(data);
            var engine = context.Model.CreatePredictionEngine<TextData, TextTokens>(tokenModel);
            var tokens = engine.Predict(new TextData { Text = text });

            return tokens;
        }
    }
}
