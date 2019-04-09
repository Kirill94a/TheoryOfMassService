using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TheoryOfMassService
{
    class Request
    {
        const float Count = 1.75F;

        public static float TimeInterval = 0f;

        public static float TotalTime = 0f;
        
        public bool IsRefusal = false;
        public bool IsServed = false;

        object requests = new object();    
    
        public bool IsWaiting = false;

        static Random r = new Random();

        public Request(int countRequests, int numberRequest)
        {
            if (countRequests == 0 && numberRequest == 0)
            {
                requests=new SeveralChannels(0, -1);
            }
            else if (countRequests > 0 && countRequests < SeveralChannels.CountStations)
            {
                requests = new SeveralChannels(countRequests, numberRequest);
            }
            else if (countRequests >= SeveralChannels.CountStations)
            {
                if (numberRequest < SeveralChannels.CountStations)
                {
                    requests = new SeveralChannels(countRequests, numberRequest);                   
                }
                else
                {
                    requests = new Waiting();
                    IsWaiting = true;
                }
            }
        }

        public static void ResetParameters()
        {
            Request.TotalTime = 0f;
        }

        public static float GetNewTimeInterval()
        {
            TimeInterval = -1 / Count * (float)Math.Log(r.NextDouble(), Math.E);

            TotalTime += TimeInterval;

            return TimeInterval;
        }

        public int CountChannels
        {
            get
            {           
                if (requests is SeveralChannels)
                {
                    return (requests as SeveralChannels).CountChannels;
                }
                else
                {
                    return -1;
                }
            }
        }

        public float CoefficientImpatience
        {
            get
            {
                return (requests as WithinSystem).coefficientImpatience;
            }
        }

        public float AmountTime
        {
            get
            {
                return (requests as WithinSystem).AmountTime;
            }
            set
            {
                (requests as WithinSystem).AmountTime = value;
            }
        }

        public float GunAmountTime
        {
            get
            {
                return (requests as WithinSystem).GunAmountTime;
            }
            set
            {
                (requests as WithinSystem).GunAmountTime = value;
            }
        }
    }
}
