using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TimeZero.Auction.Bot.Classes.Network.Acitons.Classes.ChatBot.Phrases
{
    public sealed class Phrase_Greeting : Phrase_Base
    {
        private static List<string> _inputMessageTemplates = new List<string>()
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
                 ," :lesom: "
            };

        private static readonly List<string>[] _phrases = new List<string>[]
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
            //Populate input message templates list
            _inputMessageTemplates.AddRange(_phrases_i0);

            //Populate _phrases_i1
            List<string> phrases_i1_add = new List<string>();
            foreach (string phrase in _phrases_i0)
            {
                phrases_i1_add.Add(phrase + " :privet: ");
            }
            phrases_i1_add.Add(" :privet: ");
            _phrases_i0.AddRange(phrases_i1_add);

            //Populate _phrases_i2
            List<string> phrases_i2_add = new List<string>();
            foreach (string phrase in _phrases_i0.Distinct())
            {
                string updPhrase = phrase.Replace(" :privet: ", "");
                if (!string.IsNullOrEmpty(updPhrase))
                {
                    phrases_i2_add.Add(updPhrase + " ещё раз");
                    phrases_i2_add.Add(updPhrase + " снова");
                    updPhrase = updPhrase.ToLower();
                    phrases_i2_add.Add("И снова " + updPhrase);
                    phrases_i2_add.Add("И ещё раз " + updPhrase);
                    phrases_i2_add.Add("И опять " + updPhrase);
                }
            }
            _phrases_i1.AddRange(phrases_i2_add.Distinct());
        }

        public override bool HasAnswerOnInputMessage(string message)
        {
            message = message.ToLower();
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
