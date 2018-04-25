namespace HardwareReservationAndAccountingSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDescriptionToEquipmentBundles : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.EquipmentBundles", "Description", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.EquipmentBundles", "Description");
        }
    }
}
