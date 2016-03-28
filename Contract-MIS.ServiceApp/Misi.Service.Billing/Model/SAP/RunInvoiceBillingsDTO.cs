using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Misi.Service.Billing.Model.SAP
{
    public class RunInvoiceBillingsDTO : RunInvoiceDTO
    {
        private List<BillingItemDTO> _billingItems;

        [DataMember]
        public List<BillingItemDTO> BillingItems
        {
            get { return _billingItems ?? (_billingItems = new List<BillingItemDTO>()); }
            set { _billingItems = value; }
        }
    }
}