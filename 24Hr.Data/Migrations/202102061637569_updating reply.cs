namespace _24Hr.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatingreply : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Reply", "CommentId", "dbo.Comment");
            DropIndex("dbo.Reply", new[] { "CommentId" });
            AlterColumn("dbo.Reply", "CommentId", c => c.Int());
            CreateIndex("dbo.Reply", "CommentId");
            AddForeignKey("dbo.Reply", "CommentId", "dbo.Comment", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Reply", "CommentId", "dbo.Comment");
            DropIndex("dbo.Reply", new[] { "CommentId" });
            AlterColumn("dbo.Reply", "CommentId", c => c.Int(nullable: false));
            CreateIndex("dbo.Reply", "CommentId");
            AddForeignKey("dbo.Reply", "CommentId", "dbo.Comment", "Id", cascadeDelete: true);
        }
    }
}
