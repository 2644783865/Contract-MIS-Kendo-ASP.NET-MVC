
using System.Runtime.Serialization;

namespace Misi.Service.Billing.Model.NewContract
{
    [DataContract]
    public class NewContractIpPhoneRoutingInfoDTO : NewContractRoutingInfoBaseDTO
    {
        private NewContractIpPhoneContractDTO _contract;

        [DataMember]
        public NewContractIpPhoneContractDTO Contract
        {
            get { return _contract ?? (_contract = new NewContractIpPhoneContractDTO()); }
            set { _contract = value; }
        }
    }
}