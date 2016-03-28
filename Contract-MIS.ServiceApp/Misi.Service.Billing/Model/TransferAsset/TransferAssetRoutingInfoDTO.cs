using System.Runtime.Serialization;
using Misi.Service.Billing.Model.Common;

namespace Misi.Service.Billing.Model.TransferAsset
{
    [DataContract(IsReference = true)]
    [KnownType(typeof(TransferAssetByHolderRoutingInfoDTO))]
    [KnownType(typeof(TransferAssetByLocationRoutingInfoDTO))]
    public abstract class TransferAssetRoutingInfoDTO : RoutingInfoBaseDTO
    {
        [DataMember]
        public string IdrWebNumber { get; set; }
    }
}