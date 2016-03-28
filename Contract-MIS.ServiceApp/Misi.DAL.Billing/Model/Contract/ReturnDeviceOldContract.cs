using System.ComponentModel.DataAnnotations.Schema;

namespace Misi.DAL.Billing.Model.Contract
{
    public class ReturnDeviceOldContract : ContractEquipmentData
    {
        [Column("old_number")]
        public string OldNumber { get; set; }

        [Column("old_line_number")]
        public string OldLineNumber { get; set; }

        [Column("old_holder_name")]
        public string OldHolderName { get; set; }

        [Column("old_salary_number")]
        public string OldSalaryNumber { get; set; }
    }
}
