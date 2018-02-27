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
        public string Evaluate()
        {
            return "You called Evaluation service method";
        }

        public string Generate(string minutes)
        {
            int membersCount = new Random().Next(0, 11);

            int duration=0;
            int.TryParse(minutes,out duration);

            string result;

            var polinom = new Polinom();
            polinom.items = new List<PolinomItem>();
            polinom.freeConstant = new Random().Next(-200, 201);

            for (int i=0; i<=membersCount; i++)
            {
                Random randConstant = new Random(DateTime.Now.Millisecond + i);
                Random randDegree = new Random(DateTime.Now.Millisecond + 1 + i);

                var polinomItem = new PolinomItem(
                    randConstant.Next(-10, 11),
                    randDegree.Next(0, 11)
                    );

                polinom.items.Add(polinomItem);
            }

            //double x = -234;
            result ="Generated polinom: "+ polinom.ToString();

            new PolinomManipulator().SaveAsTxt(polinom);

            return string.Format("You called Generation service method on {0} minutes...{1}{2}", minutes, Environment.NewLine, result);
        }
    }
}
