using System.ComponentModel.DataAnnotations.Schema;
using Misi.DAL.Billing.Model.Common;
using Misi.DAL.Billing.Model.Contract;

namespace Misi.DAL.Billing.Model.RoutingInfo
{
    public class NewScenarioRoutingInfo : RoutingInfoBase
    {
        private NewScenarioContract _contract;

        [Column("idr_web_number")]
        public string IdrWebNumber { get; set; }

        [Column("attribute_description")]
        public string AttributeDescription { get; set; }

        public NewScenarioContract Contract {
            get { return _contract ?? (_contract = new NewScenarioContract()); }
            set { _contract = value; }
        }
    }
}
