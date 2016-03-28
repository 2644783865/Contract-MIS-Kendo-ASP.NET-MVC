using System.Runtime.Serialization;
using Misi.Service.Billing.Model.Common;

namespace Misi.Service.Billing.Model.NewScenario
{
    [DataContract]
    public class NewScenarioRequestInfoDTO : CommonRequestInfoDTO
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