using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
using Misi.Service.Billing.Model.Common;

namespace Misi.Service.Billing.Model.Termination
{
    [DataContract]
    public class TerminationRoutingInfoDTO : RoutingInfoBaseDTO
    {
        private List<TerminationItemDTO> _terminations;

        [DataMember]
        public List<TerminationItemDTO> Terminations
        {
            get { return _terminations ?? (_terminations = new List<TerminationItemDTO>()); }
            set { _terminations = value; }
        } 
    }
}