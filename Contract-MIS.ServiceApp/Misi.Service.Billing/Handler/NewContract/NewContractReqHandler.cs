using System;
using System.Collections.Generic;
using Misi.DAL.Billing.DaoUtil;
using Misi.DAL.Billing.Model.Object;
using Misi.Service.Billing.Model.Common;
using Misi.Service.Billing.Model.NewContract;

namespace Misi.Service.Billing.Handler.NewContract
{
    public class NewContractReqHandler : RequestHandlerBase
    {
        private readonly IndexDAO _indexDao = new IndexDAO();
        private readonly NewContractDAO _newContractDAO = new NewContractDAO();

        public override string New()
        {
            
            var dummy = new NewContractDummyData();
            var req = dummy.GetDummyData();
            /*
            var req = new NewContractRequestDTO
            {
                Id = _indexDao.NewServiceRequestId(),
                IssuedBy = "Sales Admin",
                IssuedDate = DateTime.Now,
                Scenario = EScenario.NEW_CONTRACT,
                State = EServiceRequestState.DRAFT
            };
            */
            _newContractDAO.Create(NewContractHelper.Instance.ToRequest(req));
            return req.Id;
        }

        public override int? Save()
        {
            return 0;
        }

        public override ServiceRequestDTO View()
        {
            var req = _newContractDAO.Select(ServiceId, true);
            if (req != null)
            {
                return NewContractHelper.Instance.ToRequestDTO(req);
            }
            return null;
        }
    }

    internal class NewContractDummyData
    {
        private readonly IndexDAO _indexDao = new IndexDAO();

        public NewContractRequestDTO GetDummyData()
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

            var routings = new List<NewContractRoutingInfoBaseDTO>
            {
                new NewContractLaptopRoutingInfoDTO
                {
                    Contract = new NewContractLaptopContractDTO
                    {
                        AssetNumber = "AN-2343432",
                        CipNumber = "CIP-234324",
                        DeviceSn = "SN-23432432",
                        Device = "Laptop General",
                        DeliveryOrderToUser = "234324324",
                        EquipDesc = "Laptop General Bapuk",
                        Equipment = "E-2343242",
                        HolderName = "Randa Victor",
                        LineNumber = "23",
                        NotificationNumber = "NOT-23432432",
                        Number = "234324324",
                        QuotationNumber = "QUOT-234324",
                        SalaryNumber = "SAL-2343432",
                        SoDeliveryNumber = "SOD-34234234"
                    },
                    CreateDate = now,
                    CurrentStep = 1,
                    IdrWebNumber = "MX-12312312",
                    RoutingMemo = "Tolong diurusin",
                    Routings = workflow,
                    SubScenario = ESubScenario.LDP
                },
                new NewContractExtLineRoutingInfoDTO
                {
                    Contract = new NewContractExtLineContractDTO
                    {
                        ExtensionLineNumber = "2345",
                        HolderName = "Rommy Romoaldus",
                        LineNumber = "23",
                        Number = "123123",
                        QuotationNumber = "QU-324324234",
                        SalaryNumber = "SAL-24324324"
                    },
                    CreateDate = now,
                    CurrentStep = 1,
                    IdrWebNumber = "MX-12312312",
                    RoutingMemo = "Tolong diurusin",
                    Routings = workflow,
                    SubScenario = ESubScenario.EXT_LINE
                },
                new NewContractIpPhoneRoutingInfoDTO
                {
                    Contract = new NewContractIpPhoneContractDTO
                    {
                        AssetNumber = "AN-2343432",
                        CipNumber = "CIP-234324",
                        DeviceSn = "SN-23432432",
                        Device = "IP Phone Conference",
                        DeliveryOrderToUser = "234324324",
                        EquipDesc = "IP Phone and Extension Line",
                        Equipment = "E-2343242",
                        HolderName = "Randa Victor",
                        LineNumber = "23",
                        NotificationNumber = "NOT-23432432",
                        Number = "234324324",
                        QuotationNumber = "QUOT-234324",
                        SalaryNumber = "SAL-2343432",
                        SoDeliveryNumber = "SOD-34234234",
                        ExtensionLineNumber = "234"
                    },
                    CreateDate = now,
                    CurrentStep = 1,
                    IdrWebNumber = "MX-12312312",
                    RoutingMemo = "Tolong diurusin",
                    Routings = workflow,
                    SubScenario = ESubScenario.IP_PHONE
                },
                new NewContractSoftwareRoutingInfoDTO
                {
                    Contract = new NewContractSoftwareContractDTO
                    {
                        HolderName = "Rommy Romoaldus",
                        LineNumber = "23",
                        Number = "123123",
                        QuotationNumber = "QU-324324234",
                        SalaryNumber = "SAL-24324324",
                        ServiceDeliveryDate = "234324",
                        SoftwareType = "DBS ID"
                    },
                    CreateDate = now,
                    CurrentStep = 1,
                    IdrWebNumber = "MX-12312312",
                    RoutingMemo = "Tolong diurusin",
                    Routings = workflow,
                    SubScenario = ESubScenario.SOFTWARE,
                }
            };

            var req = new NewContractRequestDTO
            {
                Id = _indexDao.NewServiceRequestId(),
                IssuedBy = "Sales Admin",
                IssuedDate = now,
                RequestInfo = new NewContractRequestInfoDTO
                {
                    Company = "PT. Maju Kena Mundur Kena",
                    Id = _indexDao.NewRequestInfoId(),
                    Location = "Jakarta",
                    RequestMemo = "Harap kontrak - kontrak ini segera diproses",
                    RequestedBy = "Donan Febrianto",
                    RequestedDate = now,
                    SnOrIdNumber = "SN-324324242"
                },
                Routings = routings,
                Scenario = EScenario.NEW_CONTRACT,
                State = EServiceRequestState.DRAFT
            };
            return req;
        }
    }
}