using System.Runtime.Serialization;
using Misi.Service.Billing.Model.Common;

namespace Misi.Service.Billing.Model.NewContract
{
    [DataContract]
    public class NewContractExtLineContractDTO : ContractBaseDTO
    {
        [DataMember]
        public string QuotationNumber { get; set; }

        [DataMember]
        public string Number { get; set; }

        [DataMember]
        public string LineNumber { get; set; }

        [DataMember]
        public string HolderName { get; set; }

        [DataMember]
        public string SalaryNumber { get; set; }

        [DataMember]
        public string ExtensionLineNumber { get; set; }
    }
}