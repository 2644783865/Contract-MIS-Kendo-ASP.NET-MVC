using System.ComponentModel.DataAnnotations.Schema;
using Misi.DAL.Billing.Model.Common;

namespace Misi.DAL.Billing.Model.Contract
{
    public class NewContractExtLineContract : ContractBase
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

        [Column("extension_line_number")]
        public string ExtensionLineNumber { get; set; }
    }
}
