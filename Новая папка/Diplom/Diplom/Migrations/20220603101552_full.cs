using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Diplom.Migrations
{
    public partial class full : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cabinets",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titl = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cabinets", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Genders",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titl = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Specialities",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titl = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Specialities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Doctors",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Surname = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Lastname = table.Column<string>(nullable: true),
                    SpecialityId = table.Column<int>(nullable: false),
                    CabinetId = table.Column<int>(nullable: false),
                    DateOfEmployment = table.Column<DateTime>(nullable: false),
                    WorkWith = table.Column<DateTime>(nullable: false),
                    WorkUntil = table.Column<DateTime>(nullable: false),
                    TicketId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doctors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Doctors_Cabinets_CabinetId",
                        column: x => x.CabinetId,
                        principalTable: "Cabinets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Doctors_Specialities_SpecialityId",
                        column: x => x.SpecialityId,
                        principalTable: "Specialities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ticket",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PatientId = table.Column<int>(nullable: false),
                    DoctorId = table.Column<int>(nullable: false),
                    CabinetId = table.Column<int>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    ReceptionHourId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ticket", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ticket_Doctors_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Doctors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Patients",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Surname = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Lastname = table.Column<string>(nullable: true),
                    GenderId = table.Column<int>(nullable: false),
                    DateOfBirth = table.Column<DateTime>(nullable: false),
                    Policy = table.Column<string>(nullable: true),
                    Snils = table.Column<string>(nullable: true),
                    PassportSeries = table.Column<string>(nullable: true),
                    PassportNumber = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    TicketId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Patients_Genders_GenderId",
                        column: x => x.GenderId,
                        principalTable: "Genders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Patients_Ticket_TicketId",
                        column: x => x.TicketId,
                        principalTable: "Ticket",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ReceptionHours",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartOfReception = table.Column<DateTime>(nullable: false),
                    EndOfReception = table.Column<DateTime>(nullable: false),
                    TicketId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReceptionHours", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReceptionHours_Ticket_TicketId",
                        column: x => x.TicketId,
                        principalTable: "Ticket",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MedicalСards",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PatientId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicalСards", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MedicalСards_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MedicalRecords",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MedicalСardId = table.Column<int>(nullable: false),
                    DoctorSurname = table.Column<string>(nullable: true),
                    DoctorName = table.Column<string>(nullable: true),
                    DoctorLastname = table.Column<string>(nullable: true),
                    Diagnosis = table.Column<string>(nullable: true),
                    StartOfTreatment = table.Column<DateTime>(nullable: false),
                    EndOfTreatment = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicalRecords", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MedicalRecords_MedicalСards_MedicalСardId",
                        column: x => x.MedicalСardId,
                        principalTable: "MedicalСards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Medicines",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MedicalRecordId = table.Column<int>(nullable: false),
                    Titl = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medicines", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Medicines_MedicalRecords_MedicalRecordId",
                        column: x => x.MedicalRecordId,
                        principalTable: "MedicalRecords",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_CabinetId",
                table: "Doctors",
                column: "CabinetId");

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_SpecialityId",
                table: "Doctors",
                column: "SpecialityId");

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_TicketId",
                table: "Doctors",
                column: "TicketId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicalRecords_MedicalСardId",
                table: "MedicalRecords",
                column: "MedicalСardId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicalСards_PatientId",
                table: "MedicalСards",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_Medicines_MedicalRecordId",
                table: "Medicines",
                column: "MedicalRecordId");

            migrationBuilder.CreateIndex(
                name: "IX_Patients_GenderId",
                table: "Patients",
                column: "GenderId");

            migrationBuilder.CreateIndex(
                name: "IX_Patients_TicketId",
                table: "Patients",
                column: "TicketId");

            migrationBuilder.CreateIndex(
                name: "IX_ReceptionHours_TicketId",
                table: "ReceptionHours",
                column: "TicketId");

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_DoctorId",
                table: "Ticket",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_PatientId",
                table: "Ticket",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_ReceptionHourId",
                table: "Ticket",
                column: "ReceptionHourId");

            migrationBuilder.AddForeignKey(
                name: "FK_Doctors_Ticket_TicketId",
                table: "Doctors",
                column: "TicketId",
                principalTable: "Ticket",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Ticket_Patients_PatientId",
                table: "Ticket",
                column: "PatientId",
                principalTable: "Patients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ticket_ReceptionHours_ReceptionHourId",
                table: "Ticket",
                column: "ReceptionHourId",
                principalTable: "ReceptionHours",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Doctors_Cabinets_CabinetId",
                table: "Doctors");

            migrationBuilder.DropForeignKey(
                name: "FK_Doctors_Specialities_SpecialityId",
                table: "Doctors");

            migrationBuilder.DropForeignKey(
                name: "FK_Doctors_Ticket_TicketId",
                table: "Doctors");

            migrationBuilder.DropForeignKey(
                name: "FK_Patients_Ticket_TicketId",
                table: "Patients");

            migrationBuilder.DropForeignKey(
                name: "FK_ReceptionHours_Ticket_TicketId",
                table: "ReceptionHours");

            migrationBuilder.DropTable(
                name: "Medicines");

            migrationBuilder.DropTable(
                name: "MedicalRecords");

            migrationBuilder.DropTable(
                name: "MedicalСards");

            migrationBuilder.DropTable(
                name: "Cabinets");

            migrationBuilder.DropTable(
                name: "Specialities");

            migrationBuilder.DropTable(
                name: "Ticket");

            migrationBuilder.DropTable(
                name: "Doctors");

            migrationBuilder.DropTable(
                name: "Patients");

            migrationBuilder.DropTable(
                name: "ReceptionHours");

            migrationBuilder.DropTable(
                name: "Genders");
        }
    }
}
