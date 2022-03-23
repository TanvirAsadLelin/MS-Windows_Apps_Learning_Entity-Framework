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

namespace DatabaseFirstApproach_EntityFramework
{
    public partial class Form1 : Form
    {
        int id = 0; 
        Student_Tbl model =  new Student_Tbl();
        DatabaseFirstApproachEFDBEntities db = new DatabaseFirstApproachEFDBEntities();
        public Form1()
        {
            InitializeComponent();
            BindGridview();
        }

        void BindGridview()
        {
            dataGridViewStudentList.DataSource = db.Student_Tbl.ToList<Student_Tbl>();
            dataGridViewStudentList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            model.Name = textBoxName.Text.Trim();
            model.Gender = comboBoxGender.SelectedItem.ToString();
            model.Age = Convert.ToInt32( textBoxAge.Text.Trim());
            model.Class = Convert.ToInt32(textBoxClass.Text.Trim());
            db.Student_Tbl.Add(model);


          int value =  db.SaveChanges();
            if (value > 0)
            {
                MessageBox.Show("Inserted successfuly","Success",MessageBoxButtons.OK,MessageBoxIcon.Information);
                ResetDataForm();
                BindGridview();

            }
            else
            {
                MessageBox.Show("Insertion Failed", "Fail", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            model.Id = id;
            model.Name = textBoxName.Text.Trim();
            model.Gender = comboBoxGender.SelectedItem.ToString();
            model.Age = Convert.ToInt32(textBoxAge.Text.Trim());
            model.Class = Convert.ToInt32(textBoxClass.Text.Trim());

            //For update
            db.Entry(model).State = EntityState.Modified;

            int value = db.SaveChanges();
            if (value > 0)
            {
                MessageBox.Show("Updated successfuly", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ResetDataForm();
                BindGridview();

            }
            else
            {
                MessageBox.Show("Updation Failed", "Fail", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult dr =  MessageBox.Show("Are you sure to delete this item!","Delete",MessageBoxButtons.YesNo,MessageBoxIcon.Warning);

            if (dr == DialogResult.Yes)
            {
                model = db.Student_Tbl.Where(x => x.Id == id).FirstOrDefault();
                db.Entry(model).State = EntityState.Deleted;
                int value = db.SaveChanges();
                if (value > 0)
                {
                    MessageBox.Show("Deleted successfuly", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ResetDataForm();
                    BindGridview();

                }
                else
                {
                    MessageBox.Show("Deletion Failed", "Fail", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("No selecttion for delete", "Fail", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ResetDataForm();
        }

        void ResetDataForm()
        {
            textBoxName.Clear();
            comboBoxGender.SelectedItem = null;
            textBoxAge.Clear();
            textBoxClass.Clear(); 
        }

        private void dataGridViewStudentList_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            id =Convert.ToInt32( dataGridViewStudentList.SelectedRows[0].Cells[0].Value);

            model = db.Student_Tbl.Where(x => x.Id == id).FirstOrDefault();

            textBoxName.Text = model.Name;  
            comboBoxGender.SelectedItem = model.Gender;
            textBoxAge.Text = model.Age.ToString();
            textBoxClass.Text = model.Class.ToString();




        }
    }
}
