﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PDFViewer.Data;

#nullable disable

namespace PDFViewer.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20220722085735_addIdField")]
    partial class addIdField
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.7");

            modelBuilder.Entity("PDFViewer.Models.SvgAccessModel", b =>
                {
                    b.Property<string>("User")
                        .HasColumnType("TEXT");

                    b.Property<string>("AuthSvcUrl")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("CevreSistem")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Id")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("PrintSvcUrl")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("SirketID")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("User");

                    b.ToTable("SvgAccessModels");
                });
#pragma warning restore 612, 618
        }
    }
}
