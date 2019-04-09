using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheoryOfMassService
{
    class Parameters
    {
        static List<List<float>> parameters = new List<List<float>>();

        const int countParameters = 7;

        public static void DisplayAllParameters()
        {
            string str = "";
            string deltaStr = "";

            List<string> strings = new List<string>();

            string[] line = new string[3]{                        
                        " AverageNumOccupiedChannels |",
                        " ChanceService |",
                        " AverageLengthWaiting |"};

            deltaStr = string.Format("n={0}{1}", Program.CountStations ,"\n\n");

            MakeNewStringAndSetDeltaString(ref str, ref deltaStr);
            
            deltaStr = line[0] + line[1] + line[2] + "\n";

            MakeNewStringAndSetDeltaString(ref str, ref deltaStr);

            deltaStr = GetTab(line[0].Length - 1) + "|" + GetTab(line[1].Length - 1) + "|" + GetTab(line[2].Length - 1) + "|\n";

            MakeNewStringAndSetDeltaString(ref str, ref deltaStr);

            for (int i = 0; i < parameters.Count; i++)
            {
                deltaStr += GetIndents(line[0], Parameters.AverageNumOccupiedChannels.Get(i));
                deltaStr += GetIndents(line[1], Parameters.ChanceService.Get(i));
                deltaStr += GetIndents(line[2], Parameters.AverageLengthWaiting.Get(i)) + "\n";

                MakeNewStringAndSetDeltaString(ref str, ref deltaStr);
                          
            }

            for (int i = 0; i < 3; i++)
            {
                deltaStr += GetIndents(line[i]);
                
            }
            MakeNewStringAndSetDeltaString(ref str, ref deltaStr);

            str += "\n";

            for (int i = 0; i < 3; i++)
            {
                deltaStr += GetIndents(line[i], GetArithmeticMean(parameters, i));
                
            }

            MakeNewStringAndSetDeltaString(ref str, ref deltaStr);

            Console.WriteLine(str);
            
        }

        static void MakeNewStringAndSetDeltaString(ref string str, ref string deltaStr)
        {

            str += deltaStr;

            using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"AverageNumbers.txt", true))
            {
                file.WriteLine(deltaStr);
            }

            deltaStr = "";
        }

        static string GetTab(int lengthSpace)
        {
            return new string(' ', lengthSpace);
        }

        static string GetIndents(string line, float number){
            string str = "";

            string numberStr = string.Format("{0:F3}", number);

            str += GetTab(line.Length / 2 - numberStr.Length / 2) +
                    numberStr +
                    GetTab(line.Length / 2 + line.Length % 2 - numberStr.Length / 2 - numberStr.Length % 2 - 1) + "|";

            return str;
        }

        static string GetIndents(string line)
        {
            string str = "";

            str += GetTab(line.Length / 2) +
                    GetTab(line.Length / 2 + line.Length % 2 - 1) + "|";

            return str;
        }

        static float GetArithmeticMean(List<List<float>> numbers, int index)
        {
            float average = 0F;

            float sum = 0F;

            for (int i = 0; i < parameters.Count; i++)
            {
                sum += numbers[i][index];
            }

            average = sum / parameters.Count;

            return average;
        }

        public static void MakeNew()
        {
            parameters = GetNewParameters();
        }


        public class AverageNumOccupiedChannels
        {
            public static void Set()
            {
                parameters.Last()[0] = (float)(Parameters.CountOccupiedChannels.Last() / Program.countIterations);
            }

            public static float Get (int index)
            {
                return parameters[index][0]; 
            }            

            public static float Last()
            {
                return parameters.Last()[0];
            }
        }

        public class ChanceService
        {
            public static void Set()
            {
                parameters.Last()[1] = (float)(Parameters.CountServices.Last() / Parameters.CountRequests.Last());
            }

            public static float Get(int index)
            {
                return parameters[index][1]; 
            }

            public static float Last()
            {
                return parameters.Last()[1];
            }
        }

        public class AverageLengthWaiting
        {
            public static void Set()
            {
                parameters.Last()[2] = (float)(Parameters.LengthWaiting.Last() /  Program.countIterations);
            }

            public static float Get(int index)
            {
                return parameters[index][2]; 
            }

            public static float Last()
            {
                return parameters.Last()[2];
            }
        }

        public class CountOccupiedChannels
        {
            public static void Sum(float a)
            {
                parameters.Last()[3] += a;
            }

            public static float Last()
            {
                return parameters.Last()[3];
            }
        }
        public class LengthWaiting
        {
            public static void Sum(float a)
            {
                parameters.Last()[4] += a;
            }

            public static float Last()
            {
                return parameters.Last()[4];
            }
        }

        public class CountServices
        {
            public static void Sum(float a)
            {
                parameters.Last()[5] += a;
            }

            public static float Last()
            {
                return parameters.Last()[5];
            }
        }

        public class CountRequests
        {
            public static void Sum(float a)
            {
                parameters.Last()[6] += a;
            }

            public static float Last()
            {
                return parameters.Last()[6];
            }
        }

        static List<List<float>> GetNewParameters()
        {
            parameters.Add(new List<float>());

            for (int i = 0; i < countParameters; i++)
            {
                parameters.Last().Add(0F);
            }
            return parameters;
        }
    }
}
