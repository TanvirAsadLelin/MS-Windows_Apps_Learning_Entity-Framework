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


        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
