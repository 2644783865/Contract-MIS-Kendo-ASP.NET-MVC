using System.ComponentModel.DataAnnotations.Schema;

namespace Misi.DAL.Billing.Model.Contract
{
    public class NewContractIpPhoneContract : NewContractLaptopContract
    {
        [Column("extension_line_number")]
        public string ExtensionLineNumber { get; set; }
    }
}
