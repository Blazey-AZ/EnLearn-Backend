﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using enlearn.Data;

#nullable disable

namespace enlearn.Data.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20230319172852_Migration3")]
    partial class Migration3
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("enlearn.Entities.application", b =>
                {
                    b.Property<int>("applicationno")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("applicationno"), 1L, 1);

                    b.Property<string>("applicationstatus")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<DateTime>("date")
                        .HasColumnType("datetime2");

                    b.Property<string>("firstoption")
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<string>("secondoption")
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<int?>("studentid")
                        .HasColumnType("int");

                    b.Property<string>("tenthboard")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("tenthinstitution")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("tenthmark")
                        .HasColumnType("int");

                    b.Property<int>("tenthnoofattempts")
                        .HasColumnType("int");

                    b.Property<string>("tenthplace")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("tenthstate")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime>("tenthyear")
                        .HasColumnType("datetime2");

                    b.Property<string>("thirdoption")
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<string>("twelfthboard")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("twelfthinstitution")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("twelfthmark")
                        .HasColumnType("int");

                    b.Property<int>("twelfthnoofattempts")
                        .HasColumnType("int");

                    b.Property<string>("twelfthplace")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("twelfthstate")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime>("twelfthyear")
                        .HasColumnType("datetime2");

                    b.HasKey("applicationno");

                    b.HasIndex("studentid");

                    b.ToTable("tblcap_application");
                });

            modelBuilder.Entity("enlearn.Entities.basicdetails", b =>
                {
                    b.Property<int>("studentid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("studentid"), 1L, 1);

                    b.Property<string>("contactnumber")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("email")
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<string>("gender")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("parentcontact")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("password")
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<string>("status")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("studentname")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("username")
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.HasKey("studentid");

                    b.ToTable("tblcap_basicdetails");
                });

            modelBuilder.Entity("enlearn.Entities.caste", b =>
                {
                    b.Property<int>("casteid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("casteid"), 1L, 1);

                    b.Property<string>("castename")
                        .HasMaxLength(45)
                        .HasColumnType("nvarchar(45)");

                    b.Property<int?>("religionid")
                        .HasColumnType("int");

                    b.HasKey("casteid");

                    b.HasIndex("religionid");

                    b.ToTable("tblcap_caste");
                });

            modelBuilder.Entity("enlearn.Entities.course", b =>
                {
                    b.Property<int>("courseid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("courseid"), 1L, 1);

                    b.Property<string>("coursedescription")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("coursename")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("courseshortname")
                        .HasMaxLength(8)
                        .HasColumnType("nvarchar(8)");

                    b.Property<string>("coursetype")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("courseid");

                    b.ToTable("tblcap_course");
                });

            modelBuilder.Entity("enlearn.Entities.district", b =>
                {
                    b.Property<int>("districtid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("districtid"), 1L, 1);

                    b.Property<string>("districtname")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<int?>("stateid")
                        .HasColumnType("int");

                    b.HasKey("districtid");

                    b.HasIndex("stateid");

                    b.ToTable("tblcap_district");
                });

            modelBuilder.Entity("enlearn.Entities.interview", b =>
                {
                    b.Property<int>("interviewid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("interviewid"), 1L, 1);

                    b.Property<int>("attitude")
                        .HasColumnType("int");

                    b.Property<int>("behaviour")
                        .HasColumnType("int");

                    b.Property<DateTime>("interviewdate")
                        .HasColumnType("datetime2");

                    b.Property<int>("interviewerid")
                        .HasColumnType("int");

                    b.Property<int>("language")
                        .HasColumnType("int");

                    b.Property<int>("logicalskill")
                        .HasColumnType("int");

                    b.Property<int>("personality")
                        .HasColumnType("int");

                    b.Property<string>("remark")
                        .HasMaxLength(35)
                        .HasColumnType("nvarchar(35)");

                    b.Property<int?>("studentid")
                        .HasColumnType("int");

                    b.Property<int>("subjectknowledge")
                        .HasColumnType("int");

                    b.HasKey("interviewid");

                    b.HasIndex("interviewerid");

                    b.HasIndex("studentid");

                    b.ToTable("tblcap_interview");
                });

            modelBuilder.Entity("enlearn.Entities.interviewer", b =>
                {
                    b.Property<int>("interviewerid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("interviewerid"), 1L, 1);

                    b.Property<int>("contact")
                        .HasColumnType("int");

                    b.Property<string>("department")
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<string>("email")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("name")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("password")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("username")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("interviewerid");

                    b.ToTable("tblcap_interviewer");
                });

            modelBuilder.Entity("enlearn.Entities.interviewmark", b =>
                {
                    b.Property<int>("interviewmarkid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("interviewmarkid"), 1L, 1);

                    b.Property<string>("flanguage")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<int>("fm")
                        .HasColumnType("int");

                    b.Property<int>("fmax")
                        .HasColumnType("int");

                    b.Property<int>("m1")
                        .HasColumnType("int");

                    b.Property<int>("m2")
                        .HasColumnType("int");

                    b.Property<int>("m3")
                        .HasColumnType("int");

                    b.Property<int>("m4")
                        .HasColumnType("int");

                    b.Property<int>("max1")
                        .HasColumnType("int");

                    b.Property<int>("max2")
                        .HasColumnType("int");

                    b.Property<int>("max3")
                        .HasColumnType("int");

                    b.Property<int>("max4")
                        .HasColumnType("int");

                    b.Property<string>("optional1")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("optional2")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("optional3")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("optional4")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("slanguage")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<int>("sm")
                        .HasColumnType("int");

                    b.Property<int>("smax")
                        .HasColumnType("int");

                    b.Property<int?>("studentid")
                        .HasColumnType("int");

                    b.HasKey("interviewmarkid");

                    b.ToTable("tblcap_interviewmark");
                });

            modelBuilder.Entity("enlearn.Entities.office", b =>
                {
                    b.Property<int>("officeid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("officeid"), 1L, 1);

                    b.Property<string>("comment")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<DateTime>("date")
                        .HasColumnType("datetime2");

                    b.Property<string>("password")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("staffincharge")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("status")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<int?>("studentid")
                        .HasColumnType("int");

                    b.Property<string>("username")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("officeid");

                    b.HasIndex("studentid");

                    b.ToTable("tblcap_office");
                });

            modelBuilder.Entity("enlearn.Entities.parent", b =>
                {
                    b.Property<int>("parentid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("parentid"), 1L, 1);

                    b.Property<string>("father")
                        .HasMaxLength(35)
                        .HasColumnType("nvarchar(35)");

                    b.Property<int>("fcontact")
                        .HasColumnType("int");

                    b.Property<string>("foccuption")
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<int>("mcontact")
                        .HasColumnType("int");

                    b.Property<string>("moccuption")
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<string>("mother")
                        .HasMaxLength(35)
                        .HasColumnType("nvarchar(35)");

                    b.Property<int?>("studentid")
                        .HasColumnType("int");

                    b.HasKey("parentid");

                    b.HasIndex("studentid");

                    b.ToTable("tblcap_parent");
                });

            modelBuilder.Entity("enlearn.Entities.personaldetails", b =>
                {
                    b.Property<int>("personalid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("personalid"), 1L, 1);

                    b.Property<string>("annualincome")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("approvedcourse")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<int?>("casteid")
                        .HasColumnType("int");

                    b.Property<DateTime>("dateofbirth")
                        .HasColumnType("datetime2");

                    b.Property<int?>("districtid")
                        .HasColumnType("int");

                    b.Property<string>("email")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("housename")
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<string>("image")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("nameoffather")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("nationality")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<int>("pincode")
                        .HasColumnType("int");

                    b.Property<string>("place")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<int?>("religionid")
                        .HasColumnType("int");

                    b.Property<int?>("stateid")
                        .HasColumnType("int");

                    b.Property<int?>("studentid")
                        .HasColumnType("int");

                    b.Property<string>("tempstatus")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("personalid");

                    b.HasIndex("casteid");

                    b.HasIndex("districtid");

                    b.HasIndex("religionid");

                    b.HasIndex("stateid");

                    b.HasIndex("studentid");

                    b.ToTable("tblcap_personaldetails");
                });

            modelBuilder.Entity("enlearn.Entities.principal", b =>
                {
                    b.Property<int>("principalid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("principalid"), 1L, 1);

                    b.Property<string>("password")
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<string>("username")
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.HasKey("principalid");

                    b.ToTable("tblcap_principal");
                });

            modelBuilder.Entity("enlearn.Entities.religion", b =>
                {
                    b.Property<int>("religionid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("religionid"), 1L, 1);

                    b.Property<string>("religionname")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("religionid");

                    b.ToTable("tblcap_religion");
                });

            modelBuilder.Entity("enlearn.Entities.state", b =>
                {
                    b.Property<int>("stateid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("stateid"), 1L, 1);

                    b.Property<string>("statename")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("stateid");

                    b.ToTable("tblcap_state");
                });

            modelBuilder.Entity("enlearn.Entities.application", b =>
                {
                    b.HasOne("enlearn.Entities.basicdetails", "student")
                        .WithMany()
                        .HasForeignKey("studentid");

                    b.Navigation("student");
                });

            modelBuilder.Entity("enlearn.Entities.caste", b =>
                {
                    b.HasOne("enlearn.Entities.religion", "religion")
                        .WithMany()
                        .HasForeignKey("religionid");

                    b.Navigation("religion");
                });

            modelBuilder.Entity("enlearn.Entities.district", b =>
                {
                    b.HasOne("enlearn.Entities.state", "state")
                        .WithMany()
                        .HasForeignKey("stateid");

                    b.Navigation("state");
                });

            modelBuilder.Entity("enlearn.Entities.interview", b =>
                {
                    b.HasOne("enlearn.Entities.interviewer", "interviewer")
                        .WithMany()
                        .HasForeignKey("interviewerid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("enlearn.Entities.basicdetails", "student")
                        .WithMany()
                        .HasForeignKey("studentid");

                    b.Navigation("interviewer");

                    b.Navigation("student");
                });

            modelBuilder.Entity("enlearn.Entities.office", b =>
                {
                    b.HasOne("enlearn.Entities.basicdetails", "student")
                        .WithMany()
                        .HasForeignKey("studentid");

                    b.Navigation("student");
                });

            modelBuilder.Entity("enlearn.Entities.parent", b =>
                {
                    b.HasOne("enlearn.Entities.basicdetails", "student")
                        .WithMany()
                        .HasForeignKey("studentid");

                    b.Navigation("student");
                });

            modelBuilder.Entity("enlearn.Entities.personaldetails", b =>
                {
                    b.HasOne("enlearn.Entities.caste", "caste")
                        .WithMany()
                        .HasForeignKey("casteid");

                    b.HasOne("enlearn.Entities.district", "district")
                        .WithMany()
                        .HasForeignKey("districtid");

                    b.HasOne("enlearn.Entities.religion", "religion")
                        .WithMany()
                        .HasForeignKey("religionid");

                    b.HasOne("enlearn.Entities.state", "state")
                        .WithMany()
                        .HasForeignKey("stateid");

                    b.HasOne("enlearn.Entities.basicdetails", "student")
                        .WithMany()
                        .HasForeignKey("studentid");

                    b.Navigation("caste");

                    b.Navigation("district");

                    b.Navigation("religion");

                    b.Navigation("state");

                    b.Navigation("student");
                });
#pragma warning restore 612, 618
        }
    }
}
