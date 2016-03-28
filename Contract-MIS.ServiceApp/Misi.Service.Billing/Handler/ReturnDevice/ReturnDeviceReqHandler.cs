using System;
using System.Collections.Generic;
using Misi.DAL.Billing.DaoUtil;
using Misi.DAL.Billing.Model.Object;
using Misi.Service.Billing.Model.Common;
using Misi.Service.Billing.Model.ReturnDevice;

namespace Misi.Service.Billing.Handler.ReturnDevice
{
    public class ReturnDeviceReqHandler : RequestHandlerBase
    {
        private readonly IndexDAO _indexDao = new IndexDAO();
        private readonly ReturnDeviceDAO _returnDeviceDAO = new ReturnDeviceDAO();

        public override long Count()
        {
            return base.Count();
        }

        public override RequestInfoListItemsDTO RequestInfos()
        {
            return base.RequestInfos();
        }

        public override RequestInfoListItemsDTO LimitedRequestInfos()
        {
            return base.LimitedRequestInfos();
        }

        public override string New()
        {
            
            var dummy = new ReturnDeviceDummyData();
            var req = dummy.GetDummyData();
            /*
            var req = new ReturnDeviceRequestDTO
            {
                Id = _indexDao.NewServiceRequestId(),
                IssuedBy = "Warehouse",
                IssuedDate = DateTime.Now,
                Scenario = EScenario.RETURN_DEVICE,
                State = EServiceRequestState.DRAFT
            };
            */
            _returnDeviceDAO.Create(ReturnDeviceHelper.Instance.ToRequest(req));
            return req.Id;
        }

        public override int? Save()
        {
            return 0;
        }

        public override ServiceRequestDTO View()
        {
            var req = _returnDeviceDAO.Select(ServiceId, true);
            if (req != null)
            {
                return ReturnDeviceHelper.Instance.ToRequestDTO(req);
            }
            return null;
        }
    }

    internal class ReturnDeviceDummyData
    {
        private readonly IndexDAO _indexDao = new IndexDAO();

        public ReturnDeviceRequestDTO GetDummyData()
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

            var routings = new List<ReturnDeviceRoutingInfoDTO>
            {
                new ReturnDeviceRoutingInfoDTO
                {
                    Routings = workflow,
                    CreateDate = now,
                    CurrentStep = 1,
                    IdrWebNumber = "IDR-234234",
                    OldContract = new ReturnDeviceOldContractDTO
                    {
                        Device = "Laptop",
                        DeviceSn = "343234",
                        EquipDesc = "Laptop Lenovo i3",
                        Equipment = "234324",
                        OldHolderName = "Indra Birowo",
                        OldLineNumber = "32",
                        OldNumber = "OLD-54534534",
                        OldSalaryNumber = "SAL-4323423",
                    },
                    RoutingMemo = "Mohon segera diganti sama Laptop baru",
                    UpdContract = new ReturnDeviceUpdatedContractDTO
                    {
                        Device = "Laptop",
                        DeviceSn = "343234",
                        EquipDesc = "Laptop Lenovo i3",
                        Equipment = "234324",
                        OldHolderName = "Indra Birowo",
                        OldLineNumber = "32",
                        OldNumber = "OLD-54534534",
                        OldSalaryNumber = "SAL-4323423",
                        UpdLocation = "Tangerang",
                        ReturnDeliveryNumber = "RET-532424234"
                    }
                }
            };

            var req = new ReturnDeviceRequestDTO
            {
                Id = _indexDao.NewServiceRequestId(),
                RequestInfo = new ReturnDeviceRequestInfoDTO
                {
                    Company = "PT. Maju Mundur Wenak",
                    Email = "emailku@yourmail.com",
                    Location = "Jakarta",
                    Id = _indexDao.NewRequestInfoId(),
                    RequestMemo = "Tolong diganti dong Laptopnyeee!",
                    RequestedBy = "Donan Febrianto",
                    RequestedDate = now,
                    RequestedVia = "Wassap",
                    SnOrIdNumber = "SN-1221312"
                },
                IssuedBy = "Warehouse",
                IssuedDate = now,
                Scenario = EScenario.RETURN_DEVICE,
                State = EServiceRequestState.DRAFT,
                Routings = routings
            };
            return req;
        }
    }
}