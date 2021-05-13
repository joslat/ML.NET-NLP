using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.ML;

namespace ML.NET_NLP
{
    public class MLNET_StopWordsRemover
    {
        public TextTokens RemoveStopWords(string text)
        {
            var context = new MLContext();
            var emptyData = new List<TextData>();
            var data = context.Data.LoadFromEnumerable(emptyData);

            var detectedLanguage = MLNET_LanguageDetector.DetectLanguageMsML(text);

            var tokenization = context.Transforms.Text.TokenizeIntoWords(
                                MLNET_Params.OutputColumnName,
                                MLNET_Params.InputColumnName,
                                MLNET_Params.Separators)
                .Append(context.Transforms.Text.RemoveDefaultStopWords(
                                MLNET_Params.OutputColumnName, 
                                MLNET_Params.OutputColumnName,
                                detectedLanguage
                                ));

            if (MLNET_Params.CustomStopWords.Any())
            {
                tokenization.Append(context.Transforms.Text.RemoveStopWords(
                                MLNET_Params.OutputColumnName,
                                MLNET_Params.OutputColumnName,
                                MLNET_Params.CustomStopWords
                                ));
            }


            var tokenModel = tokenization.Fit(data);
            var engine = context.Model.CreatePredictionEngine<TextData, TextTokens>(tokenModel);
            var tokens = engine.Predict(new TextData { Text = text });

            return tokens;
        }
    }
}
