using System.Runtime.Serialization;
using Misi.Service.Billing.Model.Common;

namespace Misi.Service.Billing.Model.ReturnDevice
{
    [DataContract]
    public class ReturnDeviceRequestInfoDTO : CommonRequestInfoDTO
    {
        [DataMember]
        public string Location { get; set; }

        [DataMember]
        public string RequestedBy { get; set; }

        [DataMember]
        public string RequestedVia { get; set; }

        [DataMember]
        public string Email { get; set; }
    }
}