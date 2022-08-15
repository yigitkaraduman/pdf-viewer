using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PDFViewer.Migrations
{
    public partial class InıtalRecreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SvgAccessModels",
                columns: table => new
                {
                    User = table.Column<string>(type: "TEXT", nullable: false),
                    PrintSvcUrl = table.Column<string>(type: "TEXT", nullable: false),
                    AuthSvcUrl = table.Column<string>(type: "TEXT", nullable: false),
                    CevreSistem = table.Column<string>(type: "TEXT", nullable: false),
                    SirketID = table.Column<string>(type: "TEXT", nullable: false),
                    Password = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SvgAccessModels", x => x.User);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SvgAccessModels");
        }
    }
}
