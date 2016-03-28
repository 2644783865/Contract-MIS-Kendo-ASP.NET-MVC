using Misi.MVC.Filters;

namespace Misi.MVC.ViewModels.ProformaInvoice
{
    /// <summary>
    /// Table orange level III
    /// </summary>
    public class BillingSubItemLineViewModel
    {
        [LocalizedDisplayName("SubItemNumber", NameResourceType = typeof (Resources.ProformaInvoiceResource))]
        public int SubItemNumber { get; set; }

        [LocalizedDisplayName("RoutingCreationDate", NameResourceType = typeof (Resources.ProformaInvoiceResource))]
        public string RoutingCreationDate { get; set; }

        [LocalizedDisplayName("IdrWebNumber", NameResourceType = typeof (Resources.SharedResource))]
        public string IdrWebNumber { get; set; }

        [LocalizedDisplayName("ContractNumber", NameResourceType = typeof (Resources.ProformaInvoiceResource))]
        public string ContractNumber { get; set; }

        [LocalizedDisplayName("ContractItem", NameResourceType = typeof (Resources.ProformaInvoiceResource))]
        public string ContractItem { get; set; }

        [LocalizedDisplayName("Scenario", NameResourceType = typeof (Resources.ProformaInvoiceResource))]
        public string Scenario { get; set; }

        [LocalizedDisplayName("DetailScenario", NameResourceType = typeof (Resources.ProformaInvoiceResource))]
        public string DetailScenario { get; set; }

        [LocalizedDisplayName("EquipmentNumber", NameResourceType = typeof (Resources.ProformaInvoiceResource))]
        public string EquipmentNumber { get; set; }

        [LocalizedDisplayName("EquipmentItem", NameResourceType = typeof (Resources.ProformaInvoiceResource))]
        public string EquipmentItem { get; set; }

        [LocalizedDisplayName("Device", NameResourceType = typeof (Resources.ProformaInvoiceResource))]
        public string Device { get; set; }

        [LocalizedDisplayName("DevisionStatus", NameResourceType = typeof (Resources.ProformaInvoiceResource))]
        public bool DevisionStatus { get; set; }

        [LocalizedDisplayName("SAStatus", NameResourceType = typeof (Resources.ProformaInvoiceResource))]
        public bool SAStatus { get; set; }
    }
}