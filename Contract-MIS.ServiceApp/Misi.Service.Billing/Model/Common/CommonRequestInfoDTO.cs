using System;
using System.Runtime.Serialization;
using Misi.Service.Billing.Model.BrokenDevice;
using Misi.Service.Billing.Model.ErrorCharges;
using Misi.Service.Billing.Model.NewContract;
using Misi.Service.Billing.Model.NewScenario;
using Misi.Service.Billing.Model.ReturnDevice;
using Misi.Service.Billing.Model.TransferAsset;

namespace Misi.Service.Billing.Model.Common
{
    [DataContract(IsReference = true)]
    [KnownType(typeof(ReturnDeviceRequestInfoDTO))]
    [KnownType(typeof(NewContractRequestInfoDTO))]
    [KnownType(typeof(ErrorChargesRequestInfoDTO))]
    [KnownType(typeof(TransferAssetRequestInfoDTO))]
    [KnownType(typeof(BrokenDeviceRequestInfoDTO))]
    [KnownType(typeof(NewScenarioRequestInfoDTO))]
    public abstract class CommonRequestInfoDTO : RequestInfoBaseDTO
    {
        [DataMember]
        public DateTime RequestedDate { get; set; }

        [DataMember]
        public string SnOrIdNumber { get; set; }

        [DataMember]
        public string Company { get; set; }
    }
}