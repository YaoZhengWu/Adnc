﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Adnc.Infr.EfCore;

namespace  Adnc.Infr.EfCore.Migrations
{
    [DbContext(typeof(AdncDbContext))]
    [Migration("20200713135724_cfg2")]
    partial class cfg2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Adnc.Core.Entities.SysCfg", b =>
                {
                    b.Property<long>("ID")
                        .HasColumnName("ID")
                        .HasColumnType("bigint");

                    b.Property<string>("CfgDesc")
                        .HasColumnName("CfgDesc")
                        .HasColumnType("longtext CHARACTER SET utf8mb4")
                        .HasMaxLength(65535);

                    b.Property<string>("CfgName")
                        .HasColumnName("CfgName")
                        .HasColumnType("varchar(256) CHARACTER SET utf8mb4")
                        .HasMaxLength(256);

                    b.Property<string>("CfgValue")
                        .HasColumnName("CfgValue")
                        .HasColumnType("varchar(512) CHARACTER SET utf8mb4")
                        .HasMaxLength(512);

                    b.Property<long?>("CreateBy")
                        .HasColumnName("CreateBy")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("CreateTime")
                        .HasColumnName("CreateTime")
                        .HasColumnType("datetime");

                    b.Property<bool>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("tinyint(1)")
                        .HasDefaultValue(false);

                    b.Property<long?>("ModifyBy")
                        .HasColumnName("ModifyBy")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("ModifyTime")
                        .HasColumnName("ModifyTime")
                        .HasColumnType("datetime");

                    b.HasKey("ID");

