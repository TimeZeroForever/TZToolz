using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace Voice2Dox.LocalSettings
{
    public class AppSettings
    {

#region Static private fields

        private static string _fileName = string.Empty;
        private static AppSettings _configuration;
        private static readonly Dictionary<string, object> Values = new Dictionary<string, object>();
        private static readonly Regex RegexKeysValues = new Regex(@"(?m)^(?<KEY>.+?)[ ]*=(?<VALUE>.*?)\r*$");

#endregion

#region Static methods

        private static void ReloadConfiguration()
        {
            Values.Clear();
            if (File.Exists(_fileName))
            {
                string data = File.ReadAllText(_fileName);
                MatchCollection kvMatches = RegexKeysValues.Matches(data);
                foreach (Match kvMatch in kvMatches)
                {
                    string key = kvMatch.Groups["KEY"].Value.ToLower();
                    string value = kvMatch.Groups["VALUE"].Value;
                    Values.Add(key, value);
                }
            }
        }

        public static string FileName
        {
            get { return _fileName; }
            set
            {
                _fileName = value;
                ReloadConfiguration();
            }
        }

        public static AppSettings Instance
        {
            get { return _configuration ?? (_configuration = new AppSettings()); }
        }

#endregion

#region Class methods

        private AppSettings() { }

        public string this[string key]
        {
            get
            {
                string skey = key.ToString().Trim().ToLower();
                return Values.ContainsKey(skey) ? Values[skey].ToString() : null;
            }
            set
            {
                string skey = key.ToString().Trim().ToLower();
                Values[skey] = value;
            }
        }

        public int GetInt(string key)
        {
            int result;
            string value = (this[key] ?? "").ToString();
            if (Int32.TryParse(value, out result))
            {
                return result;
            }
            return 0;
        }

        public string GetString(string key)
        {
            string value = (this[key] ?? "").ToString();
            return value;
        }

        public bool GetBool(string key)
        {
            bool result;
            string value = (this[key] ?? "").ToString();
            if (bool.TryParse(value, out result))
            {
                return result;
            }
            return false;
        }

        public bool Save()
        {
            try
            {
                List<string> lines = new List<string>();
                foreach (string key in Values.Keys)
                {
                    string value = Values[key].ToString();
                    lines.Add(string.Format("{0}={1}", key, value));
                }
                File.WriteAllLines(_fileName, lines.ToArray());
                return true;
            }
            catch
            {
                return false;
            }
        }

#endregion

    }
}
