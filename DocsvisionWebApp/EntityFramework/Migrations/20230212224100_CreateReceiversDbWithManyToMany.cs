using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DocsvisionWebApp.EntityFramework.Repositories;


[DbContext(typeof(EmailDbContext))]
[Migration("20230212224100_CreateReceiversDbWithManyToMany")]
public class CreateReceiversDbWithManyToMany : Migration {
    
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.CreateTable(
            name: "Receivers",
            columns: table => new
            {
                Id = table.Column<Guid>(nullable: false, type: "uniqueidentifier"),
                Name = table.Column<string>(nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Receivers", r => r.Id);
            }
        );
                
        migrationBuilder.CreateTable(
            name: "EmailsReceivers",
            columns: table => new
            {
                Id = table.Column<Guid>(nullable: false, type: "uniqueidentifier"),
                EmailId = table.Column<Guid>(nullable: false, type: "uniqueidentifier"),
                ReceiverId = table.Column<Guid>(nullable: false, type: "uniqueidentifier"),
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Emails_Receivers", l => l.Id);
                table.ForeignKey(
                    name: "FK_EmailsReceivers_EmailId",
                    column: e => e.EmailId,
                    principalTable: "Emails",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
                table.ForeignKey(
                    name: "FK_EmailsReceivers_ReceiverId",
                    column: r => r.ReceiverId,
                    principalTable: "Receivers",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
            });
    }
            
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable("Receivers");
        migrationBuilder.DropTable("EmailsReceivers");
    }
}