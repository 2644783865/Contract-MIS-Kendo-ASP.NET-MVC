using System.Runtime.Serialization;
using Misi.Service.Billing.Model.Common;

namespace Misi.Service.Billing.Model.BrokenDevice
{
    [DataContract]
    public class BrokenDeviceRoutingInfoDTO : RoutingInfoBaseDTO
    {
        private BrokenDeviceContractDTO _contract;

        [DataMember]
        public string IdrWebNumber { get; set; }

        [DataMember]
        public BrokenDeviceContractDTO Contract
        {
            get { return _contract ?? (_contract = new BrokenDeviceContractDTO()); }
            set { _contract = value; }
        }
    }
}