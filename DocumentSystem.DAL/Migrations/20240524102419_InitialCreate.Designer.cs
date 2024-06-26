﻿// <auto-generated />
using DocumentSystem.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DocumentSystem.DAL.Migrations
{
    [DbContext(typeof(DocumentSystemDbContext))]
    [Migration("20240524102419_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.5");

            modelBuilder.Entity("DocumentSystem.Core.Model.DocumentEntity", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<string>("ActiveTaskId")
                        .HasColumnType("TEXT");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ActiveTaskId");

                    b.ToTable("Documents");
                });

            modelBuilder.Entity("DocumentSystem.Core.Model.TaskEntity", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("PreviousTaskID")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("PreviousTaskID");

                    b.ToTable("Tasks");
                });

            modelBuilder.Entity("DocumentSystem.Core.Model.DocumentEntity", b =>
                {
                    b.HasOne("DocumentSystem.Core.Model.TaskEntity", "ActiveTask")
                        .WithMany()
                        .HasForeignKey("ActiveTaskId");

                    b.Navigation("ActiveTask");
                });

            modelBuilder.Entity("DocumentSystem.Core.Model.TaskEntity", b =>
                {
                    b.HasOne("DocumentSystem.Core.Model.DocumentEntity", null)
                        .WithMany("Tasks")
                        .HasForeignKey("PreviousTaskID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DocumentSystem.Core.Model.DocumentEntity", b =>
                {
                    b.Navigation("Tasks");
                });
#pragma warning restore 612, 618
        }
    }
}
