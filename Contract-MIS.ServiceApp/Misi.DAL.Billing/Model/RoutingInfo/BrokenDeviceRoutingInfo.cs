using System.ComponentModel.DataAnnotations.Schema;
using Misi.DAL.Billing.Model.Common;
using Misi.DAL.Billing.Model.Contract;

namespace Misi.DAL.Billing.Model.RoutingInfo
{
    public class BrokenDeviceRoutingInfo : RoutingInfoBase
    {
        private BrokenDeviceContract _contract;

        [Column("idr_web_number")]
        public string IdrWebNumber { get; set; }

        public BrokenDeviceContract Contract
        {
            get { return _contract ?? (_contract = new BrokenDeviceContract()); }
            set { _contract = value; }
        }
    }
}
