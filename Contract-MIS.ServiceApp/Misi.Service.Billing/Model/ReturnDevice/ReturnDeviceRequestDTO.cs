using System.Collections.Generic;
using System.Runtime.Serialization;
using Misi.Service.Billing.Model.Common;

namespace Misi.Service.Billing.Model.ReturnDevice
{
    [DataContract]
    public class ReturnDeviceRequestDTO : ServiceRequestDTO
    {
        private ReturnDeviceRequestInfoDTO _requestInfo;
        private List<ReturnDeviceRoutingInfoDTO> _routings;

        [DataMember]
        public ReturnDeviceRequestInfoDTO RequestInfo
        {
            get { return _requestInfo ?? (_requestInfo = new ReturnDeviceRequestInfoDTO()); }
            set { _requestInfo = value; }
        }

        [DataMember]
        public List<ReturnDeviceRoutingInfoDTO> Routings
        {
            get { return _routings ?? (_routings = new List<ReturnDeviceRoutingInfoDTO>()); }
            set { _routings = value; }
        } 
    }
}