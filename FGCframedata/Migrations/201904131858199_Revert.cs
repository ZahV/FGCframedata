namespace FGCFrameData.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Revert : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Characters", "ImagePath");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Characters", "ImagePath", c => c.String());
        }
    }
}
