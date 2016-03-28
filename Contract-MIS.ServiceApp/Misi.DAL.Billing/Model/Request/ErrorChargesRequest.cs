using Misi.DAL.Billing.Model.Common;
using Misi.DAL.Billing.Model.RequestInfo;
using Misi.DAL.Billing.Model.RoutingInfo;

namespace Misi.DAL.Billing.Model.Request
{
    public class ErrorChargesRequest : ServiceRequestBase
    {
        private ErrorChargesRequestInfo _requestInfo;
        private ErrorChargesRoutingInfo _task;

        public ErrorChargesRequestInfo RequestInfo
        {
            get { return _requestInfo ?? (_requestInfo = new ErrorChargesRequestInfo()); }
            set { _requestInfo = value; }
        }

        public ErrorChargesRoutingInfo Routing
        {
            get { return _task ?? (_task = new ErrorChargesRoutingInfo()); }
            set { _task = value; }
        }
    }
}
