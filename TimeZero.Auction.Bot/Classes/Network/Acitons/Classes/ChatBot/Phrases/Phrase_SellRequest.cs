using System.Collections.Generic;

namespace TimeZero.Auction.Bot.Classes.Network.Acitons.Classes.ChatBot.Phrases
{
    public sealed class Phrase_SellRequest : Phrase_Base
    {
        private static readonly List<string> _inputMessageTemplates = new List<string>
            {
                 "куплю"
                ,"есть"
                ,"продаеш"
                ,"продаш"
                ,"продаёш"
                ,"купить"
                ,"вернуть"
                ,"верни"
                ,"вирни"
                ,"вернё"
                ,"вирнё"
                ,"верне"
                ,"вирне"
                ,"пажалу"
                ,"пожалу"
            };

        private static readonly List<string> _phrases_i0 = new List<string>
            {
                "Нет"
            };

        private static readonly List<string>[] _phrases = new[]
            {
                 _phrases_i0
            };

        protected override List<string>[] Phrases
        {
            get { return _phrases; }
        }

        public override int ProcessedPhraseValue { get { return 0; } }

        public override bool HasAnswerOnInputMessage(string message)
        {
            message = message.ToLower();
            foreach (string t in _inputMessageTemplates)
            {
                if (message.Contains(t) && message.Contains("?"))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
