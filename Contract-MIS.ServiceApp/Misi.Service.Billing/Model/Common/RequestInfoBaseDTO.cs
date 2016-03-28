using System.Runtime.Serialization;
using Misi.Service.Billing.Model.Termination;

namespace Misi.Service.Billing.Model.Common
{
    [DataContract(IsReference = true)]
    [KnownType(typeof(CommonRequestInfoDTO))]
    [KnownType(typeof(TerminationRequestInfoDTO))]
    public abstract class RequestInfoBaseDTO
    {
        [DataMember]
        public long No { get; set; }

        [DataMember]
        public string Id { get; set; }

        [DataMember]
        public string RequestMemo { get; set; }
    }
}