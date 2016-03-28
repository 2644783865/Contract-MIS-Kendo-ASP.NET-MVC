using System.Runtime.Serialization;

namespace Misi.Service.Billing.Model.NewContract
{
    [DataContract]
    public class NewContractSoftwareRoutingInfoDTO : NewContractRoutingInfoBaseDTO
    {
        private NewContractSoftwareContractDTO _contract;

        [DataMember]
        public NewContractSoftwareContractDTO Contract
        {
            get { return _contract ?? (_contract = new NewContractSoftwareContractDTO()); }
            set { _contract = value; }
        }
    }
}