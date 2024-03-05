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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowsFormsApp1
{
    public partial class Create : Form
    {

        private readonly DatabaseContext _db;
        public Create()
        {
            InitializeComponent();
            _db = new DatabaseContext();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string hoVaTen = textBox2.Text;
            string lop = textBox3.Text;
            string khoa = textBox4.Text;
            int soDienThoai;
            bool isValid = int.TryParse(textBox5.Text, out soDienThoai);

            if (isValid)
            {
                SinhVienModels sinhVienMoi = new SinhVienModels
                {
                    HoVaTen = hoVaTen,
                    Lop = lop,
                    Khoa = khoa,
                    SoDienThoai = soDienThoai
                };

                _db.SinhVien.Add(sinhVienMoi);
                _db.SaveChanges();

                MessageBox.Show("Thêm sinh viên thành công!");
                this.Close();
            }
        }
    }
}
