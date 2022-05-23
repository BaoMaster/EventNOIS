using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Event2206.Data.Migrations
{
    public partial class addisNOISCustomercolumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "isNOISCustomer",
                table: "Users",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isNOISCustomer",
                table: "Users");
        }
    }
}
