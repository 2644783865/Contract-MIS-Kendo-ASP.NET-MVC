using Misi.Helpdesk.Connector.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Misi.Helpdesk.Connector.DaoUtil
{
    public class TicketDao
    {
        public Ticket Select(string ticketId)
        {
            try
            {
                using (var db = new HelpDeskDbContext())
                {
                    var sql = from o in db.Tickets where o.TicketId == ticketId select o;
                    return sql.Single();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Ticket> SelectAll()
        {
            try
            {
                using (var db = new HelpDeskDbContext())
                {
                    var sql = from o in db.Tickets where o.DetailCategory.StartsWith("Transfer Asset") && o.StatusTicket != "Closed" select o;
                    return sql.ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Ticket> SelectLimit(int offset, int limit)
        {
            try
            {
                using (var db = new HelpDeskDbContext())
                {
                    var sql = from o in db.Tickets where o.DetailCategory.StartsWith("Transfer Asset") && o.StatusTicket != "Closed" select o;
                    return sql.OrderBy(o => o.StartDate).Skip(offset).Take(limit).ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int Count()
        {
            {
                try
                {
                    using (var db = new HelpDeskDbContext())
                    {
                        var sql = from o in db.Tickets where o.DetailCategory.StartsWith("Transfer Asset") && o.StatusTicket != "Closed" select o;
                        return sql.Count();
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
    }
}