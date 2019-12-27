using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NachoTacos.FeedEngine.Data.Migrations
{
    public partial class datamodel01 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FeedItems",
                columns: table => new
                {
                    FeedSourceId = table.Column<Guid>(nullable: false),
                    FeedItemId = table.Column<string>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    Summary = table.Column<string>(nullable: true),
                    BaseUri = table.Column<string>(nullable: true),
                    Content = table.Column<string>(nullable: true),
                    Copyright = table.Column<string>(nullable: true),
                    PublishDate = table.Column<DateTime>(nullable: false),
                    LastUpdatedTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FeedItems", x => new { x.FeedItemId, x.FeedSourceId });
                });

            migrationBuilder.CreateTable(
                name: "FeedTypes",
                columns: table => new
                {
                    Code = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FeedTypes", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "FeedItemAuthors",
                columns: table => new
                {
                    FeedItemAuthorId = table.Column<Guid>(nullable: false),
                    FeedItemId = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Uri = table.Column<string>(nullable: true),
                    FeedItemFeedSourceId = table.Column<Guid>(nullable: true),
                    FeedItemId1 = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FeedItemAuthors", x => x.FeedItemAuthorId);
                    table.ForeignKey(
                        name: "FK_FeedItemAuthors_FeedItems_FeedItemId1_FeedItemFeedSourceId",
                        columns: x => new { x.FeedItemId1, x.FeedItemFeedSourceId },
                        principalTable: "FeedItems",
                        principalColumns: new[] { "FeedItemId", "FeedSourceId" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FeedItemCategories",
                columns: table => new
                {
                    FeedItemCategoryId = table.Column<Guid>(nullable: false),
                    FeedItemId = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Label = table.Column<string>(nullable: true),
                    Scheme = table.Column<string>(nullable: true),
                    FeedItemFeedSourceId = table.Column<Guid>(nullable: true),
                    FeedItemId1 = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FeedItemCategories", x => x.FeedItemCategoryId);
                    table.ForeignKey(
                        name: "FK_FeedItemCategories_FeedItems_FeedItemId1_FeedItemFeedSourceId",
                        columns: x => new { x.FeedItemId1, x.FeedItemFeedSourceId },
                        principalTable: "FeedItems",
                        principalColumns: new[] { "FeedItemId", "FeedSourceId" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FeedItemContributors",
                columns: table => new
                {
                    FeedItemContributorId = table.Column<Guid>(nullable: false),
                    FeedItemId = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Uri = table.Column<string>(nullable: true),
                    FeedItemFeedSourceId = table.Column<Guid>(nullable: true),
                    FeedItemId1 = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FeedItemContributors", x => x.FeedItemContributorId);
                    table.ForeignKey(
                        name: "FK_FeedItemContributors_FeedItems_FeedItemId1_FeedItemFeedSourceId",
                        columns: x => new { x.FeedItemId1, x.FeedItemFeedSourceId },
                        principalTable: "FeedItems",
                        principalColumns: new[] { "FeedItemId", "FeedSourceId" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FeedItemLinks",
                columns: table => new
                {
                    FeedItemLinkId = table.Column<Guid>(nullable: false),
                    FeedItemId = table.Column<string>(nullable: true),
                    Title = table.Column<string>(nullable: true),
                    Url = table.Column<string>(nullable: true),
                    MediaType = table.Column<string>(nullable: true),
                    RelationshipType = table.Column<string>(nullable: true),
                    FeedItemFeedSourceId = table.Column<Guid>(nullable: true),
                    FeedItemId1 = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FeedItemLinks", x => x.FeedItemLinkId);
                    table.ForeignKey(
                        name: "FK_FeedItemLinks_FeedItems_FeedItemId1_FeedItemFeedSourceId",
                        columns: x => new { x.FeedItemId1, x.FeedItemFeedSourceId },
                        principalTable: "FeedItems",
                        principalColumns: new[] { "FeedItemId", "FeedSourceId" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FeedSources",
                columns: table => new
                {
                    FeedSourceId = table.Column<Guid>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: false),
                    FeedUrl = table.Column<string>(nullable: false),
                    FeedTypeCode = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FeedSources", x => x.FeedSourceId);
                    table.ForeignKey(
                        name: "FK_FeedSources_FeedTypes_FeedTypeCode",
                        column: x => x.FeedTypeCode,
                        principalTable: "FeedTypes",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "FeedTypes",
                columns: new[] { "Code", "Description" },
                values: new object[,]
                {
                    { "RSS091", "RSS 0.91" },
                    { "RSS092", "RSS 0.92" },
                    { "RSS1", "RSS 1.0" },
                    { "RSS2", "RSS 2.0" },
                    { "ATOM", "ATOM" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_FeedItemAuthors_FeedItemId1_FeedItemFeedSourceId",
                table: "FeedItemAuthors",
                columns: new[] { "FeedItemId1", "FeedItemFeedSourceId" });

            migrationBuilder.CreateIndex(
                name: "IX_FeedItemCategories_FeedItemId1_FeedItemFeedSourceId",
                table: "FeedItemCategories",
                columns: new[] { "FeedItemId1", "FeedItemFeedSourceId" });

            migrationBuilder.CreateIndex(
                name: "IX_FeedItemContributors_FeedItemId1_FeedItemFeedSourceId",
                table: "FeedItemContributors",
                columns: new[] { "FeedItemId1", "FeedItemFeedSourceId" });

            migrationBuilder.CreateIndex(
                name: "IX_FeedItemLinks_FeedItemId1_FeedItemFeedSourceId",
                table: "FeedItemLinks",
                columns: new[] { "FeedItemId1", "FeedItemFeedSourceId" });

            migrationBuilder.CreateIndex(
                name: "IX_FeedSources_FeedTypeCode",
                table: "FeedSources",
                column: "FeedTypeCode");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FeedItemAuthors");

            migrationBuilder.DropTable(
                name: "FeedItemCategories");

            migrationBuilder.DropTable(
                name: "FeedItemContributors");

            migrationBuilder.DropTable(
                name: "FeedItemLinks");

            migrationBuilder.DropTable(
                name: "FeedSources");

            migrationBuilder.DropTable(
                name: "FeedItems");

            migrationBuilder.DropTable(
                name: "FeedTypes");
        }
    }
}
