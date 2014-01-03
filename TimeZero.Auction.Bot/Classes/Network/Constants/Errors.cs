using System.Collections.Generic;

namespace TimeZero.Auction.Bot.Classes.Network.Constants
{
    public static class Errors
    {
        //Login/connection errors
        public static class GameError
        {
            public const string E_PLAYER_ON_ANOTHER_SERVER = "1" ;
            public const string E_INVALID_PASSWORD         = "2" ;
            public const string E_USER_HAS_DROPPED         = "3" ;
            public const string E_USER_BLOCKED             = "4" ;
            public const string E_OLD_GAME_VER             = "5" ;
            public const string E_KEY_REQUIRED             = "6" ;
            public const string E_KEY_INVALID              = "7" ;
            public const string E_GAME_IS_UPDATING         = "9" ;
            public const string E_SERVER_IS_OVERLOAD       = "10";
            public const string E_INVALID_GAME_LANG        = "11";
            public const string E_CONNECTION_ERROR         = "12";
            
            private static readonly Dictionary<string, string> Messages = new Dictionary<string, string>
                                                    {
                                                        {E_PLAYER_ON_ANOTHER_SERVER, "Игрок находится на другом игровом сервере"},
                                                        {E_INVALID_PASSWORD,         "Неверный пароль"},
                                                        {E_USER_HAS_DROPPED,         "Персонажем вошли с другого компьютера"},
                                                        {E_USER_BLOCKED,             "Персонаж заблокирован"},
                                                        {E_OLD_GAME_VER,             "Старая версия игры"},
                                                        {E_KEY_REQUIRED,             "Для входа необходим электронный ключ"},
                                                        {E_KEY_INVALID,              "Неверный электронный ключ"},
                                                        {E_GAME_IS_UPDATING,         "Идёт обновление игры, сервер недоступен"},
                                                        {E_SERVER_IS_OVERLOAD,       "Сервер перегружен"},
                                                        {E_INVALID_GAME_LANG,        "Язык клиента не соответствует языку сервера"},
                                                        {E_CONNECTION_ERROR,         "Попытка соединения не удалась"},
                                                    };

            public static string GetErrorMessage(string errorCode)
            {
                return Messages.ContainsKey(errorCode)
                           ? Messages[errorCode]
                           : "Соединение с сервером не удалось.";
            }
        }

        //Login/connection errors
        public static class ShopError
        {
            public const string E_NOT_ENOUGH_MONEY = "310";

            private static readonly Dictionary<string, string> Messages = new Dictionary<string, string>
                                                    {
                                                        {E_NOT_ENOUGH_MONEY, "Not enough money"},
                                                    };

            public static string GetErrorMessage(string errorCode)
            {
                return !string.IsNullOrEmpty(errorCode) && Messages.ContainsKey(errorCode)
                           ? Messages[errorCode]
                           : string.Format("Unknown shop error, code: {0}", errorCode);
            }
        }
    }
}
