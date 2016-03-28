using System.Collections.Generic;
using Misi.DAL.Billing.Model.Common;

namespace Misi.DAL.Billing.Model.RoutingInfo
{
    public class TerminationRoutingInfo : RoutingInfoBase
    {
        private List<TerminationItem> _terminations;

        public List<TerminationItem> Terminations
        {
            get { return _terminations ?? (_terminations = new List<TerminationItem>()); }
            set { _terminations = value; }
        }
    }
}
