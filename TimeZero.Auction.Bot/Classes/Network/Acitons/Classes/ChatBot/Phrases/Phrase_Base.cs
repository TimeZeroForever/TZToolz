using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace TimeZero.Auction.Bot.Classes.Network.Acitons.Classes.ChatBot.Phrases
{
    public abstract class Phrase_Base
    {

#region Static private fields

        private static readonly Regex _regexPhaseTemplate = new Regex(@"(?s)%(?<TEMPLATE>.+?)(:(?<CASE>.+?))*%");
        private static readonly Regex _regexEndingsCases = new Regex(@"(?s)(?<WORD>\w*?)(?<ENDINGS>\[.*?\])+?");
        private static readonly Regex _regexSingleWord = new Regex(@"(?s)\W*(?<WORD>\w+)\W*");

#endregion

#region Private fields

        private int _rndSeed = Environment.TickCount;

#endregion

#region Properties

        protected abstract List<string>[] Phrases { get; }

        public virtual int ProcessedPhraseValue { get { return 1; } }

#endregion

#region Phrase formatting methods

        private string FormatPhrase(string phrase)
        {
            //Process templates
            Match match;
            while ((match = _regexPhaseTemplate.Match(phrase)).Success)
            {
                string template = match.Groups["TEMPLATE"].Value;
                string langCase = match.Groups["CASE"].Value;
                string templateValue = GetPhraseTemplateValue(template, langCase);
                phrase = phrase.Replace(match.Value, templateValue);
            }

            //Process endings
            phrase = ProcessWordsEndings(phrase);

            //Return formatted phrase
            return phrase;
        }

        private string GetPhraseTemplateValue(string template, string langCase)
        {
            string word = string.Empty;
            switch (template.ToLower())
            {
                case "time_of_day":
                    {
                        int todIndex = (int)Math.Floor(DateTime.Now.TimeOfDay.TotalHours / 6);
                        switch (todIndex)
                        {
                            case 0:
                                word = "ночь";
                                break;
                            case 1:
                                word = "утро";
                                break;
                            case 2:
                                word = "день";
                                break;
                            case 3:
                                word = "вечер";
                                break;
                        }
                        break;
                    }
            }

            //Apply language case
            if (!string.IsNullOrEmpty(word))
            {
                word = WordsDictionary.ApplyLanguageCase(word, langCase);
            }

            return word;
        }

        private Dictionary<string, string> GetWordEndingsDictionary(string endings,
            out int maxEndingLength)
        {
            endings = endings.Trim();
            List<string> endignsList = new List<string>();
            Dictionary<string, string> endignsDictTmp = new Dictionary<string, string>();

            //Populate endings list
            string[] endingsGroups = endings.Split(new[] { "|" },
                StringSplitOptions.RemoveEmptyEntries);
            foreach (string endingsGroup in endingsGroups)
            {
                string[] endingsPairs = endingsGroup.Split('=');
                if (endingsPairs.Length == 2)
                {
                    string[] parentEndings = endingsPairs[0].Split(new[] { "," },
                            StringSplitOptions.RemoveEmptyEntries);
                    if (parentEndings.Length > 0)
                    {
                        string selfEnding = endingsPairs[1];
                        foreach (string parentEnding in parentEndings)
                        {
                            string parentEndingLower = parentEnding.Trim().ToLower();
                            if (!endignsDictTmp.ContainsKey(parentEndingLower))
                            {
                                endignsList.Add(parentEndingLower);
                                endignsDictTmp.Add(parentEndingLower, selfEnding);
                            }
                        }
                    }
                }
            }

            //Sort endings list, desc
            endignsList.Sort((s1, s2) => s1.CompareTo(s2) * -1);
            Dictionary<string, string> endignsDict = new Dictionary<string, string>();
            foreach (string parentEnding in endignsList)
            {
                endignsDict.Add(parentEnding, endignsDictTmp[parentEnding]);
            }

            //Get max ending length
            maxEndingLength = endignsList.Count > 0
                ? endignsList[0].Length
                : 0;

            //Return endings list
            return endignsDict;
        }

        private string ProcessWordsEndings(string phrase)
        {
            Match match;
            while ((match = _regexEndingsCases.Match(phrase)).Success)
            {
                int maxEndingLength;
                Group groupEndings = match.Groups["ENDINGS"];
                string endings = groupEndings.Value.Substring(1, groupEndings.Value.Length - 2);
                Dictionary<string, string> endignsDict = GetWordEndingsDictionary(
                    endings, out maxEndingLength);
                if (endignsDict.Count > 0)
                {
                    int nextWordIdx = groupEndings.Index + groupEndings.Length;
                    string nextWord = _regexSingleWord.Match(phrase, nextWordIdx).Value;
                    if (!string.IsNullOrEmpty(nextWord))
                    {
                        nextWord = nextWord.ToLower();
                        int nextWordLength = nextWord.Length;
                        maxEndingLength = Math.Min(maxEndingLength, nextWord.Length);
                        for (int i = maxEndingLength; i > 0; i--)
                        {
                            string parentEnding = nextWord.Substring(nextWordLength - i, i);
                            if (endignsDict.ContainsKey(parentEnding))
                            {
                                string newWord = string.Format("{0}{1}", match.Groups["WORD"].Value, 
                                                                         endignsDict[parentEnding]);
                                phrase = phrase.Replace(match.Value, newWord);
                                break;
                            }
                        }
                    }
                }
            }
            return phrase;
        }

#endregion

#region Class methods

        private Random GetInitialRandomInstance()
        {
            return new Random(++_rndSeed);
        }

        protected virtual int GetIterationIndex(int iteration)
        {
            return iteration;
        }

        protected virtual bool IsSenderInIgnore(int iteration)
        {
            return false;
        }

        public string GetPhrase(int iteration, ref bool senderInIgnore)
        {
            senderInIgnore |= IsSenderInIgnore(iteration);

            if (Phrases != null)
            {
                iteration = Math.Min(GetIterationIndex(iteration), Phrases.Length - 1);
                if (iteration >= 0)
                {
                    List<string> phrases = Phrases[iteration];
                    int phrasesListLength = phrases.Count;
                    if (phrasesListLength > 0)
                    {
                        Random rndInstance = GetInitialRandomInstance();
                        int phraseIdx = rndInstance.Next(phrasesListLength - 1);
                        return FormatPhrase(phrases[phraseIdx]);
                    }
                }
            }
            return null;
        }

        public abstract bool HasAnswerOnInputMessage(string message);

#endregion

    }
}
