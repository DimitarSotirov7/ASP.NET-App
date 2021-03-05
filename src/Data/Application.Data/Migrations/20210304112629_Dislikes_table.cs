using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Application.Data.Migrations
{
    public partial class Dislikes_table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Dislikes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FromUserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ToCommentId = table.Column<int>(type: "int", nullable: true),
                    ToImageId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ToMessageId = table.Column<int>(type: "int", nullable: true),
                    ToPostId = table.Column<int>(type: "int", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dislikes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Dislikes_AspNetUsers_FromUserId",
                        column: x => x.FromUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Dislikes_Comments_ToCommentId",
                        column: x => x.ToCommentId,
                        principalTable: "Comments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Dislikes_Images_ToImageId",
                        column: x => x.ToImageId,
                        principalTable: "Images",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Dislikes_Messages_ToMessageId",
                        column: x => x.ToMessageId,
                        principalTable: "Messages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Dislikes_Posts_ToPostId",
                        column: x => x.ToPostId,
                        principalTable: "Posts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Dislikes_FromUserId",
                table: "Dislikes",
                column: "FromUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Dislikes_ToCommentId",
                table: "Dislikes",
                column: "ToCommentId");

            migrationBuilder.CreateIndex(
                name: "IX_Dislikes_ToImageId",
                table: "Dislikes",
                column: "ToImageId");

            migrationBuilder.CreateIndex(
                name: "IX_Dislikes_ToMessageId",
                table: "Dislikes",
                column: "ToMessageId");

            migrationBuilder.CreateIndex(
                name: "IX_Dislikes_ToPostId",
                table: "Dislikes",
                column: "ToPostId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Dislikes");
        }
    }
}
