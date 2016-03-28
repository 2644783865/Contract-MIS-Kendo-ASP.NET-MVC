using System.Collections.Generic;
using Misi.DAL.Billing.Model;
using Misi.DAL.Billing.Model.Common;
using Misi.DAL.Billing.Model.Contract;
using Misi.DAL.Billing.Model.Request;
using Misi.DAL.Billing.Model.RequestInfo;
using Misi.DAL.Billing.Model.RoutingInfo;
using Misi.Common.Lib.Util;
using Misi.Service.Billing.Model.Termination;

namespace Misi.Service.Billing.Handler.Termination
{
    public class TerminationHelper : RequestHandlerHelper
    {
        private static volatile TerminationHelper _terminationHelper;
        private static readonly object SyncRoot = new object();

        public static TerminationHelper Instance
        {
            get
            {
                if (_terminationHelper != null) return _terminationHelper;
                lock (SyncRoot)
                {
                    if (_terminationHelper == null)
                        _terminationHelper = new TerminationHelper();
                }
                return _terminationHelper;
            }
        }

        /******************************************************************************************
         * From domain model to value object
         ******************************************************************************************/
        public TerminationRequestDTO ToRequestDTO(TerminationRequest o)
        {
            var vo = new TerminationRequestDTO();
            ClassCopier.Instance.Copy(o, vo);

            if (o.RequestInfo != null)
                vo.RequestInfo = ToRequestInfoDTO(o.RequestInfo);
            if (o.Routing != null)
                vo.Routing = ToRoutingInfoDTO(o.Routing);

            return vo;
        }

        private TerminationRequestInfoDTO ToRequestInfoDTO(TerminationRequestInfo o)
        {
            var vo = new TerminationRequestInfoDTO();
            ClassCopier.Instance.Copy(o, vo);

            if (o.Terminations != null && o.Terminations.Count > 0)
                vo.Terminations = ToTerminationsDTO(o.Terminations, false);
            return vo;
        }

        public List<TerminationItemDTO> ToTerminationsDTO(IEnumerable<TerminationItem> list, bool all)
        {
            var vos = new List<TerminationItemDTO>();
            foreach (var o in list)
            {
                var vo = new TerminationItemDTO();
                ClassCopier.Instance.Copy(o, vo);
                if (all)
                {
                    if (o.TerminatedContract != null)
                        vo.TerminatedContract = ToTerminatedContractDTO(o.TerminatedContract);
                    vo.RejectionReason = o.RejectionReason;
                }
                vos.Add(vo);
            }
            return vos;
        }

        public TerminatedContractDTO ToTerminatedContractDTO(TerminatedContract o)
        {
            var vo = new TerminatedContractDTO();
            ClassCopier.Instance.Copy(o, vo);
            return vo;
        }

        public TerminationRoutingInfoDTO ToRoutingInfoDTO(TerminationRoutingInfo o)
        {
            var vo = new TerminationRoutingInfoDTO();
            ClassCopier.Instance.Copy(o, vo);

            if (o.Routings.Count > 0)
                vo.Routings = ToRoutingsDTO(o.Routings);
            if (o.Terminations.Count > 0)
                vo.Terminations = ToTerminationsDTO(o.Terminations, true);
            return vo;
        }

        /******************************************************************************************
         * From value object to domain model
         ******************************************************************************************/
        public TerminationRequest ToRequest(TerminationRequestDTO vo)
        {
            var o = new TerminationRequest();
            ClassCopier.Instance.Copy(vo, o);

            if (vo.RequestInfo != null)
                o.RequestInfo = ToRequestInfo(vo.RequestInfo);
            if (vo.Routing != null)
                o.Routing = ToRoutingInfo(vo.Routing);

            return o;
        }

        public TerminationRequestInfo ToRequestInfo(TerminationRequestInfoDTO vo)
        {
            var o = new TerminationRequestInfo();
            ClassCopier.Instance.Copy(vo, o);

            if (vo.Terminations != null && vo.Terminations.Count > 0)
                o.Terminations = ToTerminations(vo.Terminations, false);

            return o;
        }

        public List<TerminationItem> ToTerminations(List<TerminationItemDTO> list, bool all)
        {
            var os = new List<TerminationItem>();
            foreach (var vo in list)
            {
                var o = new TerminationItem();
                ClassCopier.Instance.Copy(vo, o);

                if (all)
                {
                    if (vo.TerminatedContract != null)
                        o.TerminatedContract = ToTerminatedContract(vo.TerminatedContract);
                    o.RejectionReason = vo.RejectionReason;
                }
                os.Add(o);
            }
            return os;
        }

        public TerminatedContract ToTerminatedContract(TerminatedContractDTO vo)
        {
            var o = new TerminatedContract();
            ClassCopier.Instance.Copy(vo, o);
            return o;
        }

        public TerminationRoutingInfo ToRoutingInfo(TerminationRoutingInfoDTO o)
        {
            var vo = new TerminationRoutingInfo();
            ClassCopier.Instance.Copy(o, vo);

            if (o.Routings.Count > 0)
                vo.Routings = ToRoutings(o.Routings);
            if (o.Terminations.Count > 0)
                vo.Terminations = ToTerminations(o.Terminations, true);

            return vo;
        }
    }
}