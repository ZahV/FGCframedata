namespace FGCFrameData.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedChracterRoster : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CharacterRosters",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        GameName = c.String(),
                        ImagePath = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Characters", "CharacterRoster_Id", c => c.Int());
            CreateIndex("dbo.Characters", "CharacterRoster_Id");
            AddForeignKey("dbo.Characters", "CharacterRoster_Id", "dbo.CharacterRosters", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Characters", "CharacterRoster_Id", "dbo.CharacterRosters");
            DropIndex("dbo.Characters", new[] { "CharacterRoster_Id" });
            DropColumn("dbo.Characters", "CharacterRoster_Id");
            DropTable("dbo.CharacterRosters");
        }
    }
}
