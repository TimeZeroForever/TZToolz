using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TimeZero.Auction.Bot.Classes.Network.Acitons.Classes.ChatBot.Phrases
{
    public sealed class Phrase_BotCheck : Phrase_Base
    {
        private static List<string> _inputMessageTemplates = new List<string>()
        {
             "бот"
            ,"скупщик"
        };

        private static readonly List<string> _phrases_i0 = new List<string>
            {
                 "Иди нафиг, сам ты бот :crazy: "
                ,"Сам ты бот :crazy: "
                ,"Бот, болтать его в рот)))"
                ,"Ага, самый лучший во всея ТыЗы)"
                ,"Та да, однозначно"
                ,"Безусловно :smile: "
                ,"Да. А ещё я умею колдовать огненные шары без расхода пси"
                ,"Спасибо, поржал :smile: "
                ,"От бота слышу :crazy: "
                ,"Сто пудов! :crazy: "
                ,"Ух ты! А я и не знал! :crazy: "
                ,"У вас всех на почве ботов уже крыша поехала что ли? :smile: "
                ,"Конечно бот! И вообще все мы боты и живём в матрице! :crzswans: "
            };

        private static readonly List<string> _phrases_i1 = new List<string>
            {
                 " :lesom: дружище"
                ,"Короче, отвали"
                ,"Короче, заканчивай писать бред"
                ,"Уже не смешно. Не отвлекай"
                ,"Блин, тебе поговорить не с кем?"
                ,"Ты думаешь?))"
                ,"лол)))"
                ,"Спасибо, поржал :smile: "
            };

        private static readonly List<string> _phrases_i2 = new List<string>
            {
                 "В игнор"
                ,"Нафиг"
                ,"Задолбал"
                ,"Задолбал, не пиши мне"
                ," :lesom: "
            };

        private static readonly List<string>[] _phrases = new List<string>[]
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
