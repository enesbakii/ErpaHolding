using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ErpaHolding.DataAccess.Migrations
{
    public partial class CretateRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("ce72f253-847f-44d8-b9dc-e435221b009f"), "member" });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("f7f6baf8-e729-4351-b339-19bf83160600"), "admin" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("ce72f253-847f-44d8-b9dc-e435221b009f"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("f7f6baf8-e729-4351-b339-19bf83160600"));
        }
    }
}
