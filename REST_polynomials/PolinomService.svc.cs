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
        public string Evaluate()
        {
            return "You called Evaluation service method";
        }

        public string Generate(string minutes)
        {
            double x = -234;
            return string.Format("You called Generation service method on {0} minutes...{1}{2}", minutes, Environment.NewLine, x);
        }
    }
}
