using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SolutionSphere.Infrastructure.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Project",
                columns: table => new
                {
                    ProjectId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProjectName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProjectManager = table.Column<int>(type: "int", nullable: false),
                    DeleteFlag = table.Column<bool>(type: "bit", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Data = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Project", x => x.ProjectId);
                });

            migrationBuilder.CreateTable(
                name: "IssueData",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProjectCode = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SolutionAvailable = table.Column<bool>(type: "bit", nullable: false),
                    VisibleToEveryone = table.Column<bool>(type: "bit", nullable: false),
                    DeleteFlag = table.Column<bool>(type: "bit", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Data = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IssueData", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IssueData_Project_ProjectCode",
                        column: x => x.ProjectCode,
                        principalTable: "Project",
                        principalColumn: "ProjectId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SolutionData",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IssueId = table.Column<int>(type: "int", nullable: false),
                    Solution = table.Column<string>(type: "nvarchar(max)", maxLength: 5000, nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Data = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    DeleteFlag = table.Column<bool>(type: "bit", nullable: false),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SolutionData", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SolutionData_IssueData_IssueId",
                        column: x => x.IssueId,
                        principalTable: "IssueData",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_IssueData_Id",
                table: "IssueData",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_IssueData_ProjectCode",
                table: "IssueData",
                column: "ProjectCode");

            migrationBuilder.CreateIndex(
                name: "IX_SolutionData_IssueId",
                table: "SolutionData",
                column: "IssueId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SolutionData");

            migrationBuilder.DropTable(
                name: "IssueData");

            migrationBuilder.DropTable(
                name: "Project");
        }
    }
}
