using System.Collections.Generic;
using Misi.DAL.Billing.Model.Contract;
using Misi.DAL.Billing.Model.Request;
using Misi.DAL.Billing.Model.RequestInfo;
using Misi.DAL.Billing.Model.RoutingInfo;
using Misi.Common.Lib.Util;
using Misi.Service.Billing.Model.NewContract;

namespace Misi.Service.Billing.Handler.NewContract
{
    public class NewContractHelper : RequestHandlerHelper
    {
        private static volatile NewContractHelper _newContractHelper;
        private static readonly object SyncRoot = new object();

        public static NewContractHelper Instance
        {
            get
            {
                if (_newContractHelper != null) return _newContractHelper;
                lock (SyncRoot)
                {
                    if (_newContractHelper == null)
                        _newContractHelper = new NewContractHelper();
                }
                return _newContractHelper;
            }
        }

        /******************************************************************************************
         * From domain model to value object
         ******************************************************************************************/
        public NewContractRequestDTO ToRequestDTO(NewContractRequest o)
        {
            var vo = new NewContractRequestDTO();
            ClassCopier.Instance.Copy(o, vo);

            if (o.RequestInfo != null)
                vo.RequestInfo = ToRequestInfoDTO(o.RequestInfo);
            if (o.Routings.Count > 0)
                vo.Routings = ToRoutingInfosDTO(o.Routings);
            return vo;
        }

        public NewContractRequestInfoDTO ToRequestInfoDTO(NewContractRequestInfo o)
        {
            var vo = new NewContractRequestInfoDTO();
            ClassCopier.Instance.Copy(o, vo);
            return vo;
        }

        public List<NewContractRoutingInfoBaseDTO> ToRoutingInfosDTO(IEnumerable<NewContractRoutingInfoBase> list)
        {
            var vos = new List<NewContractRoutingInfoBaseDTO>();
            foreach (var ri in list)
            {
                NewContractRoutingInfoBaseDTO vo = null;
                if (ri.GetType() == typeof (NewContractLaptopRoutingInfo))
                {
                    var ri1 = ri as NewContractLaptopRoutingInfo;
                    if (ri1 != null)
                    {
                        vo = new NewContractLaptopRoutingInfoDTO();
                        ClassCopier.Instance.Copy(ri1, vo);

                        if (ri1.Routings.Count > 0)
                            vo.Routings = ToRoutingsDTO(ri1.Routings);
                        if (ri1.Contract != null)
                            ((NewContractLaptopRoutingInfoDTO)vo).Contract = ToNewContractLaptopContractDTO(ri1.Contract);
                    }
                }
                else if (ri.GetType() == typeof(NewContractSoftwareRoutingInfo))
                {
                    var ri1 = ri as NewContractSoftwareRoutingInfo;
                    if (ri1 != null)
                    {
                        vo = new NewContractSoftwareRoutingInfoDTO();
                        ClassCopier.Instance.Copy(ri1, vo);

                        if (ri1.Routings.Count > 0)
                            vo.Routings = ToRoutingsDTO(ri1.Routings);
                        if (ri1.Contract != null)
                            ((NewContractSoftwareRoutingInfoDTO)vo).Contract = ToNewContractSoftwareContractDTO(ri1.Contract);
                    }
                }
                else if (ri.GetType() == typeof(NewContractIpPhoneRoutingInfo))
                {
                    var ri1 = ri as NewContractIpPhoneRoutingInfo;
                    if (ri1 != null)
                    {
                        vo = new NewContractIpPhoneRoutingInfoDTO();
                        ClassCopier.Instance.Copy(ri1, vo);

                        if (ri1.Routings.Count > 0)
                            vo.Routings = ToRoutingsDTO(ri1.Routings);
                        if (ri1.Contract != null)
                            ((NewContractIpPhoneRoutingInfoDTO)vo).Contract = ToNewContractIpPhoneContractDTO(ri1.Contract);
                    }
                }
                else if (ri.GetType() == typeof(NewContractExtLineRoutingInfo))
                {
                    var ri1 = ri as NewContractExtLineRoutingInfo;
                    if (ri1 != null)
                    {
                        vo = new NewContractExtLineRoutingInfoDTO();
                        ClassCopier.Instance.Copy(ri1, vo);

                        if (ri1.Routings.Count > 0)
                            vo.Routings = ToRoutingsDTO(ri1.Routings);
                        if (ri1.Contract != null)
                            ((NewContractExtLineRoutingInfoDTO)vo).Contract = ToNewContractExtLineContractDTO(ri1.Contract);
                    }
                }
                vos.Add(vo);
            }
            return vos;
        }

        public NewContractLaptopContractDTO ToNewContractLaptopContractDTO(NewContractLaptopContract o)
        {
            var vo = new NewContractLaptopContractDTO();
            ClassCopier.Instance.Copy(o, vo);
            return vo;
        }

        public NewContractSoftwareContractDTO ToNewContractSoftwareContractDTO(NewContractSoftwareContract o)
        {
            var vo = new NewContractSoftwareContractDTO();
            ClassCopier.Instance.Copy(o, vo);
            return vo;
        }

