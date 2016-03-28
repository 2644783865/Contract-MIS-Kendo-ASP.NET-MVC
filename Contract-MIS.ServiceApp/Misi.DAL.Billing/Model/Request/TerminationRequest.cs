using Misi.DAL.Billing.Model.Common;
using Misi.DAL.Billing.Model.RequestInfo;
using Misi.DAL.Billing.Model.RoutingInfo;

namespace Misi.DAL.Billing.Model.Request
{
    public class TerminationRequest : ServiceRequestBase
    {
        private TerminationRequestInfo _requestInfo;
        private TerminationRoutingInfo _routing;

        public TerminationRequestInfo RequestInfo
        {
            get { return _requestInfo ?? (_requestInfo = new TerminationRequestInfo()); }
            set { _requestInfo = value; }
        }

        public TerminationRoutingInfo Routing
        {
            get { return _routing ?? (_routing = new TerminationRoutingInfo()); }
            set { _routing = value; }
        }
    }
}
