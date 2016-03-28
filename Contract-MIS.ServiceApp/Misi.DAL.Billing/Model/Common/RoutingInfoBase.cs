using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Misi.DAL.Billing.Model.Object;

namespace Misi.DAL.Billing.Model.Common
{
    public abstract class RoutingInfoBase
    {
        private List<RoutingItem> _routings;
        
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("no")]
        public long No { get; set; }

        [Column("sub_scenario")]
        public ESubScenario SubScenario { get; set; }

        [Column("create_date", TypeName = "datetime2")]
        public DateTime CreateDate { get; set; }

        [Column("routing_memo")]
        public string RoutingMemo { get; set; }

        public List<RoutingItem> Routings
        {
            get { return _routings ?? (_routings = new List<RoutingItem>()); }
            set { _routings = value; }
        }

        [Column("current_step")]
        public int CurrentStep { get; set; }
    }
}
