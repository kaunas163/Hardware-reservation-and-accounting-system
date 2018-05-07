namespace HardwareReservationAndAccountingSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddEquipmentTypes : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.EquipmentTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 50),
                        Color = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Equipments", "EquipmentTypeId", c => c.Int(nullable: false));
            CreateIndex("dbo.Equipments", "EquipmentTypeId");
            AddForeignKey("dbo.Equipments", "EquipmentTypeId", "dbo.EquipmentTypes", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Equipments", "EquipmentTypeId", "dbo.EquipmentTypes");
            DropIndex("dbo.Equipments", new[] { "EquipmentTypeId" });
            DropColumn("dbo.Equipments", "EquipmentTypeId");
            DropTable("dbo.EquipmentTypes");
        }
    }
}
