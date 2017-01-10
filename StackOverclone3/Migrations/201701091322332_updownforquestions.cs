namespace StackOverclone3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updownforquestions : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Posts", "Upvotes", c => c.Int(nullable: false));
            AddColumn("dbo.Posts", "Downvotes", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Posts", "Downvotes");
            DropColumn("dbo.Posts", "Upvotes");
        }
    }
}
