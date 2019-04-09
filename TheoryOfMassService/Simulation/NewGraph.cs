using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheoryOfMassService
{
    class NewGraph
    {
        public static Graph GetNewGraph(Graph graph, int delta)
        {
            var _graph = graph;

            if (delta > 0)
            {
                _graph = IncreaseCountRequests(graph, delta);
            }

            return _graph;
        }

        static Graph IncreaseCountRequests(Graph graph, int delta)
        {
            var _graph = graph;
            
            int newNumberVertex = graph.NumberVertex + delta;

            if (newNumberVertex > Graph.countVertexes)
            {
                newNumberVertex = Graph.countVertexes;

                delta = newNumberVertex - graph.NumberVertex;                
            }

            if (delta > 0)
            {

                for (int i = 0; i < graph.NumberVertex; i++)
                {
                    _graph.Get(Vertex: newNumberVertex, Request: i).IsRefusal = false;
                    _graph.Get(Vertex: newNumberVertex, Request: i).IsServed = false;
                    _graph.Get(Vertex: newNumberVertex, Request: i).IsWaiting = false;

                    _graph.Get(Vertex: newNumberVertex, Request: i).AmountTime = graph.Get(Vertex: graph.NumberVertex, Request: i).AmountTime;
                }

                for (int i = graph.NumberVertex; i < newNumberVertex; i++)
                {
                    _graph.Get(Vertex: newNumberVertex, Request: i).AmountTime = 0;

                    _graph.Get(Vertex: newNumberVertex, Request: i).IsRefusal = false;
                    _graph.Get(Vertex: newNumberVertex, Request: i).IsServed = false;
                    _graph.Get(Vertex: newNumberVertex, Request: i).IsWaiting = false;

                }
                for (int i = SeveralChannels.CountStations; i < newNumberVertex; i++)
                {
                    _graph.Get(Vertex: newNumberVertex, Request: i).IsWaiting = true;
                    _graph.Get(Vertex: newNumberVertex, Request: i).GunAmountTime += Request.TimeInterval;
                }
                _graph.NumberVertex = newNumberVertex;
            }

            return _graph;
        }

        public static Graph DecreaseCountRequests(Graph graph)
        {
            var _graph = graph;

            var indexesRequests = new List<int>();

            int delta = 0;

            for (int i = 0; i < graph.NumberVertex; i++)
            {
                if (!graph.Get(Vertex: graph.NumberVertex, Request: i).IsRefusal &&
                   !graph.Get(Vertex: graph.NumberVertex, Request: i).IsServed)
                {
                    indexesRequests.Add(i);
                }
                else
                {
                    delta++;
                }
            }

            int newNumberVertex = 0;

            if (graph.NumberVertex - delta > 0)
            {
                newNumberVertex = graph.NumberVertex - delta;
            }

            for (int i = 0; i < indexesRequests.Count; i++)
            {
                _graph.Get(Vertex: newNumberVertex, Request: i).IsRefusal = false;
                _graph.Get(Vertex: newNumberVertex, Request: i).IsServed = false;
                _graph.Get(Vertex: newNumberVertex, Request: i).IsWaiting = false;

                _graph.Get(Vertex: newNumberVertex, Request: i).AmountTime = graph.Get(Vertex: graph.NumberVertex, Request: indexesRequests[i]).AmountTime;
            }

            for (int i = SeveralChannels.CountStations; i < newNumberVertex; i++)
            {
                _graph.Get(Vertex: newNumberVertex, Request: i).IsWaiting = true;
            }

            _graph.NumberVertex = newNumberVertex;

            return _graph;
        }
    }
}
