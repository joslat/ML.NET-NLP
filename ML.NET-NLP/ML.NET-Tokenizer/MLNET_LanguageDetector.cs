using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NTextCat;
using static Microsoft.ML.Transforms.Text.StopWordsRemovingEstimator;

namespace ML.NET_NLP
{
    // References for detecting a language with C#
    // https://github.com/ivanakcheurov/ntextcat
    // https://github.com/pdonald/language-detection (other to check...)
    // https://stackoverflow.com/Questions/1192768/how-to-detect-the-language-of-a-string
    // https://www.codeproject.com/Articles/43198/Detect-a-written-text-s-language
    // http://idsyst.hu/development/language_detector.html
    // https://fasttext.cc/
    // https://fasttext.cc/docs/en/language-identification.html
    public static class MLNET_LanguageDetector
    {

        public static string DetectLanguage(string text)
        {
            // Don't forget to deploy a language profile (e.g. Core14.profile.xml) with your application.
            // (take a look at "content" folder inside of NTextCat nupkg and here: https://github.com/ivanakcheurov/ntextcat/tree/master/src/LanguageModels).
            var factory = new RankedLanguageIdentifierFactory();
            var identifier = factory.Load("Core14.profile.xml"); // can be an absolute or relative path. Beware of 260 chars limitation of the path length in Windows. Linux allows 4096 chars.
            var languages = identifier.Identify(text);
            var mostCertainLanguage = languages.FirstOrDefault();
            if (mostCertainLanguage != null)
            {
                Console.WriteLine("The language of the text is '{0}' (ISO639-3 code)", mostCertainLanguage.Item1.Iso639_3);
                return mostCertainLanguage.Item1.Iso639_3;
            }
            else
            {
                Console.WriteLine("The language couldn’t be identified with an acceptable degree of certainty");
                return string.Empty;
            }
        }

        public static Language DetectLanguageMsML(string text)
        {
            return GetMicrosoftMLLanguage(DetectLanguage(text));
        }

            private static Language GetMicrosoftMLLanguage(string ISO639LangCode)
        {
            var MsMLLanguage = Language.English;

            switch (ISO639LangCode.ToUpper())
            {
                case "ENG":
                    MsMLLanguage = Language.English;
                    break;
                
                case "ESP":
                    MsMLLanguage = Language.Spanish;
                    break;

                case "DEU":
                    MsMLLanguage = Language.German;
                    break;

                case "FRA":
                    MsMLLanguage = Language.French;
                    break;
                
                case "ITA":
                    MsMLLanguage = Language.Italian;
                    break;

                default:
                    break;
            }

            return MsMLLanguage;
        }
    }
}
