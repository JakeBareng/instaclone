using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace instaclone.Migrations.SocialMedia
{
    /// <inheritdoc />
    public partial class namechange : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "userCreatedUsername",
                table: "InstaCloneUser",
                newName: "UserCreatedUsername");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserCreatedUsername",
                table: "InstaCloneUser",
                newName: "userCreatedUsername");
        }
    }
}
