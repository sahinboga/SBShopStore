namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class shipping : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ShippingDetails", "CardName", c => c.String(maxLength: 50));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ShippingDetails", "CardName");
        }
    }
}
