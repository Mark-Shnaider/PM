using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PM.DAL.Migrations
{
    public partial class AddManyToManyRelationForWorkers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Workers_Projects_ProjectId",
                table: "Workers");

            migrationBuilder.DropForeignKey(
                name: "FK_Workers_Projects_ProjectId1",
                table: "Workers");

            migrationBuilder.DropIndex(
                name: "IX_Workers_ProjectId",
                table: "Workers");

            migrationBuilder.DropIndex(
                name: "IX_Workers_ProjectId1",
                table: "Workers");

            migrationBuilder.DropColumn(
                name: "ProjectId",
                table: "Workers");

            migrationBuilder.DropColumn(
                name: "ProjectId1",
                table: "Workers");

            migrationBuilder.CreateTable(
                name: "ProjectWorker",
                columns: table => new
                {
                    ProjectsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    WorkersId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectWorker", x => new { x.ProjectsId, x.WorkersId });
                    table.ForeignKey(
                        name: "FK_ProjectWorker_Projects_ProjectsId",
                        column: x => x.ProjectsId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProjectWorker_Workers_WorkersId",
                        column: x => x.WorkersId,
                        principalTable: "Workers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProjectWorker_WorkersId",
                table: "ProjectWorker",
                column: "WorkersId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProjectWorker");

            migrationBuilder.AddColumn<Guid>(
                name: "ProjectId",
                table: "Workers",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "ProjectId1",
                table: "Workers",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Workers_ProjectId",
                table: "Workers",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Workers_ProjectId1",
                table: "Workers",
                column: "ProjectId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Workers_Projects_ProjectId",
                table: "Workers",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Workers_Projects_ProjectId1",
                table: "Workers",
                column: "ProjectId1",
                principalTable: "Projects",
                principalColumn: "Id");
        }
    }
}
