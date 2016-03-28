using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Misi.DAL.Billing.Model.Common;
using Misi.DAL.Billing.Model.Contract;

namespace Misi.DAL.Billing.Model.RoutingInfo
{
    public class ErrorChargesRoutingInfo : RoutingInfoBase
    {
        private List<ContractWithBillings> _contracts;
        
        [Column("sold_to_party")]
        public string SoldToParty { get; set; }

        public List<ContractWithBillings> Contracts
        {
            get { return _contracts ?? (_contracts = new List<ContractWithBillings>()); }
            set { _contracts = value; }
        }
    }
}
