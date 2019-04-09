using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheoryOfMassService
{
    class CalculationParameters
    {
        public static void CalculateAverageLengthWaiting()
        {
            Parameters.AverageLengthWaiting.Set();            
        }        

        public static void CalculateAverageNumOccupiedChannels()
        {
            Parameters.AverageNumOccupiedChannels.Set();
        }

        public static void CalculateChanceService()
        {
            Parameters.ChanceService.Set();
        }

        public static void CalculateLengthWaiting(Graph graph)
        {
            if (graph.NumberVertex > SeveralChannels.CountStations)
            {
                Parameters.LengthWaiting.Sum((float)(graph.NumberVertex - SeveralChannels.CountStations));
            }
          
        }

        public static void CalculateCountOccupiedChannels(Graph graph)
        {
            if (graph.NumberVertex > SeveralChannels.CountStations)
            {
                Parameters.CountOccupiedChannels.Sum((float)SeveralChannels.CountStations);
            }
            else
            {
                Parameters.CountOccupiedChannels.Sum((float)graph.NumberVertex);
            }
        }

        public static void CalculateCountServices(Graph graph)
        {
            foreach (var v in graph.Current())
            {
                if (v.IsServed)
                {
                    Parameters.CountServices.Sum(1);
                }
            }
        }
    }
}
