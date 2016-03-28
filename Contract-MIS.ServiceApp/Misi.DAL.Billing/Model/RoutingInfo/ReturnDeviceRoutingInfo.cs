using System.ComponentModel.DataAnnotations.Schema;
using Misi.DAL.Billing.Model.Common;
using Misi.DAL.Billing.Model.Contract;

namespace Misi.DAL.Billing.Model.RoutingInfo
{
    public class ReturnDeviceRoutingInfo : RoutingInfoBase
    {
        private ReturnDeviceOldContract _oldContract;
        private ReturnDeviceUpdatedContract _updContract;

        [Column("idr_web_number")]
        public string IdrWebNumber { get; set; }

        public ReturnDeviceOldContract OldContract
        {
            get { return _oldContract ?? (_oldContract = new ReturnDeviceOldContract()); }
            set { _oldContract = value; }
        }

        public ReturnDeviceUpdatedContract UpdContract
        {
            get { return _updContract ?? (_updContract = new ReturnDeviceUpdatedContract()); }
            set { _updContract = value; }
        }
    }
}
