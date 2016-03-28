using System.ComponentModel.DataAnnotations.Schema;

namespace Misi.Helpdesk.Connector.Model
{
    [Table("tblsc")]
    public class Ticket
    {
        [Column("idx")]
        public long Idx { get; set; }

        [Column("ticketid")]
        public string TicketId { get; set; }

        [Column("mticketid")]
        public string MTicketId { get; set; }

        [Column("reportby")]
        public string ReportBy { get; set; }

        [Column("idnumber")]
        public string IdNumber { get; set; }

        [Column("reportvia")]
        public string ReportVia { get; set; }

        [Column("reportendtime")]
        public string ReportedTime { get; set; }

        [Column("company")]
        public string Company { get; set; }

        [Column("companycode")]
        public string CompanyCode { get; set; }

        [Column("location")]
        public string Location { get; set; }

        [Column("email")]
        public string Email { get; set; }

        [Column("reportdate")]
        public string ReportDate { get; set; }

        [Column("reporttime")]
        public string ReportTime { get; set; }

        [Column("assetno")]
        public string AssetNo { get; set; }

        [Column("useraccess")]
        public string UserAccess { get; set; }

        [Column("existingdevice")]
        public string ExistingDevice { get; set; }

        [Column("phone")]
        public string Phone { get; set; }

        [Column("ext")]
        public string Ext { get; set; }

        [Column("category")]
        public string Category { get; set; }

        [Column("detailcategory")]
        public string DetailCategory { get; set; }

        [Column("prjname")]
        public string PrjName { get; set; }

        [Column("urgency")]
        public string Urgency { get; set; }

        [Column("impact")]
        public string Impact { get; set; }

        [Column("priority")]
        public string Priority { get; set; }

        [Column("problem_header")]
        public string ProblemHeader { get; set; }

        [Column("problem")]
        public string Problem { get; set; }

        [Column("resolution")]
        public string Resolution { get; set; }

        [Column("statusticket")]
        public string StatusTicket { get; set; }

        [Column("descstatus")]
        public string DescStatus { get; set; }

        [Column("fromdeptescalate")]
        public string FromDeptEscalate { get; set; }

        [Column("deptescalate")]
        public string DeptEscalate { get; set; }

        [Column("fromescalate")]
        public string FromEscalate { get; set; }

        [Column("escalate")]
        public string Escalate { get; set; }

        [Column("fromescalatesn")]
        public string FromEscalateSn { get; set; }

        [Column("escalatesn")]
        public string EscalateSn { get; set; }

        [Column("reason")]
        public string Reason { get; set; }

        [Column("startdate")]
        public string StartDate { get; set; }

        [Column("starttime")]
        public string StartTime { get; set; }

        [Column("enddate")]
        public string EndDate { get; set; }

        [Column("endtime")]
        public string EndTime { get; set; }

        [Column("enddateact")]
        public string EndDateAct { get; set; }

        [Column("endtimeact")]
        public string EndTimeAct { get; set; }

        [Column("workingtime")]
        public long WorkingTime { get; set; }

        [Column("createdby")]
        public string CreatedBy { get; set; }

        [Column("createddate")]
        public string CreatedDate { get; set; }

        [Column("lastupdate")]
        public string LastUpdate { get; set; }

        [Column("lastip")]
        public string LastIp { get; set; }

        [Column("attach")]
        public string Attach { get; set; }

        [Column("counter")]
        public long Counter { get; set; }

        [Column("idxreqproblem")]
        public long IdxReqProblem { get; set; }

        [Column("timedetail")]
        public string TimeDetail { get; set; }

        [Column("detailcategory_id")]
        public long DetailCategoryId { get; set; }

        [Column("revenue_type")]
        public string RevenueType { get; set; }

        [Column("companywbs")]
        public string CompanyWBS { get; set; }

        [Column("lastuser")]
        public string LastUser { get; set; }

        [Column("wbsno")]
        public string WBSNo { get; set; }

        [Column("product")]
        public string Product { get; set; }

        [Column("location_id")]
        public long LocationId { get; set; }

        [Column("fromdeptcodeescalate")]
        public string FromDeptCodeEscalate { get; set; }

        [Column("prj_id")]
        public string PrjId { get; set; }

        [Column("deptcodeescalate")]
        public string DeptCodeEscalate { get; set; }

        [Column("sub_revenue_type")]
        public string SubRevenueType { get; set; }

        [Column("device_type")]
        public string DeviceType { get; set; }

        [Column("device_type_id")]
        public long DeviceTypeId { get; set; }

        [Column("reference_no")]
        public string ReferenceNo { get; set; }

        [Column("warranty")]
        public string Warranty { get; set; }

        [Column("year_purchase")]
        public string YearPurchase { get; set; }

        [Column("report_helpdesk_by")]
        public string ReportHelpdeskBy { get; set; }

        [Column("reopen_level")]
        public long ReopenLevel { get; set; }

        [Column("sla")]
        public string Sla { get; set; }

        [Column("is_smup")]
        public long IsSmup { get; set; }
    }
}