using System;
using System.Linq;
using System.Collections.Generic;

namespace TimeZero.Auction.Bot.Classes.Game.ObjectProperties
{
    public class ObjectPropertyList : List<ObjectProperty>
    {

#region Class methods

        public ObjectProperty Add(string name, string value)
        {
            ObjectProperty property = new ObjectProperty(name, value);
            Add(property);
            return property;
        }

        public List<object> this[string name]
        {
            get
            {
                IEnumerable<ObjectProperty> properties = this.Where(p => p.Name.Equals(name,
                    StringComparison.InvariantCultureIgnoreCase));
                int cnt = properties.Count();
                if (cnt > 0)
                {
                    List<object> values = new List<object>(cnt);
                    foreach (ObjectProperty property in properties)
                    {
                        values.Add(property.Value);
                    }
                    return values;
                }
                return null;
            }
        }

#endregion

    }
}
