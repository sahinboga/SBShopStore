namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update_cart : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Carts", "Quantity", c => c.Int(nullable: false));
            DropColumn("dbo.Carts", "CartStatus");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Carts", "CartStatus", c => c.Boolean(nullable: false));
            DropColumn("dbo.Carts", "Quantity");
        }
    }
}
