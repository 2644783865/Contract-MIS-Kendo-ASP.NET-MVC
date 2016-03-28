using System.Collections.Generic;
using Misi.DAL.Billing.Model.Common;
using Misi.DAL.Billing.Model.RequestInfo;
using Misi.DAL.Billing.Model.RoutingInfo;

namespace Misi.DAL.Billing.Model.Request
{
    public class NewScenarioRequest : ServiceRequestBase
    {
        private NewScenarioRequestInfo _requestInfo;
        private List<NewScenarioRoutingInfo> _routings; 

        public NewScenarioRequestInfo RequestInfo
        {
            get { return _requestInfo ?? (_requestInfo = new NewScenarioRequestInfo()); }
            set { _requestInfo = value; }
        }

        public List<NewScenarioRoutingInfo> Routings {
            get { return _routings ?? (_routings = new List<NewScenarioRoutingInfo>()); }
            set { _routings = value; }
        }
    }
}
