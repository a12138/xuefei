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

namespace 登录界面
{
    public partial class frmzengjia : Form
    {
        public frmzengjia()
        {
            InitializeComponent();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection conn3 = new SqlConnection("Data Source=(local);Initial Catalog=Users;Integrated Security=True");
            conn3.Open();
            SqlCommand cmd = new SqlCommand("select * from S where Sn='" + textBox1.Text.Trim() + "'", conn3);
            SqlDataReader sdr = cmd.ExecuteReader();
            sdr.Read();
            if (sdr.HasRows)
            { MessageBox.Show("已有同名学生！", "提示"); }
            else if (textBox1.Text == "" || textBox2.Text == "" || comboBox1.Text == "" || textBox4.Text == "")
            {
                MessageBox.Show("学生姓名、入学时间、所选课程、家长电话不能为空！");
            }
            else
            {
                sdr.Close();     
                string myinsert = "insert into S(Sn,Date,Kc,Ptel,Stel,L_date) values ('" + textBox1.Text + "','" + textBox2.Text + "','" + comboBox1.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + textBox2.Text + "')";
                SqlCommand mycom = new SqlCommand(myinsert, conn3);
                mycom.ExecuteNonQuery();
                conn3.Close();
                MessageBox.Show("学生信息添加成功！");
                Close();
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void frmzengjia_FormClosed(object sender, FormClosedEventArgs e)
        {
           
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void frmzengjia_Load(object sender, EventArgs e)
        {
            textBox2.Text = DateTime.Now.ToString("yyyy-MM-dd");
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
