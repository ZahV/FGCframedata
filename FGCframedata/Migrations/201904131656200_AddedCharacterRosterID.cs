namespace FGCFrameData.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedCharacterRosterID : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Characters", "CharacterRoster_Id", "dbo.CharacterRosters");
            DropIndex("dbo.Characters", new[] { "CharacterRoster_Id" });
            RenameColumn(table: "dbo.Characters", name: "CharacterRoster_Id", newName: "CharacterRosterId");
            AlterColumn("dbo.Characters", "CharacterRosterId", c => c.Int(nullable: false));
            CreateIndex("dbo.Characters", "CharacterRosterId");
            AddForeignKey("dbo.Characters", "CharacterRosterId", "dbo.CharacterRosters", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Characters", "CharacterRosterId", "dbo.CharacterRosters");
            DropIndex("dbo.Characters", new[] { "CharacterRosterId" });
            AlterColumn("dbo.Characters", "CharacterRosterId", c => c.Int());
            RenameColumn(table: "dbo.Characters", name: "CharacterRosterId", newName: "CharacterRoster_Id");
            CreateIndex("dbo.Characters", "CharacterRoster_Id");
            AddForeignKey("dbo.Characters", "CharacterRoster_Id", "dbo.CharacterRosters", "Id");
        }
    }
}
