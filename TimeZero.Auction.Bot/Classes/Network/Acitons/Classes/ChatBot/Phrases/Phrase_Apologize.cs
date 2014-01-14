using System.Collections.Generic;

namespace TimeZero.Auction.Bot.Classes.Network.Acitons.Classes.ChatBot.Phrases
{
    public sealed class Phrase_Apologize : Phrase_Base
    {
        private static readonly List<string> _inputMessageTemplates = new List<string>
            {
                 "дешевле"
                ,"скинуть цену"
                ,"сбросить цену"
                ,"снизить цену"
                ,"скидк"
            };

        private static readonly List<string> _phrases_i0 = new List<string>
            {
                  "Простите, не могу"
                 ,"Прошу прощения, но нет"
                 ,"Не могу, простите"
            };

        private static readonly List<string>[] _phrases = new[]
            {
                 _phrases_i0
            };

        protected override List<string>[] Phrases
        {
            get { return _phrases; }
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
