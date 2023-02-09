using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DocsvisionWebApp.EntityFramework;

[DbContext(typeof(EmailDbContext))]
[Migration("20230209161000_InitialCreate")]
public class InitialCreate : Migration {
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.CreateTable(
            name: "Emails",
            columns: table => new
            {
                Id = table.Column<Guid>(nullable: false, type: "uniqueidentifier"),
                Name = table.Column<string>(nullable: false),
                Receiver = table.Column<string>(nullable: false),
                Sender = table.Column<string>(nullable: false),
                Content = table.Column<string>(nullable: true),
                CreationDate = table.Column<DateTime>(nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Emails", l => l.Id);
            }
        );
    }
    
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable("Emails");
    }
}