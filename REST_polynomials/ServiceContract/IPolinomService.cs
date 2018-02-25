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
        //[WebInvoke(Method = "GET",
        //    ResponseFormat = WebMessageFormat.Json,
        //    BodyStyle = WebMessageBodyStyle.Wrapped,
        //    UriTemplate = "generate/{minutes}")]
        [WebGet]
        string Generate(string minutes);

        [OperationContract]
        string Evaluate();
    }
}
