using Microsoft.EntityFrameworkCore.Migrations;

namespace Application.Data.Migrations
{
    public partial class CommentNewProperties : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_AspNetUsers_ToUserId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Posts_PostId",
                table: "Comments");

            migrationBuilder.RenameColumn(
                name: "ToUserId",
                table: "Comments",
                newName: "ToImageId");

            migrationBuilder.RenameColumn(
                name: "PostId",
                table: "Comments",
                newName: "ToPostId");

            migrationBuilder.RenameIndex(
                name: "IX_Comments_ToUserId",
                table: "Comments",
                newName: "IX_Comments_ToImageId");

            migrationBuilder.RenameIndex(
                name: "IX_Comments_PostId",
                table: "Comments",
                newName: "IX_Comments_ToPostId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Images_ToImageId",
                table: "Comments",
                column: "ToImageId",
                principalTable: "Images",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Posts_ToPostId",
                table: "Comments",
                column: "ToPostId",
                principalTable: "Posts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Images_ToImageId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Posts_ToPostId",
                table: "Comments");

            migrationBuilder.RenameColumn(
                name: "ToPostId",
                table: "Comments",
                newName: "PostId");

            migrationBuilder.RenameColumn(
                name: "ToImageId",
                table: "Comments",
                newName: "ToUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Comments_ToPostId",
                table: "Comments",
                newName: "IX_Comments_PostId");

            migrationBuilder.RenameIndex(
                name: "IX_Comments_ToImageId",
                table: "Comments",
                newName: "IX_Comments_ToUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_AspNetUsers_ToUserId",
                table: "Comments",
                column: "ToUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Posts_PostId",
                table: "Comments",
                column: "PostId",
                principalTable: "Posts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
