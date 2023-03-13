using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;


namespace EyeHMS
{
    public partial class Form1 : Form
    {
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-5BIT6VN\\SQLEXPRESS;Initial Catalog=C:\\USERS\\USER\\DOCUMENTS\\EYECAREDB.MDF;Integrated Security=True");

        public Form1()
        {
            InitializeComponent();
        }
        public void listele()
        {
            
            SqlDataAdapter da=new SqlDataAdapter("select*from PatientTbl",con); 
            DataSet dataSet=new DataSet();
            da.Fill(dataSet);
            guna2DataGridView1.DataSource= dataSet.Tables[0];
        }
        
        private void button2_Click(object sender, EventArgs e)
        {
            
            con.Open();
            SqlCommand command = new SqlCommand("insert into PatientTbl(PatName,PatPhone,PatAdress,PatDOB,PatGender,PatAllergies)values(@PatName,@PatPhone,@PatAdress,@PatDOB,@PatGender,@PatAllergies)", con);
            command.Parameters.AddWithValue("@PatName", textBox1.Text);
            command.Parameters.AddWithValue("@PatPhone", textBox2.Text);
            command.Parameters.AddWithValue("@PatAdress", textBox3.Text);
            command.Parameters.AddWithValue("@PatDOB", Convert.ToString(textBox4.Text));
            command.Parameters.AddWithValue("@PatGender", comboBox1.Text);
            command.Parameters.AddWithValue("@PatAllergies", textBox6.Text);
            command.ExecuteNonQuery();
            listele();
            con.Close();

            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox6.Clear();
            textBox1.Focus();


        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

                    }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();
        }

        private void guna2DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            DataGridViewRow selectedRow = guna2DataGridView1.Rows[index];
            textBox1.Text = selectedRow.Cells[1].Value.ToString();
            textBox2.Text = selectedRow.Cells[2].Value.ToString();
            textBox3.Text = selectedRow.Cells[3].Value.ToString();
            textBox4.Text = selectedRow.Cells[4].Value.ToString();
            comboBox1.Text = selectedRow.Cells[5].Value.ToString();
            textBox6.Text = selectedRow.Cells[6].Value.ToString();
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand komut = new SqlCommand("update PatientTbl set PatName='"+textBox1.Text +"',PatPhone='"+textBox2.Text+"',PatAdress='"+textBox3.Text+"',PatDOB='"+textBox4.Text+"',PatGender='"+comboBox1.Text+"',PatAllergies='"+textBox6.Text+"' where PatId='"+textBox5.Text+"'", con);
            komut.ExecuteNonQuery();
            listele();
            con.Close();
           
            
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox6.Clear();
            textBox1.Focus();

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }
    }

}