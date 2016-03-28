using System;
using System.Collections.Generic;
using Misi.DAL.Billing.DaoUtil;
using Misi.DAL.Billing.Model.Object;
using Misi.Service.Billing.Model.Common;
using Misi.Service.Billing.Model.Termination;

namespace Misi.Service.Billing.Handler.Termination
{
    public class TerminationReqHandler : RequestHandlerBase
    {
        private readonly IndexDAO _indexDao = new IndexDAO();
        private readonly TerminationDAO _terminationDAO = new TerminationDAO();

        public override string New()
        {
            /*
            var dummy = new TerminationDummyData();
            var req = dummy.GetDummyData();
            */
            var req = new TerminationRequestDTO
            {
                Id = _indexDao.NewServiceRequestId(),
                IssuedBy = "Helpdesk",
                IssuedDate = DateTime.Now,
                Scenario = EScenario.TERMINATION,
                State = EServiceRequestState.DRAFT
            };
            
            _terminationDAO.Create(TerminationHelper.Instance.ToRequest(req));
            return req.Id;
        }

        public override int? Save()
        {
            return 0;
        }

        public override ServiceRequestDTO View()
        {
            var req = _terminationDAO.Select(ServiceId, true);
            if (req != null)
                return TerminationHelper.Instance.ToRequestDTO(req);
            return null;
        }
    }

    internal class TerminationDummyData
    {
        private readonly IndexDAO _indexDao = new IndexDAO();

        public TerminationRequestDTO GetDummyData()
        {
            var now = DateTime.Today;
            var workflow = new List<RoutingItemDTO>
                {
                    new RoutingItemDTO
                    {
                        ActualDate = now,
                        BaseDate = now,
                        Division = "Warehouse",
                        DivisionStatus = false,
                        Instruction = "Fixed the information please!",
                        PlanDate = now,
                        Response = "Muke gile...",
                        RoutingStatus = ERoutingStatus.IN_PROGRESS,
                        SaStatus = false,
                        Step = 1
                    },
                    new RoutingItemDTO
                    {
                        ActualDate = now,
                        BaseDate = now,
                        Division = "Workshop",
                        DivisionStatus = false,
                        Instruction = "Fixed the information please!",
                        PlanDate = now,
                        Response = "Muke gile...",
                        RoutingStatus = ERoutingStatus.IN_PROGRESS,
                        SaStatus = true,
                        Step = 1
                    }
                };

            var terminations = new List<TerminationItemDTO>
                {
                    new TerminationItemDTO
                    {
                        Application = "Email ID",
                        Branch = "Jakarta",
                        Company = "PT. Trakindo Utama",
                        ExtNumber = "1234",
                        HolderName = "Pandu Dhamar Langit",
                        RejectionReason = "Ngga ada alasan",
                        RequestedBy = "Bromo Kunto Adji",
                        RequestedDate = now,
                        SalaryNumber = "23432434",
                        Status = "Resign",
                        UserId = "bromokun"
                    },
                    new TerminationItemDTO
                    {
                        Application = "VPN ID",
                        Branch = "Jakarta",
                        Company = "PT. Trakindo Utama",
                        ExtNumber = "1234",
                        HolderName = "Gema Mahdi pamungkas",
                        RejectionReason = "Ngga ada alasan",
                        RequestedBy = "Yunia Maharani",
                        RequestedDate = now,
                        SalaryNumber = "234324",
                        Status = "Resign",
                        UserId = "pandudhamar",
                        TerminatedContract = new TerminatedContractDTO
                        {
                            Charges = 205000,
                            Currency = "IDR",
                            EndDate = now,
                            ItemCategory = "Condom",
                            LineNumber = "23",
                            Material = "Alat kontrasepsi",
                            MaterialDesc = "Condom 25",
                            MaterialPricing = "Koperasi",
                            Number = "324324232",
                            PoNumber = "PO-32432",
                            PriceGroup = "Klub 69",
                            PurchaseOrder = "PO-2343432",
                            Quantity = 20,
                            StartDate = now,
                            Unit = "Ton",
                            WbsElement = "WBS_232424234"
                        }
                    }
                };

            var requestInfo = new TerminationRequestInfoDTO
            {
                Id = _indexDao.NewRequestInfoId(),
                RequestMemo = "Tolong segera semua diterminasi",
                RequestedVia = "Email",
                Terminations = terminations
            };
            var routingInfo = new TerminationRoutingInfoDTO
            {
                CreateDate = DateTime.Now,
                CurrentStep = 1,
                RoutingMemo = "Tolong segera di terminasi",
                Routings = workflow,
                Terminations = terminations
            };
            var req = new TerminationRequestDTO
            {
                Id = _indexDao.NewServiceRequestId(),
                IssuedBy = "Helpdesk",
                IssuedDate = DateTime.Now,
                Scenario = EScenario.TERMINATION,
                State = EServiceRequestState.DRAFT,
                RequestInfo = requestInfo,
                Routing = routingInfo,
            };
            return req;
        }
    }
}