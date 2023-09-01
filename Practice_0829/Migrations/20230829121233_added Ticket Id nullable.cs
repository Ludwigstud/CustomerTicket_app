using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Practice_0829.Migrations
{
    /// <inheritdoc />
    public partial class addedTicketIdnullable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Ticket_TicketId",
                table: "Customers");

            migrationBuilder.AlterColumn<int>(
                name: "TicketId",
                table: "Customers",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_Ticket_TicketId",
                table: "Customers",
                column: "TicketId",
                principalTable: "Ticket",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Ticket_TicketId",
                table: "Customers");

            migrationBuilder.AlterColumn<int>(
                name: "TicketId",
                table: "Customers",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_Ticket_TicketId",
                table: "Customers",
                column: "TicketId",
                principalTable: "Ticket",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
