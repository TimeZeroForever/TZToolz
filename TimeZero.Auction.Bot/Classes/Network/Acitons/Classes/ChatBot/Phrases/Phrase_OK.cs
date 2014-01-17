using System.Collections.Generic;

namespace TimeZero.Auction.Bot.Classes.Network.Acitons.Classes.ChatBot.Phrases
{
    public sealed class Phrase_OK : Phrase_Base
    {
        private static readonly List<string> _inputMessageTemplates = new List<string>
            {
                 "напиши"
                ,"скинь"
                ,"закончиш"
                ,"освободиш"
                ,"освобадиш"
                ,"напишешь"
                ,"написать"
            };

        private static readonly List<string> _phrases_i0 = new List<string>
            {
                  "Ок"
                 ,"Хорошо"
            };

        private static readonly List<string>[] _phrases = new[]
            {
                 _phrases_i0
            };

        protected override List<string>[] Phrases
        {
            get { return _phrases; }
        }

        protected override bool IsSenderInIgnore(int iteration)
        {
            return true;
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
