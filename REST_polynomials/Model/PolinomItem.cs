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

        private bool _sign;

        public PolinomItem(int constantNumber, int degreeNumber)
        {
            _constant = constantNumber;
            _degree = degreeNumber;


        }

        private void determinateSign()
        {
            _sign=_constant < 0 ? false : true;
        }

        public string ToString(double variable)
        {
            return string.Format("{0}{1}{2}",_constant, variable, _degree );
        }
    }
}