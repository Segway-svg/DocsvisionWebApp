using DocsvisionWebApp.EntityFramework;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;


[DbContext(typeof(EmailDbContext))]
[Migration("20230211223800_CreateEmailDB")]
public class CreateEmailDB : Migration {
    
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.CreateTable(
            name: "Emails",
            columns: table => new
            {
                Id = table.Column<Guid>(nullable: false, type: "uniqueidentifier"),
                Name = table.Column<string>(nullable: false),
                ReceiverId = table.Column<Guid>(nullable: false),
                SenderId = table.Column<Guid>(nullable: false),
                Content = table.Column<string>(nullable: true),
                CreationDate = table.Column<DateTime>(nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Emails", l => l.Id);
            }
        );

        migrationBuilder.CreateTable(
            name: "Senders",
            columns: table => new
            {
                Id = table.Column<Guid>(nullable: false),
                Name = table.Column<string>(nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Senders", l => l.Id);
            }
        );
        
        migrationBuilder.AddForeignKey(
            name: "FK_Emails_With_SenderId_To_Senders",
            table: "Emails",
            column: "SenderId",
            principalTable: "Senders",
            principalColumn: "Id",
            onDelete: ReferentialAction.Cascade);
    }
    
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable("Emails");
        migrationBuilder.DropTable("Senders");
    }
}