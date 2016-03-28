using System;
using System.Collections.Generic;
using Misi.DAL.Billing.Model.Contract;
using Misi.DAL.Billing.Model.Request;
using Misi.DAL.Billing.Model.RequestInfo;
using Misi.DAL.Billing.Model.RoutingInfo;
using Misi.Common.Lib.Util;
using Misi.Service.Billing.Model.TransferAsset;

namespace Misi.Service.Billing.Handler.TransferAsset
{
    public class TransferAssetHelper : RequestHandlerHelper
    {
        private static volatile TransferAssetHelper _transferAssetHelper;
        private static readonly object SyncRoot = new object();

        public static TransferAssetHelper Instance
        {
            get
            {
                if (_transferAssetHelper != null) return _transferAssetHelper;
                lock (SyncRoot)
                {
                    if (_transferAssetHelper == null)
                        _transferAssetHelper = new TransferAssetHelper();
                }
                return _transferAssetHelper;
            }
        }

        /******************************************************************************************
         * From domain model to value object
         ******************************************************************************************/
        public TransferAssetRequestDTO ToRequestDTO(TransferAssetRequest o)
        {
            var vo = new TransferAssetRequestDTO();
            ClassCopier.Instance.Copy(o, vo);
            if (o.RequestInfo != null)
                vo.RequestInfo = ToRequestInfoDTO(o.RequestInfo);
            if (o.Routings.Count > 0)
                vo.Routings = ToRoutingInfosDTO(o.Routings);

            return vo;
        }

        public TransferAssetRequestInfoDTO ToRequestInfoDTO(TransferAssetRequestInfo o)
        {
            var vo = new TransferAssetRequestInfoDTO();
            ClassCopier.Instance.Copy(o, vo);
            return vo;
        }

        public List<TransferAssetRoutingInfoDTO> ToRoutingInfosDTO(IEnumerable<TransferAssetRoutingInfo> list)
        {
            var vos = new List<TransferAssetRoutingInfoDTO>();
            foreach (var o in list)
            {
                if (o.GetType() == typeof(TransferAssetByHolderRoutingInfo))
                {
                    var obj = o as TransferAssetByHolderRoutingInfo;
                    if (obj != null)
                    {
                        var vo = new TransferAssetByHolderRoutingInfoDTO();
                        ClassCopier.Instance.Copy(obj, vo);

                        if (obj.OldContract != null)
                            vo.OldContract = ToOldContractDTO(obj.OldContract);
                        if (obj.NewContract != null)
                            vo.NewContract = ToNewContractDTO(obj.NewContract);
                        if (obj.Routings.Count > 0)
                            vo.Routings = ToRoutingsDTO(obj.Routings);

                        vos.Add(vo);
                    }
                }
                else if (o.GetType() == typeof(TransferAssetByLocationRoutingInfo))
                {
                    var obj = o as TransferAssetByLocationRoutingInfo;
                    if (obj != null)
                    {
                        var vo = new TransferAssetByLocationRoutingInfoDTO();
                        ClassCopier.Instance.Copy(obj, vo);

                        if (obj.OldContract != null)
                            vo.OldContract = ToOldContractDTO(obj.OldContract);
                        if (obj.UpdContract != null)
                            vo.UpdContract = ToUpdatedContractDTO(obj.UpdContract);
                        if (obj.Routings.Count > 0)
                            vo.Routings = ToRoutingsDTO(obj.Routings);

                        vos.Add(vo);
                    }
                }
                else
                {
                    throw new Exception(Properties.Settings.Default.WrongDataType);
                }
            }
            return vos;
        }

        public TransferAssetUpdatedContractDTO ToUpdatedContractDTO(TransferAssetUpdatedContract o)
        {
            var vo = new TransferAssetUpdatedContractDTO();
            ClassCopier.Instance.Copy(o, vo);
            return vo;
        }

        public TransferAssetNewContractDTO ToNewContractDTO(TransferAssetNewContract o)
        {
            var vo = new TransferAssetNewContractDTO();
            ClassCopier.Instance.Copy(o, vo);
            return vo;
        }

        public TransferAssetOldContractDTO ToOldContractDTO(TransferAssetOldContract o)
        {
            var vo = new TransferAssetOldContractDTO();
            ClassCopier.Instance.Copy(o, vo);
            return vo;
        }

        /******************************************************************************************
         * From value object to domain model
         ******************************************************************************************/
        public TransferAssetRequest ToRequest(TransferAssetRequestDTO vo)
        {
            var o = new TransferAssetRequest();
            ClassCopier.Instance.Copy(vo, o);

            if (vo.RequestInfo != null)
                o.RequestInfo = ToRequestInfo(vo.RequestInfo);
            if (vo.Routings.Count > 0)
                o.Routings = ToRoutingInfos(vo.Routings);

            return o;
        }

        public TransferAssetRequestInfo ToRequestInfo(TransferAssetRequestInfoDTO vo)
        {
            var o = new TransferAssetRequestInfo();
            ClassCopier.Instance.Copy(vo, o);
            return o;
        }

        public List<TransferAssetRoutingInfo> ToRoutingInfos(List<TransferAssetRoutingInfoDTO> list)
        {
            System.Diagnostics.Debug.WriteLine(">>>>>>>>>> MASUK KE CONVERT TO ROUTINGS......");
            var vos = new List<TransferAssetRoutingInfo>();
            foreach (var vo in list)
            {
                if (vo.GetType() == typeof(TransferAssetByHolderRoutingInfoDTO))
                {
                    var vobj = vo as TransferAssetByHolderRoutingInfoDTO;
                    if (vobj != null)
                    {
                        var o = new TransferAssetByHolderRoutingInfo();
                        ClassCopier.Instance.Copy(vobj, o);

                        if (vobj.OldContract != null)
                            o.OldContract = ToOldContract(vobj.OldContract);
                        if (vobj.NewContract != null)
                            o.NewContract = ToNewContract(vobj.NewContract);
                        if (vobj.Routings.Count > 0)
                            o.Routings = ToRoutings(vobj.Routings);

                        vos.Add(o);
                    }
                }
                else if (vo.GetType() == typeof(TransferAssetByLocationRoutingInfoDTO))
                {
                    var vobj = vo as TransferAssetByLocationRoutingInfoDTO;
                    if (vobj != null)
                    {
                        var o = new TransferAssetByLocationRoutingInfo();
                        ClassCopier.Instance.Copy(vobj, o);

                        if (vobj.OldContract != null)
                            o.OldContract = ToOldContract(vobj.OldContract);
                        if (vobj.UpdContract != null)
                            o.UpdContract = ToUpdatedContract(vobj.UpdContract);
                        if (vobj.Routings.Count > 0)
                            o.Routings = ToRoutings(vobj.Routings);

                        vos.Add(o);
                    }
                }
                else
                {
                    throw new Exception(Properties.Settings.Default.WrongDataType);
                }
            }
            return vos;
        }

        public TransferAssetOldContract ToOldContract(TransferAssetOldContractDTO vo)
        {
            var o = new TransferAssetOldContract();
            ClassCopier.Instance.Copy(vo, o);
            return o;
        }

        public TransferAssetUpdatedContract ToUpdatedContract(TransferAssetUpdatedContractDTO vo)
        {
            var o = new TransferAssetUpdatedContract();
            ClassCopier.Instance.Copy(vo, o);
            return o;
        }

        public TransferAssetNewContract ToNewContract(TransferAssetNewContractDTO vo)
        {
            var o = new TransferAssetNewContract();
            ClassCopier.Instance.Copy(vo, o);
            return o;
        }

    }
}