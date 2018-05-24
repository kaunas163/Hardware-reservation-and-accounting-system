namespace HardwareReservationAndAccountingSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAvailabilityFieldToEquipmentAndEquipmentBundles : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.EquipmentBundles", "IsAvailable", c => c.Boolean(nullable: false));
            AddColumn("dbo.Equipments", "IsAvailable", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Equipments", "IsAvailable");
            DropColumn("dbo.EquipmentBundles", "IsAvailable");
        }
    }
}
