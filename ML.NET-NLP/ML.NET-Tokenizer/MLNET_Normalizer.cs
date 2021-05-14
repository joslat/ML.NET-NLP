using System;
using System.Collections.Generic;
using Microsoft.ML;

namespace ML.NET_NLP
{
    public class MLNET_Normalizer
    {
        public string Normalize(string text)
        {
            var context = new MLContext();
            var emptyData = new List<TextData>();
            var data = context.Data.LoadFromEnumerable(emptyData);

            var normalizedPipeline = context.Transforms.Text.NormalizeText(
                MLNET_Params.InputColumnName,
                MLNET_Params.InputColumnName,
                Microsoft.ML.Transforms.Text.TextNormalizingEstimator.CaseMode.Lower, 
                keepDiacritics: false, 
                keepPunctuations: false, 
                keepNumbers: true);
            
            var normalizeTransformer = normalizedPipeline.Fit(data);
            
            // this could be string to string like <string, string>, why use a complex type?
            var engine = context.Model.CreatePredictionEngine<TextData, TextData>(normalizeTransformer);
            
            var NormalizedText = engine.Predict(new TextData { Text = text });

            return NormalizedText.Text;
        }
    }
}
