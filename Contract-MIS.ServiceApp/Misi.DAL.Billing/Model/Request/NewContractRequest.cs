using System.Collections.Generic;
using Misi.DAL.Billing.Model.Common;
using Misi.DAL.Billing.Model.RequestInfo;
using Misi.DAL.Billing.Model.RoutingInfo;

namespace Misi.DAL.Billing.Model.Request
{
    public class NewContractRequest : ServiceRequestBase
    {
        private NewContractRequestInfo _requestInfo;
        private List<NewContractRoutingInfoBase> _routings;

        public NewContractRequestInfo RequestInfo
        {
            get { return _requestInfo ?? (_requestInfo = new NewContractRequestInfo()); }
            set { _requestInfo = value; }
        }

        public List<NewContractRoutingInfoBase> Routings
        {
            get { return _routings ?? (_routings = new List<NewContractRoutingInfoBase>()); }
            set { _routings = value; }
        }
    }
}
