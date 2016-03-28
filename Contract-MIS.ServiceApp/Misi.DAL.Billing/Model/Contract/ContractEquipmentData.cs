using System.ComponentModel.DataAnnotations.Schema;
using Misi.DAL.Billing.Model.Common;

namespace Misi.DAL.Billing.Model.Contract
{
    public abstract class ContractEquipmentData : ContractBase
    {
        [Column("equipment")]
        public string Equipment { get; set; }

        [Column("equip_desc")]
        public string EquipDesc { get; set; }

        [Column("device")]
        public string Device { get; set; }

        [Column("device_sn")]
        public string DeviceSn { get; set; }
    }
}
