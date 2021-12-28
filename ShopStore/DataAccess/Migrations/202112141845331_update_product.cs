namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update_product : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Products", "IsActive");
            DropColumn("dbo.Products", "IsDelete");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Products", "IsDelete", c => c.Boolean(nullable: false));
            AddColumn("dbo.Products", "IsActive", c => c.Boolean(nullable: false));
        }
    }
}
