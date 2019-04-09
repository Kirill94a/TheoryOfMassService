using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheoryOfMassService
{
    class Graph
    {
        public int NumberVertex = 0;
        public const int countVertexes = SeveralChannels.CountStations + Waiting.CountStations;

        public static List<Vertex> graph = new List<Vertex>();

        public Graph()
        {
            graph = new List<Vertex>();

            this.Start();
        }

        public void Start()
        {
            Calculate();
        }

        static void Calculate()
        {
            for (int i = 0; i <= countVertexes; i++)
            {
                graph.Add(new Vertex(i));
            }
        }

        public Vertex Get(int Vertex){
            return graph[Vertex];
        }

        public Request Get(int Vertex, int Request)
        {
            return graph[Vertex][Request];
        }

        public Vertex Current()
        {
            return graph[NumberVertex];
        }

        public Vertex this[int index]
        {
            get { return graph[index]; }
            set { graph[index] = value; }
        }
    }
}
