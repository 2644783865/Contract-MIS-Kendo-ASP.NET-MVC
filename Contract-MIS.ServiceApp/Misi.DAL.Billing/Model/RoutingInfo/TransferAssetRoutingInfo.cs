using System.ComponentModel.DataAnnotations.Schema;
using Misi.DAL.Billing.Model.Common;

namespace Misi.DAL.Billing.Model.RoutingInfo
{
    public abstract class TransferAssetRoutingInfo : RoutingInfoBase
    {
        [Column("idr_web_number")]
        public string IdrWebNumber { get; set; }
    }
}
