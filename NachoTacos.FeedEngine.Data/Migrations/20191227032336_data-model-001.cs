using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NachoTacos.FeedEngine.Data.Migrations
{
    public partial class datamodel001 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                name: "FeedSources",
                columns: table => new
                {
                    FeedUrl = table.Column<string>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: false),
                    FeedTypeCode = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FeedSources", x => x.FeedUrl);
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
                    { "RSS100", "RSS 1.0" },
                    { "RSS200", "RSS 2.0" },
                    { "ATOM", "ATOM" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_FeedSources_FeedTypeCode",
                table: "FeedSources",
                column: "FeedTypeCode");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FeedSources");

            migrationBuilder.DropTable(
                name: "FeedTypes");
        }
    }
}
