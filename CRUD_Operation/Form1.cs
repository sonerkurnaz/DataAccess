using CRUD_Operation.Context;
using CRUD_Operation.Model.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRUD_Operation
{
    public partial class Form1 : Form
    {
        AppDbContext db = new AppDbContext();
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            Category category = new Category();
            category.Name = txtName.Text;
            category.Description = txtDescription.Text;

            db.Categories.Add(category);
            db.SaveChanges();

            DataGridRefresh();



        }
        public void DataGridRefresh()
        {
            dataGridView1.DataSource = db.Categories
                .Where(p => p.Status != Model.Abstract.Status.Passive)
                .Select(x => new {
                    x.Id,
                    x.Name,
                    x.Description,
                    x.CreateDate
                }).ToList(); ;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DataGridRefresh();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                label3.Text = row.Cells[0].Value.ToString();
                txtName.Text = row.Cells[1].Value.ToString();
                txtDescription.Text = row.Cells[2].Value.ToString();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var category = db.Categories
                .FirstOrDefault(p => p.Id == int.Parse(label3.Text));

            category.Name = txtName.Text;
            category.Description = txtDescription.Text;
            category.UpdateDate = DateTime.Now;
            category.Status = Model.Abstract.Status.Modify;
            db.Categories.Update(category);
            db.SaveChanges();

            DataGridRefresh();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var category = db.Categories
               .FirstOrDefault(p => p.Id == int.Parse(label3.Text));
            category.DeleteDate = DateTime.Now;

            category.Name = txtName.Text;
            category.Description = txtDescription.Text;
            category.UpdateDate = DateTime.Now;
            category.Status = Model.Abstract.Status.Passive;
            db.Categories.Update(category);
            db.SaveChanges();

            DataGridRefresh();
        }
    }
}
