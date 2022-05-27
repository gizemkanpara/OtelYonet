using Microsoft.EntityFrameworkCore.Migrations;

namespace otelyonet.Migrations
{
    public partial class bir : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Birimler",
                columns: table => new
                {
                    BirimID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BirimAdı = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Birimler", x => x.BirimID);
                });

            migrationBuilder.CreateTable(
                name: "Cinsiyetler",
                columns: table => new
                {
                    CinsiyetID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CinsiyetTuru = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cinsiyetler", x => x.CinsiyetID);
                });

            migrationBuilder.CreateTable(
                name: "MusteriTipleri",
                columns: table => new
                {
                    MusteriTipID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MusteriTipleri = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MusteriTipleri", x => x.MusteriTipID);
                });

            migrationBuilder.CreateTable(
                name: "Odalar",
                columns: table => new
                {
                    OdaID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OdaAdı = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    KatNO = table.Column<int>(type: "int", nullable: false),
                    YatakSayısı = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Odalar", x => x.OdaID);
                });

            migrationBuilder.CreateTable(
                name: "Roller",
                columns: table => new
                {
                    RolID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RolAdı = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roller", x => x.RolID);
                });

            migrationBuilder.CreateTable(
                name: "Musteriler",
                columns: table => new
                {
                    MusteriID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MusteriTC = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    MusteriAdi = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    MusteriSoyadi = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    MusteriTel = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    MusteriAdresi = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CinsiyetID = table.Column<int>(type: "int", nullable: false),
                    MusteriTipID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Musteriler", x => x.MusteriID);
                    table.ForeignKey(
                        name: "FK_Musteriler_Cinsiyetler_CinsiyetID",
                        column: x => x.CinsiyetID,
                        principalTable: "Cinsiyetler",
                        principalColumn: "CinsiyetID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Musteriler_MusteriTipleri_MusteriTipID",
                        column: x => x.MusteriTipID,
                        principalTable: "MusteriTipleri",
                        principalColumn: "MusteriTipID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Kullanıcılar",
                columns: table => new
                {
                    KullanıcıID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EPosta = table.Column<string>(type: "nvarchar(52)", maxLength: 52, nullable: false),
                    Sifre = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: false),
                    RolID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kullanıcılar", x => x.KullanıcıID);
                    table.ForeignKey(
                        name: "FK_Kullanıcılar_Roller_RolID",
                        column: x => x.RolID,
                        principalTable: "Roller",
                        principalColumn: "RolID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Kullanıcılar_RolID",
                table: "Kullanıcılar",
                column: "RolID");

            migrationBuilder.CreateIndex(
                name: "IX_Musteriler_CinsiyetID",
                table: "Musteriler",
                column: "CinsiyetID");

            migrationBuilder.CreateIndex(
                name: "IX_Musteriler_MusteriTipID",
                table: "Musteriler",
                column: "MusteriTipID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Birimler");

            migrationBuilder.DropTable(
                name: "Kullanıcılar");

            migrationBuilder.DropTable(
                name: "Musteriler");

            migrationBuilder.DropTable(
                name: "Odalar");

            migrationBuilder.DropTable(
                name: "Roller");

            migrationBuilder.DropTable(
                name: "Cinsiyetler");

            migrationBuilder.DropTable(
                name: "MusteriTipleri");
        }
    }
}