                    b.ToTable("SysCfg");
                });

            modelBuilder.Entity("Adnc.Core.Entities.SysDept", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID")
                        .HasColumnType("bigint");

                    b.Property<long?>("CreateBy")
                        .HasColumnName("CreateBy")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("CreateTime")
                        .HasColumnName("CreateTime")
                        .HasColumnType("datetime");

                    b.Property<string>("FullName")
                        .HasColumnName("FullName")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4")
                        .HasMaxLength(255);

                    b.Property<long?>("ModifyBy")
                        .HasColumnName("ModifyBy")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("ModifyTime")
                        .HasColumnName("ModifyTime")
                        .HasColumnType("datetime");

                    b.Property<int?>("Num")
                        .HasColumnName("Num")
                        .HasColumnType("int");

                    b.Property<long?>("Pid")
                        .HasColumnName("Pid")
                        .HasColumnType("bigint");

                    b.Property<string>("Pids")
                        .HasColumnName("Pids")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4")
                        .HasMaxLength(255);

                    b.Property<string>("SimpleName")
                        .HasColumnName("SimpleName")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4")
                        .HasMaxLength(255);

                    b.Property<string>("Tips")
                        .HasColumnName("Tips")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4")
                        .HasMaxLength(255);

                    b.Property<int?>("Version")
                        .HasColumnName("Version")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.ToTable("SysDept");
                });

            modelBuilder.Entity("Adnc.Core.Entities.SysDict", b =>
                {
                    b.Property<long>("ID")
                        .HasColumnName("ID")
                        .HasColumnType("bigint");

                    b.Property<long?>("CreateBy")
                        .HasColumnName("CreateBy")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("CreateTime")
                        .HasColumnName("CreateTime")
                        .HasColumnType("datetime");

                    b.Property<bool>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("tinyint(1)")
                        .HasDefaultValue(false);

                    b.Property<long?>("ModifyBy")
                        .HasColumnName("ModifyBy")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("ModifyTime")
                        .HasColumnName("ModifyTime")
                        .HasColumnType("datetime");

                    b.Property<string>("Name")
                        .HasColumnName("Name")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4")
                        .HasMaxLength(255);

                    b.Property<string>("Num")
                        .HasColumnName("Num")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4")
                        .HasMaxLength(255);

                    b.Property<long?>("Pid")
                        .HasColumnName("Pid")
                        .HasColumnType("bigint");

                    b.Property<string>("Tips")
                        .HasColumnName("Tips")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4")
                        .HasMaxLength(255);

                    b.HasKey("ID");

                    b.ToTable("SysDict");
                });

            modelBuilder.Entity("Adnc.Core.Entities.SysFileInfo", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID")
                        .HasColumnType("bigint");

                    b.Property<long?>("CreateBy")
                        .HasColumnName("CreateBy")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("CreateTime")
                        .HasColumnName("CreateTime")
                        .HasColumnType("datetime");

                    b.Property<long?>("ModifyBy")
                        .HasColumnName("ModifyBy")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("ModifyTime")
                        .HasColumnName("ModifyTime")
                        .HasColumnType("datetime");

                    b.Property<string>("OriginalFileName")
                        .HasColumnName("OriginalFileName")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4")
                        .HasMaxLength(255);

                    b.Property<string>("RealFileName")
                        .HasColumnName("RealFileName")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4")
                        .HasMaxLength(255);

                    b.HasKey("ID");

                    b.ToTable("SysFileInfo");
                });

            modelBuilder.Entity("Adnc.Core.Entities.SysLoginLog", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID")
                        .HasColumnType("int");

                    b.Property<DateTime?>("CreateTime")
                        .HasColumnName("CreateTime")
                        .HasColumnType("datetime");

                    b.Property<string>("IP")
                        .HasColumnName("IP")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4")
                        .HasMaxLength(255);

                    b.Property<string>("LoginName")
                        .HasColumnName("LoginName")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4")
                        .HasMaxLength(255);

                    b.Property<string>("Message")
                        .HasColumnName("Message")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4")
                        .HasMaxLength(255);

                    b.Property<string>("Succeed")
                        .HasColumnName("Succeed")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4")
                        .HasMaxLength(255);

                    b.Property<int?>("UserId")
                        .HasColumnName("UserId")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.ToTable("SysLoginLog");
                });

            modelBuilder.Entity("Adnc.Core.Entities.SysMenu", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID")
                        .HasColumnType("bigint");

                    b.Property<string>("Code")
                        .HasColumnName("Code")
                        .HasColumnType("varchar(32) CHARACTER SET utf8mb4")
                        .HasMaxLength(32);

                    b.Property<string>("Component")
                        .HasColumnName("Component")
                        .HasColumnType("varchar(64) CHARACTER SET utf8mb4")
                        .HasMaxLength(64);

                    b.Property<long?>("CreateBy")
                        .HasColumnName("CreateBy")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("CreateTime")
                        .HasColumnName("CreateTime")
                        .HasColumnType("datetime");

                    b.Property<bool?>("Hidden")
                        .HasColumnName("Hidden")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Icon")
                        .HasColumnName("Icon")
                        .HasColumnType("varchar(32) CHARACTER SET utf8mb4")
                        .HasMaxLength(32);

                    b.Property<bool>("IsMenu")
                        .HasColumnName("IsMenu")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool?>("IsOpen")
                        .HasColumnName("IsOpen")
                        .HasColumnType("tinyint(1)");

                    b.Property<int>("Levels")
                        .HasColumnName("Levels")
                        .HasColumnType("int");

                    b.Property<long?>("ModifyBy")
                        .HasColumnName("ModifyBy")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("ModifyTime")
                        .HasColumnName("ModifyTime")
                        .HasColumnType("datetime");

                    b.Property<string>("Name")
                        .HasColumnName("Name")
                        .HasColumnType("varchar(64) CHARACTER SET utf8mb4")
                        .HasMaxLength(64);

                    b.Property<int>("Num")
                        .HasColumnName("Num")
                        .HasColumnType("int");

                    b.Property<string>("PCode")
                        .HasColumnName("PCode")
                        .HasColumnType("varchar(64) CHARACTER SET utf8mb4")
                        .HasMaxLength(64);

                    b.Property<string>("PCodes")
                        .HasColumnName("PCodes")
                        .HasColumnType("varchar(128) CHARACTER SET utf8mb4")
                        .HasMaxLength(128);

                    b.Property<bool>("Status")
                        .HasColumnName("Status")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Tips")
                        .HasColumnName("Tips")
                        .HasColumnType("varchar(32) CHARACTER SET utf8mb4")
                        .HasMaxLength(32);

                    b.Property<string>("Url")
                        .HasColumnName("Url")
                        .HasColumnType("varchar(32) CHARACTER SET utf8mb4")
                        .HasMaxLength(32);

                    b.HasKey("ID");

                    b.ToTable("SysMenu");
                });

            modelBuilder.Entity("Adnc.Core.Entities.SysNotice", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID")
                        .HasColumnType("bigint");

                    b.Property<string>("Content")
                        .HasColumnName("Content")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4")
                        .HasMaxLength(255);

                    b.Property<long?>("CreateBy")
                        .HasColumnName("CreateBy")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("CreateTime")
                        .HasColumnName("CreateTime")
                        .HasColumnType("datetime");

                    b.Property<long?>("ModifyBy")
                        .HasColumnName("ModifyBy")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("ModifyTime")
                        .HasColumnName("ModifyTime")
                        .HasColumnType("datetime");

                    b.Property<string>("Title")
                        .HasColumnName("Title")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4")
                        .HasMaxLength(255);

                    b.Property<int?>("Type")
                        .HasColumnName("Type")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.ToTable("SysNotice");
                });

            modelBuilder.Entity("Adnc.Core.Entities.SysOperationLog", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID")
                        .HasColumnType("bigint");

                    b.Property<string>("ClassName")
                        .HasColumnName("ClassName")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4")
                        .HasMaxLength(255);

                    b.Property<DateTime?>("CreateTime")
                        .HasColumnName("CreateTime")
                        .HasColumnType("datetime");

                    b.Property<string>("LogName")
                        .HasColumnName("LogName")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4")
                        .HasMaxLength(255);

                    b.Property<string>("LogType")
                        .HasColumnName("LogType")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4")
                        .HasMaxLength(255);

                    b.Property<string>("Message")
                        .HasColumnName("Message")
                        .HasColumnType("longtext CHARACTER SET utf8mb4")
                        .HasMaxLength(65535);

                    b.Property<string>("Method")
                        .HasColumnName("Method")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4")
                        .HasMaxLength(255);

                    b.Property<string>("Succeed")
                        .HasColumnName("Succeed")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4")
                        .HasMaxLength(255);

                    b.Property<int?>("UserId")
                        .HasColumnName("UserId")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.ToTable("SysOperationLog");
                });

            modelBuilder.Entity("Adnc.Core.Entities.SysRelation", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID")
                        .HasColumnType("bigint");

                    b.Property<long>("MenuId")
                        .HasColumnName("MenuId")
                        .HasColumnType("bigint");

                    b.Property<long>("RoleId")
                        .HasColumnName("RoleId")
                        .HasColumnType("bigint");

                    b.HasKey("ID");

                    b.HasIndex("MenuId");

                    b.HasIndex("RoleId");

                    b.ToTable("SysRelation");
                });

            modelBuilder.Entity("Adnc.Core.Entities.SysRole", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID")
                        .HasColumnType("bigint");

                    b.Property<long?>("CreateBy")
                        .HasColumnName("CreateBy")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("CreateTime")
                        .HasColumnName("CreateTime")
                        .HasColumnType("datetime");

                    b.Property<long?>("DeptId")
                        .HasColumnName("DeptId")
                        .HasColumnType("bigint");

                    b.Property<long?>("ModifyBy")
                        .HasColumnName("ModifyBy")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("ModifyTime")
                        .HasColumnName("ModifyTime")
                        .HasColumnType("datetime");

                    b.Property<string>("Name")
                        .HasColumnName("Name")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4")
                        .HasMaxLength(255);

                    b.Property<int?>("Num")
                        .HasColumnName("Num")
                        .HasColumnType("int");

                    b.Property<long?>("PID")
                        .HasColumnName("Pid")
                        .HasColumnType("bigint");

                    b.Property<string>("Tips")
                        .HasColumnName("Tips")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4")
                        .HasMaxLength(255);

                    b.Property<int?>("Version")
                        .HasColumnName("Version")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.ToTable("SysRole");
                });

            modelBuilder.Entity("Adnc.Core.Entities.SysTask", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID")
                        .HasColumnType("bigint");

                    b.Property<bool?>("Concurrent")
                        .HasColumnName("Concurrent")
                        .HasColumnType("tinyint(1)");

                    b.Property<long?>("CreateBy")
                        .HasColumnName("CreateBy")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("CreateTime")
                        .HasColumnName("CreateTime")
                        .HasColumnType("datetime");

                    b.Property<string>("Cron")
                        .HasColumnName("Cron")
                        .HasColumnType("varchar(50) CHARACTER SET utf8mb4")
                        .HasMaxLength(50);

                    b.Property<string>("Data")
                        .HasColumnName("Data")
                        .HasColumnType("longtext CHARACTER SET utf8mb4")
                        .HasMaxLength(65535);

                    b.Property<bool?>("Disabled")
                        .HasColumnName("Disabled")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTime?>("ExecAt")
                        .HasColumnName("ExecAt")
                        .HasColumnType("datetime");

                    b.Property<string>("ExecResult")
                        .HasColumnName("ExecResult")
                        .HasColumnType("longtext CHARACTER SET utf8mb4")
                        .HasMaxLength(65535);

                    b.Property<string>("JobClass")
                        .HasColumnName("JobClass")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4")
                        .HasMaxLength(255);

                    b.Property<string>("JobGroup")
                        .HasColumnName("JobGroup")
                        .HasColumnType("varchar(50) CHARACTER SET utf8mb4")
                        .HasMaxLength(50);

                    b.Property<long?>("ModifyBy")
                        .HasColumnName("ModifyBy")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("ModifyTime")
                        .HasColumnName("ModifyTime")
                        .HasColumnType("datetime");

                    b.Property<string>("Name")
                        .HasColumnName("Name")
                        .HasColumnType("varchar(50) CHARACTER SET utf8mb4")
                        .HasMaxLength(50);

                    b.Property<string>("Note")
                        .HasColumnName("Note")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4")
                        .HasMaxLength(255);

                    b.HasKey("ID");

                    b.ToTable("SysTask");
                });

            modelBuilder.Entity("Adnc.Core.Entities.SysTaskLog", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("ExecAt")
                        .HasColumnName("ExecAt")
                        .HasColumnType("datetime");

                    b.Property<bool?>("ExecSuccess")
                        .HasColumnName("ExecSuccess")
                        .HasColumnType("tinyint(1)");

                    b.Property<long?>("IdTask")
                        .HasColumnName("IdTask")
                        .HasColumnType("bigint");

                    b.Property<string>("JobException")
                        .HasColumnName("JobException")
                        .HasColumnType("varchar(500) CHARACTER SET utf8mb4")
                        .HasMaxLength(500);

                    b.Property<string>("Name")
                        .HasColumnName("Name")
                        .HasColumnType("varchar(50) CHARACTER SET utf8mb4")
                        .HasMaxLength(50);

                    b.HasKey("ID");

                    b.ToTable("SysTaskLog");
                });

            modelBuilder.Entity("Adnc.Core.Entities.SysUser", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID")
                        .HasColumnType("bigint");

                    b.Property<string>("Account")
                        .HasColumnName("Account")
                        .HasColumnType("varchar(32) CHARACTER SET utf8mb4")
                        .HasMaxLength(32);

                    b.Property<string>("Avatar")
                        .HasColumnName("Avatar")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4")
                        .HasMaxLength(255);

                    b.Property<DateTime?>("Birthday")
                        .HasColumnName("Birthday")
                        .HasColumnType("datetime");

                    b.Property<long?>("CreateBy")
                        .HasColumnName("CreateBy")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("CreateTime")
                        .HasColumnName("CreateTime")
                        .HasColumnType("datetime");

                    b.Property<long?>("DeptId")
                        .HasColumnName("DeptId")
                        .HasColumnType("bigint");

                    b.Property<string>("Email")
                        .HasColumnName("Email")
                        .HasColumnType("varchar(64) CHARACTER SET utf8mb4")
                        .HasMaxLength(64);

                    b.Property<long?>("ModifyBy")
                        .HasColumnName("ModifyBy")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("ModifyTime")
                        .HasColumnName("ModifyTime")
                        .HasColumnType("datetime");

                    b.Property<string>("Name")
                        .HasColumnName("Name")
                        .HasColumnType("varchar(64) CHARACTER SET utf8mb4")
                        .HasMaxLength(64);

                    b.Property<string>("Password")
                        .HasColumnName("Password")
                        .HasColumnType("varchar(64) CHARACTER SET utf8mb4")
                        .HasMaxLength(64);

                    b.Property<string>("Phone")
                        .HasColumnName("Phone")
                        .HasColumnType("varchar(16) CHARACTER SET utf8mb4")
                        .HasMaxLength(16);

                    b.Property<string>("RoleId")
                        .HasColumnName("RoleId")
                        .HasColumnType("varchar(128) CHARACTER SET utf8mb4")
                        .HasMaxLength(128);

                    b.Property<string>("Salt")
                        .HasColumnName("Salt")
                        .HasColumnType("varchar(16) CHARACTER SET utf8mb4")
                        .HasMaxLength(16);

                    b.Property<int>("Sex")
                        .HasColumnName("Sex")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnName("Status")
                        .HasColumnType("int");

                    b.Property<int?>("Version")
                        .HasColumnName("Version")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("DeptId");

                    b.ToTable("SysUser");
                });

            modelBuilder.Entity("Adnc.Core.Entities.SysUserFinance", b =>
                {
                    b.Property<long>("ID")
                        .HasColumnName("ID")
                        .HasColumnType("bigint");

                    b.Property<decimal>("Amount")
                        .HasColumnName("Amount")
                        .HasColumnType("decimal(18,4)");

                    b.Property<long?>("CreateBy")
                        .HasColumnName("CreateBy")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("CreateTime")
                        .HasColumnName("CreateTime")
                        .HasColumnType("datetime");

                    b.Property<long?>("ModifyBy")
                        .HasColumnName("ModifyBy")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("ModifyTime")
                        .HasColumnName("ModifyTime")
                        .HasColumnType("datetime");

                    b.Property<DateTime?>("RowVersion")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnName("RowVersion")
                        .HasColumnType("timestamp(3)")
                        .HasDefaultValueSql("'2000-07-01 22:33:02.559'");

                    b.HasKey("ID");

                    b.ToTable("SysUserFinance");
                });

            modelBuilder.Entity("Adnc.Core.Entities.SysRelation", b =>
                {
                    b.HasOne("Adnc.Core.Entities.SysMenu", "Menu")
                        .WithMany("Relations")
                        .HasForeignKey("MenuId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Adnc.Core.Entities.SysRole", "Role")
                        .WithMany("Relations")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Adnc.Core.Entities.SysUser", b =>
                {
                    b.HasOne("Adnc.Core.Entities.SysDept", "Dept")
                        .WithMany("Users")
                        .HasForeignKey("DeptId")
                        .OnDelete(DeleteBehavior.SetNull);
                });

            modelBuilder.Entity("Adnc.Core.Entities.SysUserFinance", b =>
                {
                    b.HasOne("Adnc.Core.Entities.SysUser", "User")
                        .WithOne("UserFinance")
                        .HasForeignKey("Adnc.Core.Entities.SysUserFinance", "ID")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
