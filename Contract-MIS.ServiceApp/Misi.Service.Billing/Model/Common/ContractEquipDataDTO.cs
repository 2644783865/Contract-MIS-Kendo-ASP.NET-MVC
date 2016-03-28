using System.Runtime.Serialization;
using Misi.Service.Billing.Model.BrokenDevice;
using Misi.Service.Billing.Model.NewScenario;
using Misi.Service.Billing.Model.ReturnDevice;
using Misi.Service.Billing.Model.TransferAsset;

namespace Misi.Service.Billing.Model.Common
{
    [DataContract(IsReference = true)]
    [KnownType(typeof(ReturnDeviceOldContractDTO))]
    [KnownType(typeof(BrokenDeviceContractDTO))]
    [KnownType(typeof(TransferAssetNewContractDTO))]
    [KnownType(typeof(TransferAssetOldContractDTO))]
    [KnownType(typeof(NewScenarionContractDTO))]
    public abstract class ContractEquipDataDTO : ContractBaseDTO
    {
        [DataMember]
        public string Equipment { get; set; }

        [DataMember]
        public string EquipDesc { get; set; }

        [DataMember]
        public string Device { get; set; }

        [DataMember]
        public string DeviceSn { get; set; }
    }
}