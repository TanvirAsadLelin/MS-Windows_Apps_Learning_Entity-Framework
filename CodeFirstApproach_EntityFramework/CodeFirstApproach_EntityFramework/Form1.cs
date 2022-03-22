using CodeFirstApproach_EntityFramework.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CodeFirstApproach_EntityFramework
{
    public partial class Form1 : Form
    {    

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
            model.Name = textBoxName.Text;
            model.Gender = comboBoxGender.SelectedItem.ToString();
            model.Age = Convert.ToInt32(textBoxAge.Text);
            model.Designation = textBoxDesignation.Text;
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
    }
}
