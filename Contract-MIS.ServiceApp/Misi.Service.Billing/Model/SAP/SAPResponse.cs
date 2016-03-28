using System.Runtime.Serialization;
using Misi.Service.Billing.Object;

namespace Misi.Service.Billing.Model.SAP
{
    [DataContract(IsReference = true)]
    [KnownType(typeof(OKResponse))]
    [KnownType(typeof(RunInvoiceDTO))]
    [KnownType(typeof(SoldToPartiesListDTO))]
    [KnownType(typeof(BillingNumberItemsDTO))]
    [KnownType(typeof(RunPrintBillingsDTO))]
    [KnownType(typeof(Contract))]
    [KnownType(typeof(NumberResult))]
    [KnownType(typeof(InvoiceProformaBillingRunsDTO))]
    public abstract class SAPResponse
    {
    }
}