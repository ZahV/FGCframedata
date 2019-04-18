namespace FGCFrameData.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedNotationsToMoves : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Moves", "RecoveryFrames", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Moves", "RecoveryFrames", c => c.Int());
        }
    }
}
