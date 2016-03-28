using System.Runtime.Serialization;

namespace Misi.Service.Billing.Model.SAP
{
    [DataContract(IsReference = true)]
    [KnownType(typeof(RunInvoiceBillingsDTO))]
    public abstract class RunInvoiceDTO : SAPResponse
    {
    }

}