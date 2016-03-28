using System.Runtime.Serialization;
using Misi.Service.Billing.Model.Common;

namespace Misi.Service.Billing.Model.BrokenDevice
{
    [DataContract]
    public class BrokenDeviceRequestDTO : ServiceRequestDTO
    {
        private BrokenDeviceRequestInfoDTO _requestInfo;
        private BrokenDeviceRoutingInfoDTO _routing;

        [DataMember]
        public BrokenDeviceRequestInfoDTO RequestInfo
        {
            get { return _requestInfo ?? (_requestInfo = new BrokenDeviceRequestInfoDTO()); }
            set { _requestInfo = value; }
        }

        [DataMember]
        public BrokenDeviceRoutingInfoDTO Routing
        {
            get { return _routing ?? (_routing = new BrokenDeviceRoutingInfoDTO()); }
            set { _routing = value; }
        }
    }
}