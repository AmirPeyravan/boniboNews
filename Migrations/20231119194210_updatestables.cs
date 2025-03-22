using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BoniboNews.Migrations
{
    /// <inheritdoc />
    public partial class updatestables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 3);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "Comments", "CreateDate", "Description", "ItemName", "ViewCount" },
                values: new object[,]
                {
                    { 1, "ندارد", "1402 / 08 / 19", "بونیبو ، در مدرسه به آموزش میده ، ما با بونیبو سرگرمی خواصخودمون رو داریم", "سعید بونیبو در مدرسه", 1 },
                    { 2, "ندارد", "1402 / 08 / 19", "هیچی ، فقط یس بونیبو", "یس بونیبو", 1 },
                    { 3, "ندارد", "1402 / 08 / 19", "این محصول بخاطر علاقه شدید بونیبو وارد شده ، آدرس جهت خرید : جنب مذرسه شریعتی هایپرمارکت ماهان", "گل محمدی", 1 }
                });
        }
    }
}
