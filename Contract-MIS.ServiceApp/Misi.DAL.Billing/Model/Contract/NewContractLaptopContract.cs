using System.ComponentModel.DataAnnotations.Schema;

namespace Misi.DAL.Billing.Model.Contract
{
    public class NewContractLaptopContract : ContractEquipmentData
    {
        [Column("quotation_number")]
        public string QuotationNumber { get; set; }

        [Column("number")]
        public string Number { get; set; }

        [Column("line_number")]
        public string LineNumber { get; set; }

        [Column("holder_name")]
        public string HolderName { get; set; }

        [Column("salary_number")]
        public string SalaryNumber { get; set; }

        [Column("so_delivery_number")]
        public string SoDeliveryNumber { get; set; }

        [Column("asset_number")]
        public string AssetNumber { get; set; }

        [Column("cip_number")]
        public string CipNumber { get; set; }

        [Column("delivery_order_to_user")]
        public string DeliveryOrderToUser { get; set; }

        [Column("notification_number")]
        public string NotificationNumber { get; set; }
    }
}
