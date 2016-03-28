using Misi.DAL.Billing.Model.Common;
using Misi.DAL.Billing.Model.RequestInfo;
using Misi.DAL.Billing.Model.RoutingInfo;

namespace Misi.DAL.Billing.Model.Request
{
    public class BrokenDeviceRequest : ServiceRequestBase
    {
        private BrokenDeviceRequestInfo _requestInfo;
        private BrokenDeviceRoutingInfo _routing;

        public BrokenDeviceRequestInfo RequestInfo
        {
            get { return _requestInfo ?? (_requestInfo = new BrokenDeviceRequestInfo()); }
            set { _requestInfo = value; }
        }

        public BrokenDeviceRoutingInfo Routing
        {
            get { return _routing ?? (_routing = new BrokenDeviceRoutingInfo()); }
            set { _routing = value; }
        }
    }
}
