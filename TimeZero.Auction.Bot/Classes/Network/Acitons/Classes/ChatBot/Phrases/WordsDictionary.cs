using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TimeZero.Auction.Bot.Classes.Network.Acitons.Classes.ChatBot.Phrases
{
    public static class WordsDictionary
    {
        private static Dictionary<string, string> _words_gen = new Dictionary<string, string>
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
                Dictionary<string, string> words_cases = null;
                switch (langCase)
                {
                    //Genitive case
                    case "gen":
                        {
                            words_cases = _words_gen;
                            break;
                        }
                }

                //If the dictionary exists
                if (words_cases != null)
                {
                    //Get word-key
                    string wordKey = (word ?? string.Empty).Trim().ToLower();

                    //Find word
                    if (words_cases.ContainsKey(wordKey))
                    {
                        word = words_cases[wordKey];
                    }
                }
            }

            return word;
        }
    }
}
