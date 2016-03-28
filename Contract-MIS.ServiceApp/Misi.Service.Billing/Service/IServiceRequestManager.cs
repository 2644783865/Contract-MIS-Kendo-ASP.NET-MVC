using System.ServiceModel;
using Misi.DAL.Billing.Model.Object;
using Misi.Service.Billing.Model.Common;

namespace Misi.Service.Billing.Service
{
    [ServiceContract]
    public interface IServiceRequestManager
    {
        [OperationContract]
        [FaultContract(typeof(FaultException))]
        long GetTotalRequestInfos(EScenario scenario);

        [OperationContract]
        [FaultContract(typeof(FaultException))]
        RequestInfoListItemsDTO GetAllRequestInfos(EScenario scenario);

        [OperationContract]
        [FaultContract(typeof(FaultException))]
        RequestInfoListItemsDTO GetLimitedRequestInfos(EScenario scenario, int offset, int limit);

        /**
         * ServiceRequest management functions
         */
        [OperationContract]
        [FaultContract(typeof(FaultException))]
        string GetNewServiceRequestId(string user, EScenario scenario, string requestInfoId = null);

        [OperationContract]
        [FaultContract(typeof(FaultException))]
        int? SaveServiceRequest(string user, ServiceRequestDTO data, bool isDraft = true);

        [OperationContract]
        [FaultContract(typeof(FaultException))]
        ServiceRequestDTO GetServiceRequest(string user, EScenario scenario, string serviceId);
    }
}
