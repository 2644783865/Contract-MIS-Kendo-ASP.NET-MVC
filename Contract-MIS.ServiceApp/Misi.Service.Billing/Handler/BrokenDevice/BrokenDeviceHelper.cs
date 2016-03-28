using Misi.DAL.Billing.Model.Contract;
using Misi.DAL.Billing.Model.Request;
using Misi.DAL.Billing.Model.RequestInfo;
using Misi.DAL.Billing.Model.RoutingInfo;
using Misi.Common.Lib.Util;
using Misi.Service.Billing.Model.BrokenDevice;

namespace Misi.Service.Billing.Handler.BrokenDevice
{
    public class BrokenDeviceHelper : RequestHandlerHelper
    {
        private static volatile BrokenDeviceHelper _brokenDeviceHelper;
        private static readonly object SyncRoot = new object();

        public static BrokenDeviceHelper Instance
        {
            get
            {
                if (_brokenDeviceHelper != null) return _brokenDeviceHelper;
                lock (SyncRoot)
                {
                    if (_brokenDeviceHelper == null)
                        _brokenDeviceHelper = new BrokenDeviceHelper();
                }
                return _brokenDeviceHelper;
            }
        }

        /******************************************************************************************
         * From domain model to value object
         ******************************************************************************************/
        public BrokenDeviceRequestDTO ToRequestDTO(BrokenDeviceRequest o)
        {
            var vo = new BrokenDeviceRequestDTO();
            ClassCopier.Instance.Copy(o, vo);

            if (o.RequestInfo != null)
                vo.RequestInfo = ToRequestInfoDTO(o.RequestInfo);
            if (o.Routing != null)
                vo.Routing = ToRoutingInfoDTO(o.Routing);
            return vo;
        }

        public BrokenDeviceRequestInfoDTO ToRequestInfoDTO(BrokenDeviceRequestInfo o)
        {
            var vo = new BrokenDeviceRequestInfoDTO();
            ClassCopier.Instance.Copy(o, vo);
            return vo;
        }

        public BrokenDeviceRoutingInfoDTO ToRoutingInfoDTO(BrokenDeviceRoutingInfo o)
        {
            var vo = new BrokenDeviceRoutingInfoDTO();
            ClassCopier.Instance.Copy(o, vo);

            if (o.Contract != null)
                vo.Contract = ToContractDTO(o.Contract);
            if (o.Routings.Count > 0)
                vo.Routings = ToRoutingsDTO(o.Routings);
            return vo;
        }

        public BrokenDeviceContractDTO ToContractDTO(BrokenDeviceContract o)
        {
            var vo = new BrokenDeviceContractDTO();
            ClassCopier.Instance.Copy(o, vo);
            return vo;
        }

        /******************************************************************************************
         * From value object to domain model
         ******************************************************************************************/
        public BrokenDeviceRequest ToRequest(BrokenDeviceRequestDTO vo)
        {
            var o = new BrokenDeviceRequest();
            ClassCopier.Instance.Copy(vo, o);

            if (vo.RequestInfo != null)
                o.RequestInfo = ToRequestInfo(vo.RequestInfo);
            if (vo.Routing != null)
                o.Routing = ToRoutingInfo(vo.Routing);
            return o;
        }

        private BrokenDeviceRequestInfo ToRequestInfo(BrokenDeviceRequestInfoDTO vo)
        {
            var o = new BrokenDeviceRequestInfo();
            ClassCopier.Instance.Copy(vo, o);
            return o;
        }

        private BrokenDeviceRoutingInfo ToRoutingInfo(BrokenDeviceRoutingInfoDTO vo)
        {
            var o = new BrokenDeviceRoutingInfo();
            ClassCopier.Instance.Copy(vo, o);

            if (vo.Contract != null)
                o.Contract = ToContract(vo.Contract);
            if (vo.Routings.Count > 0)
                o.Routings = ToRoutings(vo.Routings);
            return o;
        }

        public BrokenDeviceContract ToContract(BrokenDeviceContractDTO vo)
        {
            var o = new BrokenDeviceContract();
            ClassCopier.Instance.Copy(vo, o);
            return o;
        }

    }
}