using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ContabilidadHogar.Database.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RegistryMoneyControl",
                columns: table => new
                {
                    IdTransaction = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    TransactionDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "varchar(100)", nullable: false),
                    Details = table.Column<string>(type: "varchar(200)", nullable: false),
                    IncomeTransaction = table.Column<bool>(type: "bit", nullable: false),
                    AmountTransaction = table.Column<double>(type: "float", nullable: false),
                    BalanceTransaction = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegistryMoneyControl", x => x.IdTransaction);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RegistryMoneyControl");
        }
    }
}
