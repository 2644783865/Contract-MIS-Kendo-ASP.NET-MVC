using System.Runtime.Serialization;

namespace Misi.Service.Billing.Model.NewContract
{
    [DataContract]
    public class NewContractLaptopRoutingInfoDTO : NewContractRoutingInfoBaseDTO
    {
        private NewContractLaptopContractDTO _contract;

        [DataMember]
        public NewContractLaptopContractDTO Contract
        {
            get { return _contract ?? (_contract = new NewContractLaptopContractDTO()); }
            set { _contract = value; }
        }
    }
}