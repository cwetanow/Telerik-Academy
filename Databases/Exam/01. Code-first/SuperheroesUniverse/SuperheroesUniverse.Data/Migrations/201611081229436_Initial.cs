namespace SuperheroesUniverse.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cities",
                c => new
                    {
                        CityId = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 30),
                        CountryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CityId)
                .ForeignKey("dbo.Countries", t => t.CountryId, cascadeDelete: true)
                .Index(t => t.Name, unique: true)
                .Index(t => t.CountryId);
            
            CreateTable(
                "dbo.Countries",
                c => new
                    {
                        CountryId = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 30),
                        PlanetId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CountryId)
                .ForeignKey("dbo.Planets", t => t.PlanetId, cascadeDelete: true)
                .Index(t => t.Name, unique: true)
                .Index(t => t.PlanetId);
            
            CreateTable(
                "dbo.Planets",
                c => new
                    {
                        PlanetId = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 30),
                    })
                .PrimaryKey(t => t.PlanetId)
                .Index(t => t.Name, unique: true);
            
            CreateTable(
                "dbo.Fractions",
                c => new
                    {
                        FractionId = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 30),
                        Alignment = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.FractionId)
                .Index(t => t.Name, unique: true);
            
            CreateTable(
                "dbo.Superheroes",
                c => new
                    {
                        SuperheroId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 60),
                        SecretIdentity = c.String(nullable: false, maxLength: 20),
                        Alignment = c.Int(nullable: false),
                        Story = c.String(nullable: false),
                        CityId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SuperheroId)
                .ForeignKey("dbo.Cities", t => t.CityId, cascadeDelete: true)
                .Index(t => t.SecretIdentity, unique: true)
                .Index(t => t.CityId);
            
            CreateTable(
                "dbo.Powers",
                c => new
                    {
                        PowerId = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 35),
                    })
                .PrimaryKey(t => t.PowerId)
                .Index(t => t.Name, unique: true);
            
            CreateTable(
                "dbo.Relationships",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RelationshipType = c.Int(nullable: false),
                        FirstSuperhero_SuperheroId = c.Int(),
                        SecondSuperhero_SuperheroId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Superheroes", t => t.FirstSuperhero_SuperheroId)
                .ForeignKey("dbo.Superheroes", t => t.SecondSuperhero_SuperheroId)
                .Index(t => t.FirstSuperhero_SuperheroId)
                .Index(t => t.SecondSuperhero_SuperheroId);
            
            CreateTable(
                "dbo.FractionPlanets",
                c => new
                    {
                        Fraction_FractionId = c.Int(nullable: false),
                        Planet_PlanetId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Fraction_FractionId, t.Planet_PlanetId })
                .ForeignKey("dbo.Fractions", t => t.Fraction_FractionId, cascadeDelete: true)
                .ForeignKey("dbo.Planets", t => t.Planet_PlanetId, cascadeDelete: true)
                .Index(t => t.Fraction_FractionId)
                .Index(t => t.Planet_PlanetId);
            
            CreateTable(
                "dbo.SuperheroFractions",
                c => new
                    {
                        Superhero_SuperheroId = c.Int(nullable: false),
                        Fraction_FractionId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Superhero_SuperheroId, t.Fraction_FractionId })
                .ForeignKey("dbo.Superheroes", t => t.Superhero_SuperheroId, cascadeDelete: true)
                .ForeignKey("dbo.Fractions", t => t.Fraction_FractionId, cascadeDelete: true)
                .Index(t => t.Superhero_SuperheroId)
                .Index(t => t.Fraction_FractionId);
            
            CreateTable(
                "dbo.PowerSuperheroes",
                c => new
                    {
                        Power_PowerId = c.Int(nullable: false),
                        Superhero_SuperheroId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Power_PowerId, t.Superhero_SuperheroId })
                .ForeignKey("dbo.Powers", t => t.Power_PowerId, cascadeDelete: true)
                .ForeignKey("dbo.Superheroes", t => t.Superhero_SuperheroId, cascadeDelete: true)
                .Index(t => t.Power_PowerId)
                .Index(t => t.Superhero_SuperheroId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Relationships", "SecondSuperhero_SuperheroId", "dbo.Superheroes");
            DropForeignKey("dbo.Relationships", "FirstSuperhero_SuperheroId", "dbo.Superheroes");
            DropForeignKey("dbo.Cities", "CountryId", "dbo.Countries");
            DropForeignKey("dbo.Countries", "PlanetId", "dbo.Planets");
            DropForeignKey("dbo.PowerSuperheroes", "Superhero_SuperheroId", "dbo.Superheroes");
            DropForeignKey("dbo.PowerSuperheroes", "Power_PowerId", "dbo.Powers");
            DropForeignKey("dbo.SuperheroFractions", "Fraction_FractionId", "dbo.Fractions");
            DropForeignKey("dbo.SuperheroFractions", "Superhero_SuperheroId", "dbo.Superheroes");
            DropForeignKey("dbo.Superheroes", "CityId", "dbo.Cities");
            DropForeignKey("dbo.FractionPlanets", "Planet_PlanetId", "dbo.Planets");
            DropForeignKey("dbo.FractionPlanets", "Fraction_FractionId", "dbo.Fractions");
            DropIndex("dbo.PowerSuperheroes", new[] { "Superhero_SuperheroId" });
            DropIndex("dbo.PowerSuperheroes", new[] { "Power_PowerId" });
            DropIndex("dbo.SuperheroFractions", new[] { "Fraction_FractionId" });
            DropIndex("dbo.SuperheroFractions", new[] { "Superhero_SuperheroId" });
            DropIndex("dbo.FractionPlanets", new[] { "Planet_PlanetId" });
            DropIndex("dbo.FractionPlanets", new[] { "Fraction_FractionId" });
            DropIndex("dbo.Relationships", new[] { "SecondSuperhero_SuperheroId" });
            DropIndex("dbo.Relationships", new[] { "FirstSuperhero_SuperheroId" });
            DropIndex("dbo.Powers", new[] { "Name" });
            DropIndex("dbo.Superheroes", new[] { "CityId" });
            DropIndex("dbo.Superheroes", new[] { "SecretIdentity" });
            DropIndex("dbo.Fractions", new[] { "Name" });
            DropIndex("dbo.Planets", new[] { "Name" });
            DropIndex("dbo.Countries", new[] { "PlanetId" });
            DropIndex("dbo.Countries", new[] { "Name" });
            DropIndex("dbo.Cities", new[] { "CountryId" });
            DropIndex("dbo.Cities", new[] { "Name" });
            DropTable("dbo.PowerSuperheroes");
            DropTable("dbo.SuperheroFractions");
            DropTable("dbo.FractionPlanets");
            DropTable("dbo.Relationships");
            DropTable("dbo.Powers");
            DropTable("dbo.Superheroes");
            DropTable("dbo.Fractions");
            DropTable("dbo.Planets");
            DropTable("dbo.Countries");
            DropTable("dbo.Cities");
        }
    }
}
