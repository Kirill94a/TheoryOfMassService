using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheoryOfMassService
{
    class WithinSystem
    {
        public float AmountTime = 0f;

        public float GunAmountTime = Gun.coefficientService;

        public virtual float coefficientImpatience { get { return 0F; } }

        public static bool IsRequestDenied(Request request)
        {
            float coefficientImpatience = 0F;

            coefficientImpatience = request.CoefficientImpatience;

            bool isRequestDenied = false;

            request.AmountTime += Request.TimeInterval;

            if (request.AmountTime >= 1 / coefficientImpatience)
            {
                isRequestDenied = true;
            }

            return isRequestDenied;
        } 

    }
}
