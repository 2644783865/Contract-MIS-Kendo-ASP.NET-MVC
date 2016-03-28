using System.Runtime.Serialization;
using Misi.Service.Billing.Model.Common;

namespace Misi.Service.Billing.Model.ReturnDevice
{
    [DataContract]
    public class ReturnDeviceRoutingInfoDTO : RoutingInfoBaseDTO
    {
        private ReturnDeviceOldContractDTO _oldContract;
        private ReturnDeviceUpdatedContractDTO _updContract;

        [DataMember]
        public string IdrWebNumber { get; set; }

        [DataMember]
        public ReturnDeviceOldContractDTO OldContract
        {
            get { return _oldContract ?? (_oldContract = new ReturnDeviceOldContractDTO()); }
            set { _oldContract = value; }
        }

        public ReturnDeviceUpdatedContractDTO UpdContract
        {
            get { return _updContract ?? (_updContract = new ReturnDeviceUpdatedContractDTO()); }
            set { _updContract = value; }
        }
    }
}