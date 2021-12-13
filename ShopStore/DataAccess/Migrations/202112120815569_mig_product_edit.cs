namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_product_edit : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Products", "CreatedOn");
            DropColumn("dbo.Products", "ModifiedOn");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Products", "ModifiedOn", c => c.DateTime(nullable: false));
            AddColumn("dbo.Products", "CreatedOn", c => c.DateTime(nullable: false));
        }
    }
}
