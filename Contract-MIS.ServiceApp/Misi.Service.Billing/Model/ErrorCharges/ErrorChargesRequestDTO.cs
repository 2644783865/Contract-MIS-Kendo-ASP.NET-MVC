using System.Runtime.Serialization;
using Misi.Service.Billing.Model.Common;

namespace Misi.Service.Billing.Model.ErrorCharges
{
    [DataContract]
    public class ErrorChargesRequestDTO : ServiceRequestDTO
    {
        private ErrorChargesRequestInfoDTO _requestInfo;
        private ErrorChargesRoutingInfoDTO _routing;
        
        [DataMember]
        public ErrorChargesRequestInfoDTO RequestInfo
        {
            get { return _requestInfo ?? (_requestInfo = new ErrorChargesRequestInfoDTO()); }
            set { _requestInfo = value; }
        }

        [DataMember]
        public ErrorChargesRoutingInfoDTO Routing
        {
            get { return _routing ?? (_routing = new ErrorChargesRoutingInfoDTO()); }
            set { _routing = value; }
        }
    }
}