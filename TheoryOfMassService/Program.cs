using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TheoryOfMassService
{
    class Program
    {

        public const int countSimulations = 10, countIterations = 100000, CountStations = 4;

        static void Main(string[] args)
        {
            RunSimulation.CalculateParameters(countSimulations, countIterations);

            Parameters.DisplayAllParameters();

            Console.Read();
        }
    }
    
}
