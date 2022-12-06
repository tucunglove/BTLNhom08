using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BTL_nhom08.Models;

    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext (DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<BTL_nhom08.Models.TenXe> TenXe { get; set; } = default!;

        public DbSet<BTL_nhom08.Models.Xe> Xe { get; set; } = default!;

        public DbSet<BTL_nhom08.Models.VeXe> VeXe { get; set; } = default!;

        public DbSet<BTL_nhom08.Models.TaiXe> TaiXe { get; set; } = default!;

        public DbSet<BTL_nhom08.Models.GioiTinh> GioiTinh { get; set; } = default!;

        public DbSet<BTL_nhom08.Models.KhachHang> KhachHang { get; set; } = default!;

        public DbSet<BTL_nhom08.Models.NhanVien> NhanVien { get; set; } = default!;

        public DbSet<BTL_nhom08.Models.ChuyenXe> ChuyenXe { get; set; } = default!;

        public DbSet<BTL_nhom08.Models.BangGia> BangGia { get; set; } = default!;
    }
