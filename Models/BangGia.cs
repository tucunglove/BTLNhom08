using System.ComponentModel.DataAnnotations;
namespace BTL_nhom08.Models
{
    public class BangGia
    {
        [Key]
        public string? GiaID {get; set;}
        [Display (Name = "Giá vé")]
        public string? GiaVe {get; set;}
    }
}