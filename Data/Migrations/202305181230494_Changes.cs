namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Changes : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Products", "RatingId", "dbo.Ratings");
            DropForeignKey("dbo.Products", "CategoryId", "dbo.Categories");
            DropIndex("dbo.Products", new[] { "CategoryId" });
            DropIndex("dbo.Products", new[] { "RatingId" });
            AddColumn("dbo.Ratings", "ProductId", c => c.Int(nullable: false));
            AddColumn("dbo.Ratings", "Value", c => c.Int(nullable: false));
            AlterColumn("dbo.Products", "CategoryId", c => c.Int());
            CreateIndex("dbo.Products", "CategoryId");
            CreateIndex("dbo.Ratings", "ProductId");
            AddForeignKey("dbo.Ratings", "ProductId", "dbo.Products", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Products", "CategoryId", "dbo.Categories", "Id");
            DropColumn("dbo.Products", "RatingId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Products", "RatingId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Products", "CategoryId", "dbo.Categories");
            DropForeignKey("dbo.Ratings", "ProductId", "dbo.Products");
            DropIndex("dbo.Ratings", new[] { "ProductId" });
            DropIndex("dbo.Products", new[] { "CategoryId" });
            AlterColumn("dbo.Products", "CategoryId", c => c.Int(nullable: false));
            DropColumn("dbo.Ratings", "Value");
            DropColumn("dbo.Ratings", "ProductId");
            CreateIndex("dbo.Products", "RatingId");
            CreateIndex("dbo.Products", "CategoryId");
            AddForeignKey("dbo.Products", "CategoryId", "dbo.Categories", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Products", "RatingId", "dbo.Ratings", "Id", cascadeDelete: true);
        }
    }
}
