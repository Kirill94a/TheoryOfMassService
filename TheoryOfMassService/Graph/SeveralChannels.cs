using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheoryOfMassService
{
    class SeveralChannels : WithinSystem
    {
        public override float coefficientImpatience { get { return 0.5F; } }

        public const int CountStations = Program.CountStations;

        const int countInteractingChannels = 2;

        public int CountChannels = 0;

        List<Channel> masStations = new List<Channel>();
        static List<int> _masCountStations = new List<int>();
        static int _numberVertex = 0;

        public SeveralChannels(int inputNumberVertex, int inputNumberRequest)
        {
            int numberVertex = inputNumberVertex;
            int numberRequest = inputNumberRequest + 1;

            if (!(numberVertex == 0 && numberRequest == 0))
            {
                if (numberVertex > CountStations)
                {
                    numberVertex = CountStations;
                }

                if (_numberVertex != numberVertex)
                {
                    _numberVertex = numberVertex;
                    _masCountStations = new List<int>();
                    int count = 0;

                    if (numberVertex == 0 && numberRequest == 0)
                    {
                        _masCountStations.Add(0);

                    }
                    else
                    {
                        for (int j = numberVertex; j >= 1; j--)
                        {
                            for (int i = countInteractingChannels; i >= 1; i--)
                            {
                                if ((CountStations - count) / (j * i) > 0
                                    && (((numberVertex - _masCountStations.Count - j) > 0 && count + i * j < CountStations)) ||
                                    ((numberVertex - _masCountStations.Count - j) == 0 && count + i * j == CountStations))
                                {
                                    for (int k = 0; k < j; k++)
                                    {
                                        _masCountStations.Add(i);
                                    }
                                    count += j * i;
                                }
                            }
                        }
                        if (_masCountStations.Count < numberRequest)
                        {
                            for (int i = _masCountStations.Count; i < inputNumberVertex; i++)
                            {
                                _masCountStations.Add(countInteractingChannels);
                            }
                        }
                    }
                    _masCountStations = _masCountStations.OrderByDescending(n => n).ToList();
                }

                for (int k = 0; k < _masCountStations[inputNumberRequest]; k++)
                {
                    masStations.Add(new Channel(1));
                }
            }

            CountChannels = masStations.Count;
        }
        public Channel this[int index]
        {
            get { return masStations[index]; }
            set { masStations[index] = value; }
        }
    }
}
