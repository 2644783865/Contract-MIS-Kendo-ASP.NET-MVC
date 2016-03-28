using Misi.DAL.Billing.Model.Common;
using Misi.Common.Lib.Util;
using Misi.Service.Billing.Model.Common;
using System.Collections.Generic;

namespace Misi.Service.Billing.Handler
{
    public abstract class RequestHandlerHelper
    {
        protected List<RoutingItemDTO> ToRoutingsDTO(List<RoutingItem> list)
        {
            var vos = new List<RoutingItemDTO>();
            foreach (var o in list)
            {
                var vo = new RoutingItemDTO();
                ClassCopier.Instance.Copy(o, vo);
                vos.Add(vo);
            }
            return vos;
        }

        protected List<RoutingItem> ToRoutings(List<RoutingItemDTO> list)
        {
            var os = new List<RoutingItem>();
            foreach (var vo in list)
            {
                var o = new RoutingItem();
                ClassCopier.Instance.Copy(vo, o);
                os.Add(o);
            }
            return os;
        } 
    }
}
