using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
using Misi.Service.Billing.Model.Common;

namespace Misi.Service.Billing.Model.BrokenDevice
{
    [DataContract]
    public class BrokenDeviceContractDTO : ContractEquipDataDTO
    {
        [DataMember]
        public string Number { get; set; }

        [DataMember]
        public string LineNumber { get; set; }

        [DataMember]
        public string HolderName { get; set; }

        [DataMember]
        public string SalaryNumber { get; set; }

        [DataMember]
        public string BackupEquipment { get; set; }
    }
}