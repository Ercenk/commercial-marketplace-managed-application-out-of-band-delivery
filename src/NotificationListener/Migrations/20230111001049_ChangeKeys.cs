using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NotificationListener.Migrations
{
    /// <inheritdoc />
    public partial class ChangeKeys : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_DeployedApplications",
                table: "DeployedApplications");

            migrationBuilder.AlterColumn<string>(
                name: "ProvisioningState",
                table: "DeployedApplications",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DeployedApplications",
                table: "DeployedApplications",
                columns: new[] { "ApplicationId", "EventTime", "ProvisioningState" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_DeployedApplications",
                table: "DeployedApplications");

            migrationBuilder.AlterColumn<string>(
                name: "ProvisioningState",
                table: "DeployedApplications",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DeployedApplications",
                table: "DeployedApplications",
                column: "ApplicationId");
        }
    }
}
