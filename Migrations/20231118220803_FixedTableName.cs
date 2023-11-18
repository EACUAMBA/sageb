using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace sageb.Migrations
{
    /// <inheritdoc />
    public partial class FixedTableName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookOrder_AspNetUsers_UserId",
                table: "BookOrder");

            migrationBuilder.DropForeignKey(
                name: "FK_BookOrder_Books_BookId",
                table: "BookOrder");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BookOrder",
                table: "BookOrder");

            migrationBuilder.RenameTable(
                name: "BookOrder",
                newName: "BookOrders");

            migrationBuilder.RenameIndex(
                name: "IX_BookOrder_UserId",
                table: "BookOrders",
                newName: "IX_BookOrders_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_BookOrder_BookId",
                table: "BookOrders",
                newName: "IX_BookOrders_BookId");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "BookOrders",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BookOrders",
                table: "BookOrders",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BookOrders_AspNetUsers_UserId",
                table: "BookOrders",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BookOrders_Books_BookId",
                table: "BookOrders",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookOrders_AspNetUsers_UserId",
                table: "BookOrders");

            migrationBuilder.DropForeignKey(
                name: "FK_BookOrders_Books_BookId",
                table: "BookOrders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BookOrders",
                table: "BookOrders");

            migrationBuilder.RenameTable(
                name: "BookOrders",
                newName: "BookOrder");

            migrationBuilder.RenameIndex(
                name: "IX_BookOrders_UserId",
                table: "BookOrder",
                newName: "IX_BookOrder_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_BookOrders_BookId",
                table: "BookOrder",
                newName: "IX_BookOrder_BookId");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "BookOrder",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_BookOrder",
                table: "BookOrder",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BookOrder_AspNetUsers_UserId",
                table: "BookOrder",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BookOrder_Books_BookId",
                table: "BookOrder",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "Id");
        }
    }
}
