using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ArtCourseCenter.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Instructors_InstructorId",
                table: "Courses");

            migrationBuilder.DropForeignKey(
                name: "FK_CoursesAndTrainees_Courses_CourseId",
                table: "CoursesAndTrainees");

            migrationBuilder.DropForeignKey(
                name: "FK_CoursesAndTrainees_Trainees_TraineId",
                table: "CoursesAndTrainees");

            migrationBuilder.DropIndex(
                name: "IX_CoursesAndTrainees_CourseId",
                table: "CoursesAndTrainees");

            migrationBuilder.DropIndex(
                name: "IX_CoursesAndTrainees_TraineId",
                table: "CoursesAndTrainees");

            migrationBuilder.DropIndex(
                name: "IX_Courses_InstructorId",
                table: "Courses");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_CoursesAndTrainees_CourseId",
                table: "CoursesAndTrainees",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_CoursesAndTrainees_TraineId",
                table: "CoursesAndTrainees",
                column: "TraineId");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_InstructorId",
                table: "Courses",
                column: "InstructorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_Instructors_InstructorId",
                table: "Courses",
                column: "InstructorId",
                principalTable: "Instructors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CoursesAndTrainees_Courses_CourseId",
                table: "CoursesAndTrainees",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CoursesAndTrainees_Trainees_TraineId",
                table: "CoursesAndTrainees",
                column: "TraineId",
                principalTable: "Trainees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
