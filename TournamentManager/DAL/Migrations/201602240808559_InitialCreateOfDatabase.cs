namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreateOfDatabase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ComputerSpecifications",
                c => new
                    {
                        CompSpecId = c.Int(nullable: false, identity: true),
                        ProcessorName = c.String(maxLength: 128),
                        GraphicName = c.String(maxLength: 128),
                        StorageName = c.String(maxLength: 128),
                        RamName = c.String(maxLength: 128),
                        OsName = c.String(maxLength: 128),
                        MouseName = c.String(maxLength: 128),
                        MousePadName = c.String(maxLength: 128),
                        HeadsetName = c.String(maxLength: 128),
                        KeyboardName = c.String(maxLength: 128),
                        PlayerId = c.Int(nullable: false),
                        CompWins = c.Int(),
                        CompLost = c.Int(),
                    })
                .PrimaryKey(t => t.CompSpecId)
                .ForeignKey("dbo.Players", t => t.PlayerId, cascadeDelete: false)
                .Index(t => t.PlayerId);
            
            CreateTable(
                "dbo.Players",
                c => new
                    {
                        PlayerId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false, maxLength: 128),
                        NickName = c.String(nullable: false, maxLength: 128),
                        LastName = c.String(nullable: false, maxLength: 128),
                        MapId = c.Int(nullable: false),
                        AllTimeWins = c.Int(),
                        CurrentWins = c.Int(),
                        AllTimeLost = c.Int(),
                        CurrentLost = c.Int(),
                        TeamId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PlayerId)
                .ForeignKey("dbo.MapPools", t => t.MapId, cascadeDelete: false)
                .ForeignKey("dbo.Teams", t => t.TeamId, cascadeDelete: false)
                .Index(t => t.MapId)
                .Index(t => t.TeamId);
            
            CreateTable(
                "dbo.MapPools",
                c => new
                    {
                        MapId = c.Int(nullable: false, identity: true),
                        MapName = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.MapId);
            
            CreateTable(
                "dbo.GameSpecifications",
                c => new
                    {
                        GameSpecId = c.Int(nullable: false, identity: true),
                        DpiValue = c.Int(),
                        SensitivityValue = c.Double(),
                        PlayerId = c.Int(nullable: false),
                        GameWins = c.Int(),
                        GameLost = c.Int(),
                    })
                .PrimaryKey(t => t.GameSpecId)
                .ForeignKey("dbo.Players", t => t.PlayerId, cascadeDelete: false)
                .Index(t => t.PlayerId);
            
            CreateTable(
                "dbo.Teams",
                c => new
                    {
                        TeamId = c.Int(nullable: false, identity: true),
                        TeamName = c.String(nullable: false, maxLength: 128),
                        TeamLogo = c.Binary(),
                    })
                .PrimaryKey(t => t.TeamId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Players", "TeamId", "dbo.Teams");
            DropForeignKey("dbo.GameSpecifications", "PlayerId", "dbo.Players");
            DropForeignKey("dbo.Players", "MapId", "dbo.MapPools");
            DropForeignKey("dbo.ComputerSpecifications", "PlayerId", "dbo.Players");
            DropIndex("dbo.GameSpecifications", new[] { "PlayerId" });
            DropIndex("dbo.Players", new[] { "TeamId" });
            DropIndex("dbo.Players", new[] { "MapId" });
            DropIndex("dbo.ComputerSpecifications", new[] { "PlayerId" });
            DropTable("dbo.Teams");
            DropTable("dbo.GameSpecifications");
            DropTable("dbo.MapPools");
            DropTable("dbo.Players");
            DropTable("dbo.ComputerSpecifications");
        }
    }
}
