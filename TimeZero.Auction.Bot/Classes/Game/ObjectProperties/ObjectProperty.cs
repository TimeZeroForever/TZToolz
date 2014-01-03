namespace TimeZero.Auction.Bot.Classes.Game.ObjectProperties
{
    public sealed class ObjectProperty
    {

#region Class fields

        public string Name;
        public object Value;

#endregion

#region Class methods

        public ObjectProperty() {}

        public ObjectProperty(string name, string value)
        {
            Name = name;
            Value = value;
        }

        public static implicit operator string(ObjectProperty prop)
        {
            return (prop.Value ?? "").ToString();
        }

        public override string ToString()
        {
            return string.Format("{0} = {1}", Name, Value);
        }

#endregion

    }
}
