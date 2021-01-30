using System;
using System.IO;

namespace PointBlank___Machine
{
    public class PacotesREQ
    {
        public PacketREQ read;
        public static PacotesREQ INST() => new PacotesREQ();
        public void GetPacketAuth(AuthClient AuthClient, byte[] data)
        {
            try
            {
                lock (this)
                {
                    BinaryReader reader = new BinaryReader(new MemoryStream(data));
                    switch (reader.ReadUInt16())
                    {
                        case 529: read = new BASE_GIFT_LIST_REQ(); break;
                        case 545: read = new BASE_MYCASH_REQ(); break;
                        case 2049: read = new AUTH_BASE_SCHANNEL_LIST_REQ(); break;
                        case 2062: read = new BASE_LOGIN_ERROR_REQ(); break;
                        case 2564: read = new BASE_LOGIN_REQ(); break;
                        case 2566: read = new BASE_MYINFO_REQ(); break;
                        case 2578: read = new BASE_ENTER_SERVER_REQ(); break;
                        case 2655: read = new BASE_EXIT_AUTH_REQ(); break;
                        case 2694: read = new BASE_CLIENT_URL_REQ(); break;
                        case 2699: read = new BASE_INVENTORY_REQ(); break;
                    }
                    if (read != null)
                    {
                        read.SetReader(AuthClient, null, reader, data);
                        Program.Form1.label15.Text = $"{data.Length}";
                        Dados.IniciarThead(read.Run);
                        read = null;
                    }
                }
            }
            catch (Exception ex)
            {
                new _Message().Error(ex.ToString());
            }
        }
        public void GetPacketGame(GameClient Gameclient, byte[] data)
        {
            try
            {
                lock (this)
                {
                    BinaryReader reader = new BinaryReader(new MemoryStream(data));
                    switch (reader.ReadUInt16())
                    {
                        case 279: read = new FRIEND_UPDATE_REQ(); break;
                        case 283: read = new FRIEND_INVITE_REQ(); break;
                        case 291: read = new AUTH_SEND_WHISPER_REQ(); break;
                        case 294: read = new AUTH_RECV_WHISPER_REQ(); break;
                        case 418: read = new BOX_MESSAGE_CREATE_REQ(); break;
                        case 427: read = new BOX_MESSAGE_RECV_REQ(); break;
                        case 523: read = new SHOP_GET_GOODS_REQ(); break;
                        case 525: read = new SHOP_GET_ITEMS_REQ(); break;
                        case 527: read = new SHOP_GET_MATCHING_REQ(); break;
                        case 1311: read = new CLAN_CREATE_REQ(); break;
                        case 1359: read = new CLAN_CHATTING_REQ(); break;
                        case 2049: read = new GAME_BASE_SCHANNEL_LIST_REQ(); break;
                        case 2055: read = new SERVER_MESSAGE_ANNOUNCE_REQ(); break;
                        case 2580: read = new BASE_USER_ENTER_REQ(); break;
                        case 2574: read = new BASE_CHANNEL_ANNOUNCE_REQ(); break;
                        case 2645: read = new BASE_CHANNEL_PASSWRD_REQ(); break;
                        case 2655: read = new BASE_EXIT_GAME_REQ(); break;
                        case 3074: read = new LOBBY_GET_ROOMLIST_REQ(); break;
                        case 3080: read = new LOBBY_ENTER_REQ(); break;
                        case 3090: read = new LOBBY_CREATE_ROOM_REQ(); break;
                        case 3093: read = new LOBBY_CHATTING_REQ(); break;
                        case 3102: read = new LOBBY_CREATE_NICK_NAME_REQ(); break;
                        case 3332: read = new BATTLE_READYBATTLE_REQ(); break;
                        case 3334: read = new BATTLE_STARTBATTLE_REQ(); break;
                        case 3851: read = new BASE_CHAT_ROOM_REQ(); break;
                        case 3855: read = new LOBBY_USER_LIST_REQ(); break;
                    }
                    if (read != null)
                    {
                        read.SetReader(null, Gameclient, reader, data);
                        Program.Form1.label15.Text = $"{data.Length}";
                        Dados.IniciarThead(read.Run);
                        read = null;
                    }
                }
            }
            catch (Exception ex)
            {
                new _Message().Error(ex.ToString());
            }
        }
    }
}
