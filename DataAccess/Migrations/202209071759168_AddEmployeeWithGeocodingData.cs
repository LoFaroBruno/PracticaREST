namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddEmployeeWithGeocodingData : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.EmployeeWithGeocodingDatas",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        City = c.String(nullable: false, maxLength: 50),
                        Address = c.String(nullable: false, maxLength: 40),
                        Latitude = c.Double(nullable: false),
                        Longitude = c.Double(nullable: false),
                        Document = c.Int(nullable: false),
                        FirstName = c.String(nullable: false, maxLength: 15),
                        LastName = c.String(nullable: false, maxLength: 15),
                        BirthDate = c.DateTime(nullable: false),
                        Mail = c.String(nullable: false),
                        ConfirmMail = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            DropTable("dbo.Employees");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Document = c.Int(nullable: false),
                        FirstName = c.String(nullable: false, maxLength: 15),
                        LastName = c.String(nullable: false, maxLength: 15),
                        BirthDate = c.DateTime(nullable: false),
                        Mail = c.String(nullable: false),
                        ConfirmMail = c.String(nullable: false),
                        City = c.String(maxLength: 50),
                        Address = c.String(maxLength: 40),
                        Latitude = c.Double(),
                        Longitude = c.Double(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.ID);
            
            DropTable("dbo.EmployeeWithGeocodingDatas");
        }
    }
}
