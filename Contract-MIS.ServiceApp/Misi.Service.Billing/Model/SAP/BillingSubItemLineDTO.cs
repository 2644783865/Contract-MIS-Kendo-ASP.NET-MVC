using System.Runtime.Serialization;

namespace Misi.Service.Billing.Model.SAP
{
    [DataContract]
    public class BillingSubItemLineDTO
    {
        [DataMember]
        public int SubItemNumber { get; set; }

        [DataMember]
        public string RoutingCreationDate { get; set; }

        [DataMember]
        public string IdrWebNumber { get; set; }

        [DataMember]
        public string ContractNumber { get; set; }

        [DataMember]
        public string ContractItem { get; set; }

        [DataMember]
        public string Scenario { get; set; }

        [DataMember]
        public string DetailScenario { get; set; }

        [DataMember]
        public string EquipmentNumber { get; set; }

        [DataMember]
        public string EquipmentItem { get; set; }

        [DataMember]
        public string Device { get; set; }

        [DataMember]
        public bool DevisionStatus { get; set; }

        [DataMember]
        public bool SAStatus { get; set; }
    }
}