using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClubRegistration
{
    public partial class FrmClubRegistration : Form
    {
        private ClubRegistrationQuery clubRegistrationQuery;
        private int count = 1; 
        private int ID, Age;
        private string FirstName, MiddleName, LastName, Gender, Program;
        private long StudentId;

        public FrmClubRegistration()
        {
            InitializeComponent();
  
        }
        private void FrmClubRegistration_Load(object sender, EventArgs e)
        {
         
            clubRegistrationQuery = new ClubRegistrationQuery();
            RefreshListOfClubMembers();
            LoadComboBoxData();
        }


        private void LoadComboBoxData()
        {
            cboGender.Items.Clear();
            cboGender.Items.Add("Male");
            cboGender.Items.Add("Female");

            cboProgram.Items.Clear();
            cboProgram.Items.Add("BSIT");
            cboProgram.Items.Add("BSCS");
            cboProgram.Items.Add("BSCPE");

            cboGender.DropDownStyle = ComboBoxStyle.DropDownList;
            cboProgram.DropDownStyle = ComboBoxStyle.DropDownList;

            cboGender.SelectedIndex = 0;
            cboProgram.SelectedIndex = 0;
        }

        private void RefreshListOfClubMembers()
        {
            clubRegistrationQuery.DisplayList();
            dataGridView1.DataSource = clubRegistrationQuery.bindingSource;
        }

      
        private void Register_Click(object sender, EventArgs e)
        {
            try
            {
                ID = RegistrationID();
                StudentId = long.Parse(txtStudentId.Text);
                FirstName = txtFirstName.Text;
                MiddleName = txtMiddleName.Text;
                LastName = txtLastName.Text;
                Age = int.Parse(txtAge.Text);
                Gender = cboGender.SelectedItem.ToString();
                Program = cboProgram.SelectedItem.ToString();

                clubRegistrationQuery.RegisterStudent(StudentId, FirstName, MiddleName, LastName, Age, Gender, Program);

                RefreshListOfClubMembers();
                ClearInputs();

                MessageBox.Show("Student registered successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Registration Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearInputs()
        {
            txtStudentId.Clear();
            txtFirstName.Clear();
            txtMiddleName.Clear();
            txtLastName.Clear();
            txtAge.Clear();
            cboGender.SelectedIndex = 0;
            cboProgram.SelectedIndex = 0;
        }
    

        private int RegistrationID()
        {
            return count++;  
        }


        private void button3_Click(object sender, EventArgs e)
        {
            RefreshListOfClubMembers();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            RefreshListOfClubMembers();
        }

    }
}