using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace instaclone.Migrations.SocialMedia
{
    /// <inheritdoc />
    public partial class userame : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserCreatedUsername",
                table: "InstaCloneUser",
                newName: "userCreatedUsername");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "userCreatedUsername",
                table: "InstaCloneUser",
                newName: "UserCreatedUsername");
        }
    }
}
