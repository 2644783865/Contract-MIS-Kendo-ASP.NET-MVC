using System.Runtime.Serialization;

namespace Misi.Service.Billing.Model.NewContract
{
    [DataContract]
    public class NewContractExtLineRoutingInfoDTO : NewContractRoutingInfoBaseDTO
    {
        private NewContractExtLineContractDTO _contract;

        [DataMember]
        public NewContractExtLineContractDTO Contract
        {
            get { return _contract ?? (_contract = new NewContractExtLineContractDTO()); }
            set { _contract = value; }
        }
    }
}