using System.Collections.Generic;
using System.Runtime.Serialization;
using Misi.Service.Billing.Model.Common;

namespace Misi.Service.Billing.Model.Termination
{
    [DataContract]
    public class TerminationRequestInfoDTO : RequestInfoBaseDTO
    {
        private List<TerminationItemDTO> _terminations;

        [DataMember]
        public string RequestedVia { get; set; }

        [DataMember]
        public List<TerminationItemDTO> Terminations
        {
            get { return _terminations ?? (_terminations = new List<TerminationItemDTO>()); }
            set { _terminations = value; }
        } 
    }
}