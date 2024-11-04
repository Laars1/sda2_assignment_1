using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sda2.Masterdata.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EmployeeInfos",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    PinNumber = table.Column<int>(type: "int", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    UserId = table.Column<double>(type: "float", nullable: false),
                    PhoneNumber = table.Column<double>(type: "float", nullable: false),
                    Snn = table.Column<double>(type: "float", nullable: false),
                    StreetAddress = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    City = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    State = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false),
                    ZipCode = table.Column<int>(type: "int", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CompanyName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    UserType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeInfos", x => x.EmployeeId);
                });

            migrationBuilder.CreateTable(
                name: "Stores",
                columns: table => new
                {
                    SID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stores", x => x.SID);
                });

            migrationBuilder.CreateTable(
                name: "CustomerInfos",
                columns: table => new
                {
                    CustomerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PhoneNumber = table.Column<double>(type: "float", nullable: false),
                    Rewards = table.Column<float>(type: "real", nullable: false),
                    StreetAddress = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    City = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    State = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false),
                    ZipCode = table.Column<int>(type: "int", nullable: false),
                    EmployeeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerInfos", x => x.CustomerId);
                    table.ForeignKey(
                        name: "FK_CustomerInfos_EmployeeInfos_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "EmployeeInfos",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RegistersTables",
                columns: table => new
                {
                    RegisterId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OpenTotal = table.Column<float>(type: "real", nullable: false),
                    CloseTotal = table.Column<float>(type: "real", nullable: false),
                    RegisterNum = table.Column<int>(type: "int", nullable: false),
                    OpenEmpId = table.Column<int>(type: "int", nullable: true),
                    CloseEmpId = table.Column<int>(type: "int", nullable: true),
                    OpenTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CloseTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DropTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DropEmpId = table.Column<int>(type: "int", nullable: true),
                    DropTotal = table.Column<float>(type: "real", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegistersTables", x => x.RegisterId);
                    table.ForeignKey(
                        name: "FK_RegistersTables_EmployeeInfos_CloseEmpId",
                        column: x => x.CloseEmpId,
                        principalTable: "EmployeeInfos",
                        principalColumn: "EmployeeId");
                    table.ForeignKey(
                        name: "FK_RegistersTables_EmployeeInfos_DropEmpId",
                        column: x => x.DropEmpId,
                        principalTable: "EmployeeInfos",
                        principalColumn: "EmployeeId");
                    table.ForeignKey(
                        name: "FK_RegistersTables_EmployeeInfos_OpenEmpId",
                        column: x => x.OpenEmpId,
                        principalTable: "EmployeeInfos",
                        principalColumn: "EmployeeId");
                });

            migrationBuilder.CreateTable(
                name: "EmployeeInfoStore",
                columns: table => new
                {
                    EmployeeInfosEmployeeId = table.Column<int>(type: "int", nullable: false),
                    StoresSID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeInfoStore", x => new { x.EmployeeInfosEmployeeId, x.StoresSID });
                    table.ForeignKey(
                        name: "FK_EmployeeInfoStore_EmployeeInfos_EmployeeInfosEmployeeId",
                        column: x => x.EmployeeInfosEmployeeId,
                        principalTable: "EmployeeInfos",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeeInfoStore_Stores_StoresSID",
                        column: x => x.StoresSID,
                        principalTable: "Stores",
                        principalColumn: "SID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CustomerInfos_EmployeeId",
                table: "CustomerInfos",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeInfoStore_StoresSID",
                table: "EmployeeInfoStore",
                column: "StoresSID");

            migrationBuilder.CreateIndex(
                name: "IX_RegistersTables_CloseEmpId",
                table: "RegistersTables",
                column: "CloseEmpId");

            migrationBuilder.CreateIndex(
                name: "IX_RegistersTables_DropEmpId",
                table: "RegistersTables",
                column: "DropEmpId");

            migrationBuilder.CreateIndex(
                name: "IX_RegistersTables_OpenEmpId",
                table: "RegistersTables",
                column: "OpenEmpId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CustomerInfos");

            migrationBuilder.DropTable(
                name: "EmployeeInfoStore");

            migrationBuilder.DropTable(
                name: "RegistersTables");

            migrationBuilder.DropTable(
                name: "Stores");

            migrationBuilder.DropTable(
                name: "EmployeeInfos");
        }
    }
}
