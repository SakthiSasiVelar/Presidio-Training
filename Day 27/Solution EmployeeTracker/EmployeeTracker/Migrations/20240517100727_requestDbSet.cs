using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmployeeTracker.Migrations
{
    public partial class requestDbSet : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Request_Employees_ClosedBy",
                table: "Request");

            migrationBuilder.DropForeignKey(
                name: "FK_Request_Employees_RaisedBy",
                table: "Request");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Request",
                table: "Request");

            migrationBuilder.RenameTable(
                name: "Request",
                newName: "Requests");

            migrationBuilder.RenameIndex(
                name: "IX_Request_RaisedBy",
                table: "Requests",
                newName: "IX_Requests_RaisedBy");

            migrationBuilder.RenameIndex(
                name: "IX_Request_ClosedBy",
                table: "Requests",
                newName: "IX_Requests_ClosedBy");

            migrationBuilder.AlterColumn<int>(
                name: "ClosedBy",
                table: "Requests",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Requests",
                table: "Requests",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Requests_Employees_ClosedBy",
                table: "Requests",
                column: "ClosedBy",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Requests_Employees_RaisedBy",
                table: "Requests",
                column: "RaisedBy",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Requests_Employees_ClosedBy",
                table: "Requests");

            migrationBuilder.DropForeignKey(
                name: "FK_Requests_Employees_RaisedBy",
                table: "Requests");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Requests",
                table: "Requests");

            migrationBuilder.RenameTable(
                name: "Requests",
                newName: "Request");

            migrationBuilder.RenameIndex(
                name: "IX_Requests_RaisedBy",
                table: "Request",
                newName: "IX_Request_RaisedBy");

            migrationBuilder.RenameIndex(
                name: "IX_Requests_ClosedBy",
                table: "Request",
                newName: "IX_Request_ClosedBy");

            migrationBuilder.AlterColumn<int>(
                name: "ClosedBy",
                table: "Request",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Request",
                table: "Request",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Request_Employees_ClosedBy",
                table: "Request",
                column: "ClosedBy",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Request_Employees_RaisedBy",
                table: "Request",
                column: "RaisedBy",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
