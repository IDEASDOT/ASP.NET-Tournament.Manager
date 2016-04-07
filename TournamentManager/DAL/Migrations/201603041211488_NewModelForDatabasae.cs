namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewModelForDatabasae : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ComputerSpecifications",
                c => new
                    {
                        CompSpecId = c.Int(nullable: false, identity: true),
                        OsName = c.String(maxLength: 128),
                        PlayerId = c.Int(nullable: false),
                        CompWins = c.Int(),
                        CompLost = c.Int(),
                    })
                .PrimaryKey(t => t.CompSpecId)
                .ForeignKey("dbo.Players", t => t.PlayerId, cascadeDelete: false)
                .Index(t => t.PlayerId);
            
            CreateTable(
                "dbo.PieceInComputers",
                c => new
                    {
                        PieceInComputerId = c.Int(nullable: false, identity: true),
                        Quantity = c.Int(nullable: false),
                        ProductSelectorId = c.Int(nullable: false),
                        CompSpecId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PieceInComputerId)
                .ForeignKey("dbo.ComputerSpecifications", t => t.CompSpecId, cascadeDelete: false)
                .ForeignKey("dbo.ProductSelectors", t => t.ProductSelectorId, cascadeDelete: false)
                .Index(t => t.ProductSelectorId)
                .Index(t => t.CompSpecId);
            
            CreateTable(
                "dbo.ProductSelectors",
                c => new
                    {
                        ProductSelectorId = c.Int(nullable: false, identity: true),
                        ManufactorerTypeId = c.Int(nullable: false),
                        ManufactorerId = c.Int(nullable: false),
                        ModelSerieId = c.Int(nullable: false),
                        ModelSerieTypeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ProductSelectorId)
                .ForeignKey("dbo.Manufactorers", t => t.ManufactorerId, cascadeDelete: false)
                .ForeignKey("dbo.ManufactorerTypes", t => t.ManufactorerTypeId, cascadeDelete: false)
                .ForeignKey("dbo.ModelSeries", t => t.ModelSerieId, cascadeDelete: false)
                .ForeignKey("dbo.ModelSerieTypes", t => t.ModelSerieTypeId, cascadeDelete: false)
                .Index(t => t.ManufactorerTypeId)
                .Index(t => t.ManufactorerId)
                .Index(t => t.ModelSerieId)
                .Index(t => t.ModelSerieTypeId);
            
            CreateTable(
                "dbo.Manufactorers",
                c => new
                    {
                        ManufactorerId = c.Int(nullable: false, identity: true),
                        ManufactorerName = c.String(nullable: false, maxLength: 64),
                    })
                .PrimaryKey(t => t.ManufactorerId);
            
            CreateTable(
                "dbo.ManufactorerTypes",
                c => new
                    {
                        ManufactorerTypeId = c.Int(nullable: false, identity: true),
                        ManufactorerTypeName = c.String(nullable: false, maxLength: 64),
                    })
                .PrimaryKey(t => t.ManufactorerTypeId);
            
            CreateTable(
                "dbo.ModelSeries",
                c => new
                    {
                        ModelSerieId = c.Int(nullable: false, identity: true),
                        ModelSerieName = c.String(nullable: false, maxLength: 64),
                    })
                .PrimaryKey(t => t.ModelSerieId);
            
            CreateTable(
                "dbo.ModelSerieTypes",
                c => new
                    {
                        ModelSerieTypeId = c.Int(nullable: false, identity: true),
                        ModelSerieTypeName = c.String(nullable: false, maxLength: 64),
                    })
                .PrimaryKey(t => t.ModelSerieTypeId);
            
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
                        Match_MatchId = c.Int(),
                    })
                .PrimaryKey(t => t.MapId)
                .ForeignKey("dbo.Matches", t => t.Match_MatchId)
                .Index(t => t.Match_MatchId);
            
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
                        TeamAbbreviation = c.String(nullable: false, maxLength: 10),
                        TeamLogo = c.Binary(),
                    })
                .PrimaryKey(t => t.TeamId);
            
            CreateTable(
                "dbo.Matches",
                c => new
                    {
                        MatchId = c.Int(nullable: false, identity: true),
                        FirstTeamId = c.Int(nullable: false),
                        SecondTeamId = c.Int(nullable: false),
                        NumberOfMapsPlayed = c.Int(),
                        FirstTeamFirstMapRoundsWon = c.Int(),
                        SecondTeamFirstMapRoundsWon = c.Int(),
                        FirstTeamSecondMapRoundsWon = c.Int(),
                        SecondTeamSecondMapRoundsWon = c.Int(),
                        FirstTeamThirdMapRoundsWon = c.Int(),
                        SecondTeamThirdMapRoundsWon = c.Int(),
                        FirstTeamFourthMapRoundsWon = c.Int(),
                        SecondTeamFourthMapRoundsWon = c.Int(),
                        FirstTeamFifthMapRoundsWon = c.Int(),
                        SecondTeamFifthMapRoundsWon = c.Int(),
                    })
                .PrimaryKey(t => t.MatchId)
                .ForeignKey("dbo.Teams", t => t.FirstTeamId, cascadeDelete: false)
                .ForeignKey("dbo.Teams", t => t.SecondTeamId, cascadeDelete: false)
                .Index(t => t.FirstTeamId)
                .Index(t => t.SecondTeamId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Matches", "SecondTeamId", "dbo.Teams");
            DropForeignKey("dbo.MapPools", "Match_MatchId", "dbo.Matches");
            DropForeignKey("dbo.Matches", "FirstTeamId", "dbo.Teams");
            DropForeignKey("dbo.Players", "TeamId", "dbo.Teams");
            DropForeignKey("dbo.GameSpecifications", "PlayerId", "dbo.Players");
            DropForeignKey("dbo.Players", "MapId", "dbo.MapPools");
            DropForeignKey("dbo.ComputerSpecifications", "PlayerId", "dbo.Players");
            DropForeignKey("dbo.PieceInComputers", "ProductSelectorId", "dbo.ProductSelectors");
            DropForeignKey("dbo.ProductSelectors", "ModelSerieTypeId", "dbo.ModelSerieTypes");
            DropForeignKey("dbo.ProductSelectors", "ModelSerieId", "dbo.ModelSeries");
            DropForeignKey("dbo.ProductSelectors", "ManufactorerTypeId", "dbo.ManufactorerTypes");
            DropForeignKey("dbo.ProductSelectors", "ManufactorerId", "dbo.Manufactorers");
            DropForeignKey("dbo.PieceInComputers", "CompSpecId", "dbo.ComputerSpecifications");
            DropIndex("dbo.Matches", new[] { "SecondTeamId" });
            DropIndex("dbo.Matches", new[] { "FirstTeamId" });
            DropIndex("dbo.GameSpecifications", new[] { "PlayerId" });
            DropIndex("dbo.MapPools", new[] { "Match_MatchId" });
            DropIndex("dbo.Players", new[] { "TeamId" });
            DropIndex("dbo.Players", new[] { "MapId" });
            DropIndex("dbo.ProductSelectors", new[] { "ModelSerieTypeId" });
            DropIndex("dbo.ProductSelectors", new[] { "ModelSerieId" });
            DropIndex("dbo.ProductSelectors", new[] { "ManufactorerId" });
            DropIndex("dbo.ProductSelectors", new[] { "ManufactorerTypeId" });
            DropIndex("dbo.PieceInComputers", new[] { "CompSpecId" });
            DropIndex("dbo.PieceInComputers", new[] { "ProductSelectorId" });
            DropIndex("dbo.ComputerSpecifications", new[] { "PlayerId" });
            DropTable("dbo.Matches");
            DropTable("dbo.Teams");
            DropTable("dbo.GameSpecifications");
            DropTable("dbo.MapPools");
            DropTable("dbo.Players");
            DropTable("dbo.ModelSerieTypes");
            DropTable("dbo.ModelSeries");
            DropTable("dbo.ManufactorerTypes");
            DropTable("dbo.Manufactorers");
            DropTable("dbo.ProductSelectors");
            DropTable("dbo.PieceInComputers");
            DropTable("dbo.ComputerSpecifications");
        }
    }
}
