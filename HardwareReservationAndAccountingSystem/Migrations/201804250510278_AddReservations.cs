namespace HardwareReservationAndAccountingSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddReservations : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Reservations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ReservedFrom = c.DateTime(nullable: false),
                        ReservedTo = c.DateTime(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        UpdatedOn = c.DateTime(nullable: false),
                        ReservationStatusId = c.Byte(nullable: false),
                        EquipmentBundleId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.EquipmentBundles", t => t.EquipmentBundleId, cascadeDelete: true)
                .ForeignKey("dbo.ReservationStatus", t => t.ReservationStatusId, cascadeDelete: true)
                .Index(t => t.ReservationStatusId)
                .Index(t => t.EquipmentBundleId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Reservations", "ReservationStatusId", "dbo.ReservationStatus");
            DropForeignKey("dbo.Reservations", "EquipmentBundleId", "dbo.EquipmentBundles");
            DropIndex("dbo.Reservations", new[] { "EquipmentBundleId" });
            DropIndex("dbo.Reservations", new[] { "ReservationStatusId" });
            DropTable("dbo.Reservations");
        }
    }
}
