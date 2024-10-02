namespace ARS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TblAdminLogin",
                c => new
                    {
                        AdminId = c.Int(nullable: false, identity: true),
                        AdminName = c.String(nullable: false, maxLength: 10),
                        Password = c.String(nullable: false, maxLength: 10),
                    })
                .PrimaryKey(t => t.AdminId);
            
            CreateTable(
                "dbo.TblFlightBook",
                c => new
                    {
                        Bid = c.Int(nullable: false, identity: true),
                        bCusName = c.String(nullable: false),
                        bCusAddress = c.String(nullable: false),
                        bCusEmail = c.String(nullable: false),
                        bCusSeat = c.String(nullable: false),
                        bCusPhoneNum = c.String(nullable: false),
                        bCusCnic = c.String(nullable: false),
                        ResID = c.Int(nullable: false),
                        TicketReserve_tbls_ResID = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Bid)
                .ForeignKey("dbo.TicketReserve_tbl", t => t.TicketReserve_tbls_ResID)
                .Index(t => t.TicketReserve_tbls_ResID);
            
            CreateTable(
                "dbo.TicketReserve_tbl",
                c => new
                    {
                        ResID = c.String(nullable: false, maxLength: 128),
                        Resfrom = c.String(nullable: false),
                        Resto = c.String(nullable: false),
                        ResDepDate = c.String(nullable: false),
                        ResTime = c.String(nullable: false),
                        PlaneId = c.Int(nullable: false),
                        Planeseat = c.Int(nullable: false),
                        ResTicketPrice = c.Single(nullable: false),
                        ResPlaneType = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ResID)
                .ForeignKey("dbo.AeroPlaneInfoes", t => t.PlaneId, cascadeDelete: true)
                .Index(t => t.PlaneId);
            
            CreateTable(
                "dbo.AeroPlaneInfoes",
                c => new
                    {
                        Planeid = c.Int(nullable: false, identity: true),
                        Aplane = c.String(nullable: false, maxLength: 30),
                        SeatingCapacity = c.Int(nullable: false),
                        Price = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.Planeid);
            
            CreateTable(
                "dbo.TblUserAccount",
                c => new
                    {
                        UserID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false, maxLength: 40),
                        LastName = c.String(nullable: false, maxLength: 40),
                        EmailID = c.String(nullable: false, maxLength: 30),
                        Password = c.String(nullable: false, maxLength: 20),
                        ConfirmPassword = c.String(nullable: false, maxLength: 20),
                        Age = c.String(nullable: false),
                        Phoneno = c.String(nullable: false, maxLength: 20),
                        NICNo = c.String(maxLength: 40),
                    })
                .PrimaryKey(t => t.UserID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TblFlightBook", "TicketReserve_tbls_ResID", "dbo.TicketReserve_tbl");
            DropForeignKey("dbo.TicketReserve_tbl", "PlaneId", "dbo.AeroPlaneInfoes");
            DropIndex("dbo.TicketReserve_tbl", new[] { "PlaneId" });
            DropIndex("dbo.TblFlightBook", new[] { "TicketReserve_tbls_ResID" });
            DropTable("dbo.TblUserAccount");
            DropTable("dbo.AeroPlaneInfoes");
            DropTable("dbo.TicketReserve_tbl");
            DropTable("dbo.TblFlightBook");
            DropTable("dbo.TblAdminLogin");
        }
    }
}
