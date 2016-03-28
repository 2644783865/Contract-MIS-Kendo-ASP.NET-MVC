using System.Runtime.Serialization;
using Misi.Service.Billing.Model.Common;

namespace Misi.Service.Billing.Model.BrokenDevice
{
    [DataContract]
    public class BrokenDeviceRequestInfoDTO : CommonRequestInfoDTO
    {
        [DataMember]
        public string RequestedBy { get; set; }

        [DataMember]
        public string CustomerId { get; set; }

        [DataMember]
        public string Branch { get; set; }
    }
}