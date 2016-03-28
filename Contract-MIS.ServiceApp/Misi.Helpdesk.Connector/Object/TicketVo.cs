using System.Runtime.Serialization;

namespace Misi.Helpdesk.Connector.Object
{
    [DataContract]
    public class TicketVo
    {
        [DataMember]
        public long Idx { get; set; }

        [DataMember]
        public string TicketId { get; set; }

        [DataMember]
        public string MTicketId { get; set; }

        [DataMember]
        public string ReportBy { get; set; }

        [DataMember]
        public string IdNumber { get; set; }

        [DataMember]
        public string ReportVia { get; set; }

        [DataMember]
        public string ReportedTime { get; set; }

        [DataMember]
        public string Company { get; set; }

        [DataMember]
        public string CompanyCode { get; set; }

        [DataMember]
        public string Location { get; set; }

        [DataMember]
        public string Email { get; set; }

        [DataMember]
        public string ReportDate { get; set; }

        [DataMember]
        public string ReportTime { get; set; }

        [DataMember]
        public string AssetNo { get; set; }

        [DataMember]
        public string UserAccess { get; set; }

        [DataMember]
        public string ExistingDevice { get; set; }

        [DataMember]
        public string Phone { get; set; }

        [DataMember]
        public string Ext { get; set; }

        [DataMember]
        public string Category { get; set; }

        [DataMember]
        public string DetailCategory { get; set; }

        [DataMember]
        public string PrjName { get; set; }

        [DataMember]
        public string Urgency { get; set; }

        [DataMember]
        public string Impact { get; set; }

        [DataMember]
        public string Priority { get; set; }

        [DataMember]
        public string ProblemHeader { get; set; }

        [DataMember]
        public string Problem { get; set; }

        [DataMember]
        public string Resolution { get; set; }

        [DataMember]
        public string StatusTicket { get; set; }

        [DataMember]
        public string DescStatus { get; set; }

        [DataMember]
        public string FromDeptEscalate { get; set; }

        [DataMember]
        public string DeptEscalate { get; set; }

        [DataMember]
        public string FromEscalate { get; set; }

        [DataMember]
        public string Escalate { get; set; }

        [DataMember]
        public string FromEscalateSn { get; set; }

        [DataMember]
        public string EscalateSn { get; set; }

        [DataMember]
        public string Reason { get; set; }

        [DataMember]
        public string StartDate { get; set; }

        [DataMember]
        public string StartTime { get; set; }

        [DataMember]
        public string EndDate { get; set; }

        [DataMember]
        public string EndTime { get; set; }

        [DataMember]
        public string EndDateAct { get; set; }

        [DataMember]
        public string EndTimeAct { get; set; }

        [DataMember]
        public long WorkingTime { get; set; }

        [DataMember]
        public string CreatedBy { get; set; }

        [DataMember]
        public string CreatedDate { get; set; }

        [DataMember]
        public string LastUpdate { get; set; }

        [DataMember]
        public string LastIp { get; set; }

        [DataMember]
        public string Attach { get; set; }

        [DataMember]
        public long Counter { get; set; }

        [DataMember]
        public long IdxReqProblem { get; set; }

        [DataMember]
        public string TimeDetail { get; set; }

        [DataMember]
        public long DetailCategoryId { get; set; }

        [DataMember]
        public string RevenueType { get; set; }

        [DataMember]
        public string CompanyWBS { get; set; }

        [DataMember]
        public string LastUser { get; set; }

        [DataMember]
        public string WBSNo { get; set; }

        [DataMember]
        public string Product { get; set; }

        [DataMember]
        public long LocationId { get; set; }

        [DataMember]
        public string FromDeptCodeEscalate { get; set; }

        [DataMember]
        public string PrjId { get; set; }

        [DataMember]
        public string DeptCodeEscalate { get; set; }

        [DataMember]
        public string SubRevenueType { get; set; }

        [DataMember]
        public string DeviceType { get; set; }

        [DataMember]
        public long DeviceTypeId { get; set; }

        [DataMember]
        public string ReferenceNo { get; set; }

        [DataMember]
        public string Warranty { get; set; }

        [DataMember]
        public string YearPurchase { get; set; }

        [DataMember]
        public string ReportHelpdeskBy { get; set; }

        [DataMember]
        public long ReopenLevel { get; set; }

        [DataMember]
        public string Sla { get; set; }

        [DataMember]
        public long IsSmup { get; set; }
    }

}