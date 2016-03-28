using System.Runtime.Serialization;

namespace Misi.Service.Billing.Model.SAP
{
    [DataContract(IsReference = true)]
    [KnownType(typeof(RunPrintBillingsDTO))]
    public abstract class RunPrintDTO : SAPResponse
    {
    }

}