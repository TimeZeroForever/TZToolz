using System.Collections.Generic;
using System.Linq;

namespace TimeZero.Auction.Bot.Classes.Network.Acitons.Classes.ChatBot.Phrases
{
    public sealed class Phrase_Shopping : Phrase_Base
    {
        private static readonly List<string> _inputMessageTemplates = new List<string>
            {
                 "продам"
                ,"купишь"
                ,"купите"
                ,"интересует"
                ,"нужн"
                ,"нужен"
                ,"продаю"
                ,"продаё"
                ,"продае"
            };

        private static readonly List<string> _phrases_i0 = new List<string>
            {
                 "Простите, не интересует"
                ,"Не интересует"
                ,"Не нужно"
                ,"Сейчас нет"
                ,"Не торгую"
                ,"Нет"
            };

        private static readonly List<string> _phrases_i1 = new List<string>();

        private static readonly List<string> _phrases_i2 = new List<string>
            {
                 "В игнор"
                ,"Нафиг"
                ,"Задолбал, не пиши мне"
                ,"Задолбал"
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

        static Phrase_Shopping()
        {
            //Populate _phrases_i1
            List<string> phrasesI1Add = new List<string>();
            foreach (string phrase in _phrases_i0.Distinct())
            {
                string updPhrase = phrase.Replace("Простите, ", "")
                                         .Replace(", простите", "");
                if (!string.IsNullOrEmpty(updPhrase))
                {
                    phrasesI1Add.Add(updPhrase + ", писал же");
                    updPhrase = updPhrase.ToLower();
                    phrasesI1Add.Add("Эм, ещё раз говорю, " + updPhrase);
                    phrasesI1Add.Add("И ещё раз, " + updPhrase);
                    phrasesI1Add.Add("Повторяю, " + updPhrase);
                    phrasesI1Add.Add("Я вроде уже писал, что " + updPhrase + ", правда?");
                    phrasesI1Add.Add("Предыдущее сообщение не дошло? " + updPhrase);
                }
            }
            _phrases_i1.AddRange(phrasesI1Add.Distinct());
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
