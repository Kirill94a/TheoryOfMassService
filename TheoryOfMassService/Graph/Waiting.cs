using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheoryOfMassService
{
    class Waiting : WithinSystem
    {
        public override float coefficientImpatience { get { return 0.35F; } }

        public const int CountStations = 1;

    }
}
