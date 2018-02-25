using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace REST_polynomials.Model
{
    public class Polinom : Interfaces.IShouldSaveAsTxt
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

        public string SaveAsTxt()
        {
            string result="";

            if (items != null)
            {
                foreach (var e in items)
                {
                    result = string.Concat(result, e.ToString());
                }
            }
            return result;
        }


    }
}
