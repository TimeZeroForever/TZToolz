using System.Collections.Generic;

namespace TimeZero.Auction.Bot.Classes.Network.Acitons.Classes.ChatBot.Phrases
{
    public static class WordsDictionary
    {
        private static readonly Dictionary<string, string> _words_gen = new Dictionary<string, string>
        {
             { "ночь" , "ночи"   }
            ,{ "утро" , "утра"   }
            ,{ "день" , "дня"    }
            ,{ "вечер", "вечера" }
        };

        public static string ApplyLanguageCase(string word, string langCase)
        {
            //Normalize lang. case string
            langCase = (langCase ?? string.Empty).Trim().ToLower();

            //If case is not null
            if (!string.IsNullOrEmpty(langCase))
            {
                //Get appropriate lang. case dictionary
                Dictionary<string, string> wordsCases = null;
                switch (langCase)
                {
                    //Genitive case
                    case "gen":
                        {
                            wordsCases = _words_gen;
                            break;
                        }
                }

                //If the dictionary exists
                if (wordsCases != null)
                {
                    //Get word-key
                    string wordKey = (word ?? string.Empty).Trim().ToLower();

                    //Find word
                    if (wordsCases.ContainsKey(wordKey))
                    {
                        word = wordsCases[wordKey];
                    }
                }
            }

            return word;
        }
    }
}
