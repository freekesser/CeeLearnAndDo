namespace CeeLearnAndDo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class First : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ArticleReplies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Content = c.String(),
                        CheckedAt = c.DateTime(),
                        User_Id = c.Int(),
                        Article_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.User_Id)
                .ForeignKey("dbo.Articles", t => t.Article_Id)
                .Index(t => t.User_Id)
                .Index(t => t.Article_Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Role = c.Int(nullable: false),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Email = c.String(),
                        Password = c.String(),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Articles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Description = c.String(),
                        Content = c.String(),
                        CreatedAt = c.DateTime(nullable: false),
                        User_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.User_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.KnowledgebaseReplies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Content = c.String(),
                        CreatedAt = c.DateTime(nullable: false),
                        User_Id = c.Int(),
                        Knowledgebase_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.User_Id)
                .ForeignKey("dbo.Knowledgebases", t => t.Knowledgebase_Id)
                .Index(t => t.User_Id)
                .Index(t => t.Knowledgebase_Id);
            
            CreateTable(
                "dbo.Knowledgebases",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Content = c.String(),
                        PublishedAt = c.DateTime(),
                        User_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.User_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.Questions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Email = c.String(),
                        Content = c.String(),
                        Replyed = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Knowledgebases", "User_Id", "dbo.Users");
            DropForeignKey("dbo.KnowledgebaseReplies", "Knowledgebase_Id", "dbo.Knowledgebases");
            DropForeignKey("dbo.KnowledgebaseReplies", "User_Id", "dbo.Users");
            DropForeignKey("dbo.Articles", "User_Id", "dbo.Users");
            DropForeignKey("dbo.ArticleReplies", "Article_Id", "dbo.Articles");
            DropForeignKey("dbo.ArticleReplies", "User_Id", "dbo.Users");
            DropIndex("dbo.Knowledgebases", new[] { "User_Id" });
            DropIndex("dbo.KnowledgebaseReplies", new[] { "Knowledgebase_Id" });
            DropIndex("dbo.KnowledgebaseReplies", new[] { "User_Id" });
            DropIndex("dbo.Articles", new[] { "User_Id" });
            DropIndex("dbo.ArticleReplies", new[] { "Article_Id" });
            DropIndex("dbo.ArticleReplies", new[] { "User_Id" });
            DropTable("dbo.Questions");
            DropTable("dbo.Knowledgebases");
            DropTable("dbo.KnowledgebaseReplies");
            DropTable("dbo.Articles");
            DropTable("dbo.Users");
            DropTable("dbo.ArticleReplies");
        }
    }
}
