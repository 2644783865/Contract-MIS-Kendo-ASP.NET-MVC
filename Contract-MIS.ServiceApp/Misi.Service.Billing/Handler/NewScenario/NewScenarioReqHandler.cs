using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Misi.DAL.Billing.DaoUtil;
using Misi.Service.Billing.Model.Common;
using Misi.Service.Billing.Model.NewScenario;
using Misi.DAL.Billing.Model.Object;

namespace Misi.Service.Billing.Handler.NewScenario
{
    public class NewScenarioReqHandler : RequestHandlerBase
    {
        private readonly IndexDAO _indexDao = new IndexDAO();
        private readonly NewScenarioDAO _newScenarioDAO = new NewScenarioDAO();

        public override string New()
        {
            
            var dummy = new NewScenarioDummyData();
            var req = dummy.GetDummyData();
            /*
            var req = new NewScenarioRequestDTO
            {
                Id = _indexDao.NewServiceRequestId(),
                IssuedBy = "Sales Admin",
                IssuedDate = DateTime.Now,
                Scenario = EScenario.NEW_SCENARIO,
                State = EServiceRequestState.DRAFT
            };
            */
            _newScenarioDAO.Create(NewScenarioHelper.Instance.ToRequest(req));
            return req.Id;
        }

        public override int? Save()
        {
            return 0;
        }

        public override ServiceRequestDTO View()
        {
            var req = _newScenarioDAO.Select(ServiceId, true);
            if (req != null)
            {
                return NewScenarioHelper.Instance.ToRequestDTO(req);
            }
            return null;
        }
    }

    internal class NewScenarioDummyData
    {
        private readonly IndexDAO _indexDao = new IndexDAO();

        public NewScenarioRequestDTO GetDummyData()
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

            var routings = new List<NewScenarioRoutingInfoDTO>
            {
                new NewScenarioRoutingInfoDTO
                {
                    Routings = workflow,
                    Contract = new NewScenarionContractDTO
                    {
                        Device = "Laptop",
                        DeviceSn = "343234",
                        EquipDesc = "Laptop Lenovo i3",
                        Equipment = "234324",
                    },
                    CreateDate = now,
                    CurrentStep = 1,
                    IdrWebNumber = "IDR-23432442",
                    RoutingMemo = "Tolong dong diurus segera!",
                    AttributeDescription = "Pleaseeee deeegh..."
                },
                new NewScenarioRoutingInfoDTO
                {
                    Routings = workflow,
                    Contract = new NewScenarionContractDTO
                    {
                        Device = "Desktop PC",
                        DeviceSn = "343234",
                        EquipDesc = "PC Jangkrik Bhineka",
                        Equipment = "234324",
                    },
                    CreateDate = now,
                    CurrentStep = 1,
                    IdrWebNumber = "IDR-5345435",
                    RoutingMemo = "Tolong dong diurus segera!",
                    AttributeDescription = "Pleaseeee deeegh..."
                }
            };

            var req = new NewScenarioRequestDTO
            {
                Id = _indexDao.NewServiceRequestId(),
                RequestInfo = new NewScenarioRequestInfoDTO()
                {
                    Id = _indexDao.NewRequestInfoId(),
                    Company = "PT. Gulung Tikar",
                    Email = "gulung@email.com",
                    Location = "Mbantul Yogya",
                    RequestMemo = "Rek sak karepmu",
                    RequestedBy = "Arek Malang",
                    RequestedDate = now,
                    RequestedVia = "Yahoo Messenger",
                    SnOrIdNumber = "SN-34534534"
                },
                IssuedBy = "Sales Admin",
                IssuedDate = DateTime.Now,
                Scenario = EScenario.NEW_SCENARIO,
                State = EServiceRequestState.DRAFT,
                Routings = routings
            };
            return req;
        }
    }
}