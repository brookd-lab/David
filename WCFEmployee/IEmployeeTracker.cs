using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WCFEmployee
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IEmployeeTracker
    {
        [OperationContract]
        [WebInvoke(UriTemplate = "GetAll",
            Method = "GET")]
        List<Employee> GetAll();

        [OperationContract]
        [WebInvoke(UriTemplate = "GetById?id={id}",
            Method = "GET")]
        Employee GetById(int id);

        [OperationContract]
        [WebInvoke(UriTemplate = "Insert",
            Method = "POST")]
        Employee Insert(string name, decimal salary);

        [OperationContract]
        [WebInvoke(UriTemplate = "Update",
            Method = "PUT")]
        Employee Update(int id, string name, decimal salary);

        [OperationContract]
        [WebInvoke(UriTemplate = "Delete?id={id}",
            Method = "DELETE")]
        Employee Delete(int id);
    }


    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    [DataContract]
    public class CompositeType
    {
        private ApplicationDbContext context;

        [DataMember]
        public ApplicationDbContext Context
        {
            get { return context; }
            set { context = value; }
        }
    }
}
