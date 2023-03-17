using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PostHive.Migrations
{
    public partial class switchedToFluentApi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Comments_RepliedToCommentId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Users_AuthorId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Users_AuthorId",
                table: "Posts");

            migrationBuilder.CreateTable(
                name: "UserDownvotedComments",
                columns: table => new
                {
                    DownvotedById = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DownvotedCommentsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserDownvotedComments", x => new { x.DownvotedById, x.DownvotedCommentsId });
                    table.ForeignKey(
                        name: "FK_UserDownvotedComments_Comments_DownvotedCommentsId",
                        column: x => x.DownvotedCommentsId,
                        principalTable: "Comments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserDownvotedComments_Users_DownvotedById",
                        column: x => x.DownvotedById,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserDownvotedPosts",
                columns: table => new
                {
                    DownvotedById = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DownvotedPostsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserDownvotedPosts", x => new { x.DownvotedById, x.DownvotedPostsId });
                    table.ForeignKey(
                        name: "FK_UserDownvotedPosts_Posts_DownvotedPostsId",
                        column: x => x.DownvotedPostsId,
                        principalTable: "Posts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserDownvotedPosts_Users_DownvotedById",
                        column: x => x.DownvotedById,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserUpvotedComments",
                columns: table => new
                {
                    UpvotedById = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UpvotedCommentsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserUpvotedComments", x => new { x.UpvotedById, x.UpvotedCommentsId });
                    table.ForeignKey(
                        name: "FK_UserUpvotedComments_Comments_UpvotedCommentsId",
                        column: x => x.UpvotedCommentsId,
                        principalTable: "Comments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserUpvotedComments_Users_UpvotedById",
                        column: x => x.UpvotedById,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserUpvotedPosts",
                columns: table => new
                {
                    UpvotedById = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UpvotedPostsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserUpvotedPosts", x => new { x.UpvotedById, x.UpvotedPostsId });
                    table.ForeignKey(
                        name: "FK_UserUpvotedPosts_Posts_UpvotedPostsId",
                        column: x => x.UpvotedPostsId,
                        principalTable: "Posts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserUpvotedPosts_Users_UpvotedById",
                        column: x => x.UpvotedById,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserDownvotedComments_DownvotedCommentsId",
                table: "UserDownvotedComments",
                column: "DownvotedCommentsId");

            migrationBuilder.CreateIndex(
                name: "IX_UserDownvotedPosts_DownvotedPostsId",
                table: "UserDownvotedPosts",
                column: "DownvotedPostsId");

            migrationBuilder.CreateIndex(
                name: "IX_UserUpvotedComments_UpvotedCommentsId",
                table: "UserUpvotedComments",
                column: "UpvotedCommentsId");

            migrationBuilder.CreateIndex(
                name: "IX_UserUpvotedPosts_UpvotedPostsId",
                table: "UserUpvotedPosts",
                column: "UpvotedPostsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Comments_RepliedToCommentId",
                table: "Comments",
                column: "RepliedToCommentId",
                principalTable: "Comments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Users_AuthorId",
                table: "Comments",
                column: "AuthorId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Users_AuthorId",
                table: "Posts",
                column: "AuthorId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Comments_RepliedToCommentId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Users_AuthorId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Users_AuthorId",
                table: "Posts");

            migrationBuilder.DropTable(
                name: "UserDownvotedComments");

            migrationBuilder.DropTable(
                name: "UserDownvotedPosts");

            migrationBuilder.DropTable(
                name: "UserUpvotedComments");

            migrationBuilder.DropTable(
                name: "UserUpvotedPosts");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Comments_RepliedToCommentId",
                table: "Comments",
                column: "RepliedToCommentId",
                principalTable: "Comments",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Users_AuthorId",
                table: "Comments",
                column: "AuthorId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Users_AuthorId",
                table: "Posts",
                column: "AuthorId",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}
