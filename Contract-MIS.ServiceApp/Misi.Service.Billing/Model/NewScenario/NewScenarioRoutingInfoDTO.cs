using System.Runtime.Serialization;
using Misi.Service.Billing.Model.Common;

namespace Misi.Service.Billing.Model.NewScenario
{
    [DataContract]
    public class NewScenarioRoutingInfoDTO : RoutingInfoBaseDTO
    {
        private NewScenarionContractDTO _contract;

        [DataMember]
        public string IdrWebNumber { get; set; }

        [DataMember]
        public string AttributeDescription { get; set; }

        [DataMember]
        public NewScenarionContractDTO Contract
        {
            get { return _contract ?? (_contract = new NewScenarionContractDTO()); }
            set { _contract = value; }
        }
    }
}