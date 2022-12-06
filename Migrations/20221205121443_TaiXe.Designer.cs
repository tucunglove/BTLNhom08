﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BTLnhom08.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20221205121443_TaiXe")]
    partial class TaiXe
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.0");

            modelBuilder.Entity("BTL_nhom08.Models.BangGia", b =>
                {
                    b.Property<string>("GiaID")
                        .HasColumnType("TEXT");

                    b.Property<string>("GiaVe")
                        .HasColumnType("TEXT");

                    b.HasKey("GiaID");

                    b.ToTable("BangGia");
                });

            modelBuilder.Entity("BTL_nhom08.Models.ChuyenXe", b =>
                {
                    b.Property<string>("MaChuyenXe")
                        .HasColumnType("TEXT");

                    b.Property<string>("DiemDen")
                        .HasColumnType("TEXT");

                    b.Property<string>("DiemDi")
                        .HasColumnType("TEXT");

                    b.Property<string>("GiaID")
                        .HasColumnType("TEXT");

                    b.Property<string>("MaTaiXe")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("NgayDi")
                        .HasColumnType("TEXT");

                    b.Property<string>("TenChuyenXe")
                        .HasColumnType("TEXT");

                    b.HasKey("MaChuyenXe");

                    b.HasIndex("GiaID");

                    b.HasIndex("MaTaiXe");

                    b.ToTable("ChuyenXe");
                });

            modelBuilder.Entity("BTL_nhom08.Models.GioiTinh", b =>
                {
                    b.Property<string>("ID")
                        .HasColumnType("TEXT");

                    b.Property<string>("TenGioiTinh")
                        .HasColumnType("TEXT");

                    b.HasKey("ID");

                    b.ToTable("GioiTinh");
                });

            modelBuilder.Entity("BTL_nhom08.Models.KhachHang", b =>
                {
                    b.Property<string>("MaKhachHang")
                        .HasColumnType("TEXT");

                    b.Property<string>("CMND")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Diachi")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Ngaysinh")
                        .HasColumnType("TEXT");

                    b.Property<string>("SoDienThoai")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("TenGioiTinh")
                        .HasColumnType("TEXT");

                    b.Property<string>("TenKhachHang")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("MaKhachHang");

                    b.HasIndex("TenGioiTinh");

                    b.ToTable("KhachHang");
                });

            modelBuilder.Entity("BTL_nhom08.Models.NhanVien", b =>
                {
                    b.Property<string>("MaNhanVien")
                        .HasColumnType("TEXT");

                    b.Property<string>("CMND")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Diachi")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Ngaysinh")
                        .HasColumnType("TEXT");

                    b.Property<string>("SoDienThoai")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("TenGioiTinh")
                        .HasColumnType("TEXT");

                    b.Property<string>("TenNhanVien")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("MaNhanVien");

                    b.HasIndex("TenGioiTinh");

                    b.ToTable("NhanVien");
                });

            modelBuilder.Entity("BTL_nhom08.Models.TaiXe", b =>
                {
                    b.Property<string>("MaTaiXe")
                        .HasColumnType("TEXT");

                    b.Property<string>("CMND")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Diachi")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Ngaysinh")
                        .HasColumnType("TEXT");

                    b.Property<string>("SoDienThoai")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("TenGioiTinh")
                        .HasColumnType("TEXT");

                    b.Property<string>("TenTaiXe")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("MaTaiXe");

                    b.HasIndex("TenGioiTinh");

                    b.ToTable("TaiXe");
                });

            modelBuilder.Entity("BTL_nhom08.Models.TenXe", b =>
                {
                    b.Property<string>("XeID")
                        .HasColumnType("TEXT");

                    b.Property<string>("TenXe_BienSo")
                        .HasColumnType("TEXT");

                    b.HasKey("XeID");

                    b.ToTable("TenXe");
                });

            modelBuilder.Entity("BTL_nhom08.Models.VeXe", b =>
                {
                    b.Property<string>("MaVe")
                        .HasColumnType("TEXT");

                    b.Property<string>("MaKhachHang")
                        .HasColumnType("TEXT");

                    b.Property<string>("MaNhanVien")
                        .HasColumnType("TEXT");

                    b.Property<string>("TenVe")
                        .HasColumnType("TEXT");

                    b.Property<string>("TenXe_BienSo")
                        .HasColumnType("TEXT");

                    b.HasKey("MaVe");

                    b.HasIndex("MaKhachHang");

                    b.HasIndex("MaNhanVien");

                    b.HasIndex("TenXe_BienSo");

                    b.ToTable("VeXe");
                });

            modelBuilder.Entity("BTL_nhom08.Models.Xe", b =>
                {
                    b.Property<string>("MaXe")
                        .HasColumnType("TEXT");

                    b.Property<string>("MaTaiXe")
                        .HasColumnType("TEXT");

                    b.Property<string>("TenCuaXe")
                        .HasColumnType("TEXT");

                    b.HasKey("MaXe");

                    b.HasIndex("MaTaiXe");

                    b.HasIndex("TenCuaXe");

                    b.ToTable("Xe");
                });

            modelBuilder.Entity("BTL_nhom08.Models.ChuyenXe", b =>
                {
                    b.HasOne("BTL_nhom08.Models.BangGia", "BangGia")
                        .WithMany()
                        .HasForeignKey("GiaID");

                    b.HasOne("BTL_nhom08.Models.TaiXe", "TaiXe")
                        .WithMany()
                        .HasForeignKey("MaTaiXe")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BangGia");

                    b.Navigation("TaiXe");
                });

            modelBuilder.Entity("BTL_nhom08.Models.KhachHang", b =>
                {
                    b.HasOne("BTL_nhom08.Models.GioiTinh", "GioiTinh")
                        .WithMany()
                        .HasForeignKey("TenGioiTinh");

                    b.Navigation("GioiTinh");
                });

            modelBuilder.Entity("BTL_nhom08.Models.NhanVien", b =>
                {
                    b.HasOne("BTL_nhom08.Models.GioiTinh", "GioiTinh")
                        .WithMany()
                        .HasForeignKey("TenGioiTinh");

                    b.Navigation("GioiTinh");
                });

            modelBuilder.Entity("BTL_nhom08.Models.TaiXe", b =>
                {
                    b.HasOne("BTL_nhom08.Models.GioiTinh", "GioiTinh")
                        .WithMany()
                        .HasForeignKey("TenGioiTinh");

                    b.Navigation("GioiTinh");
                });

            modelBuilder.Entity("BTL_nhom08.Models.VeXe", b =>
                {
                    b.HasOne("BTL_nhom08.Models.KhachHang", "KhachHang")
                        .WithMany()
                        .HasForeignKey("MaKhachHang");

                    b.HasOne("BTL_nhom08.Models.NhanVien", "NhanVien")
                        .WithMany()
                        .HasForeignKey("MaNhanVien");

                    b.HasOne("BTL_nhom08.Models.TenXe", "TenXe")
                        .WithMany()
                        .HasForeignKey("TenXe_BienSo");

                    b.Navigation("KhachHang");

                    b.Navigation("NhanVien");

                    b.Navigation("TenXe");
                });

            modelBuilder.Entity("BTL_nhom08.Models.Xe", b =>
                {
                    b.HasOne("BTL_nhom08.Models.TaiXe", "TaiXe")
                        .WithMany()
                        .HasForeignKey("MaTaiXe");

                    b.HasOne("BTL_nhom08.Models.TenXe", "TenXe")
                        .WithMany()
                        .HasForeignKey("TenCuaXe");

                    b.Navigation("TaiXe");

                    b.Navigation("TenXe");
                });
#pragma warning restore 612, 618
        }
    }
}
