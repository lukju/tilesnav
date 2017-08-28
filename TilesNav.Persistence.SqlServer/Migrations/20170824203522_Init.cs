using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace TilesNav.Persistence.SqlServer.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TileDatasource",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Endpoint = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Secret = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TileDatasource", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "TileRenderer",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Secret = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TileRenderer", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "TilesViews",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TilesViews", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "TileDefinitions",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DatasourceId = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Icon = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RendererId = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TileDefinitions", x => x.ID);
                    table.ForeignKey(
                        name: "FK_TileDefinitions_TileDatasource_DatasourceId",
                        column: x => x.DatasourceId,
                        principalTable: "TileDatasource",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TileDefinitions_TileRenderer_RendererId",
                        column: x => x.RendererId,
                        principalTable: "TileRenderer",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TilesViewContainer",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TilesViewID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TilesViewContainer", x => x.ID);
                    table.ForeignKey(
                        name: "FK_TilesViewContainer_TilesViews_TilesViewID",
                        column: x => x.TilesViewID,
                        principalTable: "TilesViews",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TilesViewItem",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DefinitionID = table.Column<int>(type: "int", nullable: false),
                    Height = table.Column<int>(type: "int", nullable: false),
                    TilesViewContainerID = table.Column<int>(type: "int", nullable: true),
                    Width = table.Column<int>(type: "int", nullable: false),
                    X = table.Column<int>(type: "int", nullable: false),
                    Y = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TilesViewItem", x => x.ID);
                    table.ForeignKey(
                        name: "FK_TilesViewItem_TileDefinitions_DefinitionID",
                        column: x => x.DefinitionID,
                        principalTable: "TileDefinitions",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TilesViewItem_TilesViewContainer_TilesViewContainerID",
                        column: x => x.TilesViewContainerID,
                        principalTable: "TilesViewContainer",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TileDefinitions_DatasourceId",
                table: "TileDefinitions",
                column: "DatasourceId");

            migrationBuilder.CreateIndex(
                name: "IX_TileDefinitions_RendererId",
                table: "TileDefinitions",
                column: "RendererId");

            migrationBuilder.CreateIndex(
                name: "IX_TilesViewContainer_TilesViewID",
                table: "TilesViewContainer",
                column: "TilesViewID");

            migrationBuilder.CreateIndex(
                name: "IX_TilesViewItem_DefinitionID",
                table: "TilesViewItem",
                column: "DefinitionID");

            migrationBuilder.CreateIndex(
                name: "IX_TilesViewItem_TilesViewContainerID",
                table: "TilesViewItem",
                column: "TilesViewContainerID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TilesViewItem");

            migrationBuilder.DropTable(
                name: "TileDefinitions");

            migrationBuilder.DropTable(
                name: "TilesViewContainer");

            migrationBuilder.DropTable(
                name: "TileDatasource");

            migrationBuilder.DropTable(
                name: "TileRenderer");

            migrationBuilder.DropTable(
                name: "TilesViews");
        }
    }
}
