using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Models
{
    internal class SinhVienModels
    {
        [Key]
        public int MaSinhVien {  get; set; }
        public string HoVaTen { get; set; }
        public string Lop { get; set; }
        public string Khoa { get; set; }
        public int SoDienThoai { get; set; }
    }
}
