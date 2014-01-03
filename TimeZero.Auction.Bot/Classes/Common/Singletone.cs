namespace TimeZero.Auction.Bot.Classes.Common
{
    public class Singletone<TClass> where TClass: class, new()
    {

#region Private static fields

        private static TClass _instance = new TClass();

#endregion

#region Static properties

        public static TClass Instance
        {
            get { return _instance; }
            set { _instance = value; }
        }

#endregion

    }
}
