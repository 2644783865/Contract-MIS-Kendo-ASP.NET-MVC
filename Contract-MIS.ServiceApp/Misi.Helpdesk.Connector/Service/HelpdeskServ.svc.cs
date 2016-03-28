using Misi.Helpdesk.Connector.DaoUtil;
using Misi.Helpdesk.Connector.Model;
using Misi.Helpdesk.Connector.Object;
using System;
using System.Collections.Generic;

namespace Misi.Helpdesk.Connector.Service
{
    public class HelpdeskServ : IHelpdeskServ
    {

        private readonly TicketDao dao = new TicketDao();

        public Tickets SelectAllTickets()
        {
            try
            {
                var list = new Tickets {Collection = new List<TicketVo>()};
                foreach (var t in dao.SelectAll())
                {
                    var tv = toTicketVo(t);
                    list.Collection.Add(tv);
                }
                return list;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Tickets SelectLimitedTickets(int offset, int limit)
        {
            try
            {
                var list = new Tickets {Collection = new List<TicketVo>()};
                foreach (var t in dao.SelectLimit(offset, limit))
                {
                    System.Diagnostics.Debug.WriteLine(t.StartDate);
                    var tv = toTicketVo(t);
                    list.Collection.Add(tv);
                }
                return list;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public TicketVo SelectTicket(string ticketId)
        {
            try
            {
                return toTicketVo(dao.Select(ticketId));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int TotalTickets()
        {
            try
            {
                return dao.Count();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private TicketVo toTicketVo(Ticket t)
        {
            var tv = new TicketVo
            {
                AssetNo = t.AssetNo,
                Attach = t.Attach,
                Category = t.Category,
                Company = t.Company,
                CompanyCode = t.CompanyCode,
                CompanyWBS = t.CompanyWBS,
                Counter = t.Counter,
                CreatedBy = t.CreatedBy,
                CreatedDate = t.CreatedDate,
                DeptCodeEscalate = t.DeptCodeEscalate,
                DeptEscalate = t.DeptEscalate,
                DescStatus = t.DescStatus,
                DetailCategory = t.DetailCategory,
                DetailCategoryId = t.DetailCategoryId,
                DeviceType = t.DeviceType,
                DeviceTypeId = t.DeviceTypeId,
                Email = t.Email,
                EndDate = t.EndDate,
                EndDateAct = t.EndDateAct,
                EndTime = t.EndTime,
                EndTimeAct = t.EndTimeAct,
                Escalate = t.Escalate,
                EscalateSn = t.EscalateSn,
                ExistingDevice = t.ExistingDevice,
                Ext = t.Ext,
                FromDeptCodeEscalate = t.FromDeptCodeEscalate,
                FromDeptEscalate = t.FromDeptEscalate,
                FromEscalate = t.FromEscalate,
                FromEscalateSn = t.FromEscalateSn,
                IdNumber = t.IdNumber,
                Idx = t.Idx,
                IdxReqProblem = t.IdxReqProblem,
                Impact = t.Impact,
                IsSmup = t.IsSmup,
                LastIp = t.LastIp,
                LastUpdate = t.LastUpdate,
                LastUser = t.LastUser,
                Location = t.Location,
                LocationId = t.LocationId,
                MTicketId = t.MTicketId,
                Phone = t.Phone,
                Priority = t.Priority,
                PrjId = t.PrjId,
                PrjName = t.PrjName,
                Problem = t.Problem,
                ProblemHeader = t.ProblemHeader,
                Product = t.Product,
                Reason = t.Reason,
                ReferenceNo = t.ReferenceNo,
                ReopenLevel = t.ReopenLevel,
                ReportBy = t.ReportBy,
                ReportDate = t.ReportDate,
                ReportedTime = t.ReportedTime,
                ReportHelpdeskBy = t.ReportHelpdeskBy,
                ReportTime = t.ReportTime,
                ReportVia = t.ReportVia,
                Resolution = t.Resolution,
                RevenueType = t.RevenueType,
                Sla = t.Sla,
                StartDate = t.StartDate,
                StartTime = t.StartTime,
                StatusTicket = t.StatusTicket,
                SubRevenueType = t.SubRevenueType,
                TicketId = t.TicketId,
                TimeDetail = t.TimeDetail,
                Urgency = t.Urgency,
                UserAccess = t.UserAccess,
                Warranty = t.Warranty,
                WBSNo = t.WBSNo,
                WorkingTime = t.WorkingTime,
                YearPurchase = t.YearPurchase
            };
            return tv;
        }

    }
}
