using System;
using Misi.DAL.Billing.Model.Object;
using Misi.Service.Billing.Handler;
using Misi.Service.Billing.Model.Common;

namespace Misi.Service.Billing.Service
{
    public class ServiceRequestManager : IServiceRequestManager
    {
        public long GetTotalRequestInfos(EScenario scenario)
        {
            return RequestHandlerFactory.Instance.GetHandler(scenario).Count();
        }

        public RequestInfoListItemsDTO GetAllRequestInfos(EScenario scenario)
        {
            return RequestHandlerFactory.Instance.GetHandler(scenario).RequestInfos();
        }

        public RequestInfoListItemsDTO GetLimitedRequestInfos(EScenario scenario, int offset, int limit)
        {
            var rh = RequestHandlerFactory.Instance.GetHandler(scenario);
            if (rh == null) throw new NotImplementedException();
            rh.Offset = offset;
            rh.Limit = limit;
            return rh.LimitedRequestInfos();
        }

        public string GetNewServiceRequestId(string user, EScenario scenario, string requestInfoId = null)
        {
            var rh = RequestHandlerFactory.Instance.GetHandler(scenario);
            if (rh == null) throw new NotImplementedException();
            rh.User = new UserAndRoleDTO
            {
                Username = user
            };
            rh.RequestInfoId = requestInfoId;
            return rh.New();
        }

        public int? SaveServiceRequest(string user, ServiceRequestDTO data, bool isDraft = true)
        {
            var rh = RequestHandlerFactory.Instance.GetHandler(data);
            if (rh == null) throw new NotImplementedException();
            rh.User = new UserAndRoleDTO
            {
                Username = user
            };
            rh.ServiceRequest = data;
            rh.IsDraft = isDraft;
            return rh.Save();
        }

        public ServiceRequestDTO GetServiceRequest(string user, EScenario scenario, string serviceId)
        {
            var rh = RequestHandlerFactory.Instance.GetHandler(scenario);
            if (rh == null) throw new NotImplementedException();
            rh.User = new UserAndRoleDTO
            {
                Username = user
            };
            rh.ServiceId = serviceId;
            return rh.View();
        }
    }
}
