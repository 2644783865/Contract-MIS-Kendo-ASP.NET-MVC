using System.Collections.Generic;
using System.Runtime.Serialization;
using Misi.Service.Billing.Model.Common;

namespace Misi.Service.Billing.Model.NewContract
{
    [DataContract]
    public class NewContractRequestDTO : ServiceRequestDTO
    {
        private NewContractRequestInfoDTO _requestInfo;
        private List<NewContractRoutingInfoBaseDTO> _routings;
        
        [DataMember]
        public NewContractRequestInfoDTO RequestInfo
        {
            get { return _requestInfo ?? (_requestInfo = new NewContractRequestInfoDTO()); }
            set { _requestInfo = value; }
        }

        [DataMember]
        public List<NewContractRoutingInfoBaseDTO> Routings
        {
            get { return _routings ?? (_routings = new List<NewContractRoutingInfoBaseDTO>()); }
            set { _routings = value; }
        }
    }
}