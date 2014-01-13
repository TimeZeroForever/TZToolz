using System.Collections.Generic;

namespace TimeZero.Auction.Bot.Classes.Network.Acitons.Classes.ChatBot.Phrases
{
    public sealed class Phrase_Dumping : Phrase_Base
    {
        private static readonly List<string> _inputMessageTemplates = new List<string>
            {
                 "демп"
                ,"занижа"
            };

        private static readonly List<string> _phrases_i0 = new List<string>
            {
                 "Это моё решение"
                ,"Я так считаю нужным"
                ,"Я так хочу"
                ,"Мне так нужно"
                ,"Это моё дело"
                ,"Мне так хочется"
                ,"Потому что так нужно"
                ,"Так нужно"
            };

        private static readonly List<string> _phrases_i1 = new List<string>
            {
                 "Давай"
                ,"Ага"
                ,"Угу"
                ,"Ок"
                ,"Бла-бла-бла"
            };

        private static readonly List<string>[] _phrases = new[]
            {
                 _phrases_i0
                ,_phrases_i1
            };

        protected override List<string>[] Phrases
        {
            get { return _phrases; }
        }

        protected override bool IsSenderInIgnore(int iteration)
        {
            return iteration == 2;
        }

        static Phrase_Dumping()
        {
            //Populate _phrases_i1
            List<string> phrasesI1Add = new List<string>();
            foreach (string phrase in _phrases_i0)
            {
                phrasesI1Add.Add(phrase + ", что не так?");
                string updPhrase = phrase.ToLower();
                phrasesI1Add.Add("Повторяю, " + updPhrase);
                phrasesI1Add.Add("Ещё раз, " + updPhrase);
            }
            _phrases_i1.AddRange(phrasesI1Add);
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
