using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace enlearn.Data.Migrations
{
    public partial class Migration2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "officeid",
                table: "tblcap_parent",
                newName: "parentid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "parentid",
                table: "tblcap_parent",
                newName: "officeid");
        }
    }
}
