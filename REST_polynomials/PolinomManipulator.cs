using REST_polynomials.DataLayer;
using REST_polynomials.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading;

namespace REST_polynomials
{
    public class PolinomManipulator
    {       
        private FileLayer _data;

        private Thread generationThread, evaluationThread;

        public PolinomManipulator()
        {
            _data = new FileLayer();
        }

        public string startPolinomGeneration(string minutes)
        {
            if (generationThread.ThreadState == ThreadState.Running)
                return "Generation is in progress. Please wait...";

            generationThread = new Thread(Generate);
            generationThread.Start();
        }

        public string Generate(string minutes)
        {
            int membersCount = new Random().Next(0, 11);

            int duration = 0;
            int.TryParse(minutes, out duration);

            string result;

            var polinom = new Polinom();
            polinom.items = new List<PolinomItem>();
            polinom.freeConstant = new Random().Next(-200, 201);

            for (int i = 0; i <= membersCount; i++)
            {
                Random randConstant = new Random(DateTime.Now.Millisecond + i);
                Random randDegree = new Random(DateTime.Now.Millisecond + 1 + i);

                var polinomItem = new PolinomItem(
                    randConstant.Next(-10, 11),
                    randDegree.Next(0, 11)
                    );

                polinom.items.Add(polinomItem);
            }

            result = "Generated polinom: " + polinom.ToString();

            _data.SaveAsTxt(polinom);

            return string.Format("You called Generation service method on {0} minutes...{1}{2}", minutes, Environment.NewLine, result);
        }

        public string polinomGeneration(string minutes)
        {

        }

        public string Evaluate(string strValue)
        {
            double value;

            if (!double.TryParse(strValue, out value))
            {
               return "Error! Incorrect value passed. Value should be valid double.";
            }

            var polinoms = _data.GetDataFromFileStorage();

            if (polinoms.Count == 0)
            {
                return "Error! There is no generated polinoms!";
            }          

            foreach(var e in polinoms)
            {
                e.EvaluatedResult = getEvaluationForPolinom(e, value);
            }

            return polinoms.OrderByDescending(p => p.EvaluatedResult).FirstOrDefault().ToString();                
        }

        public double getEvaluationForPolinom(Polinom polinom, double variable)
        {
            double result = polinom.freeConstant;

            foreach(var item in polinom.items)
            {
                result += item.Constant*(Math.Pow(variable, item.Degree));
            }

            return result;
        }


      
    }
}