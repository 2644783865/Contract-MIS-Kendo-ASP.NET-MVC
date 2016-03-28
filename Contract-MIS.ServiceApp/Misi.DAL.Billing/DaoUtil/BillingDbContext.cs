using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Misi.DAL.Billing.Model.Common;
using Misi.DAL.Billing.Model.SAP;
using Misi.Service.Billing.Object;

namespace Misi.DAL.Billing.DaoUtil
{
    public class BillingDbContext : DbContext
    {
        public DbSet<ServiceRequestBase> ServiceRequests { get; set; }
        public DbSet<ContractBase> Contracts { get; set; }
        public DbSet<RequestInfoBase> RequestInfos { get; set; }
        public DbSet<RoutingInfoBase> RoutingInfos { get; set; }
        public DbSet<RoutingItem> RoutingItems { get; set; }
        public DbSet<TerminationItem> Terminations { get; set; }
        public DbSet<Division> Divisions { get; set; }
        public DbSet<UserAndRole> UserRoles { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Index> Indexes { get; set; }
        public DbSet<InvoiceProformaHeader> InvoiceProformaHeaders { get; set; }
        public DbSet<InvoiceProformaBilling> InvoiceProformaBillings { get; set; }
        public DbSet<InvoiceProformaItemDTO> CachedBillings { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
