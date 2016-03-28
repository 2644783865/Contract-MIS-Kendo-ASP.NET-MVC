using Misi.Helpdesk.Connector.Model;
using System.Data.Entity;

namespace Misi.Helpdesk.Connector.DaoUtil
{
    [DbConfigurationType(typeof(MySql.Data.Entity.MySqlEFConfiguration))]
    public class HelpDeskDbContext : DbContext
    {
        public DbSet<Ticket> Tickets { get; set; }
    }
}