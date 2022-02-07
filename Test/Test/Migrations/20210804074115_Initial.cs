using Microsoft.EntityFrameworkCore.Migrations;

namespace Test.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.CreateTable(
            //    name: "Tambs",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        WeightMainRef = table.Column<double>(type: "float", nullable: true),
            //        WeightMainAct = table.Column<double>(type: "float", nullable: true),
            //        WeightDryRef = table.Column<double>(type: "float", nullable: true),
            //        WeightDryAct = table.Column<double>(type: "float", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Tambs", x => x.Id);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Labs",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        BaseWeight = table.Column<double>(type: "float", nullable: true),
            //        ProductBrand = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        BaseWeightLFace = table.Column<double>(type: "float", nullable: true),
            //        BaseWeightLMid = table.Column<double>(type: "float", nullable: true),
            //        TambId = table.Column<int>(type: "int", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Labs", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_Labs_Tambs_TambId",
            //            column: x => x.TambId,
            //            principalTable: "Tambs",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateIndex(
            //    name: "IX_Labs_TambId",
            //    table: "Labs",
            //    column: "TambId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Labs");

            migrationBuilder.DropTable(
                name: "Tambs");
        }
    }
}
