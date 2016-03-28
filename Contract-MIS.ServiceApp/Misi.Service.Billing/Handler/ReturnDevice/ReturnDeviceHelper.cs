using System.Collections.Generic;
using Misi.DAL.Billing.Model.Contract;
using Misi.DAL.Billing.Model.Request;
using Misi.DAL.Billing.Model.RequestInfo;
using Misi.DAL.Billing.Model.RoutingInfo;
using Misi.Common.Lib.Util;
using Misi.Service.Billing.Model.ReturnDevice;

namespace Misi.Service.Billing.Handler.ReturnDevice
{
    public class ReturnDeviceHelper : RequestHandlerHelper
    {
        private static volatile ReturnDeviceHelper _returnDeviceHelper;
        private static readonly object SyncRoot = new object();

        public static ReturnDeviceHelper Instance
        {
            get
            {
                if (_returnDeviceHelper != null) return _returnDeviceHelper;
                lock (SyncRoot)
                {
                    if (_returnDeviceHelper == null)
                        _returnDeviceHelper = new ReturnDeviceHelper();
                }
                return _returnDeviceHelper;
            }
        }

        /******************************************************************************************
         * From domain model to value object
         ******************************************************************************************/
        public ReturnDeviceRequestDTO ToRequestDTO(ReturnDeviceRequest o)
        {
            var vo = new ReturnDeviceRequestDTO();
            ClassCopier.Instance.Copy(o, vo);

            if (o.RequestInfo != null)
                vo.RequestInfo = ToRequestInfoDTO(o.RequestInfo);
            if (o.Routings.Count > 0)
                vo.Routings = ToRoutingInfosDTO(o.Routings);

            return vo;
        }

        public ReturnDeviceRequestInfoDTO ToRequestInfoDTO(ReturnDeviceRequestInfo o)
        {
            var vo = new ReturnDeviceRequestInfoDTO();
            ClassCopier.Instance.Copy(o, vo);
            return vo;
        }

        public List<ReturnDeviceRoutingInfoDTO> ToRoutingInfosDTO(IEnumerable<ReturnDeviceRoutingInfo> list)
        {
            var vos = new List<ReturnDeviceRoutingInfoDTO>();
            foreach (var o in list)
            {
                var vo = new ReturnDeviceRoutingInfoDTO();
                ClassCopier.Instance.Copy(o, vo);

                if (o.Routings.Count > 0)
                    vo.Routings = ToRoutingsDTO(o.Routings);
                if (o.OldContract != null)
                    vo.OldContract = ToOldContractDTO(o.OldContract);
                if (o.UpdContract != null)
                    vo.UpdContract = ToUpdatedContractDTO(o.UpdContract);

                vos.Add(vo);
            }
            return vos;
        }

        public ReturnDeviceOldContractDTO ToOldContractDTO(ReturnDeviceOldContract o)
        {
            var vo = new ReturnDeviceOldContractDTO();
            ClassCopier.Instance.Copy(o, vo);
            return vo;
        }

        public ReturnDeviceUpdatedContractDTO ToUpdatedContractDTO(ReturnDeviceUpdatedContract o)
        {
            var vo = new ReturnDeviceUpdatedContractDTO();
            ClassCopier.Instance.Copy(o, vo);
            return vo;
        }

        /******************************************************************************************
         * From value object to domain model
         ******************************************************************************************/
        public ReturnDeviceRequest ToRequest(ReturnDeviceRequestDTO vo)
        {
            var o = new ReturnDeviceRequest();
            ClassCopier.Instance.Copy(vo, o);

            if (vo.RequestInfo != null)
                o.RequestInfo = ToRequestInfo(vo.RequestInfo);
            if (vo.Routings.Count > 0)
                o.Routings = ToRoutingInfos(vo.Routings);

            return o;
        }
        
        public ReturnDeviceRequestInfo ToRequestInfo(ReturnDeviceRequestInfoDTO vo)
        {
            var o = new ReturnDeviceRequestInfo();
            ClassCopier.Instance.Copy(vo, o);
            return o;
        }

        public List<ReturnDeviceRoutingInfo> ToRoutingInfos(IEnumerable<ReturnDeviceRoutingInfoDTO> list)
        {
            var vos = new List<ReturnDeviceRoutingInfo>();
            foreach (var vo in list)
            {
                var o = new ReturnDeviceRoutingInfo();
                ClassCopier.Instance.Copy(vo, o);

                if (vo.Routings.Count > 0)
                    o.Routings = ToRoutings(vo.Routings);
                if (vo.OldContract != null)
                    o.OldContract = ToOldContract(vo.OldContract);
                if (vo.UpdContract != null)
                    o.UpdContract = ToUpdatedContract(vo.UpdContract);

                vos.Add(o);
            }
            return vos;
        }
        public ReturnDeviceOldContract ToOldContract(ReturnDeviceOldContractDTO vo)
        {
            var o = new ReturnDeviceOldContract();
            ClassCopier.Instance.Copy(vo, o);
            return o;
        }

        public ReturnDeviceUpdatedContract ToUpdatedContract(ReturnDeviceUpdatedContractDTO vo)
        {
            var o = new ReturnDeviceUpdatedContract();
            ClassCopier.Instance.Copy(vo, o);
            return o;
        }

    }
}