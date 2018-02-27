using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace REST_polynomials.Model
{
    public class Polinom
    {
        private Double _variable;

        public double Variable
        {
            get
            {
                return _variable;
            }

            set
            {
                _variable = value;
            }
        }

        public List<PolinomItem> items;

        public int freeConstant { get; set; }

        public override string ToString()
        {
            string result="";

            if (items != null && items.Count>0)
            {
                foreach (var e in items)
                {
                    result = string.Concat(result, e.Sign, e.ToString());
                }

                result = string.Concat(result, freeConstant>-1?"+":"",freeConstant);
            }

            if (result.FirstOrDefault() == '+')
                result = result.Substring(1);
            return result;
        }


    }
}
