namespace HardwareReservationAndAccountingSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateReservationStatuses : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO ReservationStatus (Id, Slug, Title) VALUES (1, 'pending', 'Laukanti patvirtinimo')");
            Sql("INSERT INTO ReservationStatus (Id, Slug, Title) VALUES (2, 'confirmed', 'Patvirtinta')");
            Sql("INSERT INTO ReservationStatus (Id, Slug, Title) VALUES (3, 'complete', 'Baigta')");
            Sql("INSERT INTO ReservationStatus (Id, Slug, Title) VALUES (4, 'canceled', 'Atšaukta')");
            Sql("INSERT INTO ReservationStatus (Id, Slug, Title) VALUES (5, 'stolen', 'Pavogta')");
            Sql("INSERT INTO ReservationStatus (Id, Slug, Title) VALUES (6, 'broken', 'Sugadinta')");
            Sql("INSERT INTO ReservationStatus (Id, Slug, Title) VALUES (7, 'other', 'Kita')");
        }
        
        public override void Down()
        {
            Sql("DELETE * FROM ReservationStatus");
        }
    }
}
