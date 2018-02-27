using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace REST_polynomials.Model
{
    public class PolinomItem
    {
        private int _constant;

        private int _degree;

        public string Sign
        {
            get
            {
                return Constant >= 0 ? "+" : ""; 
            }
        }

        public int Constant
        {
            get
            {
                return _constant;
            }

            set
            {
                _constant = value;
            }
        }

        public int Degree
        {
            get
            {
                return _degree;
            }

            set
            {
                _degree = value;
            }
        }

        public PolinomItem(int constantNumber, int degreeNumber)
        {
            Constant = constantNumber;
            Degree = degreeNumber;

        }

        public string ToString(string variable=null)
        {
            if (variable == null)
                variable = "X";

            return string.Format("{0}{1}{2}", Constant, variable, Degree );
        }

    }
}