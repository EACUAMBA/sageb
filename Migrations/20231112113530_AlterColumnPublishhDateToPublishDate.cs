using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace sageb.Migrations
{
    /// <inheritdoc />
    public partial class AlterColumnPublishhDateToPublishDate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PublishhDate",
                table: "Books",
                newName: "PublishDate");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PublishDate",
                table: "Books",
                newName: "PublishhDate");
        }
    }
}
