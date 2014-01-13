using System.Collections.Generic;

namespace TimeZero.Auction.Bot.Classes.Network.Acitons.Classes.ChatBot.Phrases
{
    public sealed class Phrase_Unknown : Phrase_Base
    {
        private static readonly List<string> _phrase_i0 = new List<string>
            {
                 "Занят"
                ,"Я занят"
                ,"Сейчас занят"
                ,"Работаю, извини"
                ,"Давай потом"
            };

        private static readonly List<string>[] _phrases = new[]
            {
                 _phrase_i0
            };

        protected override List<string>[] Phrases
        {
            get { return _phrases; }
        }

        protected override bool IsSenderInIgnore(int iteration)
        {
            return iteration == 1;
        }

        public override bool HasAnswerOnInputMessage(string message)
        {
            return true;
        }
    }
}
