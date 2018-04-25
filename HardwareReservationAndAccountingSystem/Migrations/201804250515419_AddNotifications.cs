namespace HardwareReservationAndAccountingSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNotifications : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Notifications",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Topic = c.String(nullable: false),
                        Description = c.String(),
                        CreatedOn = c.DateTime(nullable: false),
                        IsRead = c.Boolean(nullable: false),
                        IsArchived = c.Boolean(nullable: false),
                        ReservationId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Reservations", t => t.ReservationId, cascadeDelete: true)
                .Index(t => t.ReservationId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Notifications", "ReservationId", "dbo.Reservations");
            DropIndex("dbo.Notifications", new[] { "ReservationId" });
            DropTable("dbo.Notifications");
        }
    }
}
