using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Métier
{
    public class Compteur
    {
        public int Time { get; set; }
        public bool IsOver { get { return Time == 0; }  }

        public Compteur()
        {

        }

        public void Tick()
        {
            if(Time > 0)
            {
                Time--;
            }
        }
    }
}
