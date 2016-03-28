using System.Collections.Generic;
using System.Runtime.Serialization;
using Misi.Service.Billing.Model.Common;

namespace Misi.Service.Billing.Model.NewScenario
{
    [DataContract]
    public class NewScenarioRequestDTO : ServiceRequestDTO
    {
        private NewScenarioRequestInfoDTO _requestInfo;
        private List<NewScenarioRoutingInfoDTO> _routings;

        [DataMember]
        public NewScenarioRequestInfoDTO RequestInfo
        {
            get { return _requestInfo ?? (_requestInfo = new NewScenarioRequestInfoDTO()); }
            set { _requestInfo = value; }
        }

        [DataMember]
        public List<NewScenarioRoutingInfoDTO> Routings
        {
            get { return _routings ?? (_routings = new List<NewScenarioRoutingInfoDTO>()); }
            set { _routings = value; }
        }
    }
}