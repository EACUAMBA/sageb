using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace sageb.Migrations
{
    /// <inheritdoc />
    public partial class FixedUserForeignKeyDataType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookOrder_AspNetUsers_UserId1",
                table: "BookOrder");

            migrationBuilder.DropIndex(
                name: "IX_BookOrder_UserId1",
                table: "BookOrder");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "BookOrder");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "BookOrder",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_BookOrder_UserId",
                table: "BookOrder",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_BookOrder_AspNetUsers_UserId",
                table: "BookOrder",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookOrder_AspNetUsers_UserId",
                table: "BookOrder");

            migrationBuilder.DropIndex(
                name: "IX_BookOrder_UserId",
                table: "BookOrder");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "BookOrder",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AddColumn<string>(
                name: "UserId1",
                table: "BookOrder",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_BookOrder_UserId1",
                table: "BookOrder",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_BookOrder_AspNetUsers_UserId1",
                table: "BookOrder",
                column: "UserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
