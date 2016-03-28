using System.Collections.Generic;
using Misi.DAL.Billing.Model.Contract;
using Misi.DAL.Billing.Model.Request;
using Misi.DAL.Billing.Model.RequestInfo;
using Misi.DAL.Billing.Model.RoutingInfo;
using Misi.Common.Lib.Util;
using Misi.Service.Billing.Model.ErrorCharges;

namespace Misi.Service.Billing.Handler.ErrorCharges
{
    public class ErrorChargesHelper : RequestHandlerHelper
    {
        private static volatile ErrorChargesHelper _errorChargesHelper;
        private static readonly object SyncRoot = new object();

        public static ErrorChargesHelper Instance
        {
            get
            {
                if (_errorChargesHelper != null) return _errorChargesHelper;
                lock (SyncRoot)
                {
                    if (_errorChargesHelper == null)
                        _errorChargesHelper = new ErrorChargesHelper();
                }
                return _errorChargesHelper;
            }
        }

        /******************************************************************************************
         * From domain model to value object
         ******************************************************************************************/
        public ErrorChargesRequestDTO ToRequestDTO(ErrorChargesRequest o)
        {
            var vo = new ErrorChargesRequestDTO();
            ClassCopier.Instance.Copy(o, vo);
            if (o.RequestInfo != null)
                vo.RequestInfo = ToRequestInfoDTO(o.RequestInfo);
            if (o.Routing != null)
                vo.Routing = ToRoutingInfoDTO(o.Routing);
            return vo;
        }

        public ErrorChargesRequestInfoDTO ToRequestInfoDTO(ErrorChargesRequestInfo o)
        {
            var vo = new ErrorChargesRequestInfoDTO();
            ClassCopier.Instance.Copy(o, vo);
            return vo;
        }

        public ErrorChargesRoutingInfoDTO ToRoutingInfoDTO(ErrorChargesRoutingInfo o)
        {
            var vo = new ErrorChargesRoutingInfoDTO();
            ClassCopier.Instance.Copy(o, vo);

            if (o.Routings.Count > 0)
                vo.Routings = ToRoutingsDTO(o.Routings);
            if (o.Contracts.Count > 0)
                vo.Contracts = ToContractsVo(o.Contracts);
            return vo;
        }

        public List<ContractWithBillingsDTO> ToContractsVo(IEnumerable<ContractWithBillings> list)
        {
            var vos = new List<ContractWithBillingsDTO>();
            foreach (var o in list)
            {
                var vo = new ContractWithBillingsDTO();
                ClassCopier.Instance.Copy(o, vo);

                if (o.Billings.Count > 0)
                    vo.Billings = ToBillingsDTO(o.Billings);

                vos.Add(vo);
            }
            return vos;
        }

        public List<ContractBillingDTO> ToBillingsDTO(List<ContractBilling> list)
        {
            var vos = new List<ContractBillingDTO>();
            foreach (var o in list)
            {
                var vo = new ContractBillingDTO();
                ClassCopier.Instance.Copy(o, vo);
                vos.Add(vo);
            }
            return vos;
        }

        /******************************************************************************************
         * From value object to domain model
         ******************************************************************************************/
        public ErrorChargesRequest ToRequest(ErrorChargesRequestDTO vo)
        {
            var o = new ErrorChargesRequest();
            ClassCopier.Instance.Copy(vo, o);

            if (vo.RequestInfo != null)
                o.RequestInfo = ToRequestInfo(vo.RequestInfo);
            if (vo.Routing != null)
                o.Routing = ToRoutingInfo(vo.Routing);

            return o;
        }

        public ErrorChargesRequestInfo ToRequestInfo(ErrorChargesRequestInfoDTO vo)
        {
            var o = new ErrorChargesRequestInfo();
            ClassCopier.Instance.Copy(vo, o);
            return o;
        }

        public ErrorChargesRoutingInfo ToRoutingInfo(ErrorChargesRoutingInfoDTO vo)
        {
            var o = new ErrorChargesRoutingInfo();
            ClassCopier.Instance.Copy(vo, o);

            if (vo.Routings.Count > 0)
                o.Routings = ToRoutings(vo.Routings);
            if (vo.Contracts.Count > 0)
                o.Contracts = ToContracts(vo.Contracts);

            return o;
        }

        public List<ContractWithBillings> ToContracts(List<ContractWithBillingsDTO> list)
        {
            var os = new List<ContractWithBillings>();
            foreach (var vo in list)
            {
                var o = new ContractWithBillings();
                ClassCopier.Instance.Copy(vo, o);

                if (vo.Billings.Count > 0)
                    o.Billings = ToBillings(vo.Billings);

                os.Add(o);
            }
            return os;
        }

        public List<ContractBilling> ToBillings(List<ContractBillingDTO> list)
        {
            var os = new List<ContractBilling>();
            foreach (var vo in list)
            {
                var o = new ContractBilling();
                ClassCopier.Instance.Copy(vo, o);
                os.Add(o);
            }
            return os;
        }
    }
}