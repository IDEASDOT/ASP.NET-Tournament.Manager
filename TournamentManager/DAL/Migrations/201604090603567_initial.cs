namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Article",
                c => new
                    {
                        ArticleId = c.Int(nullable: false, identity: true),
                        ArticleName = c.String(maxLength: 255),
                        ArticleHeadlineId = c.Int(nullable: false),
                        ArticleBodyId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ArticleId)
                .ForeignKey("dbo.MultiLangString", t => t.ArticleBodyId)
                .ForeignKey("dbo.MultiLangString", t => t.ArticleHeadlineId)
                .Index(t => t.ArticleHeadlineId)
                .Index(t => t.ArticleBodyId);
            
            CreateTable(
                "dbo.MultiLangString",
                c => new
                    {
                        MultiLangStringId = c.Int(nullable: false, identity: true),
                        Value = c.String(),
                        Owner = c.String(maxLength: 255),
                    })
                .PrimaryKey(t => t.MultiLangStringId);
            
            CreateTable(
                "dbo.Translation",
                c => new
                    {
                        TranslationId = c.Int(nullable: false, identity: true),
                        Value = c.String(),
                        MultiLangStringId = c.Int(nullable: false),
                        Culture = c.String(maxLength: 12),
                    })
                .PrimaryKey(t => t.TranslationId)
                .ForeignKey("dbo.MultiLangString", t => t.MultiLangStringId)
                .Index(t => t.MultiLangStringId);
            
            CreateTable(
                "dbo.ComputerSpecification",
                c => new
                    {
                        CompSpecId = c.Int(nullable: false, identity: true),
                        OsName = c.String(maxLength: 128),
                        PlayerId = c.Int(nullable: false),
                        CompWins = c.Int(),
                        CompLost = c.Int(),
                    })
                .PrimaryKey(t => t.CompSpecId)
                .ForeignKey("dbo.Player", t => t.PlayerId)
                .Index(t => t.PlayerId);
            
            CreateTable(
                "dbo.PieceInComputer",
                c => new
                    {
                        PieceInComputerId = c.Int(nullable: false, identity: true),
                        Quantity = c.Int(nullable: false),
                        ProductSelectorId = c.Int(nullable: false),
                        CompSpecId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PieceInComputerId)
                .ForeignKey("dbo.ComputerSpecification", t => t.CompSpecId)
                .ForeignKey("dbo.ProductSelector", t => t.ProductSelectorId)
                .Index(t => t.ProductSelectorId)
                .Index(t => t.CompSpecId);
            
            CreateTable(
                "dbo.ProductSelector",
                c => new
                    {
                        ProductSelectorId = c.Int(nullable: false, identity: true),
                        ManufactorerTypeId = c.Int(nullable: false),
                        ManufactorerId = c.Int(nullable: false),
                        ModelSerieTypeId = c.Int(nullable: false),
                        ModelSerieId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ProductSelectorId)
                .ForeignKey("dbo.Manufactorer", t => t.ManufactorerId)
                .ForeignKey("dbo.ManufactorerType", t => t.ManufactorerTypeId)
                .ForeignKey("dbo.ModelSerie", t => t.ModelSerieId)
                .ForeignKey("dbo.ModelSerieType", t => t.ModelSerieTypeId)
                .Index(t => t.ManufactorerTypeId)
                .Index(t => t.ManufactorerId)
                .Index(t => t.ModelSerieTypeId)
                .Index(t => t.ModelSerieId);
            
            CreateTable(
                "dbo.Manufactorer",
                c => new
                    {
                        ManufactorerId = c.Int(nullable: false, identity: true),
                        ManufactorerName = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.ManufactorerId);
            
            CreateTable(
                "dbo.ManufactorerType",
                c => new
                    {
                        ManufactorerTypeId = c.Int(nullable: false, identity: true),
                        ManufactorerTypeName = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.ManufactorerTypeId);
            
            CreateTable(
                "dbo.ModelSerie",
                c => new
                    {
                        ModelSerieId = c.Int(nullable: false, identity: true),
                        ModelSerieName = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.ModelSerieId);
            
            CreateTable(
                "dbo.ModelSerieType",
                c => new
                    {
                        ModelSerieTypeId = c.Int(nullable: false, identity: true),
                        ModelSerieTypeName = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.ModelSerieTypeId);
            
            CreateTable(
                "dbo.Player",
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
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PlayerId)
                .ForeignKey("dbo.Team", t => t.TeamId)
                .ForeignKey("dbo.Map", t => t.MapId)
                .ForeignKey("dbo.UserInt", t => t.UserId)
                .Index(t => t.MapId)
                .Index(t => t.TeamId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Map",
                c => new
                    {
                        MapId = c.Int(nullable: false, identity: true),
                        MapName = c.String(nullable: false, maxLength: 64),
                    })
                .PrimaryKey(t => t.MapId);
            
            CreateTable(
                "dbo.MapInfo",
                c => new
                    {
                        MapInfoId = c.Int(nullable: false, identity: true),
                        MapId = c.Int(nullable: false),
                        MatchId = c.Int(nullable: false),
                        FirstTeamScore = c.Int(nullable: false),
                        SecondTeamScore = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MapInfoId)
                .ForeignKey("dbo.Map", t => t.MapId)
                .ForeignKey("dbo.Match", t => t.MatchId)
                .Index(t => t.MapId)
                .Index(t => t.MatchId);
            
            CreateTable(
                "dbo.Match",
                c => new
                    {
                        MatchId = c.Int(nullable: false, identity: true),
                        FirstTeamId = c.Int(nullable: false),
                        SecondTeamId = c.Int(nullable: false),
                        DateTime = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        Date = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        Time = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                    })
                .PrimaryKey(t => t.MatchId)
                .ForeignKey("dbo.Team", t => t.FirstTeamId)
                .ForeignKey("dbo.Team", t => t.SecondTeamId)
                .Index(t => t.FirstTeamId)
                .Index(t => t.SecondTeamId);
            
            CreateTable(
                "dbo.Team",
                c => new
                    {
                        TeamId = c.Int(nullable: false, identity: true),
                        TeamName = c.String(nullable: false, maxLength: 64),
                        TeamAbbreviation = c.String(nullable: false, maxLength: 10),
                    })
                .PrimaryKey(t => t.TeamId);
            
            CreateTable(
                "dbo.GameSpecification",
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
                .ForeignKey("dbo.Player", t => t.PlayerId)
                .Index(t => t.PlayerId);
            
            CreateTable(
                "dbo.UserInt",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(precision: 7, storeType: "datetime2"),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                        FirstName = c.String(maxLength: 128),
                        LastName = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.UserClaimInt",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.UserInt", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.UserLoginInt",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.UserInt", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.UserRoleInt",
                c => new
                    {
                        UserId = c.Int(nullable: false),
                        RoleId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.RoleInt", t => t.RoleId)
                .ForeignKey("dbo.UserInt", t => t.UserId)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.RoleInt",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Player", "UserId", "dbo.UserInt");
            DropForeignKey("dbo.UserRoleInt", "UserId", "dbo.UserInt");
            DropForeignKey("dbo.UserRoleInt", "RoleId", "dbo.RoleInt");
            DropForeignKey("dbo.UserLoginInt", "UserId", "dbo.UserInt");
            DropForeignKey("dbo.UserClaimInt", "UserId", "dbo.UserInt");
            DropForeignKey("dbo.GameSpecification", "PlayerId", "dbo.Player");
            DropForeignKey("dbo.Player", "MapId", "dbo.Map");
            DropForeignKey("dbo.Match", "SecondTeamId", "dbo.Team");
            DropForeignKey("dbo.MapInfo", "MatchId", "dbo.Match");
            DropForeignKey("dbo.Match", "FirstTeamId", "dbo.Team");
            DropForeignKey("dbo.Player", "TeamId", "dbo.Team");
            DropForeignKey("dbo.MapInfo", "MapId", "dbo.Map");
            DropForeignKey("dbo.ComputerSpecification", "PlayerId", "dbo.Player");
            DropForeignKey("dbo.PieceInComputer", "ProductSelectorId", "dbo.ProductSelector");
            DropForeignKey("dbo.ProductSelector", "ModelSerieTypeId", "dbo.ModelSerieType");
            DropForeignKey("dbo.ProductSelector", "ModelSerieId", "dbo.ModelSerie");
            DropForeignKey("dbo.ProductSelector", "ManufactorerTypeId", "dbo.ManufactorerType");
            DropForeignKey("dbo.ProductSelector", "ManufactorerId", "dbo.Manufactorer");
            DropForeignKey("dbo.PieceInComputer", "CompSpecId", "dbo.ComputerSpecification");
            DropForeignKey("dbo.Article", "ArticleHeadlineId", "dbo.MultiLangString");
            DropForeignKey("dbo.Article", "ArticleBodyId", "dbo.MultiLangString");
            DropForeignKey("dbo.Translation", "MultiLangStringId", "dbo.MultiLangString");
            DropIndex("dbo.RoleInt", "RoleNameIndex");
            DropIndex("dbo.UserRoleInt", new[] { "RoleId" });
            DropIndex("dbo.UserRoleInt", new[] { "UserId" });
            DropIndex("dbo.UserLoginInt", new[] { "UserId" });
            DropIndex("dbo.UserClaimInt", new[] { "UserId" });
            DropIndex("dbo.UserInt", "UserNameIndex");
            DropIndex("dbo.GameSpecification", new[] { "PlayerId" });
            DropIndex("dbo.Match", new[] { "SecondTeamId" });
            DropIndex("dbo.Match", new[] { "FirstTeamId" });
            DropIndex("dbo.MapInfo", new[] { "MatchId" });
            DropIndex("dbo.MapInfo", new[] { "MapId" });
            DropIndex("dbo.Player", new[] { "UserId" });
            DropIndex("dbo.Player", new[] { "TeamId" });
            DropIndex("dbo.Player", new[] { "MapId" });
            DropIndex("dbo.ProductSelector", new[] { "ModelSerieId" });
            DropIndex("dbo.ProductSelector", new[] { "ModelSerieTypeId" });
            DropIndex("dbo.ProductSelector", new[] { "ManufactorerId" });
            DropIndex("dbo.ProductSelector", new[] { "ManufactorerTypeId" });
            DropIndex("dbo.PieceInComputer", new[] { "CompSpecId" });
            DropIndex("dbo.PieceInComputer", new[] { "ProductSelectorId" });
            DropIndex("dbo.ComputerSpecification", new[] { "PlayerId" });
            DropIndex("dbo.Translation", new[] { "MultiLangStringId" });
            DropIndex("dbo.Article", new[] { "ArticleBodyId" });
            DropIndex("dbo.Article", new[] { "ArticleHeadlineId" });
            DropTable("dbo.RoleInt");
            DropTable("dbo.UserRoleInt");
            DropTable("dbo.UserLoginInt");
            DropTable("dbo.UserClaimInt");
            DropTable("dbo.UserInt");
            DropTable("dbo.GameSpecification");
            DropTable("dbo.Team");
            DropTable("dbo.Match");
            DropTable("dbo.MapInfo");
            DropTable("dbo.Map");
            DropTable("dbo.Player");
            DropTable("dbo.ModelSerieType");
            DropTable("dbo.ModelSerie");
            DropTable("dbo.ManufactorerType");
            DropTable("dbo.Manufactorer");
            DropTable("dbo.ProductSelector");
            DropTable("dbo.PieceInComputer");
            DropTable("dbo.ComputerSpecification");
            DropTable("dbo.Translation");
            DropTable("dbo.MultiLangString");
            DropTable("dbo.Article");
        }
    }
}
