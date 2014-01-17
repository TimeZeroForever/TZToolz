using System.Collections.Generic;
using System.Linq;

namespace TimeZero.Auction.Bot.Classes.Network.Acitons.Classes.ChatBot.Phrases
{
    public sealed class Phrase_Greeting : Phrase_Base
    {
        private static readonly List<string> _inputMessageTemplates = new List<string>
            {
                 "добрый"
                ,"доброе"
                ,"прив"
                ,"здраств"
                ,"здравств"
                ,"здрас"
                ,"сдраств"
                ,"сдравств"
                ,"сдрас"
                ,"ку-ку"
                ,"куку"
            };

        private static readonly List<string> _phrases_i0 = new List<string>
            {
                 "Добр[чь=ая|нь,ер=ый|ро=ое] %time_of_day%"
                ,"Здравствуйте"
                ,"Здравствуй"
                ,"Привет"
            };

        private static readonly List<string> _phrases_i1 = new List<string>
            {
                 "Уже здоровались вроде :smile: "
            };

        private static readonly List<string> _phrases_i2 = new List<string>
            {
                  "Не трать моё время"
                 ,"Очень смешно"
                 ,"Оригинально"
                 ,"Пока"
                 ,"В игнор"
                 ,"Игнор"
                 ," :lesom: "
            };

        private static readonly List<string>[] _phrases = new[]
            {
                 _phrases_i0
                ,_phrases_i1
                ,_phrases_i2
            };

        protected override List<string>[] Phrases
        {
            get { return _phrases; }
        }

        protected override bool IsSenderInIgnore(int iteration)
        {
            return iteration == 2;
        }

        static Phrase_Greeting()
        {
            //Populate _phrases_i0
            List<string> phrasesI0Add = new List<string>();
            foreach (string phrase in _phrases_i0)
            {
                phrasesI0Add.Add(phrase + " :privet: ");
            }
            phrasesI0Add.Add(" :privet: ");
            _phrases_i0.AddRange(phrasesI0Add);

            //Populate _phrases_i1
            List<string> phrasesI1Add = new List<string>();
            foreach (string phrase in _phrases_i0.Distinct())
            {
                string updPhrase = phrase.Replace(" :privet: ", "");
                if (!string.IsNullOrEmpty(updPhrase))
                {
                    phrasesI1Add.Add(updPhrase + " ещё раз");
                    phrasesI1Add.Add(updPhrase + " снова");
                    updPhrase = updPhrase.ToLower();
                    phrasesI1Add.Add("И снова " + updPhrase);
                    phrasesI1Add.Add("И ещё раз " + updPhrase);
                    phrasesI1Add.Add("И опять " + updPhrase);
                }
            }
            _phrases_i1.AddRange(phrasesI1Add.Distinct());
        }

        public override bool HasAnswerOnInputMessage(string message)
        {
            message = message.ToLower();
            if (message.Trim() == ":privet:")
            {
                return true;
            }
            foreach (string t in _inputMessageTemplates)
            {
                if (message.Contains(t))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
