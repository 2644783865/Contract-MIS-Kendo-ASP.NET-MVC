using System;
using System.Collections.Generic;
using System.ServiceModel;
using Misi.Service.Billing.Model.SAP;
using Misi.Service.Billing.Object;

namespace Misi.Service.Billing.Service
{
    [ServiceContract]
    public interface ISAPProxyService
    {
        [OperationContract]
        [FaultContract(typeof(FaultException))]
        List<string> QuerySoldToParties(string user);

        [OperationContract]
        [FaultContract(typeof(FaultException))]
        List<BillingNumberItemDTO> QueryBillingNumbers(string user, string soldToParty, DateTime startDate, DateTime endDate);

        [OperationContract]
        [FaultContract(typeof(FaultException))]
        int QueryTotalBillingRecords(string user);

        [OperationContract]
        [FaultContract(typeof(FaultException))]
        RunInvoiceHeaderDTO QueryRunInvoiceHeader(string user, string billingNo, bool billingBlock, bool reasonForRejection, bool proformaFlag);

        [OperationContract]
        [FaultContract(typeof(FaultException))]
        IEnumerable<InvoiceProformaItemDTO> QueryRunInvoiceBillingsAll(string user);

        [OperationContract]
        [FaultContract(typeof(FaultException))]
        RunInvoiceHeaderDTO QueryRunInvoiceHeaderFromDB(string user, long no);

        [OperationContract]
        [FaultContract(typeof(FaultException))]
        void UpdateRunInvoiceBilling(string user, string recNo, string reason, string remarks);

        [OperationContract]
        [FaultContract(typeof(FaultException))]
        int? SaveRunInvoiceBillings(string user);

        [OperationContract]
        [FaultContract(typeof(FaultException))]
        IEnumerable<InvoiceProformaBillingRunDTO> QueryBillingRunsFromDB(string user);

        [OperationContract]
        [FaultContract(typeof (FaultException))]
        void SaveInitialSAPData(string user);

        [OperationContract]
        [FaultContract(typeof(FaultException))]
        int? SubmitInvoiceProforma(string user);

        [OperationContract]
        [FaultContract(typeof(FaultException))]
        int? SubmitInvoiceProformaByID(string user, long ID);

        [OperationContract]
        [FaultContract(typeof(FaultException))]
        SAPResponse GetBillingsToPrintAppendix(string user, string billingNumber);

        [OperationContract]
        [FaultContract(typeof(FaultException))]
        SAPResponse GetBillingsToPrintHeader(string user, string billingNumber);

        [OperationContract]
        [FaultContract(typeof(FaultException))]
        SAPResponse GetBillingsToPrint(string user, string billingNumber);

        [OperationContract]
        [FaultContract(typeof(FaultException))]
        SAPResponse GetBillingsToPrintTotal(string user, string billingNumber);

        [OperationContract]
        [FaultContract(typeof(FaultException))]
        int? SaveBillingBlock(string user, string billingNumber);

    }
}
