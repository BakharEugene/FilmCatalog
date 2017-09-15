namespace FilmCatalog.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Films",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        ReleaseDate = c.DateTime(nullable: false),
                        Producer = c.String(),
                        IdUser = c.Int(),
                        IdPoster = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Posters", t => t.IdPoster)
                .ForeignKey("dbo.Users", t => t.IdUser)
                .Index(t => t.IdUser)
                .Index(t => t.IdPoster);
            
            CreateTable(
                "dbo.Posters",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Path = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Email = c.String(),
                        Password = c.String(),
                        RoleId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Roles", t => t.RoleId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Films", "IdUser", "dbo.Users");
            DropForeignKey("dbo.Users", "RoleId", "dbo.Roles");
            DropForeignKey("dbo.Films", "IdPoster", "dbo.Posters");
            DropIndex("dbo.Users", new[] { "RoleId" });
            DropIndex("dbo.Films", new[] { "IdPoster" });
            DropIndex("dbo.Films", new[] { "IdUser" });
            DropTable("dbo.Roles");
            DropTable("dbo.Users");
            DropTable("dbo.Posters");
            DropTable("dbo.Films");
        }
    }
}
