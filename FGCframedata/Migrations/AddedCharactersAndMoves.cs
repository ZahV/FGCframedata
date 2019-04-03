namespace FGCFrameData.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedCharactersAndMoves : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Characters",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        CharacterVariation = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Moves",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Input = c.String(nullable: false),
                        StartupFrames = c.Int(nullable: false),
                        ActiveFrames = c.Int(nullable: false),
                        RecoveryFrames = c.Int(),
                        FrameAdvantage = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Moves");
            DropTable("dbo.Characters");
        }
    }
}
