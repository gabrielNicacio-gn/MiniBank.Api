﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MiniBank.Api.Data;

#nullable disable

namespace MiniBank.Api.Migrations
{
    [DbContext(typeof(BankDb))]
    partial class BankDbModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.0");

            modelBuilder.Entity("MiniBank.Api.Models.Deposite", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DepositeDateAndTime")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("UserId")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Value")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Deposites");
                });

            modelBuilder.Entity("MiniBank.Api.Models.Transaction", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("ReceiverId")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("SenderId")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("TransactionDateAndTime")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Value")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ReceiverId");

                    b.HasIndex("SenderId");

                    b.ToTable("Transactions");
                });

            modelBuilder.Entity("MiniBank.Api.Models.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Balance")
                        .HasColumnType("TEXT");

                    b.Property<string>("Document")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsActivate")
                        .HasColumnType("INTEGER");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(120)
                        .HasColumnType("TEXT");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("UserType")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("Document")
                        .IsUnique();

                    b.HasIndex("Email")
                        .IsUnique();

                    b.ToTable("Users");
                });

            modelBuilder.Entity("MiniBank.Api.Models.Deposite", b =>
                {
                    b.HasOne("MiniBank.Api.Models.User", "Depositor")
                        .WithMany("DepositeOfUser")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Depositor");
                });

            modelBuilder.Entity("MiniBank.Api.Models.Transaction", b =>
                {
                    b.HasOne("MiniBank.Api.Models.User", "Receiver")
                        .WithMany("TransactionsReceiver")
                        .HasForeignKey("ReceiverId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MiniBank.Api.Models.User", "Sender")
                        .WithMany("TransactionsSender")
                        .HasForeignKey("SenderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Receiver");

                    b.Navigation("Sender");
                });

            modelBuilder.Entity("MiniBank.Api.Models.User", b =>
                {
                    b.Navigation("DepositeOfUser");

                    b.Navigation("TransactionsReceiver");

                    b.Navigation("TransactionsSender");
                });
#pragma warning restore 612, 618
        }
    }
}
