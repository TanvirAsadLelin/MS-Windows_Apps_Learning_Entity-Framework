using CodeFirstApproach_EntityFramework.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CodeFirstApproach_EntityFramework
{
    public partial class Form1 : Form
    {
        int id = 0;
        Employee model = new Employee();
        EmployeeDB_Context db = new EmployeeDB_Context();
        public Form1()
        {
            InitializeComponent();
            BindGridview();
        }

        void BindGridview()
        {
            dataGridViewEmployeeList.DataSource = db.Employees.ToList<Employee>();
            dataGridViewEmployeeList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        void ResetForm()
        {
            textBoxName.Clear();
            comboBoxGender.SelectedItem = null;
            textBoxAge.Clear();
            textBoxDesignation.Clear();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            
            db.Employees.Add(model);
            int value = db.SaveChanges();

            if (value > 0)
            {
                MessageBox.Show("Inserted successfuly", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                BindGridview();
                ResetForm();
            }
            else
            {
                MessageBox.Show("Insertion failed", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void dataGridViewEmployeeList_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            id = Convert.ToInt32( dataGridViewEmployeeList.SelectedRows[0].Cells[0].Value);
            model = db.Employees.Where(x => x.Id == id).FirstOrDefault();

            textBoxName.Text = model.Name;
            comboBoxGender.SelectedItem = model.Gender;
            textBoxAge.Text = model.Age.ToString();
            textBoxDesignation.Text = model.Designation;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            model.Id = id;
            model.Name = textBoxName.Text;
            model.Gender = comboBoxGender.SelectedItem.ToString();
            model.Age = Convert.ToInt32(textBoxAge.Text);
            model.Designation = textBoxDesignation.Text;

            db.Entry(model).State = EntityState.Modified;
            int value = db.SaveChanges();

            if (value > 0)
            {
                MessageBox.Show("Updated successfuly", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                BindGridview();
                ResetForm();
            }
            else
            {
                MessageBox.Show("Update failed", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Are you sure to delete this data !", "Alert", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dr == DialogResult.Yes)
            {
                model = db.Employees.Where(x => x.Id == id).FirstOrDefault();
                db.Entry(model).State = EntityState.Deleted;
                int value = db.SaveChanges();

                if (value > 0)
                {
                    MessageBox.Show("Deleted successfuly", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    BindGridview();
                    ResetForm();
                }
                else
                {
                    MessageBox.Show("Delation failed", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("You cancel the delete operation", "NO", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
