using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace webapi.Migrations
{
    public partial class addedrelationships : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Teachers_TeacherId",
                table: "Courses");

            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Courses_CourseId",
                table: "Customers");

            migrationBuilder.DropIndex(
                name: "IX_Customers_CourseId",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "CourseId",
                table: "Customers");

            migrationBuilder.AddColumn<int>(
                name: "CurrentCourseId",
                table: "Customers",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "TeacherId",
                table: "Courses",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CustomerId",
                table: "Courses",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "CourseCustomerCurrent",
                columns: table => new
                {
                    CourseId = table.Column<int>(type: "INTEGER", nullable: false),
                    CustomerId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseCustomerCurrent", x => new { x.CourseId, x.CustomerId });
                    table.ForeignKey(
                        name: "FK_CourseCustomerCurrent_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "CourseId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CourseCustomerCurrent_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CourseCustomerFinished",
                columns: table => new
                {
                    CourseId = table.Column<int>(type: "INTEGER", nullable: false),
                    CustomerId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseCustomerFinished", x => new { x.CourseId, x.CustomerId });
                    table.ForeignKey(
                        name: "FK_CourseCustomerFinished_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "CourseId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CourseCustomerFinished_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Customers_CurrentCourseId",
                table: "Customers",
                column: "CurrentCourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_CustomerId",
                table: "Courses",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseCustomerCurrent_CustomerId",
                table: "CourseCustomerCurrent",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseCustomerFinished_CustomerId",
                table: "CourseCustomerFinished",
                column: "CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_Customers_CustomerId",
                table: "Courses",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_Teachers_TeacherId",
                table: "Courses",
                column: "TeacherId",
                principalTable: "Teachers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_Courses_CurrentCourseId",
                table: "Customers",
                column: "CurrentCourseId",
                principalTable: "Courses",
                principalColumn: "CourseId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Customers_CustomerId",
                table: "Courses");

            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Teachers_TeacherId",
                table: "Courses");

            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Courses_CurrentCourseId",
                table: "Customers");

            migrationBuilder.DropTable(
                name: "CourseCustomerCurrent");

            migrationBuilder.DropTable(
                name: "CourseCustomerFinished");

            migrationBuilder.DropIndex(
                name: "IX_Customers_CurrentCourseId",
                table: "Customers");

            migrationBuilder.DropIndex(
                name: "IX_Courses_CustomerId",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "CurrentCourseId",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "Courses");

            migrationBuilder.AddColumn<int>(
                name: "CourseId",
                table: "Customers",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "TeacherId",
                table: "Courses",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_CourseId",
                table: "Customers",
                column: "CourseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_Teachers_TeacherId",
                table: "Courses",
                column: "TeacherId",
                principalTable: "Teachers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_Courses_CourseId",
                table: "Customers",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "CourseId");
        }
    }
}
