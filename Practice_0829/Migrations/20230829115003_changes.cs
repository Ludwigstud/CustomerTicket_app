using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Practice_0829.Migrations
{
    /// <inheritdoc />
    public partial class changes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Ticket_AssignedTicketId",
                table: "Customers");

            migrationBuilder.DropIndex(
                name: "IX_Customers_AssignedTicketId",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "AssignedTicketId",
                table: "Customers");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_TicketId",
                table: "Customers",
                column: "TicketId");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_Ticket_TicketId",
                table: "Customers",
                column: "TicketId",
                principalTable: "Ticket",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Ticket_TicketId",
                table: "Customers");

            migrationBuilder.DropIndex(
                name: "IX_Customers_TicketId",
                table: "Customers");

            migrationBuilder.AddColumn<int>(
                name: "AssignedTicketId",
                table: "Customers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Customers_AssignedTicketId",
                table: "Customers",
                column: "AssignedTicketId");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_Ticket_AssignedTicketId",
                table: "Customers",
                column: "AssignedTicketId",
                principalTable: "Ticket",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
