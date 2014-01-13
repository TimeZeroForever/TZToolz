using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TimeZero.Auction.Bot.Classes.Network.Acitons.Classes.ChatBot.Phrases
{
    public sealed class Phrase_Shopping : Phrase_Base
    {
        private static List<string> _inputMessageTemplates = new List<string>()
        {
             "продам"
            ,"купи"
            ,"интересует"
            ,"нужн"
            ,"продаю"
            ,"продаё"
        };

        private static readonly List<string> _phrases_i0 = new List<string>
            {
                 "Простите, не интересует"
                ,"Не интересует"
                ,"Не нужно"
                ,"Сейчас нет"
                ,"Не торгую"
                ,"Сейчас с рук не торгую"
                ,"С рук не торгую, простите"
                ,"Нет"
            };

        private static readonly List<string> _phrases_i1 = new List<string>
            {
            };

        private static readonly List<string> _phrases_i2 = new List<string>
            {
                 "В игнор"
                ,"Нафиг"
                ,"Задолбал, не пиши мне"
                ,"Задолбал"
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

        static Phrase_Shopping()
        {
            //Populate input message templates list
            _inputMessageTemplates.AddRange(_phrases_i0);

            //Populate _phrases_i2
            List<string> phrases_i2_add = new List<string>();
            foreach (string phrase in _phrases_i0.Distinct())
            {
                string updPhrase = phrase.Replace("Простите, ", "")
                                         .Replace(", простите", "");
                if (!string.IsNullOrEmpty(updPhrase))
                {
                    phrases_i2_add.Add(updPhrase + ", писал же");
                    updPhrase = updPhrase.ToLower();
                    phrases_i2_add.Add("Эм, " + updPhrase);
                    phrases_i2_add.Add("И ещё раз: " + updPhrase);
                    phrases_i2_add.Add("Повторяю: " + updPhrase);
                    phrases_i2_add.Add("Я вроде уже писал, что " + updPhrase + ", правда?");
                    phrases_i2_add.Add("Предыдущее сообщение не дошло? " + updPhrase);
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
