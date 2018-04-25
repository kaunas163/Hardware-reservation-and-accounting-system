namespace HardwareReservationAndAccountingSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddReservationStatuses : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.EquipmentBundleEquipments", newName: "EquipmentEquipmentBundles");
            DropPrimaryKey("dbo.EquipmentEquipmentBundles");
            CreateTable(
                "dbo.ReservationStatus",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        Slug = c.String(nullable: false),
                        Title = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddPrimaryKey("dbo.EquipmentEquipmentBundles", new[] { "Equipment_Id", "EquipmentBundle_Id" });
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.EquipmentEquipmentBundles");
            DropTable("dbo.ReservationStatus");
            AddPrimaryKey("dbo.EquipmentEquipmentBundles", new[] { "EquipmentBundle_Id", "Equipment_Id" });
            RenameTable(name: "dbo.EquipmentEquipmentBundles", newName: "EquipmentBundleEquipments");
        }
    }
}
