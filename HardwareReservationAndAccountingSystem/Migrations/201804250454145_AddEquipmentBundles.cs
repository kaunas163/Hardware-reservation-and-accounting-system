namespace HardwareReservationAndAccountingSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddEquipmentBundles : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.EquipmentBundles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.EquipmentBundleEquipments",
                c => new
                    {
                        EquipmentBundle_Id = c.Int(nullable: false),
                        Equipment_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.EquipmentBundle_Id, t.Equipment_Id })
                .ForeignKey("dbo.EquipmentBundles", t => t.EquipmentBundle_Id, cascadeDelete: true)
                .ForeignKey("dbo.Equipments", t => t.Equipment_Id, cascadeDelete: true)
                .Index(t => t.EquipmentBundle_Id)
                .Index(t => t.Equipment_Id);
            
            AlterColumn("dbo.Equipments", "Title", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.EquipmentBundleEquipments", "Equipment_Id", "dbo.Equipments");
            DropForeignKey("dbo.EquipmentBundleEquipments", "EquipmentBundle_Id", "dbo.EquipmentBundles");
            DropIndex("dbo.EquipmentBundleEquipments", new[] { "Equipment_Id" });
            DropIndex("dbo.EquipmentBundleEquipments", new[] { "EquipmentBundle_Id" });
            AlterColumn("dbo.Equipments", "Title", c => c.String());
            DropTable("dbo.EquipmentBundleEquipments");
            DropTable("dbo.EquipmentBundles");
        }
    }
}
