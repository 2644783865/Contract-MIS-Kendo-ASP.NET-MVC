using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Misi.Service.Billing.Model.Common
{
    [DataContract]
    public class RequestInfoListItemDTO
    {
        [DataMember]
        public string Id { get; set; }

        [DataMember]
        public string RequestedBy { get; set; }

        [DataMember]
        public DateTime RequestedDate { get; set; }

        [DataMember]
        public string RequestMemo { get; set; }

        [DataMember]
        public string Company { get; set; }
    }

    [DataContract]
    public class RequestInfoListItemsDTO
    {
        private List<RequestInfoListItemDTO> _list;

        [DataMember]
        public List<RequestInfoListItemDTO> List
        {
            get { return _list ?? (_list = new List<RequestInfoListItemDTO>()); }
            set { _list = value; }
        }
    }
}