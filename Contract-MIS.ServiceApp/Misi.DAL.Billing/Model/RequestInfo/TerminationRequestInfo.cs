using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Misi.DAL.Billing.Model.Common;

namespace Misi.DAL.Billing.Model.RequestInfo
{
    public class TerminationRequestInfo : RequestInfoBase
    {
        private List<TerminationItem> _terminations;
        
        [Column("requested_via")]
        public string RequestedVia { get; set; }

        public List<TerminationItem> Terminations
        {
            get { return _terminations ?? (_terminations = new List<TerminationItem>()); }
            set { _terminations = value; }
        }
    }
}
