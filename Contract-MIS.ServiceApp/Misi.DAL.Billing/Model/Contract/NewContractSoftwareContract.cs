using System.ComponentModel.DataAnnotations.Schema;
using Misi.DAL.Billing.Model.Common;

namespace Misi.DAL.Billing.Model.Contract
{
    public class NewContractSoftwareContract : ContractBase
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

        [Column("software_type")]
        public string SoftwareType { get; set; }

        [Column("service_delivery_date")]
        public string ServiceDeliveryDate { get; set; }
    }
}
