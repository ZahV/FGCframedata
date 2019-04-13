namespace FGCFrameData.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Revert1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Characters", "ImagePath", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Characters", "ImagePath");
        }
    }
}
