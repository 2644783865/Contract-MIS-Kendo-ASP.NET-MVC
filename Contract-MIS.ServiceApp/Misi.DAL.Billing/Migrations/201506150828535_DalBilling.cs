namespace Misi.DAL.Billing.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DalBilling : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.InvoiceProformaItemDTO", "LogMessage", c => c.String());
            AddColumn("dbo.InvoiceProformaBilling", "LogMessage", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.InvoiceProformaBilling", "LogMessage");
            DropColumn("dbo.InvoiceProformaItemDTO", "LogMessage");
        }
    }
}
