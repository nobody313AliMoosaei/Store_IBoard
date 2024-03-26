using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Store_IBoard.DL.Migrations
{
    /// <inheritdoc />
    public partial class AddSendEmailSMSModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SendEmailSMSModels",
                columns: table => new
                {
                    Id = table.Column<string>(type: "VARCHAR(40)", maxLength: 40, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Code = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SendEmailSMSModels", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SendEmailSMSModel_Email",
                table: "SendEmailSMSModels",
                column: "Email");

            migrationBuilder.CreateIndex(
                name: "IX_SendEmailSMSModel_PhoneNumber",
                table: "SendEmailSMSModels",
                column: "PhoneNumber");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SendEmailSMSModels");
        }
    }
}
