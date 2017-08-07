using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using ClinicalResearchAPI.Context;

namespace ClinicalResearchAPI.Migrations
{
    [DbContext(typeof(PatientContext))]
    partial class PatientContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.1")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Models.Models.ClinicalResult", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ClinicalDataPoint1");

                    b.Property<string>("ClinicalDataPoint2");

                    b.Property<int?>("PatientId");

                    b.HasKey("Id");

                    b.HasIndex("PatientId");

                    b.ToTable("ClinicalResult");
                });

            modelBuilder.Entity("Models.Models.CustomClinicalDataPoint", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("ClinicalResultId");

                    b.Property<string>("Key");

                    b.Property<string>("Value");

                    b.HasKey("Id");

                    b.HasIndex("ClinicalResultId");

                    b.ToTable("CustomClinicalDataPoint");
                });

            modelBuilder.Entity("Models.Models.Patient", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("DoctorId");

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<int>("ManagerId");

                    b.Property<int>("TechnicianId");

                    b.HasKey("Id");

                    b.ToTable("Patients");
                });

            modelBuilder.Entity("Models.Models.StudyResult", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("PatientId");

                    b.Property<int>("StudyDataPoint1");

                    b.Property<string>("StudyDataPoint2");

                    b.HasKey("Id");

                    b.HasIndex("PatientId");

                    b.ToTable("StudyResult");
                });

            modelBuilder.Entity("Models.Models.ClinicalResult", b =>
                {
                    b.HasOne("Models.Models.Patient")
                        .WithMany("ClinicalResults")
                        .HasForeignKey("PatientId");
                });

            modelBuilder.Entity("Models.Models.CustomClinicalDataPoint", b =>
                {
                    b.HasOne("Models.Models.ClinicalResult")
                        .WithMany("CustomClinicalDataPoints")
                        .HasForeignKey("ClinicalResultId");
                });

            modelBuilder.Entity("Models.Models.StudyResult", b =>
                {
                    b.HasOne("Models.Models.Patient")
                        .WithMany("StudyResults")
                        .HasForeignKey("PatientId");
                });
        }
    }
}
