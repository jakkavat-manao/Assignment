using Microsoft.EntityFrameworkCore.Migrations;

namespace Assignment.Migrations
{
    public partial class RenameTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TransactionsDbSet_CustomersDbSet_CustomerId",
                table: "TransactionsDbSet");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TransactionsDbSet",
                table: "TransactionsDbSet");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CustomersDbSet",
                table: "CustomersDbSet");

            migrationBuilder.RenameTable(
                name: "TransactionsDbSet",
                newName: "Transactions");

            migrationBuilder.RenameTable(
                name: "CustomersDbSet",
                newName: "Customers");

            migrationBuilder.RenameIndex(
                name: "IX_TransactionsDbSet_CustomerId",
                table: "Transactions",
                newName: "IX_Transactions_CustomerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Transactions",
                table: "Transactions",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Customers",
                table: "Customers",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_Customers_CustomerId",
                table: "Transactions",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_Customers_CustomerId",
                table: "Transactions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Transactions",
                table: "Transactions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Customers",
                table: "Customers");

            migrationBuilder.RenameTable(
                name: "Transactions",
                newName: "TransactionsDbSet");

            migrationBuilder.RenameTable(
                name: "Customers",
                newName: "CustomersDbSet");

            migrationBuilder.RenameIndex(
                name: "IX_Transactions_CustomerId",
                table: "TransactionsDbSet",
                newName: "IX_TransactionsDbSet_CustomerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TransactionsDbSet",
                table: "TransactionsDbSet",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CustomersDbSet",
                table: "CustomersDbSet",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TransactionsDbSet_CustomersDbSet_CustomerId",
                table: "TransactionsDbSet",
                column: "CustomerId",
                principalTable: "CustomersDbSet",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
