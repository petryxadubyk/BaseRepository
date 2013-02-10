namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        CustomerId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Address = c.String(),
                    })
                .PrimaryKey(t => t.CustomerId);
            
            CreateTable(
                "dbo.Deliveries",
                c => new
                    {
                        DeliveryId = c.Int(nullable: false, identity: true),
                        CustomerId = c.Int(nullable: false),
                        Description = c.String(),
                        IsDelivered = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.DeliveryId)
                .ForeignKey("dbo.Customers", t => t.CustomerId, cascadeDelete: true)
                .Index(t => t.CustomerId);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.Deliveries", new[] { "CustomerId" });
            DropForeignKey("dbo.Deliveries", "CustomerId", "dbo.Customers");
            DropTable("dbo.Deliveries");
            DropTable("dbo.Customers");
        }
    }
}
