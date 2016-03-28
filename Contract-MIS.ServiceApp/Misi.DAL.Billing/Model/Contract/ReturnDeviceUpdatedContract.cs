using System.ComponentModel.DataAnnotations.Schema;

namespace Misi.DAL.Billing.Model.Contract
{
    public class ReturnDeviceUpdatedContract : ReturnDeviceOldContract
    {
        [Column("upd_location")]
        public string UpdLocation { get; set; }

        [Column("return_delivery_number")]
        public string ReturnDeliveryNumber { get; set; }
    }
}
