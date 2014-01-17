using System.Collections.Generic;

namespace TimeZero.Auction.Bot.Classes.Network.Acitons.Classes.ChatBot.Phrases
{
    public sealed class Phrase_Credit : Phrase_Base
    {
        private static readonly List<string> _inputMessageTemplates = new List<string>
            {
                 "кредит"
                ,"кридит"
            };

        private static readonly List<string> _phrases_i0 = new List<string>
            {
                 "Нет"
                ,"Кредитами не занимаюсь"
            };

        private static readonly List<string> _phrases_i1 = new List<string>();

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
            return iteration == 1;
        }

        static Phrase_Credit()
        {
            //Populate _phrases_i1
            List<string> phrasesI1Add = new List<string>();
            foreach (string phrase in _phrases_i0)
            {
                string updPhrase = phrase.ToLower();
                phrasesI1Add.Add("Ещё раз говорю, " + updPhrase);
                phrasesI1Add.Add("Повторяю, " + updPhrase);
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
