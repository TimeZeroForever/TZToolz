using System.Collections.Generic;

namespace TimeZero.Auction.Bot.Classes.Network.Acitons.Classes.ChatBot.Phrases
{
    public sealed class Phrase_BotCheck : Phrase_Base
    {
        private static readonly List<string> _inputMessageTemplates = new List<string>
            {
                 "бот"
                ,"скупщик"
            };

        private static readonly List<string> _phrases_i0 = new List<string>
            {
                 "Иди нафиг, сам ты бот"
                ,"Сам ты бот"
                ,"Бот, болтать его в рот"
                ,"Ага, самый лучший во всея ТыЗы"
                ,"Та да, однозначно"
                ,"Сто пудов"
                ,"Безусловно"
                ,"Спасибо, поржал"
                ,"От бота слышу"
                ,"Ух ты! А я и не знал!"
                ,"Круто! Так шо, я скоро стану богатым?"
                ,"У вас всех на почве ботов уже крыша поехала что ли?"
                ,"Конечно бот! И вообще все мы боты и живём в матрице!"
            };

        private static readonly List<string> _phrases_i1 = new List<string>
            {
                 " :lesom: дружище"
                ,"Короче, отвали"
                ,"Что ты от меня хочешь?"
                ,"Короче, что тебе нужно?"
                ,"Короче, заканчивай писать бред"
                ,"Уже не смешно. Не отвлекай"
                ,"Блин, тебе поговорить не с кем?"
                ,"Ты думаешь?))"
                ,"лол)))"
                ,"До свидания"
                ,"Спасибо, поржал :smile: "
            };

        private static readonly List<string> _phrases_i2 = new List<string>
            {
                 "В игнор"
                ,"Игнор"
                ,"Нафиг"
                ,"Задолбал"
                ,"Задолбал, не пиши мне"
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

        static Phrase_BotCheck()
        {
            string[] smilesList = new[] { " :smile: ", " :crazy: ", ")", "))" };

            //Populate _phrases_i0
            List<string> phrasesI0Add = new List<string>();
            foreach (string phrase in _phrases_i0)
            {
                foreach (string smile in smilesList)
                {
                    phrasesI0Add.Add(phrase + smile);
                }
            }
            _phrases_i0.AddRange(phrasesI0Add);
        }

        protected override bool IsSenderInIgnore(int iteration)
        {
            return iteration == 2;
        }

        public override bool HasAnswerOnInputMessage(string message)
        {
            foreach (string t in _inputMessageTemplates)
            {
                if (message.Contains(t) &&
                    !message.Contains("боты") &&
                    !message.Contains("боти") &&
                    !message.Contains("забот") &&
                    !message.Contains("робот"))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
