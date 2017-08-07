using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ClinicalResearchAPI.Migrations
{
    public partial class firsttime : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Patients",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DoctorId = table.Column<int>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    ManagerId = table.Column<int>(nullable: false),
                    TechnicianId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ClinicalResult",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ClinicalDataPoint1 = table.Column<int>(nullable: false),
                    ClinicalDataPoint2 = table.Column<string>(nullable: true),
                    PatientId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClinicalResult", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClinicalResult_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StudyResult",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PatientId = table.Column<int>(nullable: true),
                    StudyDataPoint1 = table.Column<int>(nullable: false),
                    StudyDataPoint2 = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudyResult", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudyResult_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CustomClinicalDataPoint",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ClinicalResultId = table.Column<int>(nullable: true),
                    Key = table.Column<string>(nullable: true),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomClinicalDataPoint", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CustomClinicalDataPoint_ClinicalResult_ClinicalResultId",
                        column: x => x.ClinicalResultId,
                        principalTable: "ClinicalResult",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ClinicalResult_PatientId",
                table: "ClinicalResult",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomClinicalDataPoint_ClinicalResultId",
                table: "CustomClinicalDataPoint",
                column: "ClinicalResultId");

            migrationBuilder.CreateIndex(
                name: "IX_StudyResult_PatientId",
                table: "StudyResult",
                column: "PatientId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CustomClinicalDataPoint");

            migrationBuilder.DropTable(
                name: "StudyResult");

            migrationBuilder.DropTable(
                name: "ClinicalResult");

            migrationBuilder.DropTable(
                name: "Patients");
        }
    }
}
