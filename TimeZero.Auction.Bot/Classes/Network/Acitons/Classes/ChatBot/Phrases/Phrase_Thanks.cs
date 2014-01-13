using System.Collections.Generic;

namespace TimeZero.Auction.Bot.Classes.Network.Acitons.Classes.ChatBot.Phrases
{
    class Phrase_Thanks : Phrase_Base
    {
        private static readonly List<string> _inputMessageTemplates = new List<string>
            {
                 "спасиб"
                ,"спосиб"
                ,"благодар"
                ,"благадар"
                ,"спс"
                ,"до свидан"
                ,"досвидан"
                ,"щаслив"
                ,"щастлив"
                ,"счаслив"
                ,"счастлив"
            };

        private static readonly List<string> _phrases_i0 = new List<string>
            {
                 "Хороше[ня,ра=го|чи=й] %time_of_day:gen%"
                ,"Удачи"
                ,"Да не вопрос"
                ,"Пока"
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

        static Phrase_Thanks()
        {
            string[] smilesList = new[] { " :privet: ", " :smile: ", ")", "))" };

            //Populate _phrases_i1
            List<string> phrasesI0Add = new List<string>();
            foreach (string phrase in _phrases_i0)
            {
                foreach (string smile in smilesList)
                {
                    phrasesI0Add.Add(phrase + smile);
                }
            }
            foreach (string smile in smilesList)
            {
                phrasesI0Add.Add(smile);
            }
            _phrases_i0.AddRange(phrasesI0Add);
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