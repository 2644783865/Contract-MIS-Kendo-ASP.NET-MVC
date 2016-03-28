using System.Runtime.Serialization;
using Misi.Service.Billing.Model.Common;

namespace Misi.Service.Billing.Model.NewScenario
{
    public class NewScenarionContractDTO : ContractEquipDataDTO
    {
        [DataMember]
        public string Number { get; set; }

        [DataMember]
        public string LineNumber { get; set; }
    }
}