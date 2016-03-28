using Misi.Service.Billing.Model.Common;
using System;

namespace Misi.Service.Billing.Handler
{
    public abstract class RequestHandlerBase : IRequestHandler
    {
        public ServiceRequestDTO ServiceRequest { get; set; }
        public string RequestInfoId { get; set; }
        public UserAndRoleDTO User { get; set; }
        public string ServiceId { get; set; }
        public bool IsDraft { get; set; }
        public int Offset { get; set; }
        public int Limit { get; set; }

        public virtual long Count()
        {
            throw new NotImplementedException();
        }

        public virtual RequestInfoListItemsDTO RequestInfos()
        {
            throw new NotImplementedException();
        }

        public virtual RequestInfoListItemsDTO LimitedRequestInfos()
        {
            throw new NotImplementedException();
        }

        public virtual string New()
        {
            throw new NotImplementedException();
        }

        public virtual int? Save()
        {
            throw new NotImplementedException();
        }

        public virtual ServiceRequestDTO View()
        {
            throw new NotImplementedException();
        }

    }
}