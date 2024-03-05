using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.Data;
using WindowsFormsApp1.Models;

namespace WindowsFormsApp1
{
    public partial class Edit : Form
    {
        private readonly DatabaseContext _db;
        public Edit(string masinhvien, string hovaten, string lop, string khoa, string sodienthoai)
        {
            InitializeComponent();
            _db = new DatabaseContext();
            textBox1.Text = masinhvien.ToString();
            textBox2.Text = hovaten.ToString();
            textBox3.Text = lop.ToString();
            textBox4.Text = khoa.ToString();
            textBox5.Text = sodienthoai.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int maSinhVien;
            int.TryParse(textBox1.Text, out maSinhVien);
            string hoVaTen = textBox2.Text;
            string lop = textBox3.Text;
            string khoa = textBox4.Text;
            int soDienThoai;
            bool isValid_2 = int.TryParse(textBox5.Text, out soDienThoai);

            if (isValid_2)
            {
                SinhVienModels sinhVienUpdate = new SinhVienModels
                {
                    MaSinhVien = maSinhVien, // Gán giá trị mã sinh viên
                    HoVaTen = hoVaTen,
                    Lop = lop,
                    Khoa = khoa,
                    SoDienThoai = soDienThoai
                };

                _db.SinhVien.Update(sinhVienUpdate);
                _db.SaveChanges();

                MessageBox.Show("Sửa sinh viên thành công!");
                this.Close();
            }
            else
            {
                MessageBox.Show("Số điện thoại không hợp lệ!");
            }
        }
    }
}
