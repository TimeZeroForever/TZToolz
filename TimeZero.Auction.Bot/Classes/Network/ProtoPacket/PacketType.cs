namespace TimeZero.Auction.Bot.Classes.Network.ProtoPacket
{
    public static class FromServer
    {
        public const string PASSWORD_KEY    = "KEY"           ;
        public const string ERROR           = "ERROR"         ;
        public const string LOGIN_DONE      = "OK"            ;

        public const string MY_INFO         = "MYPARAM"       ;
        public const string MY_SKILLS       = "SKILLS"        ;
        public const string MY_BAFFS        = "BAFF"          ;
        public const string MY_PROF         = "PROF"          ;
        public const string MY_SPECIALS     = "SPECIAL"       ;
        public const string MY_SPECIALS_A   = "SPECIALA"      ;
        public const string MY_SPECIALS_D   = "SPECIALD"      ;
        public const string CHANGE_ONE      = "CHANGE_ONE"    ;
        public const string ITEM_ADD_ONE    = "ADD_ONE"       ;

        public const string BOT_INFO        = "BOT"           ;
        public const string DIALOG_DATA     = "DLG"           ;
        public const string SHOP_DATA       = "SH"            ;
        public const string SHOP_ERROR      = "SH_ERR"        ;
        public const string SHOP_OK         = "SH_OK"         ;

        public const string EXCHANGE        = "EXCHANGE"      ;
        public const string EXCHANGE_CANCEL = "EXCHANGEDEL"   ;
        
        public const string DM              = "DM"            ;

        public const string MOVE_ERROR      = "ERRGO"         ;
        public const string GO_TO_BUILDING  = "GOBLD"         ;

        public const string CHAT_MESSAGE    = "CHAT_MSG"      ;
        public const string CHAT            = "CHAT"          ;

        public const string CLIENT_STATUS   = "CLIENT_STATUS" ;
        public const string UPDATE_VER      = "UPDATE_VER"    ;
        public const string LOL             = "LOL"           ;
        public const string IMS             = "IMS"           ;
        public const string LB              = "LB"            ;

    }

    public static class FromClient
    {
        public const string GREETING        = "LIST"    ;
        public const string LOGIN_DATA      = "LOGIN"   ;
        public const string PING            = "N"       ;
        public const string GET_MY_INFO     = "GETME"   ;
        public const string GET_PLAYER_INFO = "GETINFO" ;
        public const string GO_TO_BUILDING  = "GOBLD"   ;
        public const string GO_TO_LOCATION  = "GOLOC"   ;
        public const string GO_TO_ADIT      = "HD"      ;
        public const string SHOP            = "SH"      ;
        public const string CLEAR_IMS       = "CLIMS"   ;
        public const string JOIN_INVENTORY  = "JOIN"    ;
        public const string CHAT            = "CHAT"    ;        
    }
}
