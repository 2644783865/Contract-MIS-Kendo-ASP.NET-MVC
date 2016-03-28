using System;
using System.Runtime.Serialization;
using Misi.DAL.Billing.Model.Object;

namespace Misi.Service.Billing.Model.Common
{
    [DataContract]
    public class RoutingItemDTO
    {
        [DataMember]
        public long No { get; set; }

        [DataMember]
        public long Step { get; set; }

        [DataMember]
        public string Division { get; set; }

        [DataMember]
        public string Instruction { get; set; }

        [DataMember]
        public string Response { get; set; }

        [DataMember]
        public DateTime BaseDate { get; set; }

        [DataMember]
        public DateTime PlanDate { get; set; }

        [DataMember]
        public DateTime ActualDate { get; set; }

        [DataMember]
        public bool DivisionStatus { get; set; }

        [DataMember]
        public bool SaStatus { get; set; }

        [DataMember]
        public ERoutingStatus RoutingStatus { get; set; }
    }
}