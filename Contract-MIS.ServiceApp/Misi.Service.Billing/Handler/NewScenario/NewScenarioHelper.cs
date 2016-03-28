using System.Collections.Generic;
using Misi.DAL.Billing.Model.Contract;
using Misi.DAL.Billing.Model.Request;
using Misi.DAL.Billing.Model.RequestInfo;
using Misi.DAL.Billing.Model.RoutingInfo;
using Misi.Common.Lib.Util;
using Misi.Service.Billing.Model.NewScenario;

namespace Misi.Service.Billing.Handler.NewScenario
{
    public class NewScenarioHelper : RequestHandlerHelper
    {
        private static volatile NewScenarioHelper _newScenarioHelper;
        private static readonly object SyncRoot = new object();

        public static NewScenarioHelper Instance
        {
            get
            {
                if (_newScenarioHelper != null) return _newScenarioHelper;
                lock (SyncRoot)
                {
                    if (_newScenarioHelper == null)
                        _newScenarioHelper = new NewScenarioHelper();
                }
                return _newScenarioHelper;
            }
        }

        /******************************************************************************************
         * From domain model to value object
         ******************************************************************************************/
        public NewScenarioRequestDTO ToRequestDTO(NewScenarioRequest o)
        {
            var vo = new NewScenarioRequestDTO();
            ClassCopier.Instance.Copy(o, vo);

            if (o.RequestInfo != null)
                vo.RequestInfo = ToRequestInfoDTO(o.RequestInfo);
            if (o.Routings.Count > 0)
                vo.Routings = ToRoutingInfosDTO(o.Routings);

            return vo;
        }

        public NewScenarioRequestInfoDTO ToRequestInfoDTO(NewScenarioRequestInfo o)
        {
            var vo = new NewScenarioRequestInfoDTO();
            ClassCopier.Instance.Copy(o, vo);
            return vo;
        }

        public List<NewScenarioRoutingInfoDTO> ToRoutingInfosDTO(List<NewScenarioRoutingInfo> list)
        {
            var vos = new List<NewScenarioRoutingInfoDTO>();
            foreach (var o in list)
            {
                System.Diagnostics.Debug.WriteLine(">>>>> ITERASI .........");
                var vo = new NewScenarioRoutingInfoDTO();
                ClassCopier.Instance.Copy(o, vo);

                if (o.Routings.Count > 0)
                    vo.Routings = ToRoutingsDTO(o.Routings);
                if (o.Contract != null)
                    vo.Contract = ToContractDTO(o.Contract);

                vos.Add(vo);
            }
            return vos;
        }

        public NewScenarionContractDTO ToContractDTO(NewScenarioContract o)
        {
            var vo = new NewScenarionContractDTO();
            ClassCopier.Instance.Copy(o, vo);
            return vo;
        }

       
        /******************************************************************************************
         * From value object to domain model
         ******************************************************************************************/
        public NewScenarioRequest ToRequest(NewScenarioRequestDTO vo)
        {
            var o = new NewScenarioRequest();
            ClassCopier.Instance.Copy(vo, o);

            if (vo.RequestInfo != null)
                o.RequestInfo = ToRequestInfo(vo.RequestInfo);
            if (vo.Routings.Count > 0)
                o.Routings = ToRoutingInfos(vo.Routings);

            return o;
        }

        public NewScenarioRequestInfo ToRequestInfo(NewScenarioRequestInfoDTO vo)
        {
            var o = new NewScenarioRequestInfo();
            ClassCopier.Instance.Copy(vo, o);
            return o;
        }

        public List<NewScenarioRoutingInfo> ToRoutingInfos(List<NewScenarioRoutingInfoDTO> list)
        {
            var os = new List<NewScenarioRoutingInfo>();
            foreach (var vo in list)
            {
                var o = new NewScenarioRoutingInfo();
                ClassCopier.Instance.Copy(vo, o);

                if (vo.Routings.Count > 0)
                    o.Routings = ToRoutings(vo.Routings);
                if (vo.Contract != null)
                    o.Contract = ToContract(vo.Contract);

                os.Add(o);
            }
            return os;
        }

        public NewScenarioContract ToContract(NewScenarionContractDTO vo)
        {
            var o = new NewScenarioContract();
            ClassCopier.Instance.Copy(vo, o);
            return o;
        }
    }
}