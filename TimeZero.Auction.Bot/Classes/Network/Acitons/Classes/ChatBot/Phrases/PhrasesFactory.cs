using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TimeZero.Auction.Bot.Classes.Network.Acitons.Classes.ChatBot.Phrases
{
    public static class PhrasesFactory
    {

#region Static private fields

        private static readonly List<Phrase_Base> Phrases = new List<Phrase_Base>
        {
             new Phrase_Greeting()
            ,new Phrase_Shopping()
            ,new Phrase_Dumping()
            ,new Phrase_SellRequest()
            ,new Phrase_BotCheck()
            ,new Phrase_Thanks()
            ,new Phrase_OK()
            ,new Phrase_Invective()
            ,new Phrase_Apologize()
            ,new Phrase_Credit()
        };

        private static readonly Phrase_Base PhraseUnknown = new Phrase_Unknown();

#endregion

#region Static methods

        public static IEnumerable<Phrase_Base> GetPhraseObjects(string message)
        {
            IEnumerable<Phrase_Base> objs = Phrases.Where(p => p.HasAnswerOnInputMessage(message));
            if (objs.Count() == 0)
            {
                objs = new[] { PhraseUnknown };
            }
            return objs.Where(p => p != null);
        }

        public static string ProcessChatMessageForAnswer(ChatMessage chatMessage)
        {
            string answer = null;
            IEnumerable<Phrase_Base> objs = GetPhraseObjects(chatMessage.Message);
            if (objs.Count() > 0)
            {
                StringBuilder sbAnswer = new StringBuilder();
                ChatBotConversation conversation = chatMessage.Conversation;

                //Check for standalone phase
                Phrase_Base standalonePhrase = objs.FirstOrDefault
                    (
                        o => o is Phrase_Invective
                    );
                if (standalonePhrase != null)
                {
                    objs = objs.Where(o => o == standalonePhrase);
                }

                foreach (Phrase_Base phraseObj in objs)
                {
                    //Get iteration number
                    int iteration = 0;
                    if (conversation.PhrasesObjects.ContainsKey(phraseObj))
                    {
                        iteration = conversation.PhrasesObjects[phraseObj] + 1;
                        conversation.PhrasesObjects[phraseObj] = iteration;
                    }
                    else
                    {
                        conversation.PhrasesObjects.Add(phraseObj, iteration);
                    }

                    //Get phrase
                    string phrase = phraseObj.GetPhrase(iteration, ref conversation.SenderInIgnore);

                    //Add phrase to result
                    if (!string.IsNullOrEmpty(phrase))
                    {
                        conversation.ProcessedPhrasesCount += phraseObj.ProcessedPhraseValue;
                        sbAnswer.AppendFormat("{0}{1}", sbAnswer.Length == 0 ? "" : ". ", phrase);
                    }
                }
                answer = sbAnswer.ToString();
            }

            return string.IsNullOrEmpty(answer) ? null : answer;
        }

#endregion

    }
}
