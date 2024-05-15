using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bit2C.Data.Migrations
{
    public partial class createnewUserOrderupt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "UserOrders",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserOrders",
                table: "UserOrders",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_UserOrders",
                table: "UserOrders");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "UserOrders");
        }
    }
}
