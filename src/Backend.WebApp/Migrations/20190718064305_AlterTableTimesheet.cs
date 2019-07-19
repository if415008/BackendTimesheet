using Microsoft.EntityFrameworkCore.Migrations;

namespace Backend.WebApp.Migrations
{
    public partial class AlterTableTimesheet : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Timesheets_TaskId",
                table: "Timesheets",
                column: "TaskId");

            migrationBuilder.AddForeignKey(
                name: "FK_Timesheets_Tasks_TaskId",
                table: "Timesheets",
                column: "TaskId",
                principalTable: "Tasks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Timesheets_Tasks_TaskId",
                table: "Timesheets");

            migrationBuilder.DropIndex(
                name: "IX_Timesheets_TaskId",
                table: "Timesheets");
        }
    }
}
