using System.ComponentModel.DataAnnotations;

namespace BTL_nhom08.Models
{
    public class GioiTinh
    {
        public string? ID {get; set;}
        [Display (Name = "Giới tính")]
        public string? TenGioiTinh {get; set;}
    }
}