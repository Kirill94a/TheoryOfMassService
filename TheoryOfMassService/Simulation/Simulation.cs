using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TheoryOfMassService
{
    class Simulation
    {
        public static void Start(int countIterations)
        {
            Graph graph = new Graph();

            Parameters.MakeNew();
            Request.ResetParameters();

            for (int i = 0; i < countIterations; i++)
            {
                int countNewRequests = 1;

                Request.TimeInterval = Request.GetNewTimeInterval();

                graph = NewGraph.GetNewGraph(graph, countNewRequests);

                Parameters.CountRequests.Sum(countNewRequests);

                foreach (var v in graph.Current())
                {
                    if (!v.IsWaiting)
                    {
                        v.IsServed = Gun.IsHit(v);
                    }
                }

                foreach (var v in graph.Current())
                {
                    if (!v.IsServed)
                    {
                        v.IsRefusal = WithinSystem.IsRequestDenied(v);
                    }
                }              

                CalculationParameters.CalculateCountServices(graph);
               
                graph = NewGraph.DecreaseCountRequests(graph);
               
                CalculationParameters.CalculateCountOccupiedChannels(graph);                                         
                CalculationParameters.CalculateLengthWaiting(graph);
                
            }
            CalculationParameters.CalculateAverageNumOccupiedChannels();
            CalculationParameters.CalculateAverageLengthWaiting();
            CalculationParameters.CalculateChanceService();
        }
    }
}
