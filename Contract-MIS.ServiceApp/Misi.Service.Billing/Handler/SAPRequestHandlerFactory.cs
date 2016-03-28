using Misi.Service.Billing.Handler.SAP;

namespace Misi.Service.Billing.Handler
{
    public class SAPRequestHandlerFactory
    {
        private static volatile SAPRequestHandlerFactory _factory;
        private static readonly object SyncRoot1 = new object();

        public static SAPRequestHandlerFactory Instance
        {
            get
            {
                if (_factory != null) return _factory;
                lock (SyncRoot1)
                {
                    if (_factory == null)
                    {
                        _factory = new SAPRequestHandlerFactory();
                    }
                }
                return _factory;
            }
        }

        public SAPRequestHandlerBase GetSAPRequestHandler(ESAPScenario scenario)
        {
            switch (scenario)
            {
                case ESAPScenario.QUERY_SOLD_TO_PARTIES_LIST:
                    return new QuerySoldToPartiesHandler();

                //---- BROMO -----
                case ESAPScenario.QUERY_BILLING_NUMBERS:
                    return new QueryBillingNumbersHandler();
                case ESAPScenario.QUERY_BILLING_TOTAL_RECORDS:
                    return new QueryTotalBillingRecordsHandler();
                case ESAPScenario.QUERY_INVOICE_HEADER_FROM_SAP:
                    return new QueryInvoiceHeaderFromSAPHandler();
                case ESAPScenario.QUERY_INVOICE_HEADER_FROM_DB:
                    return new QueryInvoiceHeaderFromDBHandler();
                case ESAPScenario.QUERY_BILLING_RUNS:
                    return new QueryBillingRunsFromDBHandler();
                case ESAPScenario.QUERY_INVOICE_BILLINGS_ALL:
                    return new QueryInvoiceBillingsAllHandler();
                case ESAPScenario.UPDATE_BILLING_ITEM:
                    return new UpdateInvoiceBillingHandler();
                case ESAPScenario.SAVE_UPDATED_BILLING_ITEMS:
                    return new SaveBillingsUpdatesHandler();
                case ESAPScenario.SAVE_INITIAL_SAP_DATA:
                    return new SaveInitialSAPDataHandler();

                //---- Febri ----
                case ESAPScenario.SUBMIT_BILLING_ITEMS:
                    return new SubmitBillingsUpdatesHandler();
                case ESAPScenario.SUBMIT_BILLING_ITEMS_BY_ID:
                    return new SubmitBillingsUpdatesByIDHandler();
            }
            return null;
        }
    }
}