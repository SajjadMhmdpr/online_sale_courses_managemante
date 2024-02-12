using Microsoft.EntityFrameworkCore.Migrations;

namespace data_access.Migrations
{
    public partial class teacherCourse : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    totalTime = table.Column<float>(type: "real", nullable: false),
                    descript = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    videoIntro = table.Column<int>(type: "int", nullable: false),
                    price = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.id);
                });

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

            migrationBuilder.CreateTable(
                name: "TeacherCourses",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    teacherid = table.Column<int>(type: "int", nullable: true),
                    courseid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeacherCourses", x => x.id);
                    table.ForeignKey(
                        name: "FK_TeacherCourses_Courses_courseid",
                        column: x => x.courseid,
                        principalTable: "Courses",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TeacherCourses_Teachers_teacherid",
                        column: x => x.teacherid,
                        principalTable: "Teachers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CourseTeacher_teachersid",
                table: "CourseTeacher",
                column: "teachersid");

            migrationBuilder.CreateIndex(
                name: "IX_TeacherCourses_courseid",
                table: "TeacherCourses",
                column: "courseid");

            migrationBuilder.CreateIndex(
                name: "IX_TeacherCourses_teacherid",
                table: "TeacherCourses",
                column: "teacherid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CourseTeacher");

            migrationBuilder.DropTable(
                name: "TeacherCourses");

            migrationBuilder.DropTable(
                name: "Courses");
        }
    }
}
