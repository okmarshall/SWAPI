using Microsoft.EntityFrameworkCore.Migrations;

namespace SWAPI.Library.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "People",
                columns: table => new
                {
                    PersonId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Url = table.Column<string>(nullable: true),
                    Created = table.Column<string>(nullable: true),
                    Edited = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    BirthYear = table.Column<string>(nullable: true),
                    EyeColor = table.Column<string>(nullable: true),
                    Gender = table.Column<string>(nullable: true),
                    HairColor = table.Column<string>(nullable: true),
                    Height = table.Column<string>(nullable: true),
                    Mass = table.Column<string>(nullable: true),
                    SkinColor = table.Column<string>(nullable: true),
                    Homeworld = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_People", x => x.PersonId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "People");
        }
    }
}
