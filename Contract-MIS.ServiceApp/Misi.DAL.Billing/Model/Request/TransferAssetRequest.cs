using System.Collections.Generic;
using Misi.DAL.Billing.Model.Common;
using Misi.DAL.Billing.Model.RequestInfo;
using Misi.DAL.Billing.Model.RoutingInfo;

namespace Misi.DAL.Billing.Model.Request
{
    public class TransferAssetRequest : ServiceRequestBase
    {
        private TransferAssetRequestInfo _requestInfo;
        private List<TransferAssetRoutingInfo> _routings;

        public TransferAssetRequestInfo RequestInfo
        {
            get { return _requestInfo ?? (_requestInfo = new TransferAssetRequestInfo()); }
            set { _requestInfo = value as TransferAssetRequestInfo; }
        }

        public List<TransferAssetRoutingInfo> Routings
        {
            get { return _routings ?? (_routings = new List<TransferAssetRoutingInfo>()); }
            set { _routings = value; }
        }
    }
}
