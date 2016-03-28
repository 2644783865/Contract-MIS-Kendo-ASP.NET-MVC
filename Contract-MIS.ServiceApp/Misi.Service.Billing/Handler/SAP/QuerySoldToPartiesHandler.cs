using System.Linq;
using System.ServiceModel;
using Misi.Service.Billing.Model.Common;
using Misi.Service.Billing.Model.SAP;

namespace Misi.Service.Billing.Handler.SAP
{
    public class QuerySoldToPartiesHandler : SAPRequestHandlerBase
    {
        private const string FUNCTIONAL_BAPI = "ZBAPI_SOLDTOPARTY_GETLIST";

        public override void SetHandlerArguments(string user, object[] args = null)
        {
            Username = user;
        }

        public override SAPResponse ExecuteQuery()
        {

            ParseCredential(Username);

            var list = new SoldToPartiesListDTO();
            var cred = ParseCredential(Username);
            var dest = SAPConnectionFactory.Instance.GetRfcDestination(cred);
            if (dest == null) return null;
            var repo = dest.Repository;
            var func = repo.CreateFunction(FUNCTIONAL_BAPI);
            func.SetValue("SALES_ORG", Properties.Settings.Default.OrgNumber);
            func.Invoke(dest);

            var stpTbl = func.GetTable("SOLD_TO_PARTY");
            var list3 = stpTbl.Select(e => new SoldToParty
            {
                KUNNR = e.GetString("KUNNR"),
                LOEVM = e.GetString("LOEVM"),
                NAME1 = e.GetString("NAME1"),
                SPART = e.GetString("SPART"),
                VTWEG = e.GetString("VTWEG")
            });
            foreach (var item in list3)
            {
                list.List.Add(new KeyValueDTO
                {
                    Key = item.KUNNR,
                    Value = item.NAME1
                });
            }
            return list;
        }
    }
}