using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointBlank___Machine
{
    public class LOBBY_GET_ROOMLIST_ACK : Processor
    {
        public LOBBY_GET_ROOMLIST_ACK() : base (3073)
        {

        }

        public override byte[] Write() => Return();
    }
}
