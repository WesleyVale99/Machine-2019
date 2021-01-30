namespace PointBlank___Machine
{
    public class LOBBY_CREATE_ROOM_ACK : Processor
    {
        public Sala r;
        public LOBBY_CREATE_ROOM_ACK(Sala r) : base(3089)
        {
            this.r = r;
        }
        public override byte[] Write()
        {
            send.WriteD(0); //ERROR
            send.WriteS(r.Nome, 23);
            send.WriteH(r.Mapa += 1);
            send.WriteC(0); //stage4vs4
            send.WriteC(1); //type
            send.WriteC(0);
            send.WriteC(0);
            send.WriteC(r.slots); //slots
            send.WriteC(0);
            send.WriteC(4);//all Weapons
            send.WriteC(0);//randomMap
            send.WriteC(0);//special
            send.WriteS(player.nick, 33); // NICK DO PLAYER
            send.WriteC(66); //66
            send.WriteC(0);
            send.WriteC(0);
            send.WriteC(0);
            send.WriteC(0);
            send.WriteC(0);
            send.WriteH(0);
            send.WriteS(r.senha, 4); //PASSWORD
            return Return();
        }
    }
}
