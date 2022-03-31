using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Api.Migrations
{
    public partial class transpostfee : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TotalFee",
                table: "TransportFee");

            migrationBuilder.AddColumn<string>(
                name: "Money",
                table: "TransportFee",
                type: "int",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Money",
                table: "TransportFee");

            migrationBuilder.AddColumn<int>(
                name: "TotalFee",
                table: "TransportFee",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
