namespace ActiviList.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedatabase : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Item", "OwnerId", c => c.Guid(nullable: false));
            AddColumn("dbo.Item", "Nombre", c => c.String(maxLength: 50));
            AddColumn("dbo.SubActivity", "OwnerId", c => c.Guid(nullable: false));
            AddColumn("dbo.SubActivity", "Nombre", c => c.String(maxLength: 50));
            AlterColumn("dbo.SubActivity", "Name", c => c.String(nullable: false, maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.SubActivity", "Name", c => c.String());
            DropColumn("dbo.SubActivity", "Nombre");
            DropColumn("dbo.SubActivity", "OwnerId");
            DropColumn("dbo.Item", "Nombre");
            DropColumn("dbo.Item", "OwnerId");
        }
    }
}
