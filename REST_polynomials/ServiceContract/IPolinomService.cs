using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace REST_polynomials
{
    [ServiceContract]
    public interface IPolinomService
    {
        [OperationContract]
        [WebGet]
        string Generate(string minutes);

        [OperationContract]
        [WebGet]
        string Evaluate(string value);
    }
}
