using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EduWork.Data.Migrations
{
    /// <inheritdoc />
    public partial class v11 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorkOnProjects_WorkDays_WorkId",
                table: "WorkOnProjects");

            migrationBuilder.DropIndex(
                name: "IX_WorkOnProjects_WorkId",
                table: "WorkOnProjects");

            migrationBuilder.DropColumn(
                name: "WorkId",
                table: "WorkOnProjects");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "WorkId",
                table: "WorkOnProjects",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_WorkOnProjects_WorkId",
                table: "WorkOnProjects",
                column: "WorkId");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkOnProjects_WorkDays_WorkId",
                table: "WorkOnProjects",
                column: "WorkId",
                principalTable: "WorkDays",
                principalColumn: "WorkDayId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
