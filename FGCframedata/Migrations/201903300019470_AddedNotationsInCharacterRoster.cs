namespace FGCframedata.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedNotationsInCharacterRoster : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.CharacterRosters", "GameName", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.CharacterRosters", "GameName", c => c.String());
        }
    }
}
