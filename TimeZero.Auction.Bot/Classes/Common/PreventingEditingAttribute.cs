using System;

namespace TimeZero.Auction.Bot.Common
{
    [AttributeUsage(AttributeTargets.Property)]
    public class PreventingEditingAttribute : Attribute { }
}