using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    public partial class addApprovedByColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.AddColumn<string>(
            //    name: "UserDocumentNo",
            //    table: "LettersHD",
            //    type: "nvarchar(max)",
            //    nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "approvedBy",
                table: "LettersHD",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropColumn(
            //    name: "UserDocumentNo",
            //    table: "LettersHD");

            migrationBuilder.DropColumn(
                name: "approvedBy",
                table: "LettersHD");
        }
    }
}
