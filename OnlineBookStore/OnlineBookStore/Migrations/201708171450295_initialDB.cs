namespace OnlineBookStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialDB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Books",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        Author = c.String(),
                        Publication = c.String(),
                        Price = c.Double(nullable: false),
                        UnitsAvailable = c.Long(nullable: false),
                        CategoryId = c.Int(nullable: false),
                        ReleaseDate = c.DateTime(nullable: false),
                        ImageUrl = c.String(),
                        PreviewUrl = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.CategoryId, cascadeDelete: true)
                .Index(t => t.CategoryId);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AlterColumn("dbo.AspNetUsers", "UserName", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Books", "CategoryId", "dbo.Categories");
            DropIndex("dbo.Books", new[] { "CategoryId" });
            AlterColumn("dbo.AspNetUsers", "UserName", c => c.String());
            DropTable("dbo.Categories");
            DropTable("dbo.Books");
        }
    }
}
