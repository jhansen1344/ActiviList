namespace ActiviList.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Item", "SubActivity_Id", "dbo.SubActivity");
            DropIndex("dbo.Item", new[] { "SubActivity_Id" });
            CreateTable(
                "dbo.SubActivityItem",
                c => new
                    {
                        SubActivity_Id = c.Int(nullable: false),
                        Item_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.SubActivity_Id, t.Item_Id })
                .ForeignKey("dbo.SubActivity", t => t.SubActivity_Id, cascadeDelete: true)
                .ForeignKey("dbo.Item", t => t.Item_Id, cascadeDelete: true)
                .Index(t => t.SubActivity_Id)
                .Index(t => t.Item_Id);
            
            AlterColumn("dbo.SubActivity", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.SubActivity", "Nombre", c => c.String(nullable: false));
            DropColumn("dbo.Item", "SubActivity_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Item", "SubActivity_Id", c => c.Int());
            DropForeignKey("dbo.SubActivityItem", "Item_Id", "dbo.Item");
            DropForeignKey("dbo.SubActivityItem", "SubActivity_Id", "dbo.SubActivity");
            DropIndex("dbo.SubActivityItem", new[] { "Item_Id" });
            DropIndex("dbo.SubActivityItem", new[] { "SubActivity_Id" });
            AlterColumn("dbo.SubActivity", "Nombre", c => c.String(maxLength: 50));
            AlterColumn("dbo.SubActivity", "Name", c => c.String(nullable: false, maxLength: 50));
            DropTable("dbo.SubActivityItem");
            CreateIndex("dbo.Item", "SubActivity_Id");
            AddForeignKey("dbo.Item", "SubActivity_Id", "dbo.SubActivity", "Id");
        }
    }
}
