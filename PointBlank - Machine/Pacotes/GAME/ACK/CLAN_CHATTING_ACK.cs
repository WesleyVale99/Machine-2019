using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointBlank___Machine
{
    public class CLAN_CHATTING_ACK : Processor
    {
        public Chat_Type Type;
        public string MSG;
        public CLAN_CHATTING_ACK(Chat_Type type, string MSG) : base (1358)
        {
            this.Type = type;
            this.MSG = MSG;
        }
        public override byte[] Write()
        {
            send.WriteH((short)Type);
            send.WriteH((short)MSG.Length);
            send.WriteS(MSG, MSG.Length);
            return Return();
        }
    }
}
