using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CourseSignupSystem.Migrations
{
    public partial class CourseSignupSystem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Course",
                columns: table => new
                {
                    CourseId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseCode = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    CourseName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    CourseStartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CourseEndTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Course", x => x.CourseId);
                });

            migrationBuilder.CreateTable(
                name: "Department",
                columns: table => new
                {
                    DepartmentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DepartmentName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Department", x => x.DepartmentId);
                });

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    RoleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.RoleId);
                });

            migrationBuilder.CreateTable(
                name: "ScheduleHoliday",
                columns: table => new
                {
                    ScheduleHolidayId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ScheduleHolidayName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ScheduleHolidayReason = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ScheduleHolidayStartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ScheduleHolidayEndDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScheduleHoliday", x => x.ScheduleHolidayId);
                });

            migrationBuilder.CreateTable(
                name: "ScoreOralTests",
                columns: table => new
                {
                    ScoreOralTestId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ScoreOralTestFisrt = table.Column<float>(type: "real", nullable: false),
                    ScoreOralTestSecond = table.Column<float>(type: "real", nullable: false),
                    ScoreOralTestThird = table.Column<float>(type: "real", nullable: false),
                    ScoreOralTestFourth = table.Column<float>(type: "real", nullable: false),
                    ScoreOralTestFifth = table.Column<float>(type: "real", nullable: false),
                    ScoreFinalFisrt = table.Column<float>(type: "real", nullable: false),
                    ScoreFinalSecond = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScoreOralTests", x => x.ScoreOralTestId);
                });

            migrationBuilder.CreateTable(
                name: "ScoreType",
                columns: table => new
                {
                    ScoreTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ScoreTypeName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    ScoreTypeCoefficient = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScoreType", x => x.ScoreTypeId);
                });

            migrationBuilder.CreateTable(
                name: "Turnover",
                columns: table => new
                {
                    TurnoverId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TurnoverStudent = table.Column<int>(type: "int", nullable: false),
                    TurnoverStudentCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    TurnoverStudentClass = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    TurnoverStudentName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    TurnoverStudyDate = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    TurnoverStartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TurnoverEndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TurnoverTuition = table.Column<double>(type: "float", nullable: false),
                    TurnoverTotalTuition = table.Column<double>(type: "float", nullable: false),
                    TurnoverTeacher = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Turnover", x => x.TurnoverId);
                });

            migrationBuilder.CreateTable(
                name: "Class",
                columns: table => new
                {
                    ClassId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClassCourse = table.Column<int>(type: "int", nullable: false),
                    ClassCode = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    ClassName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    ClassSchoolYear = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    ClassDescription = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ClassCourseName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    ClassQuantity = table.Column<int>(type: "int", nullable: false),
                    ClassStatus = table.Column<bool>(type: "bit", nullable: false),
                    ClassTuition = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Class", x => x.ClassId);
                    table.ForeignKey(
                        name: "FK_Class_Course_ClassCourse",
                        column: x => x.ClassCourse,
                        principalTable: "Course",
                        principalColumn: "CourseId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Subject",
                columns: table => new
                {
                    SubjectId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubjectDepartment = table.Column<int>(type: "int", nullable: false),
                    SubjectCourse = table.Column<int>(type: "int", nullable: false),
                    SubjectCode = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    SubjectName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subject", x => x.SubjectId);
                    table.ForeignKey(
                        name: "FK_Subject_Course_SubjectCourse",
                        column: x => x.SubjectCourse,
                        principalTable: "Course",
                        principalColumn: "CourseId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Subject_Department_SubjectDepartment",
                        column: x => x.SubjectDepartment,
                        principalTable: "Department",
                        principalColumn: "DepartmentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ScoreDetails",
                columns: table => new
                {
                    ScoreDetailId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ScoreClassId = table.Column<int>(type: "int", nullable: false),
                    ScoreStudentName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ScoreSubjectName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ScoreDetailOral = table.Column<int>(type: "int", nullable: false),
                    ScoreDetailMediumScore = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScoreDetails", x => x.ScoreDetailId);
                    table.ForeignKey(
                        name: "FK_ScoreDetails_Class_ScoreClassId",
                        column: x => x.ScoreClassId,
                        principalTable: "Class",
                        principalColumn: "ClassId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ScoreDetails_ScoreOralTests_ScoreDetailOral",
                        column: x => x.ScoreDetailOral,
                        principalTable: "ScoreOralTests",
                        principalColumn: "ScoreOralTestId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserSurname = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    UserFisrtName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    UserTeacherCode = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    UserTaxCode = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    UserStudentCode = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    UserEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserPhone = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: true),
                    UserAddress = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    UserGender = table.Column<int>(type: "int", nullable: false),
                    UserBirthday = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserParentName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    UserImg = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    UserClass = table.Column<int>(type: "int", nullable: false),
                    UserMainSubject = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    UserParttimeSubject = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    UserPassword = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    UserRole = table.Column<int>(type: "int", nullable: false),
                    UserBlock = table.Column<bool>(type: "bit", nullable: false),
                    UserStatus = table.Column<bool>(type: "bit", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    classModelClassId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_User_Class_classModelClassId",
                        column: x => x.classModelClassId,
                        principalTable: "Class",
                        principalColumn: "ClassId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_User_Role_UserRole",
                        column: x => x.UserRole,
                        principalTable: "Role",
                        principalColumn: "RoleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Score",
                columns: table => new
                {
                    ScoreId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ScoreSubjectId = table.Column<int>(type: "int", nullable: false),
                    ScoreType = table.Column<int>(type: "int", nullable: false),
                    ScoreCourse = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    ScoreSubjectName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    ScoreTypeName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    ScoreQuantity = table.Column<int>(type: "int", nullable: false),
                    ScoreQuantityRequired = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Score", x => x.ScoreId);
                    table.ForeignKey(
                        name: "FK_Score_ScoreType_ScoreType",
                        column: x => x.ScoreType,
                        principalTable: "ScoreType",
                        principalColumn: "ScoreTypeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Score_Subject_ScoreSubjectId",
                        column: x => x.ScoreSubjectId,
                        principalTable: "Subject",
                        principalColumn: "SubjectId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Receipts",
                columns: table => new
                {
                    ReceiptsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReceiptsStudentId = table.Column<int>(type: "int", nullable: false),
                    ReceiptsClassName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    ReceiptsTraining = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    ReceiptsFee = table.Column<double>(type: "float", nullable: false),
                    ReceiptsTypeFee = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    ReceiptsRateFee = table.Column<double>(type: "float", nullable: false),
                    ReceiptsDiscount = table.Column<int>(type: "int", nullable: false),
                    ReceiptsNote = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ReceiptsSurcharge = table.Column<double>(type: "float", nullable: false),
                    ReceiptsPayableFee = table.Column<double>(type: "float", nullable: false),
                    ReceiptsStatus = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Receipts", x => x.ReceiptsId);
                    table.ForeignKey(
                        name: "FK_Receipts_User_ReceiptsStudentId",
                        column: x => x.ReceiptsStudentId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RegisterClass",
                columns: table => new
                {
                    RegisterClassId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RegisterUser = table.Column<int>(type: "int", nullable: false),
                    RegisterClassCourse = table.Column<int>(type: "int", nullable: false),
                    RegisterClassCourseName = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    RegistClassDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RegisterClassDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RegisterClassTuition = table.Column<double>(type: "float", nullable: false),
                    RegisterClassStudentCode = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    RegisterClassStudentName = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegisterClass", x => x.RegisterClassId);
                    table.ForeignKey(
                        name: "FK_RegisterClass_User_RegisterUser",
                        column: x => x.RegisterUser,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ScheduleStudent",
                columns: table => new
                {
                    ScheduleStudentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ScheduleUser = table.Column<int>(type: "int", nullable: false),
                    ScheduleSubject = table.Column<int>(type: "int", nullable: false),
                    ScheduleClassId = table.Column<int>(type: "int", nullable: false),
                    ScheduleStudentCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ScheduleStudentName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ScheduleClassName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ScheduleSubjectName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ScheduleRoom = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ScheduleOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ScheduleStartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ScheduleEndDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScheduleStudent", x => x.ScheduleStudentId);
                    table.ForeignKey(
                        name: "FK_ScheduleStudent_User_ScheduleUser",
                        column: x => x.ScheduleUser,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ScheduleTeacher",
                columns: table => new
                {
                    ScheduleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ScheduleUser = table.Column<int>(type: "int", nullable: false),
                    ScheduleSubject = table.Column<int>(type: "int", nullable: false),
                    ScheduleClassId = table.Column<int>(type: "int", nullable: false),
                    ScheduleTeacherCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ScheduleTeacherName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ScheduleClassName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ScheduleSubjectName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ScheduleRoom = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ScheduleTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ScheduleOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ScheduleStartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ScheduleEndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Schedule = table.Column<DateTime>(type: "datetime2", nullable: false),
                    subjectModelSubjectId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScheduleTeacher", x => x.ScheduleId);
                    table.ForeignKey(
                        name: "FK_ScheduleTeacher_Subject_subjectModelSubjectId",
                        column: x => x.subjectModelSubjectId,
                        principalTable: "Subject",
                        principalColumn: "SubjectId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ScheduleTeacher_User_ScheduleUser",
                        column: x => x.ScheduleUser,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Class_ClassCourse",
                table: "Class",
                column: "ClassCourse");

            migrationBuilder.CreateIndex(
                name: "IX_Receipts_ReceiptsStudentId",
                table: "Receipts",
                column: "ReceiptsStudentId");

            migrationBuilder.CreateIndex(
                name: "IX_RegisterClass_RegisterUser",
                table: "RegisterClass",
                column: "RegisterUser");

            migrationBuilder.CreateIndex(
                name: "IX_ScheduleStudent_ScheduleUser",
                table: "ScheduleStudent",
                column: "ScheduleUser");

            migrationBuilder.CreateIndex(
                name: "IX_ScheduleTeacher_ScheduleUser",
                table: "ScheduleTeacher",
                column: "ScheduleUser");

            migrationBuilder.CreateIndex(
                name: "IX_ScheduleTeacher_subjectModelSubjectId",
                table: "ScheduleTeacher",
                column: "subjectModelSubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Score_ScoreSubjectId",
                table: "Score",
                column: "ScoreSubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Score_ScoreType",
                table: "Score",
                column: "ScoreType");

            migrationBuilder.CreateIndex(
                name: "IX_ScoreDetails_ScoreClassId",
                table: "ScoreDetails",
                column: "ScoreClassId");

            migrationBuilder.CreateIndex(
                name: "IX_ScoreDetails_ScoreDetailOral",
                table: "ScoreDetails",
                column: "ScoreDetailOral");

            migrationBuilder.CreateIndex(
                name: "IX_Subject_SubjectCourse",
                table: "Subject",
                column: "SubjectCourse");

            migrationBuilder.CreateIndex(
                name: "IX_Subject_SubjectDepartment",
                table: "Subject",
                column: "SubjectDepartment");

            migrationBuilder.CreateIndex(
                name: "IX_User_classModelClassId",
                table: "User",
                column: "classModelClassId");

            migrationBuilder.CreateIndex(
                name: "IX_User_UserRole",
                table: "User",
                column: "UserRole");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Receipts");

            migrationBuilder.DropTable(
                name: "RegisterClass");

            migrationBuilder.DropTable(
                name: "ScheduleHoliday");

            migrationBuilder.DropTable(
                name: "ScheduleStudent");

            migrationBuilder.DropTable(
                name: "ScheduleTeacher");

            migrationBuilder.DropTable(
                name: "Score");

            migrationBuilder.DropTable(
                name: "ScoreDetails");

            migrationBuilder.DropTable(
                name: "Turnover");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "ScoreType");

            migrationBuilder.DropTable(
                name: "Subject");

            migrationBuilder.DropTable(
                name: "ScoreOralTests");

            migrationBuilder.DropTable(
                name: "Class");

            migrationBuilder.DropTable(
                name: "Role");

            migrationBuilder.DropTable(
                name: "Department");

            migrationBuilder.DropTable(
                name: "Course");
        }
    }
}
