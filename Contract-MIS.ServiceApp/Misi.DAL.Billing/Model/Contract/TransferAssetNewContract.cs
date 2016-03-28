using System.ComponentModel.DataAnnotations.Schema;

namespace Misi.DAL.Billing.Model.Contract
{
    public class TransferAssetNewContract : ContractEquipmentData
    {
        [Column("new_number")]
        public string NewNumber { get; set; }

        [Column("new_line_number")]
        public string NewLineNumber { get; set; }

        [Column("new_holder_name")]
        public string NewHolderName { get; set; }

        [Column("new_salary_number")]
        public string NewSalaryNumber { get; set; }

        [Column("new_location")]
        public string NewLocation { get; set; }

        [Column("return_delivery_number")]
        public string ReturnDeliveryNumber { get; set; }

        [Column("so_delivery_number")]
        public string SoDeliveryNumber { get; set; }

        [Column("delivery_order_to_user")]
        public string DeliveryOrderToUser { get; set; }
    }
}
