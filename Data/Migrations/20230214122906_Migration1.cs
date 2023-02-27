using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace enlearn.Data.Migrations
{
    public partial class Migration1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tblcap_basicdetails",
                columns: table => new
                {
                    studentid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    studentname = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    contactnumber = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    gender = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    username = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    password = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    parentcontact = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    status = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblcap_basicdetails", x => x.studentid);
                });

            migrationBuilder.CreateTable(
                name: "tblcap_course",
                columns: table => new
                {
                    courseid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    coursename = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    courseshortname = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: true),
                    coursetype = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    coursedescription = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblcap_course", x => x.courseid);
                });

            migrationBuilder.CreateTable(
                name: "tblcap_interviewer",
                columns: table => new
                {
                    interviewerid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    department = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    contact = table.Column<int>(type: "int", nullable: false),
                    email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    username = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    password = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblcap_interviewer", x => x.interviewerid);
                });

            migrationBuilder.CreateTable(
                name: "tblcap_interviewmark",
                columns: table => new
                {
                    interviewmarkid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    studentid = table.Column<int>(type: "int", nullable: true),
                    flanguage = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    fm = table.Column<int>(type: "int", nullable: false),
                    fmax = table.Column<int>(type: "int", nullable: false),
                    slanguage = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    sm = table.Column<int>(type: "int", nullable: false),
                    smax = table.Column<int>(type: "int", nullable: false),
                    optional1 = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    m1 = table.Column<int>(type: "int", nullable: false),
                    max1 = table.Column<int>(type: "int", nullable: false),
                    optional2 = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    m2 = table.Column<int>(type: "int", nullable: false),
                    max2 = table.Column<int>(type: "int", nullable: false),
                    optional3 = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    m3 = table.Column<int>(type: "int", nullable: false),
                    max3 = table.Column<int>(type: "int", nullable: false),
                    optional4 = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    m4 = table.Column<int>(type: "int", nullable: false),
                    max4 = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblcap_interviewmark", x => x.interviewmarkid);
                });

            migrationBuilder.CreateTable(
                name: "tblcap_principal",
                columns: table => new
                {
                    principalid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    username = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    password = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblcap_principal", x => x.principalid);
                });

            migrationBuilder.CreateTable(
                name: "tblcap_religion",
                columns: table => new
                {
                    religionid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    religionname = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblcap_religion", x => x.religionid);
                });

            migrationBuilder.CreateTable(
                name: "tblcap_state",
                columns: table => new
                {
                    stateid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    statename = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblcap_state", x => x.stateid);
                });

            migrationBuilder.CreateTable(
                name: "tblcap_application",
                columns: table => new
                {
                    applicationno = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    studentid = table.Column<int>(type: "int", nullable: true),
                    firstoption = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    secondoption = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    thirdoption = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    tenthboard = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    tenthinstitution = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    tenthplace = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    tenthstate = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    tenthyear = table.Column<DateTime>(type: "datetime2", nullable: false),
                    tenthmark = table.Column<int>(type: "int", nullable: false),
                    tenthnoofattempts = table.Column<int>(type: "int", nullable: false),
                    twelfthboard = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    twelfthinstitution = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    twelfthplace = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    twelfthstate = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    twelfthyear = table.Column<DateTime>(type: "datetime2", nullable: false),
                    twelfthmark = table.Column<int>(type: "int", nullable: false),
                    twelfthnoofattempts = table.Column<int>(type: "int", nullable: false),
                    date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    applicationstatus = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblcap_application", x => x.applicationno);
                    table.ForeignKey(
                        name: "FK_tblcap_application_tblcap_basicdetails_studentid",
                        column: x => x.studentid,
                        principalTable: "tblcap_basicdetails",
                        principalColumn: "studentid");
                });

            migrationBuilder.CreateTable(
                name: "tblcap_office",
                columns: table => new
                {
                    officeid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    studentid = table.Column<int>(type: "int", nullable: true),
                    status = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    staffincharge = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    comment = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    username = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    password = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblcap_office", x => x.officeid);
                    table.ForeignKey(
                        name: "FK_tblcap_office_tblcap_basicdetails_studentid",
                        column: x => x.studentid,
                        principalTable: "tblcap_basicdetails",
                        principalColumn: "studentid");
                });

            migrationBuilder.CreateTable(
                name: "tblcap_parent",
                columns: table => new
                {
                    officeid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    studentid = table.Column<int>(type: "int", nullable: true),
                    father = table.Column<string>(type: "nvarchar(35)", maxLength: 35, nullable: true),
                    mother = table.Column<string>(type: "nvarchar(35)", maxLength: 35, nullable: true),
                    foccuption = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    moccuption = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    fcontact = table.Column<int>(type: "int", nullable: false),
                    mcontact = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblcap_parent", x => x.officeid);
                    table.ForeignKey(
                        name: "FK_tblcap_parent_tblcap_basicdetails_studentid",
                        column: x => x.studentid,
                        principalTable: "tblcap_basicdetails",
                        principalColumn: "studentid");
                });

            migrationBuilder.CreateTable(
                name: "tblcap_interview",
                columns: table => new
                {
                    interviewid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    studentid = table.Column<int>(type: "int", nullable: true),
                    interviewerid = table.Column<int>(type: "int", nullable: false),
                    attitude = table.Column<int>(type: "int", nullable: false),
                    personality = table.Column<int>(type: "int", nullable: false),
                    logicalskill = table.Column<int>(type: "int", nullable: false),
                    behaviour = table.Column<int>(type: "int", nullable: false),
                    subjectknowledge = table.Column<int>(type: "int", nullable: false),
                    language = table.Column<int>(type: "int", nullable: false),
                    interviewdate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    remark = table.Column<string>(type: "nvarchar(35)", maxLength: 35, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblcap_interview", x => x.interviewid);
                    table.ForeignKey(
                        name: "FK_tblcap_interview_tblcap_basicdetails_studentid",
                        column: x => x.studentid,
                        principalTable: "tblcap_basicdetails",
                        principalColumn: "studentid");
                    table.ForeignKey(
                        name: "FK_tblcap_interview_tblcap_interviewer_interviewerid",
                        column: x => x.interviewerid,
                        principalTable: "tblcap_interviewer",
                        principalColumn: "interviewerid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tblcap_caste",
                columns: table => new
                {
                    casteid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    castename = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: true),
                    religionid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblcap_caste", x => x.casteid);
                    table.ForeignKey(
                        name: "FK_tblcap_caste_tblcap_religion_religionid",
                        column: x => x.religionid,
                        principalTable: "tblcap_religion",
                        principalColumn: "religionid");
                });

            migrationBuilder.CreateTable(
                name: "tblcap_district",
                columns: table => new
                {
                    districtid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    districtname = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    stateid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblcap_district", x => x.districtid);
                    table.ForeignKey(
                        name: "FK_tblcap_district_tblcap_state_stateid",
                        column: x => x.stateid,
                        principalTable: "tblcap_state",
                        principalColumn: "stateid");
                });

            migrationBuilder.CreateTable(
                name: "tblcap_personaldetails",
                columns: table => new
                {
                    personalid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    studentid = table.Column<int>(type: "int", nullable: true),
                    image = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    nameoffather = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    dateofbirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    nationality = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    annualincome = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    religionid = table.Column<int>(type: "int", nullable: true),
                    casteid = table.Column<int>(type: "int", nullable: true),
                    housename = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    place = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    stateid = table.Column<int>(type: "int", nullable: true),
                    districtid = table.Column<int>(type: "int", nullable: true),
                    pincode = table.Column<int>(type: "int", nullable: false),
                    email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    tempstatus = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    approvedcourse = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblcap_personaldetails", x => x.personalid);
                    table.ForeignKey(
                        name: "FK_tblcap_personaldetails_tblcap_basicdetails_studentid",
                        column: x => x.studentid,
                        principalTable: "tblcap_basicdetails",
                        principalColumn: "studentid");
                    table.ForeignKey(
                        name: "FK_tblcap_personaldetails_tblcap_caste_casteid",
                        column: x => x.casteid,
                        principalTable: "tblcap_caste",
                        principalColumn: "casteid");
                    table.ForeignKey(
                        name: "FK_tblcap_personaldetails_tblcap_district_districtid",
                        column: x => x.districtid,
                        principalTable: "tblcap_district",
                        principalColumn: "districtid");
                    table.ForeignKey(
                        name: "FK_tblcap_personaldetails_tblcap_religion_religionid",
                        column: x => x.religionid,
                        principalTable: "tblcap_religion",
                        principalColumn: "religionid");
                    table.ForeignKey(
                        name: "FK_tblcap_personaldetails_tblcap_state_stateid",
                        column: x => x.stateid,
                        principalTable: "tblcap_state",
                        principalColumn: "stateid");
                });

            migrationBuilder.CreateIndex(
                name: "IX_tblcap_application_studentid",
                table: "tblcap_application",
                column: "studentid");

            migrationBuilder.CreateIndex(
                name: "IX_tblcap_caste_religionid",
                table: "tblcap_caste",
                column: "religionid");

            migrationBuilder.CreateIndex(
                name: "IX_tblcap_district_stateid",
                table: "tblcap_district",
                column: "stateid");

            migrationBuilder.CreateIndex(
                name: "IX_tblcap_interview_interviewerid",
                table: "tblcap_interview",
                column: "interviewerid");

            migrationBuilder.CreateIndex(
                name: "IX_tblcap_interview_studentid",
                table: "tblcap_interview",
                column: "studentid");

            migrationBuilder.CreateIndex(
                name: "IX_tblcap_office_studentid",
                table: "tblcap_office",
                column: "studentid");

            migrationBuilder.CreateIndex(
                name: "IX_tblcap_parent_studentid",
                table: "tblcap_parent",
                column: "studentid");

            migrationBuilder.CreateIndex(
                name: "IX_tblcap_personaldetails_casteid",
                table: "tblcap_personaldetails",
                column: "casteid");

            migrationBuilder.CreateIndex(
                name: "IX_tblcap_personaldetails_districtid",
                table: "tblcap_personaldetails",
                column: "districtid");

            migrationBuilder.CreateIndex(
                name: "IX_tblcap_personaldetails_religionid",
                table: "tblcap_personaldetails",
                column: "religionid");

            migrationBuilder.CreateIndex(
                name: "IX_tblcap_personaldetails_stateid",
                table: "tblcap_personaldetails",
                column: "stateid");

            migrationBuilder.CreateIndex(
                name: "IX_tblcap_personaldetails_studentid",
                table: "tblcap_personaldetails",
                column: "studentid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tblcap_application");

            migrationBuilder.DropTable(
                name: "tblcap_course");

            migrationBuilder.DropTable(
                name: "tblcap_interview");

            migrationBuilder.DropTable(
                name: "tblcap_interviewmark");

            migrationBuilder.DropTable(
                name: "tblcap_office");

            migrationBuilder.DropTable(
                name: "tblcap_parent");

            migrationBuilder.DropTable(
                name: "tblcap_personaldetails");

            migrationBuilder.DropTable(
                name: "tblcap_principal");

            migrationBuilder.DropTable(
                name: "tblcap_interviewer");

            migrationBuilder.DropTable(
                name: "tblcap_basicdetails");

            migrationBuilder.DropTable(
                name: "tblcap_caste");

            migrationBuilder.DropTable(
                name: "tblcap_district");

            migrationBuilder.DropTable(
                name: "tblcap_religion");

            migrationBuilder.DropTable(
                name: "tblcap_state");
        }
    }
}
