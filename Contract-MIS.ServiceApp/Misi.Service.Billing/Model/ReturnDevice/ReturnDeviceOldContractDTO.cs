using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
using Misi.Service.Billing.Model.Common;

namespace Misi.Service.Billing.Model.ReturnDevice
{
    [DataContract(IsReference = true)]
    [KnownType(typeof(ReturnDeviceUpdatedContractDTO))]
    public class ReturnDeviceOldContractDTO : ContractEquipDataDTO
    {
        [DataMember]
        public string OldNumber { get; set; }

        [DataMember]
        public string OldLineNumber { get; set; }

        [DataMember]
        public string OldHolderName { get; set; }

        [DataMember]
        public string OldSalaryNumber { get; set; }
    }
}