using System.Runtime.Serialization;

namespace Misi.Service.Billing.Model.ReturnDevice
{
    [DataContract]
    public class ReturnDeviceUpdatedContractDTO : ReturnDeviceOldContractDTO
    {
        [DataMember]
        public string UpdLocation { get; set; }

        [DataMember]
        public string ReturnDeliveryNumber { get; set; }
    }
}