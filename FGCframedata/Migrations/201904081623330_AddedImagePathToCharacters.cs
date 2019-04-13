namespace FGCFrameData.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedImagePathToCharacters : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Characters", "ImagePath", c => c.String());
            DropColumn("dbo.Characters", "CharacterVariation");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Characters", "CharacterVariation", c => c.Int());
            DropColumn("dbo.Characters", "ImagePath");
        }
    }
}
