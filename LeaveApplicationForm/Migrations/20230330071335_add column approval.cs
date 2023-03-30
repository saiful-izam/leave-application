using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LeaveApplicationForm.Migrations
{
    /// <inheritdoc />
    public partial class addcolumnapproval : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_leaveForms",
                table: "leaveForms");

            migrationBuilder.RenameTable(
                name: "leaveForms",
                newName: "LeaveForms");

            migrationBuilder.RenameColumn(
                name: "startDate",
                table: "LeaveForms",
                newName: "StartDate");

            migrationBuilder.RenameColumn(
                name: "reason",
                table: "LeaveForms",
                newName: "Reason");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "LeaveForms",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "endDate",
                table: "LeaveForms",
                newName: "EndDate");

            migrationBuilder.RenameColumn(
                name: "emailManager",
                table: "LeaveForms",
                newName: "EmailManager");

            migrationBuilder.RenameColumn(
                name: "email",
                table: "LeaveForms",
                newName: "Email");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "LeaveForms",
                newName: "Id");

            migrationBuilder.AlterColumn<string>(
                name: "Reason",
                table: "LeaveForms",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "LeaveForms",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "EmailManager",
                table: "LeaveForms",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "LeaveForms",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "ApprovalStatus",
                table: "LeaveForms",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_LeaveForms",
                table: "LeaveForms",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_LeaveForms",
                table: "LeaveForms");

            migrationBuilder.DropColumn(
                name: "ApprovalStatus",
                table: "LeaveForms");

            migrationBuilder.RenameTable(
                name: "LeaveForms",
                newName: "leaveForms");

            migrationBuilder.RenameColumn(
                name: "StartDate",
                table: "leaveForms",
                newName: "startDate");

            migrationBuilder.RenameColumn(
                name: "Reason",
                table: "leaveForms",
                newName: "reason");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "leaveForms",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "EndDate",
                table: "leaveForms",
                newName: "endDate");

            migrationBuilder.RenameColumn(
                name: "EmailManager",
                table: "leaveForms",
                newName: "emailManager");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "leaveForms",
                newName: "email");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "leaveForms",
                newName: "id");

            migrationBuilder.AlterColumn<string>(
                name: "reason",
                table: "leaveForms",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "name",
                table: "leaveForms",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "emailManager",
                table: "leaveForms",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "email",
                table: "leaveForms",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_leaveForms",
                table: "leaveForms",
                column: "id");
        }
    }
}
