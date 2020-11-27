using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace CSE445Project3
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {
        //defining all methods 
        [OperationContract]
        string findNearestStore(string zipCode, string storeName);

        [OperationContract]
        string showAllStates();

        [OperationContract]
        string getTax(string zipcode);

        [OperationContract]
        string getAirQuality(string city);

        [OperationContract]
        string removeFromMemberXML(string username);

        [OperationContract]
        string removeFromStaffXML(string username);

        [OperationContract]
        string searchMemberUsernameXML(string username);

        [OperationContract]
        string searchMemberPasswordXML(string username);

        [OperationContract]
        string searchStaffUsernameXML(string username);

        [OperationContract]
        string searchStaffPasswordXML(string username);

        //name of service ref is TestRef
        //TODO: Add your service operations here
    }
}
