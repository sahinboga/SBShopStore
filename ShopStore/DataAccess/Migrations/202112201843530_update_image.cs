namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update_image : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Images", "ImageTitle");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Images", "ImageTitle", c => c.String(maxLength: 100));
        }
    }
}
