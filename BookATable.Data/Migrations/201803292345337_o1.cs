namespace BookATable.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class o1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "ImgURL", c => c.String());
            AddColumn("dbo.Users", "Username", c => c.String());
            AddColumn("dbo.Users", "FirstName", c => c.String());
            AddColumn("dbo.Users", "LastName", c => c.String());
            AddColumn("dbo.Users", "IsEmailConfirmed", c => c.Boolean(nullable: false));
            AddColumn("dbo.Users", "ValidationCode", c => c.String());
            DropColumn("dbo.Users", "Name");
            DropColumn("dbo.Users", "Phone");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "Phone", c => c.String());
            AddColumn("dbo.Users", "Name", c => c.String());
            DropColumn("dbo.Users", "ValidationCode");
            DropColumn("dbo.Users", "IsEmailConfirmed");
            DropColumn("dbo.Users", "LastName");
            DropColumn("dbo.Users", "FirstName");
            DropColumn("dbo.Users", "Username");
            DropColumn("dbo.Users", "ImgURL");
        }
    }
}
