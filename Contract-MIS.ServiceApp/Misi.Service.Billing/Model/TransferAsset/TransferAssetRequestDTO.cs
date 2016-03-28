using System.Collections.Generic;
using System.Runtime.Serialization;
using Misi.Service.Billing.Model.Common;

namespace Misi.Service.Billing.Model.TransferAsset
{
    [DataContract]
    public class TransferAssetRequestDTO : ServiceRequestDTO
    {
        private TransferAssetRequestInfoDTO _requestInfo;
        private List<TransferAssetRoutingInfoDTO> _routings;

        [DataMember]
        public TransferAssetRequestInfoDTO RequestInfo
        {
            get { return _requestInfo ?? (_requestInfo = new TransferAssetRequestInfoDTO());}
            set { _requestInfo = value; }
        }

        [DataMember]
        public List<TransferAssetRoutingInfoDTO> Routings
        {
            get { return _routings ?? (_routings = new List<TransferAssetRoutingInfoDTO>()); }
            set { _routings = value; }
        }
    }

}