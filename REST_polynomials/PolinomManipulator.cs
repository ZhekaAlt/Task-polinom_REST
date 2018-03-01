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

        private static Thread generationThread, evaluationThread;

        public PolinomManipulator()
        {
            _data = new FileLayer();
        }

        public string startPolinomGeneration(string minutes)
        {
            if (generationThread!=null && generationThread.IsAlive)
                return "Generation is in progress. Please wait...";

            int duration = 0;
            int.TryParse(minutes, out duration);

            generationThread = new Thread(()=>Generate(duration));
            generationThread.Start();

            return string.Format("You called Generation service method for {0} minutes", minutes);
        }

        public string startPolinomEvaluation(string strValue)
        {
            if (evaluationThread != null && evaluationThread.IsAlive)
                return "Evasluation is in progress. Please wait...";

            double value;

            if (!double.TryParse(strValue, out value))
            {
                return "Error! Incorrect value passed. Value should be valid double.";
            }
            string retVal="";

            evaluationThread = new Thread(()=>{ retVal = Evaluate(value); });
            evaluationThread.Start();
            evaluationThread.Join();

            return retVal;
        }

        public void Generate(int minutes)
        {          
            var timerThread = new Thread(() => MyTimer(minutes));
            timerThread.Start();

            int membersCount = new Random().Next(0, 11);

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

            timerThread.Join();

            _data.SaveAsTxt(polinom);                       
        }

        public string Evaluate(double value)
        {            
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

        private void MyTimer(int minutes)
        {
            int sec = 60 * minutes;
            while (sec > 0)
            {
                Thread.Sleep(1000);
                sec--;
            }
        }
    }
}