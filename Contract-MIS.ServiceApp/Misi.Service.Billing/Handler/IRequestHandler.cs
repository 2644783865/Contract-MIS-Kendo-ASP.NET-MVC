using Misi.Service.Billing.Model.Common;

namespace Misi.Service.Billing.Handler
{
    public interface IRequestHandler
    {
        long Count();
        RequestInfoListItemsDTO RequestInfos();
        RequestInfoListItemsDTO LimitedRequestInfos();

        string New();
        int? Save();
        ServiceRequestDTO View();
    }
}
