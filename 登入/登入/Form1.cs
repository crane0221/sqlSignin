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

namespace 登入
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {
            //using (SqlConnection con = cn1.cn)
            //{
            //    con.Open();
            //    SqlCommand cmd = new SqlCommand();
            //    cmd.Connection = con;
            //}
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string email = textBox1.Text;
            string password = textBox2.Text;
            string conn = @"Data Source=.;Initial Catalog=Disneyland_Shanghai_ANO;Integrated Security=True";
            SqlConnection sqlcon = new SqlConnection(conn);
            sqlcon.Open();
            string sql = "Select Email,Password From Account Where Email = '" + email + "' And Password = '" + password + "'";
            SqlCommand sqlcmd = new SqlCommand(sql,sqlcon);
            SqlDataReader sqlred = sqlcmd.ExecuteReader();
            if (email.Equals("")||password.Equals(""))
            {
                MessageBox.Show("帳號或密碼不能空");
            }
            else
            {
                if (sqlred.HasRows)
                {
                    MessageBox.Show("登入成功");
                    Form2 form2 = new Form2();
                    form2.Show();
                    this.Hide();
                }
                else
                {
                    DialogResult dr = MessageBox.Show("是否註冊新使用者？", "登入失敗", MessageBoxButtons.YesNo,MessageBoxIcon.Question);
                    if (dr == DialogResult.Yes)
                    {
                        Form3 form3 = new Form3();
                        form3.Show();
                        this.Hide();
                    }
                    else
                    {
                        this.Show();
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            form3.Show();
            this.Show();
        }
    }
}
