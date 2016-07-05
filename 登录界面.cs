using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 登录界面
{
    public partial class frmdenglu : Form
    {
        public frmdenglu()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void n_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "")
                MessageBox.Show("提示：请输入用户名和密码！", "警告");
            SqlConnection conn = new SqlConnection("Data Source=(local);Initial Catalog=Users;Integrated Security=True");
            conn.Open();
            SqlCommand cmd = new SqlCommand("select * from Users where UsersId='" + textBox1.Text.Trim() + "' and USersPwd='" + textBox2.Text.Trim() + "'", conn);
            SqlDataReader sdr = cmd.ExecuteReader();
            sdr.Read();
            if (sdr.HasRows)
            { 
                this.Visible = false;//隐藏当前窗口
            //实例化一个窗口
            c m = new c();
            //打开这个窗口
            m.ShowDialog();
           }
            else
                MessageBox.Show("提示：用户名或密码错误!", "警告");
            conn.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            zc c = new zc();
            c.ShowDialog();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            
        }

        private void frmdenglu_Load(object sender, EventArgs e)
        {

        }

        private void frmdenglu_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
