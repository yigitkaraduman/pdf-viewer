using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PDFViewer.Migrations
{
    public partial class keyUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_SvgAccessModels",
                table: "SvgAccessModels");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "SvgAccessModels",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_SvgAccessModels",
                table: "SvgAccessModels",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_SvgAccessModels",
                table: "SvgAccessModels");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "SvgAccessModels",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .OldAnnotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_SvgAccessModels",
                table: "SvgAccessModels",
                column: "User");
        }
    }
}
