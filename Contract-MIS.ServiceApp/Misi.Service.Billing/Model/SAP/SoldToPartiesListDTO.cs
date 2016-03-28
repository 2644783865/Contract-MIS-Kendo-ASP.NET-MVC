using System.Collections.Generic;
using System.Runtime.Serialization;
using Misi.Service.Billing.Model.Common;

namespace Misi.Service.Billing.Model.SAP
{
    [DataContract]
    public class SoldToPartiesListDTO : SAPResponse
    {
        private List<KeyValueDTO> _list;

        [DataMember]
        public List<KeyValueDTO> List
        {
            get { return _list ?? (_list = new List<KeyValueDTO>()); }
            set { _list = value; }
        }
    }

}