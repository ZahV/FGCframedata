namespace FGCFrameData.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedMoves : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Moves", "CharacterId", c => c.Int(nullable: false));
            CreateIndex("dbo.Moves", "CharacterId");
            AddForeignKey("dbo.Moves", "CharacterId", "dbo.Characters", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Moves", "CharacterId", "dbo.Characters");
            DropIndex("dbo.Moves", new[] { "CharacterId" });
            DropColumn("dbo.Moves", "CharacterId");
        }
    }
}
