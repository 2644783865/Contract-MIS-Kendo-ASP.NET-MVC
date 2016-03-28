using System;
using System.Runtime.Serialization;
using Misi.DAL.Billing.Model;
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
    [KnownType(typeof(BrokenDeviceRequestDTO))]
    [KnownType(typeof(ErrorChargesRequestDTO))]
    [KnownType(typeof(NewContractRequestDTO))]
    [KnownType(typeof(ReturnDeviceRequestDTO))]
    [KnownType(typeof(TerminationRequestDTO))]
    [KnownType(typeof(TransferAssetRequestDTO))]
    [KnownType(typeof(NewScenarioRequestDTO))]
    public abstract class ServiceRequestDTO
    {
        [DataMember]
        public long No { get; set; }

        [DataMember]
        public string Id { get; set; }

        [DataMember]
        public EScenario Scenario { get; set; }

        [DataMember]
        public string IssuedBy { get; set; }

        [DataMember]
        public DateTime IssuedDate { get; set; }

        [DataMember]
        public EServiceRequestState State { get; set; }
    }
}