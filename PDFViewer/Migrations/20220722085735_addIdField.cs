using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PDFViewer.Migrations
{
    public partial class addIdField : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "SvgAccessModels",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Id",
                table: "SvgAccessModels");
        }
    }
}
