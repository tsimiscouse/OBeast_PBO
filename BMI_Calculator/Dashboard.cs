using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Runtime.Remoting.Contexts;

namespace BMI_Calculator
{
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
           InitializeComponent();
        }
        private void ProgressButton_Click(object sender, EventArgs e)
        {
            ProgressTab Frm = new ProgressTab();
            Hide();
            Frm.ShowDialog();

        }

        private void ProfileButton_Click(object sender, EventArgs e)
        {
            SignInForm Frm = new SignInForm();
            Hide();
            Frm.ShowDialog();
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            String querry = "select * from BMI";
            SqlConnection connect = new SqlConnection("Data Source=LAPTOP-29Q67NHD\\SQLEXPRESS;Initial Catalog=BMIApp;Integrated Security=True");
            SqlCommand cmd = new SqlCommand(querry , connect);
            try
            {
                connect.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    weightInformation.Text = reader["Weight"].ToString();
                    HeightInformation.Text = reader["Height"].ToString();
                    BodyMassIndex.Text = reader["BMI"].ToString();
                    statusLabel.Text = reader["status"].ToString();
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                connect.Close();
            }
            
        }

        private void CalorieButton_Click(object sender, EventArgs e)
        {
            CalorieForm Frm = new CalorieForm();
            Hide();
            Frm.ShowDialog();
        }

        private void homeButton_Click(object sender, EventArgs e)
        {

        }

        private void ExerciseButton_Click(object sender, EventArgs e)
        {
            ExcersiceForm Frm = new ExcersiceForm();
            Hide();
            Frm.ShowDialog();
        }
    }
}
