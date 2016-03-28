using System;
using System.Collections.Generic;
using Misi.DAL.Billing.DaoUtil;
using Misi.DAL.Billing.Model.Object;
using Misi.Service.Billing.HelpdeskConnectorService;
using Misi.Service.Billing.Model.Common;
using Misi.Service.Billing.Model.TransferAsset;

namespace Misi.Service.Billing.Handler.TransferAsset
{
    public class TransferAssetReqHandler : RequestHandlerBase
    {
        private readonly IndexDAO _indexDao = new IndexDAO();
        private readonly TransferAssetDAO _transferAssetDAO = new TransferAssetDAO();

        public override long Count()
        {
            var hdesk = new HelpdeskServClient(Properties.Settings.Default.HelpdeskRefUrl);
            return hdesk.TotalTickets();
        }

        public override RequestInfoListItemsDTO RequestInfos()
        {
            var reqInfos = new RequestInfoListItemsDTO();
            var hdesk = new HelpdeskServClient(Properties.Settings.Default.HelpdeskRefUrl);
            var tickets = hdesk.SelectAllTickets();
            foreach (var t in tickets.Collection)
            {
                reqInfos.List.Add(new RequestInfoListItemDTO
                {
                    Company = t.Company,
                    Id = t.TicketId,
                    RequestMemo = t.Problem,
                    RequestedBy = t.ReportBy,
                    RequestedDate = DateTime.ParseExact(t.ReportDate, Properties.Settings.Default.HelpdeskDateFormat, System.Globalization.CultureInfo.InvariantCulture)
                });
            }
            return reqInfos;
        }

        public override RequestInfoListItemsDTO LimitedRequestInfos()
        {
            var reqInfos = new RequestInfoListItemsDTO();
            var hdesk = new HelpdeskServClient(Properties.Settings.Default.HelpdeskRefUrl);
            var tickets = hdesk.SelectLimitedTickets(Offset, Limit);
            foreach (var t in tickets.Collection)
            {
                reqInfos.List.Add(new RequestInfoListItemDTO
                {
                    Company = t.Company,
                    Id = t.TicketId,
                    RequestMemo = t.Problem,
                    RequestedBy = t.ReportBy,
                    RequestedDate = DateTime.ParseExact(t.ReportDate, Properties.Settings.Default.HelpdeskDateFormat, System.Globalization.CultureInfo.InvariantCulture)
                });
            }
            return reqInfos;
        }

        public override string New()
        {
            var hdesk = new HelpdeskServClient(Properties.Settings.Default.HelpdeskRefUrl);
            var t = hdesk.SelectTicket(RequestInfoId);
            /*
            var dummy = new TransferAssetDummyData();
            var req = dummy.GetDummyData(t);
            */
            var req = new TransferAssetRequestDTO
            {
                Id = _indexDao.NewServiceRequestId(),
                RequestInfo = new TransferAssetRequestInfoDTO
                {
                    Company = t.Company,
                    DetailCategory = t.DetailCategory,
                    Email = t.Email,
                    Id = RequestInfoId,
                    Location = t.Location,
                    RequestMemo = t.Problem,
                    RequestedBy = t.ReportBy,
                    RequestedDate = DateTime.ParseExact(t.ReportDate, Properties.Settings.Default.HelpdeskDateFormat, System.Globalization.CultureInfo.InvariantCulture),
                    RequestedVia = t.ReportVia,
                    SnOrIdNumber = t.IdNumber,
                    TicketCategory = t.Category
                },
                IssuedBy = "Helpdesk",
                IssuedDate = DateTime.Now,
                Scenario = EScenario.TRANSFER_ASSET,
                State = EServiceRequestState.DRAFT,
            };
            
            _transferAssetDAO.Create(TransferAssetHelper.Instance.ToRequest(req));
            return req.Id;
        }

        public override int? Save()
        {
            var req = ServiceRequest as TransferAssetRequestDTO;
            return _transferAssetDAO.Update(TransferAssetHelper.Instance.ToRequest(req));
        }

        public override ServiceRequestDTO View()
        {
            var req = _transferAssetDAO.Select(ServiceId, true);
            if (req != null)
            {
                return TransferAssetHelper.Instance.ToRequestDTO(req);
            }
            return null;
        }
    }

    internal class TransferAssetDummyData
    {
        private readonly IndexDAO _indexDao = new IndexDAO();

