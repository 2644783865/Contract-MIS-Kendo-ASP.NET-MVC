using System;
using System.Collections.Generic;
using Misi.DAL.Billing.DaoUtil;
using Misi.DAL.Billing.Model.Object;
using Misi.Service.Billing.Model.Common;
using Misi.Service.Billing.Model.ErrorCharges;

namespace Misi.Service.Billing.Handler.ErrorCharges
{
    public class ErrorChargesReqHandler : RequestHandlerBase
    {
        private readonly IndexDAO _indexDao = new IndexDAO();
        private readonly ErrorChargesDAO _errorChargesDAO = new ErrorChargesDAO();

        public override string New()
        {
            
            var dummy = new ErrorChargesDummyData();
            var req = dummy.GetDummyData();
            /*
            var req = new ErrorChargesRequestDTO
            {
                Id = _indexDao.NewServiceRequestId(),
                IssuedBy = "Sales Admin",
                IssuedDate = DateTime.Now,
                Scenario = EScenario.ERROR_CHARGES,
                State = EServiceRequestState.DRAFT
            };
            */
            _errorChargesDAO.Create(ErrorChargesHelper.Instance.ToRequest(req));
            return req.Id;
        }

        public override int? Save()
        {
            return 0;
        }

        public override ServiceRequestDTO View()
        {
            var req = _errorChargesDAO.Select(ServiceId, true);
            if (req != null)
            {
                return ErrorChargesHelper.Instance.ToRequestDTO(req);
            }
            return null;
        }
    }

    internal class ErrorChargesDummyData
    {
        private readonly IndexDAO _indexDao = new IndexDAO();

        public ErrorChargesRequestDTO GetDummyData()
        {
            var now = DateTime.Now;
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
                    Division = "Sales Admin",
                    DivisionStatus = false,
                    Instruction = "Fixed the information please!",
                    PlanDate = now,
                    Response = "Muke gile juga!",
                    RoutingStatus = ERoutingStatus.IN_PROGRESS,
                    SaStatus = false,
                    Step = 2
                }
            };

            var billings = new List<ContractBillingDTO>
            {
                new ContractBillingDTO
                {
                    Actual = 10000,
                    Charges = 20000,
                    Currency = "USD",
                    Deduction = 4000,
                    PlanDate = now,
                    SubItem = "30.1"
                },
                new ContractBillingDTO
                {
                    Actual = 20000,
                    Charges = 20000,
                    Currency = "USD",
                    Deduction = 3400,
                    PlanDate = now,
                    SubItem = "30.2"
                }
            };

            var req = new ErrorChargesRequestDTO
            {
                Id = _indexDao.NewServiceRequestId(),
                RequestInfo = new ErrorChargesRequestInfoDTO
                {
                    Id = _indexDao.NewRequestInfoId(),
                    Company = "PT. Klub Malam 1001",
                    Email = "klubmalam@pijetenak.com",
                    Location = "Mangga Besar",
                    RequestMemo = "Tolong agar semua kesalahan charges diganti!",
                    RequestedBy = "Dadan Germo",
                    RequestedDate = now,
                    RequestedVia = "Wassap",
                    SnOrIdNumber = "SN-32432424"
                },
                IssuedBy = "Sales Admin",
                IssuedDate = DateTime.Now,
                Scenario = EScenario.ERROR_CHARGES,
                State = EServiceRequestState.DRAFT,
                Routing = new ErrorChargesRoutingInfoDTO
                {
                    CreateDate = now,
                    CurrentStep = 1,
                    RoutingMemo = "Harap segera diselesaikan",
                    Routings = workflow,
                    SoldToParty = "PT. Klub Malam 1001",
                    Contracts = new List<ContractWithBillingsDTO>
                    {
                        new ContractWithBillingsDTO
                        {
                            Charges = 20000,
                            Currency = "IDR",
                            EndDate = now,
                            HolderName = "Dadan Germo",
                            ItemCategory = "MV4",
                            LineNumber = "34",
                            Material = "SIM-23432",
                            MaterialDesc = "Email Service",
                            MaterialPricing = "Software",
                            Number = "234324",
                            PoNumber = "345345",
                            PriceGroup = "TMT Price",
                            PurchaseOrder = "PO234324",
                            Quantity = 23,
                            ReasonForRjection = "Completion of Contract",
                            StartDate = now,
                            Unit = "Kg",
                            WbsElement = "234324",
                            Billings = billings
                        },
                        new ContractWithBillingsDTO
                        {
                            Charges = 3242442,
                            Currency = "USD",
                            EndDate = now,
                            HolderName = "Jimmy Jangkrek",
                            ItemCategory = "MVP4324",
                            LineNumber = "35",
                            Material = "SIM-23432",
                            MaterialDesc = "Phone Service",
                            MaterialPricing = "Hardware",
                            Number = "234324",
                            PoNumber = "345345",
                            PriceGroup = "TMT Price",
                            PurchaseOrder = "PO234324",
                            Quantity = 23,
                            ReasonForRjection = "Completion of Contract",
                            StartDate = now,
                            Unit = "Kg",
                            WbsElement = "234324",
                            Billings = billings
                        },
                    }
                }
            };
            return req;
        }
    }
}