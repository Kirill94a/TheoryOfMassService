using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TheoryOfMassService
{
    class RunSimulation
    {
        public static void CalculateParameters(int countSimulations, int countIterations)
        {
            for (int i = 0; i < countSimulations; i++)
            {
                Simulation.Start(countIterations);          
            }
        }
    }
}
