using System;
using System.Collections.Generic;
using Misi.DAL.Billing.DaoUtil;
using Misi.DAL.Billing.Model.Object;
using Misi.Service.Billing.Model.BrokenDevice;
using Misi.Service.Billing.Model.Common;

namespace Misi.Service.Billing.Handler.BrokenDevice
{
    public class BrokenDeviceReqHandler : RequestHandlerBase
    {
        private readonly IndexDAO _indexDao = new IndexDAO();
        private readonly BrokenDeviceDAO _brokenDeviceDAO = new BrokenDeviceDAO();

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
            
            var dummy = new BrokenDeviceDummyData();
            var req = dummy.GetDummyData();
            /*
            var req = new BrokenDeviceRequestDTO
            {
                Id = _indexDao.NewServiceRequestId(),
                IssuedBy = "Workshop",
                IssuedDate = DateTime.Now,
                Scenario = EScenario.BROKEN_DEVICE,
                State = EServiceRequestState.DRAFT
            };
            */
            _brokenDeviceDAO.Create(BrokenDeviceHelper.Instance.ToRequest(req));
            return req.Id;
        }

        public override int? Save()
        {
            return 0;
        }

        public override ServiceRequestDTO View()
        {
            var req = _brokenDeviceDAO.Select(ServiceId, true);
            if (req != null)
                return BrokenDeviceHelper.Instance.ToRequestDTO(req);
            return null;
        }
    }

    internal class BrokenDeviceDummyData
    {
        private readonly IndexDAO _indexDao = new IndexDAO();

        public BrokenDeviceRequestDTO GetDummyData()
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
            var contract = new BrokenDeviceContractDTO
            {
                BackupEquipment = "BAK-234234324",
                Device = "DIV-2343242",
                DeviceSn = "SN-2423424",
                EquipDesc = "Laptop Bapuk",
                Equipment = "EQ-324234234",
                HolderName = "Mohammad Romdan",
                LineNumber = "23",
                Number = "234324",
                SalaryNumber = "SAL-346353"
            };
            var requestInfo = new BrokenDeviceRequestInfoDTO
            {
                Branch = "Mampang",
                Company = "PT. Trakindo",
                CustomerId = "CUS-234234",
                Id = _indexDao.NewRequestInfoId(),
                RequestMemo = "Segera diurus hinggga beres!",
                RequestedBy = "Bromo Kunto Adji",
                RequestedDate = now,
                SnOrIdNumber = "23432"
            };
            var routingInfo = new BrokenDeviceRoutingInfoDTO
            {
                CreateDate = now,
                CurrentStep = 1,
                IdrWebNumber = "IDRW-234324324",
                RoutingMemo = "Tolong diurus segera!",
                Routings = workflow,
                Contract = contract
            };
            var req = new BrokenDeviceRequestDTO
            {
                Id = _indexDao.NewServiceRequestId(),
                IssuedBy = "Workshop",
                IssuedDate = now,
                Scenario = EScenario.BROKEN_DEVICE,
                State = EServiceRequestState.DRAFT,
                RequestInfo = requestInfo,
                Routing = routingInfo
            };
            return req;
        }
    }
}