        public TransferAssetRequestDTO GetDummyData(TicketVo t)
        {
            var workflow = new List<RoutingItemDTO>
            {
                new RoutingItemDTO
                {
                    ActualDate = DateTime.Now,
                    BaseDate = DateTime.Now,
                    Division = "Warehouse",
                    DivisionStatus = false,
                    Instruction = "Fixed the information please!",
                    PlanDate = DateTime.Now,
                    Response = "Muke gile...",
                    RoutingStatus = ERoutingStatus.IN_PROGRESS,
                    SaStatus = false,
                    Step = 1
                },
                new RoutingItemDTO
                {
                    ActualDate = DateTime.Now,
                    BaseDate = DateTime.Now,
                    Division = "Sales Admin",
                    DivisionStatus = false,
                    Instruction = "Fixed the information please!",
                    PlanDate = DateTime.Now,
                    Response = "Muke gile juga!",
                    RoutingStatus = ERoutingStatus.IN_PROGRESS,
                    SaStatus = false,
                    Step = 2
                }
            };

            var routings = new List<TransferAssetRoutingInfoDTO>();
            var rbh = new TransferAssetByHolderRoutingInfoDTO
            {
                CreateDate = DateTime.Now,
                CurrentStep = 1,
                IdrWebNumber = "123456",
                NewContract = new TransferAssetNewContractDTO
                {
                    DeliveryOrderToUser = "1234567890",
                    Device = "Laptop",
                    DeviceSn = "343234",
                    EquipDesc = "Laptop Lenovo i3",
                    Equipment = "234324",
                    NewHolderName = "Bromo Kunto Adji",
                    NewLineNumber = "32",
                    NewLocation = "Jakarta",
                    NewNumber = "NEW-54534534",
                    NewSalaryNumber = "SAL-2234324",
                    ReturnDeliveryNumber = "RET-2343224",
                    SoDeliveryNumber = "SOD-2342344"
                },
                OldContract = new TransferAssetOldContractDTO
                {
                    Device = "Laptop",
                    DeviceSn = "343234",
                    EquipDesc = "Laptop Lenovo i3",
                    Equipment = "234324",
                    OldHolderName = "Indra Birowo",
                    OldLineNumber = "32",
                    OldLocation = "Jakarta",
                    OldNumber = "OLD-54534534",
                    OldSalaryNumber = "SAL-4323423",
                },
                RoutingMemo = "Please dikerjakan semua ya!",
                Routings = workflow,
                SubScenario = ESubScenario.BY_HOLDER_NAME
            };
            routings.Add(rbh);

            var rbl = new TransferAssetByLocationRoutingInfoDTO
            {
                CreateDate = DateTime.Now,
                CurrentStep = 1,
                IdrWebNumber = "123456",
                UpdContract = new TransferAssetUpdatedContractDTO
                {
                    Device = "Laptop",
                    DeviceSn = "343234",
                    EquipDesc = "Laptop Lenovo i3",
                    Equipment = "234324",
                    OldHolderName = "Indra Birowo",
                    OldLineNumber = "32",
                    OldLocation = "Jakarta",
                    OldNumber = "OLD-54534534",
                    OldSalaryNumber = "SAL-4323423",
                    UpdLocation = "Bangka Belitung"
                },
                OldContract = new TransferAssetOldContractDTO
                {
                    Device = "Laptop",
                    DeviceSn = "343234",
                    EquipDesc = "Laptop Lenovo i3",
                    Equipment = "234324",
                    OldHolderName = "Indra Birowo",
                    OldLineNumber = "32",
                    OldLocation = "Jakarta",
                    OldNumber = "OLD-54534534",
                    OldSalaryNumber = "SAL-4323423",
                },
                RoutingMemo = "Please dikerjakan semua ya!",
                Routings = workflow,
                SubScenario = ESubScenario.BY_HOLDER_NAME
            };
            routings.Add(rbl);

            var req = new TransferAssetRequestDTO
            {
                Id = _indexDao.NewServiceRequestId(),
                RequestInfo = new TransferAssetRequestInfoDTO
                {
                    Company = t.Company,
                    DetailCategory = t.DetailCategory,
                    Email = t.Email,
                    Id = t.IdNumber,
                    Location = t.Location,
                    RequestMemo = t.Problem,
                    RequestedBy = t.ReportBy,
                    RequestedDate = DateTime.ParseExact(t.ReportDate, Properties.Settings.Default.HelpdeskDateFormat, System.Globalization.CultureInfo.InvariantCulture),
                    RequestedVia = t.ReportVia,
                    SnOrIdNumber = t.IdNumber,
                    TicketCategory = t.Category
                },
                IssuedBy = "Helpdesk",
                IssuedDate = DateTime.Now,
                Scenario = EScenario.TRANSFER_ASSET,
                State = EServiceRequestState.DRAFT,
                Routings = routings
            };
            return req;
        }
    }
}