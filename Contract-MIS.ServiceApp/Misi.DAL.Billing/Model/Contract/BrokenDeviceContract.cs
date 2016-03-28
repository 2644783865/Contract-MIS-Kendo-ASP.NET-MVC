using System.ComponentModel.DataAnnotations.Schema;

namespace Misi.DAL.Billing.Model.Contract
{
    public class BrokenDeviceContract : ContractEquipmentData
    {
        [Column("number")]
        public string Number { get; set; }

        [Column("line_number")]
        public string LineNumber { get; set; }

        [Column("holder_name")]
        public string HolderName { get; set; }

        [Column("salary_number")]
        public string SalaryNumber { get; set; }

        [Column("backup_equipment")]
        public string BackupEquipment { get; set; }
    }
}
