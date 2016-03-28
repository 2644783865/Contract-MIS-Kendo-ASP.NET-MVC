using System.Runtime.Serialization;
using Misi.Service.Billing.Model.Common;

namespace Misi.Service.Billing.Model.Termination
{
    [DataContract]
    public class TerminationRequestDTO : ServiceRequestDTO
    {
        private TerminationRequestInfoDTO _requestInfo;
        private TerminationRoutingInfoDTO _routing;

        [DataMember]
        public TerminationRequestInfoDTO RequestInfo
        {
            get { return _requestInfo ?? (_requestInfo = new TerminationRequestInfoDTO()); }
            set { _requestInfo = value; }
        }

        [DataMember]
        public TerminationRoutingInfoDTO Routing
        {
            get { return _routing ?? (_routing = new TerminationRoutingInfoDTO()); }
            set { _routing = value; }
        } 
    }
}