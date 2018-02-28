using REST_polynomials.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace REST_polynomials
{
    // NOTE: In order to launch WCF Test Client for testing this service, please select PolinomService.svc or PolinomService.svc.cs at the Solution Explorer and start debugging.

    public class PolinomService : IPolinomService
    {
        public string Evaluate(string value)
        {
            return new PolinomManipulator().Evaluate(value);
        }

        public string Generate(string minutes)
        {
            return new PolinomManipulator().Generate(minutes);
        }
    }
}
