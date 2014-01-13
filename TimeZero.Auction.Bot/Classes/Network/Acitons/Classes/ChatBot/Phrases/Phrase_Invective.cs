using System.Collections.Generic;

namespace TimeZero.Auction.Bot.Classes.Network.Acitons.Classes.ChatBot.Phrases
{
    public sealed class Phrase_Invective :  Phrase_Base
    {
        private static readonly List<string> _inputMessageTemplates = new List<string>
            {
                 "@#"
                ,"нуб"
                ,"нуп"
                ,"чмо"
                ,"урод"
                ,"козел"
                ,"казел"
                ,"козёл"
                ,"казёл"
                ,"дурак"
                ,"баран"
                ,"петух"
                ,"питух"
                ,"олень"
                ,"алень"
                ,"дятел"
                ,"идиот"
                ,"мудак"
                ,"мудло"
            };

        private static readonly List<string> _phrases_i0 = new List<string>
            {
                 "Игнор"
                ,"В игнор"
                ," :lesom: "
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
