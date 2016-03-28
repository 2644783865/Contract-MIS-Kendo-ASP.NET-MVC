using Misi.Helpdesk.Connector.Object;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.ServiceModel;

namespace Misi.Helpdesk.Connector.Service
{
    [ServiceContract]
    public interface IHelpdeskServ
    {
        [OperationContract]
        [FaultContract(typeof(FaultException))]
        Tickets SelectAllTickets();

        [OperationContract]
        [FaultContract(typeof(FaultException))]
        Tickets SelectLimitedTickets(int offset, int limit);

        [OperationContract]
        [FaultContract(typeof(FaultException))]
        TicketVo SelectTicket(string ticketId);

        [OperationContract]
        [FaultContract(typeof(FaultException))]
        int TotalTickets();
    }

    [DataContract]
    public class Tickets
    {
        [DataMember]
        public List<TicketVo> Collection { get; set; }
    }
}
