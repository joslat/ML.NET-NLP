using System;
using System.Collections.Generic;
using Microsoft.ML;

namespace ML.NET_NLP
{
    public class MLNET_Tokenizer
    {
        public TextTokens Tokenize(string text)
        {
            var context = new MLContext();
            var emptyData = new List<TextData>();
            var data = context.Data.LoadFromEnumerable(emptyData);
            var tokenization = context.Transforms.Text.TokenizeIntoWords(
                            MLNET_Params.OutputColumnName,
                            MLNET_Params.InputColumnName,
                            MLNET_Params.Separators);
            var tokenModel = tokenization.Fit(data);
            var engine = context.Model.CreatePredictionEngine<TextData, TextTokens>(tokenModel);
            var tokens = engine.Predict(new TextData { Text = text });

            return tokens;
        }
    }
}
