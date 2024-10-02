namespace ARS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TblFlightBook", "DDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.TblFlightBook", "Dtime", c => c.String(maxLength: 15));
            AlterColumn("dbo.TblUserAccount", "Phoneno", c => c.String(nullable: false));
            AlterColumn("dbo.TblUserAccount", "NICNo", c => c.String(maxLength: 13));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.TblUserAccount", "NICNo", c => c.String(maxLength: 40));
            AlterColumn("dbo.TblUserAccount", "Phoneno", c => c.String(nullable: false, maxLength: 20));
            DropColumn("dbo.TblFlightBook", "Dtime");
            DropColumn("dbo.TblFlightBook", "DDate");
        }
    }
}
