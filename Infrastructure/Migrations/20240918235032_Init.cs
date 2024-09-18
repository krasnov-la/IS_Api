using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "activities",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    Admin = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    Start = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Finish = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Preview = table.Column<Guid>(type: "uuid", nullable: false),
                    Link = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_activities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "users_info",
                columns: table => new
                {
                    EmailAddress = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    AvatarImgLink = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    Nickname = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    FirstName = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    LastName = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    MiddleName = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    Course = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    BannedBy = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: true),
                    Role = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users_info", x => x.EmailAddress);
                });

            migrationBuilder.CreateTable(
                name: "verification_requests",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Student = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    EventName = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    Description = table.Column<string>(type: "character varying(512)", maxLength: 512, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Status = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_verification_requests", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "achievements",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Admin = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    Score = table.Column<float>(type: "real", nullable: false),
                    requestId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_achievements", x => x.Id);
                    table.ForeignKey(
                        name: "FK_achievements_verification_requests_requestId",
                        column: x => x.requestId,
                        principalTable: "verification_requests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "comments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Admin = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    Message = table.Column<string>(type: "character varying(512)", maxLength: 512, nullable: false),
                    requestId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_comments_verification_requests_requestId",
                        column: x => x.requestId,
                        principalTable: "verification_requests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "images",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "uuid", nullable: false),
                    RequestId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_images", x => x.Guid);
                    table.ForeignKey(
                        name: "FK_images_verification_requests_RequestId",
                        column: x => x.RequestId,
                        principalTable: "verification_requests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_achievements_requestId",
                table: "achievements",
                column: "requestId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_comments_requestId",
                table: "comments",
                column: "requestId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_images_RequestId",
                table: "images",
                column: "RequestId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "achievements");

            migrationBuilder.DropTable(
                name: "activities");

            migrationBuilder.DropTable(
                name: "comments");

            migrationBuilder.DropTable(
                name: "images");

            migrationBuilder.DropTable(
                name: "users_info");

            migrationBuilder.DropTable(
                name: "verification_requests");
        }
    }
}
