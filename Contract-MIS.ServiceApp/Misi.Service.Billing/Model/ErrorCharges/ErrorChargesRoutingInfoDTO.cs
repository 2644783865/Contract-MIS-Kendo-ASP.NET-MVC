using System.Collections.Generic;
using System.Runtime.Serialization;
using Misi.Service.Billing.Model.Common;

namespace Misi.Service.Billing.Model.ErrorCharges
{
    [DataContract]
    public class ErrorChargesRoutingInfoDTO : RoutingInfoBaseDTO
    {
        private List<ContractWithBillingsDTO> _contracts;
        
        [DataMember]
        public string SoldToParty { get; set; }

        [DataMember]
        public List<ContractWithBillingsDTO> Contracts
        {
            get { return _contracts ?? (_contracts = new List<ContractWithBillingsDTO>()); }
            set { _contracts = value; }
        }
    }
}