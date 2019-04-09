using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheoryOfMassService
{
    class Channel
    {
        public int Count = 0;
        
        List<Gun> guns = new List<Gun>();

        public Channel(int countChannels)
        {
            Count = countChannels;

            if (countChannels == 0)
            {
                guns.Add(new Gun());
            }
            else
            {
                for (int i = 0; i < countChannels - 1; i++)
                {
                    guns.Add(new Gun());
                }
            }
        }
    }
}
