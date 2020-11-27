using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace RestFul_Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {
        //defining RESTful method
        [OperationContract]
        [WebGet(UriTemplate= "giveDirections?origin={origin}&destination={destination}&mode={mode}", ResponseFormat = WebMessageFormat.Json)]
        string giveDirections(string origin, string destination, string mode);

        // TODO: Add your service operations here
    }
}
