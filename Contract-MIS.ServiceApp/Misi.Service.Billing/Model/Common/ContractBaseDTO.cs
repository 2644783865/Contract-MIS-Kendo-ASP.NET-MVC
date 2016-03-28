using System.Runtime.Serialization;
using Misi.Service.Billing.Model.NewContract;
using Misi.Service.Billing.Model.Termination;

namespace Misi.Service.Billing.Model.Common
{
    [DataContract(IsReference = true)]
    [KnownType(typeof(ContractEquipDataDTO))]
    [KnownType(typeof(TerminatedContractDTO))]
    [KnownType(typeof(NewContractSoftwareContractDTO))]
    [KnownType(typeof(TerminatedContractDTO))]
    [KnownType(typeof(NewContractExtLineContractDTO))]
    public abstract class ContractBaseDTO
    {
        [DataMember]
        public long No { get; set; }
    }
}