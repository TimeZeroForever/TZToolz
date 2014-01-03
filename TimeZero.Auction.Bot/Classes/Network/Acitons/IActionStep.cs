using TimeZero.Auction.Bot.Classes.Game.Client;

namespace TimeZero.Auction.Bot.Classes.Network.Acitons
{
    public interface IActionStep
    {
        bool DoStep(NetworkClient networkClient, GameClient client);
        void Reset();

        bool IsReadyForAction { get; }
    }
}
