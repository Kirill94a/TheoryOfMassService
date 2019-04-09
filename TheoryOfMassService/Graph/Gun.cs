using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheoryOfMassService
{
    class Gun
    {
        const float rateFire = 1f/3f;
        const float chanceHit = 0.51f;
        public const float coefficientService = 1 / (rateFire * chanceHit * countGuns);

        const int countGuns = 2;

        static Random r = new Random(); 

        public static bool IsHit(Request request)
        {
            bool _isHit = false;

            request.GunAmountTime += Request.TimeInterval;

            if (request.GunAmountTime >= 1 / (rateFire * chanceHit * countGuns))
            {
               _isHit |= true;

                request.GunAmountTime = 0f;
            }
            return _isHit;
        }
    }
}
