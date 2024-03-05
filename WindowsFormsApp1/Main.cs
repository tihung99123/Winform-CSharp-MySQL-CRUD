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
    public partial class Main : Form
    {
        private readonly DatabaseContext _db;

        public Main()
        {
            InitializeComponent();
            _db = new DatabaseContext();

            dataGridView1.Columns.Add("MaSinhVien", "Mã Sinh Viên");
            dataGridView1.Columns.Add("HoVaTen", "Họ và Tên");
            dataGridView1.Columns.Add("Lop", "Lớp");
            dataGridView1.Columns.Add("Khoa", "Khoa");
            dataGridView1.Columns.Add("SoDienThoai", "Số Điện Thoại");

            LoadData();
        }

        private void LoadData()
        {
            var students = _db.SinhVien.ToList();

            foreach (var student in students)
            {
                dataGridView1.Rows.Add(student.MaSinhVien, student.HoVaTen, student.Lop, student.Khoa, student.SoDienThoai);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();
            LoadData();
            dataGridView1.Refresh();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Create create = new Create();
            create.ShowDialog();
            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();
            LoadData();
            dataGridView1.Refresh();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
                string maSinhVien = selectedRow.Cells["MaSinhVien"].Value.ToString();
                string hoVaTen = selectedRow.Cells["HoVaTen"].Value.ToString();
                string lop = selectedRow.Cells["Lop"].Value.ToString();
                string khoa = selectedRow.Cells["Khoa"].Value.ToString();
                string soDienThoai = selectedRow.Cells["SoDienThoai"].Value.ToString();

                Edit edit = new Edit(maSinhVien, hoVaTen, lop, khoa, soDienThoai);
                edit.ShowDialog();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một sinh viên để chỉnh sửa!");
            }
            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();
            LoadData();
            dataGridView1.Refresh();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
                int maSinhVien;
                int.TryParse(selectedRow.Cells["MaSinhVien"].Value.ToString(),out maSinhVien);

                SinhVienModels sinhVienXoa = _db.SinhVien.FirstOrDefault(s => s.MaSinhVien == maSinhVien);
                if (sinhVienXoa != null)
                {
                    _db.SinhVien.Remove(sinhVienXoa);
                    _db.SaveChanges();
                    MessageBox.Show("Xóa sinh viên thành công!");
                }
                else
                {
                    MessageBox.Show("Không tìm thấy sinh viên cần xóa!");
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một sinh viên để xóa!");
            }
            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();
            LoadData();
            dataGridView1.Refresh();
        }
    }
}
