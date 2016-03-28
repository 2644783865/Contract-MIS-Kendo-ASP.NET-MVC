using System.Collections.Generic;
using Misi.DAL.Billing.Model.Common;
using Misi.DAL.Billing.Model.RequestInfo;
using Misi.DAL.Billing.Model.RoutingInfo;

namespace Misi.DAL.Billing.Model.Request
{
    public class ReturnDeviceRequest : ServiceRequestBase
    {
        private ReturnDeviceRequestInfo _requestInfo;
        private List<ReturnDeviceRoutingInfo> _routings;

        public ReturnDeviceRequestInfo RequestInfo
        {
            get { return _requestInfo ?? (_requestInfo = new ReturnDeviceRequestInfo()); }
            set { _requestInfo = value; }
        }

        public List<ReturnDeviceRoutingInfo> Routings
        {
            get { return _routings ?? (_routings = new List<ReturnDeviceRoutingInfo>()); }
            set { _routings = value; }
        }
    }
}
