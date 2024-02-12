using Microsoft.EntityFrameworkCore.Migrations;

namespace data_access.Migrations
{
    public partial class teacherCourseTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CourseTeacher");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CourseTeacher",
                columns: table => new
                {
                    coursesid = table.Column<int>(type: "int", nullable: false),
                    teachersid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseTeacher", x => new { x.coursesid, x.teachersid });
                    table.ForeignKey(
                        name: "FK_CourseTeacher_Courses_coursesid",
                        column: x => x.coursesid,
                        principalTable: "Courses",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CourseTeacher_Teachers_teachersid",
                        column: x => x.teachersid,
                        principalTable: "Teachers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CourseTeacher_teachersid",
                table: "CourseTeacher",
                column: "teachersid");
        }
    }
}
