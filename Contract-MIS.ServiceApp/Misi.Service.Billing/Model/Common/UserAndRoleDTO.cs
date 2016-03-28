using System.Runtime.Serialization;

namespace Misi.Service.Billing.Model.Common
{
    [DataContract]
    public class UserAndRoleDTO
    {
        [DataMember]
        public long No { get; set; }

        [DataMember]
        public string Username { get; set; }

        [DataMember]
        public string Role { get; set; }

        [DataMember]
        public string Division { get; set; }
    }
}