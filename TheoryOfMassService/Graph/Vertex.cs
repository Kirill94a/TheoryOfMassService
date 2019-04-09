using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheoryOfMassService
{
    class Vertex : IEnumerable
    {
        public List<Request> vertex = new List<Request>();

        public Vertex(int numberVertex)
        {
            if (numberVertex == 0)
            {
                vertex.Add(new Request(0, 0));
            }
            else
            {
                if (numberVertex < Graph.countVertexes)
                {
                    for (int i = 0; i < numberVertex; i++)
                    {
                        vertex.Add(new Request(numberVertex, i));
                    }
                }
                else
                {
                    for (int i = 0; i < Graph.countVertexes; i++)
                    {
                        vertex.Add(new Request(Graph.countVertexes, i));
                    }
                }
            }
        }

        public Request this[int index]
        {
            get { return vertex[index]; }
            set { vertex[index] = value; }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return (IEnumerator)GetEnumerator();
        }

        public VertexEnum GetEnumerator()
        {
            return new VertexEnum(vertex);
        }

        public class VertexEnum : IEnumerator
        {
            public List<Request> _vertex;

            int position = -1;

            public VertexEnum(List<Request> list)
            {
                _vertex = list;
            }

            public bool MoveNext()
            {
                position++;
                return (position < _vertex.Count);
            }

            public void Reset()
            {
                position = -1;
            }

            object IEnumerator.Current
            {
                get
                {
                    return Current;
                }
            }

            public Request Current
            {
                get
                {
                    try
                    {
                        return _vertex[position];
                    }
                    catch (IndexOutOfRangeException)
                    {
                        throw new InvalidOperationException();
                    }
                }
            }
        }
    }
}
