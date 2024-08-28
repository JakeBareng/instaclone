using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace instaclone.Migrations
{
    /// <inheritdoc />
    public partial class tablenamechange : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserClaims_InstaCloneUsers_UserId",
                table: "AspNetUserClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserLogins_InstaCloneUsers_UserId",
                table: "AspNetUserLogins");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserRoles_InstaCloneUsers_UserId",
                table: "AspNetUserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserTokens_InstaCloneUsers_UserId",
                table: "AspNetUserTokens");

            migrationBuilder.DropPrimaryKey(
                name: "PK_InstaCloneUsers",
                table: "InstaCloneUsers");

            migrationBuilder.RenameTable(
                name: "InstaCloneUsers",
                newName: "InstaCloneUser");

            migrationBuilder.AddPrimaryKey(
                name: "PK_InstaCloneUser",
                table: "InstaCloneUser",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserClaims_InstaCloneUser_UserId",
                table: "AspNetUserClaims",
                column: "UserId",
                principalTable: "InstaCloneUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserLogins_InstaCloneUser_UserId",
                table: "AspNetUserLogins",
                column: "UserId",
                principalTable: "InstaCloneUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserRoles_InstaCloneUser_UserId",
                table: "AspNetUserRoles",
                column: "UserId",
                principalTable: "InstaCloneUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserTokens_InstaCloneUser_UserId",
                table: "AspNetUserTokens",
                column: "UserId",
                principalTable: "InstaCloneUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserClaims_InstaCloneUser_UserId",
                table: "AspNetUserClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserLogins_InstaCloneUser_UserId",
                table: "AspNetUserLogins");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserRoles_InstaCloneUser_UserId",
                table: "AspNetUserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserTokens_InstaCloneUser_UserId",
                table: "AspNetUserTokens");

            migrationBuilder.DropPrimaryKey(
                name: "PK_InstaCloneUser",
                table: "InstaCloneUser");

            migrationBuilder.RenameTable(
                name: "InstaCloneUser",
                newName: "InstaCloneUsers");

            migrationBuilder.AddPrimaryKey(
                name: "PK_InstaCloneUsers",
                table: "InstaCloneUsers",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserClaims_InstaCloneUsers_UserId",
                table: "AspNetUserClaims",
                column: "UserId",
                principalTable: "InstaCloneUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserLogins_InstaCloneUsers_UserId",
                table: "AspNetUserLogins",
                column: "UserId",
                principalTable: "InstaCloneUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserRoles_InstaCloneUsers_UserId",
                table: "AspNetUserRoles",
                column: "UserId",
                principalTable: "InstaCloneUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserTokens_InstaCloneUsers_UserId",
                table: "AspNetUserTokens",
                column: "UserId",
                principalTable: "InstaCloneUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
