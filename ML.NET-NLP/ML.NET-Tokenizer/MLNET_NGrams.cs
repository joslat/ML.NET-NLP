using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.ML;
using Microsoft.ML.Data;

namespace ML.NET_NLP
{
    public class MLNET_NGrams
    {
        public void Generate(string text)
        {
            var context = new MLContext();
            var data = new List<TextData>();
            data.Add(new TextData { Text = text });
            var dataView = context.Data.LoadFromEnumerable(data);

            var detectedLanguage = MLNET_LanguageDetector.DetectLanguageMsML(text);

            var nGramPipelineChain = context.Transforms.Text.TokenizeIntoWords(
                                MLNET_Params.OutputColumnName,
                                MLNET_Params.InputColumnName,
                                MLNET_Params.Separators)
                .Append(context.Transforms.Text.RemoveDefaultStopWords(
                                MLNET_Params.OutputColumnName,
                                MLNET_Params.OutputColumnName,
                                detectedLanguage
                                ))
                .Append(context.Transforms.Text.RemoveStopWords(
                                MLNET_Params.OutputColumnName,
                                MLNET_Params.OutputColumnName,
                                MLNET_Params.CustomStopWords
                                ))
                .Append(context.Transforms.Conversion.MapValueToKey(MLNET_Params.OutputColumnName)
                .Append(context.Transforms.Text.ProduceNgrams(
                    MLNET_Params.NGramColumnName,
                    MLNET_Params.OutputColumnName,
                    ngramLength: 2,
                    useAllLengths: false,
                    weighting: Microsoft.ML.Transforms.Text.NgramExtractingEstimator.WeightingCriteria.TfIdf)));

            var fittedData = nGramPipelineChain.Fit(dataView);
            // we sort of get the ngrams here...
            var dataTransformed = fittedData.Transform(dataView);
            var preview = dataTransformed.Preview();

            VBuffer<ReadOnlyMemory<char>> slotNames = default;
            dataTransformed.Schema["NGrams"].GetSlotNames(ref slotNames);
            var nGramsColumn = dataTransformed.GetColumn<VBuffer<float>>(dataTransformed.Schema["NGrams"]);
            var slots = slotNames.GetValues();

            // var engine = context.Model.CreatePredictionEngine<TextData, TextTokens>(tokenModel);
            // var tokens = engine.Predict(new TextData { Text = text });
            
            Console.WriteLine("NGrams");

            foreach (var row in nGramsColumn)
            {
                foreach (var item in row.Items())
                {
                    Console.WriteLine($"{slots[item.Key]} ");
                }

                Console.WriteLine();
            }

            // return Ngrams? unsure what to return here...
        }
    }
}
