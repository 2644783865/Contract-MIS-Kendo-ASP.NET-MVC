using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Misi.DAL.Billing.Model.Object;
using Misi.Service.Billing.Model.BrokenDevice;
using Misi.Service.Billing.Model.ErrorCharges;
using Misi.Service.Billing.Model.NewContract;
using Misi.Service.Billing.Model.NewScenario;
using Misi.Service.Billing.Model.ReturnDevice;
using Misi.Service.Billing.Model.Termination;
using Misi.Service.Billing.Model.TransferAsset;

namespace Misi.Service.Billing.Model.Common
{
    [DataContract(IsReference = true)]
    [KnownType(typeof(BrokenDeviceRoutingInfoDTO))]
    [KnownType(typeof(NewContractRoutingInfoBaseDTO))]
    [KnownType(typeof(ReturnDeviceRoutingInfoDTO))]
    [KnownType(typeof(TerminationRoutingInfoDTO))]
    [KnownType(typeof(TransferAssetRoutingInfoDTO))]
    [KnownType(typeof(NewScenarioRoutingInfoDTO))]
    public abstract class RoutingInfoBaseDTO
    {
        private List<RoutingItemDTO> _routings;

        [DataMember]
        public long No { get; set; }

        [DataMember]
        public ESubScenario SubScenario { get; set; }

        [DataMember]
        public DateTime CreateDate { get; set; }

        [DataMember]
        public string RoutingMemo { get; set; }

        [DataMember]
        public List<RoutingItemDTO> Routings
        {
            get { return _routings ?? (_routings = new List<RoutingItemDTO>()); }
            set { _routings = value; }
        }

        [DataMember]
        public int CurrentStep { get; set; }
    }
}