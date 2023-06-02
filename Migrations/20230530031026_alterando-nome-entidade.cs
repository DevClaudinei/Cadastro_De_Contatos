using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CadastroTeste.Migrations
{
    public partial class alterandonomeentidade : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Emails_Contatos_ContatoId",
                table: "Emails");

            migrationBuilder.DropTable(
                name: "Contatos");

            migrationBuilder.RenameColumn(
                name: "Endereco",
                table: "Emails",
                newName: "Address");

            migrationBuilder.RenameColumn(
                name: "ContatoId",
                table: "Emails",
                newName: "ContatId");

            migrationBuilder.RenameIndex(
                name: "IX_Emails_ContatoId",
                table: "Emails",
                newName: "IX_Emails_ContatId");

            migrationBuilder.CreateTable(
                name: "Contacts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Company = table.Column<string>(type: "TEXT", nullable: true),
                    PersonalPhone = table.Column<string>(type: "TEXT", nullable: true),
                    CommercialPhone = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contacts", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Emails_Contacts_ContatId",
                table: "Emails",
                column: "ContatId",
                principalTable: "Contacts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Emails_Contacts_ContatId",
                table: "Emails");

            migrationBuilder.DropTable(
                name: "Contacts");

            migrationBuilder.RenameColumn(
                name: "ContatId",
                table: "Emails",
                newName: "ContatoId");

            migrationBuilder.RenameColumn(
                name: "Address",
                table: "Emails",
                newName: "Endereco");

            migrationBuilder.RenameIndex(
                name: "IX_Emails_ContatId",
                table: "Emails",
                newName: "IX_Emails_ContatoId");

            migrationBuilder.CreateTable(
                name: "Contatos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Empresa = table.Column<string>(type: "TEXT", nullable: true),
                    Nome = table.Column<string>(type: "TEXT", nullable: true),
                    TelefoneComercial = table.Column<string>(type: "TEXT", nullable: true),
                    TelefonePessoal = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contatos", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Emails_Contatos_ContatoId",
                table: "Emails",
                column: "ContatoId",
                principalTable: "Contatos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
