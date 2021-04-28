using Microsoft.EntityFrameworkCore.Migrations;

namespace arquivei_api.Migrations
{
    public partial class remove_id_from_nfe : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Nfes",
                table: "Nfes");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Nfes");

            migrationBuilder.AlterColumn<string>(
                name: "AccessKey",
                table: "Nfes",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Nfes",
                table: "Nfes",
                column: "AccessKey");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Nfes",
                table: "Nfes");

            migrationBuilder.AlterColumn<string>(
                name: "AccessKey",
                table: "Nfes",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Nfes",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Nfes",
                table: "Nfes",
                column: "Id");
        }
    }
}