        public NewContractIpPhoneContractDTO ToNewContractIpPhoneContractDTO(NewContractIpPhoneContract o)
        {
            var vo = new NewContractIpPhoneContractDTO();
            ClassCopier.Instance.Copy(o, vo);
            return vo;
        }

        public NewContractExtLineContractDTO ToNewContractExtLineContractDTO(NewContractExtLineContract o)
        {
            var vo = new NewContractExtLineContractDTO();
            ClassCopier.Instance.Copy(o, vo);
            return vo;
        }

        /******************************************************************************************
         * From value object to domain model
         ******************************************************************************************/
        public NewContractRequest ToRequest(NewContractRequestDTO vo)
        {
            var o = new NewContractRequest();
            ClassCopier.Instance.Copy(vo, o);

            if (vo.RequestInfo != null)
                o.RequestInfo = ToRequestInfo(vo.RequestInfo);
            if (vo.Routings.Count > 0)
                o.Routings = ToRoutingInfos(vo.Routings);
            return o;
        }

        public NewContractRequestInfo ToRequestInfo(NewContractRequestInfoDTO vo)
        {
            var o = new NewContractRequestInfo();
            ClassCopier.Instance.Copy(vo, o);
            return o;
        }

        public List<NewContractRoutingInfoBase> ToRoutingInfos(IEnumerable<NewContractRoutingInfoBaseDTO> list)
        {
            var os = new List<NewContractRoutingInfoBase>();
            foreach (var ri in list)
            {
                NewContractRoutingInfoBase o = null;
                if (ri.GetType() == typeof (NewContractLaptopRoutingInfoDTO))
                {
                    var ri1 = ri as NewContractLaptopRoutingInfoDTO;
                    if (ri1 != null)
                    {
                        o = new NewContractLaptopRoutingInfo();
                        ClassCopier.Instance.Copy(ri1, o);

                        if (ri1.Routings.Count > 0)
                            o.Routings = ToRoutings(ri1.Routings);
                        if (ri1.Contract != null)
                            ((NewContractLaptopRoutingInfo)o).Contract = ToNewContractLaptopContract(ri1.Contract);
                    }
                }
                else if (ri.GetType() == typeof(NewContractSoftwareRoutingInfoDTO))
                {
                    var ri1 = ri as NewContractSoftwareRoutingInfoDTO;
                    if (ri1 != null)
                    {
                        o = new NewContractSoftwareRoutingInfo();
                        ClassCopier.Instance.Copy(ri1, o);

                        if (ri1.Routings.Count > 0)
                            o.Routings = ToRoutings(ri1.Routings);
                        if (ri1.Contract != null)
                            ((NewContractSoftwareRoutingInfo)o).Contract = ToNewContractSoftwareContract(ri1.Contract);
                    }
                }
                else if (ri.GetType() == typeof(NewContractIpPhoneRoutingInfoDTO))
                {
                    var ri1 = ri as NewContractIpPhoneRoutingInfoDTO;
                    if (ri1 != null)
                    {
                        o = new NewContractIpPhoneRoutingInfo();
                        ClassCopier.Instance.Copy(ri1, o);

                        if (ri1.Routings.Count > 0)
                            o.Routings = ToRoutings(ri1.Routings);
                        if (ri1.Contract != null)
                            ((NewContractIpPhoneRoutingInfo)o).Contract = ToNewContractIpPhoneContract(ri1.Contract);
                    }
                }
                else if (ri.GetType() == typeof(NewContractExtLineRoutingInfoDTO))
                {
                    var ri1 = ri as NewContractExtLineRoutingInfoDTO;
                    if (ri1 != null)
                    {
                        o = new NewContractExtLineRoutingInfo();
                        ClassCopier.Instance.Copy(ri1, o);

                        if (ri1.Routings.Count > 0)
                            o.Routings = ToRoutings(ri1.Routings);
                        if (ri1.Contract != null)
                            ((NewContractExtLineRoutingInfo)o).Contract = ToNewContractExtLineContract(ri1.Contract);
                    }
                }
                os.Add(o);
            }
            return os;
        }

        public NewContractLaptopContract ToNewContractLaptopContract(NewContractLaptopContractDTO vo)
        {
            var o = new NewContractLaptopContract();
            ClassCopier.Instance.Copy(vo, o);
            return o;
        }

        public NewContractSoftwareContract ToNewContractSoftwareContract(NewContractSoftwareContractDTO vo)
        {
            var o = new NewContractSoftwareContract();
            ClassCopier.Instance.Copy(vo, o);
            return o;
        }

        public NewContractIpPhoneContract ToNewContractIpPhoneContract(NewContractIpPhoneContractDTO vo)
        {
            var o = new NewContractIpPhoneContract();
            ClassCopier.Instance.Copy(vo, o);
            return o;
        }

        public NewContractExtLineContract ToNewContractExtLineContract(NewContractExtLineContractDTO vo)
        {
            var o = new NewContractExtLineContract();
            ClassCopier.Instance.Copy(vo, o);
            return o;
        }
    }
}