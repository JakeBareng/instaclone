using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace instaclone.Migrations.SocialMedia
{
    /// <inheritdoc />
    public partial class RemovedTitlePropertyPost : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Title",
                table: "Posts");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Posts",
                type: "text",
                nullable: true);
        }
    }
}
