using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poisson_sStreams
{
    class Program
    {
        static void Main(string[] args)
        {
            const int count = 1000000;
            double lambda = 1.75f;
            double reverseLambda = 1.0d / lambda;
            double summ = 0d;
            Random r = new Random();

            for (int i = 0; i < count; i++)
            {
                summ += -reverseLambda * Math.Log(r.NextDouble(), Math.E);
            }

            Console.WriteLine(count / summ);

            r = new Random();
            summ = 0d;

            for (int i = 0; i < count; i++)
            {
                summ += -lambda * Math.Log(r.NextDouble(), Math.E);
            }

            Console.WriteLine(summ / count);

            Console.Read();
        }
    }
}
