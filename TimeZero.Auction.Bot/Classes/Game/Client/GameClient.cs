using AxShockwaveFlashObjects;
using System.Text.RegularExpressions;
using TimeZero.Auction.Bot.Classes.Game.InventoryItems;
using TimeZero.Auction.Bot.Classes.Game.ObjectProperties;

namespace TimeZero.Auction.Bot.Classes.Game.Client
{
    public sealed class GameClient
    {

#region Properties

        public string LocalIP  { get; private set; }
        public string Login    { get; private set; }
        public string Password { get; private set; }
        public string Version  { get; private set; }
        public string Version2 { get; private set; }

        public InventoryItemList InventoryItems { get; set; }
        public ObjectPropertyList AdditionalData { get; private set; }

        public AxShockwaveFlash FlashPlayer { get; private set; }

#endregion

#region Class methods

        public GameClient()
        {
            AdditionalData = new ObjectPropertyList();
            InventoryItems = new InventoryItemList();
        }

        public GameClient(string localIP, string login, string password, string version, 
                          string version2, AxShockwaveFlash flashPlayer) 
            : this()
        {
            Init(localIP, login, password, version, version2, flashPlayer);
        }

        public void Init(string localIP, string login, string password, string version,
                         string version2, AxShockwaveFlash flashPlayer)
        {
            LocalIP = localIP;
            Login = login;
            Password = password;
            Version = version;
            Version2 = version2;
            FlashPlayer = flashPlayer;
        }

        public string GetPasswordHash(string key)
        {
            string passwordHash = FlashPlayer.CallFunction(string.Format(@"
<invoke name=""joinBattle"" returntype=""xml"">
<arguments>
    <string>{0}</string>
    <string>{1}</string>
    <true/>
</arguments>
</invoke>", key, Password));
            return new Regex(@"(?<=<string>).*?(?=</string>)").Match(passwordHash).Value;
        }

        public void Reset()
        {
            AdditionalData.Clear();
            InventoryItems.Clear();
        }

#endregion

    }
}
