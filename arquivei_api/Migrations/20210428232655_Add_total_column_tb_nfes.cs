using Microsoft.EntityFrameworkCore.Migrations;

namespace arquivei_api.Migrations
{
    public partial class Add_total_column_tb_nfes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Total",
                table: "Nfes",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Total",
                table: "Nfes");
        }
    }
}
