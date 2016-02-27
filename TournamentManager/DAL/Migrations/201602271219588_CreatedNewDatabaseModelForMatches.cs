namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreatedNewDatabaseModelForMatches : DbMigration
    {
        public override void Up()
        {
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
            
            AddColumn("dbo.Players", "Match_MatchId", c => c.Int());
            AddColumn("dbo.Players", "Match_MatchId1", c => c.Int());
            AddColumn("dbo.MapPools", "Match_MatchId", c => c.Int());
            AddColumn("dbo.Teams", "TeamAbbreviation", c => c.String(nullable: false, maxLength: 10));
            CreateIndex("dbo.Players", "Match_MatchId");
            CreateIndex("dbo.Players", "Match_MatchId1");
            CreateIndex("dbo.MapPools", "Match_MatchId");
            AddForeignKey("dbo.Players", "Match_MatchId", "dbo.Matches", "MatchId");
            AddForeignKey("dbo.MapPools", "Match_MatchId", "dbo.Matches", "MatchId");
            AddForeignKey("dbo.Players", "Match_MatchId1", "dbo.Matches", "MatchId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Players", "Match_MatchId1", "dbo.Matches");
            DropForeignKey("dbo.Matches", "SecondTeamId", "dbo.Teams");
            DropForeignKey("dbo.MapPools", "Match_MatchId", "dbo.Matches");
            DropForeignKey("dbo.Players", "Match_MatchId", "dbo.Matches");
            DropForeignKey("dbo.Matches", "FirstTeamId", "dbo.Teams");
            DropIndex("dbo.Matches", new[] { "SecondTeamId" });
            DropIndex("dbo.Matches", new[] { "FirstTeamId" });
            DropIndex("dbo.MapPools", new[] { "Match_MatchId" });
            DropIndex("dbo.Players", new[] { "Match_MatchId1" });
            DropIndex("dbo.Players", new[] { "Match_MatchId" });
            DropColumn("dbo.Teams", "TeamAbbreviation");
            DropColumn("dbo.MapPools", "Match_MatchId");
            DropColumn("dbo.Players", "Match_MatchId1");
            DropColumn("dbo.Players", "Match_MatchId");
            DropTable("dbo.Matches");
        }
    }
}
