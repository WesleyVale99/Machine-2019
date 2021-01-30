using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointBlank___Machine
{
   public class BATTLE_PRESTARTBATTLE_ACK : Processor
    {
        public BATTLE_PRESTARTBATTLE_ACK() : base(3348)
        {

        }

        public override byte[] Write()
        {
            send.WriteH(0);
            send.WriteC(0);
            send.WriteC(1);
            return Return();
        }
    }
}
