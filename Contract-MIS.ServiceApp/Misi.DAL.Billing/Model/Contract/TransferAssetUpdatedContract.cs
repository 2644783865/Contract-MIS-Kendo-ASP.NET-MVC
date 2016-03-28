using System.ComponentModel.DataAnnotations.Schema;

namespace Misi.DAL.Billing.Model.Contract
{
    public class TransferAssetUpdatedContract : TransferAssetOldContract
    {
        [Column("upd_location")]
        public string UpdLocation { get; set; }
    }
}
