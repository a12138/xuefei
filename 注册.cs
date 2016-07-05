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
    public partial class zc : Form
    {
        public zc()
        {
            InitializeComponent();
        }

        private void 注册_Load(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "")
                MessageBox.Show("请输入用户名、密码！", "警告");
            else
            {
                SqlConnection conn = new SqlConnection("Data Source=(local);Initial Catalog=Users;Integrated Security=True");
                conn.Open();
                SqlCommand cmd = new SqlCommand("select * from Users where UsersId='" + textBox1.Text.Trim() + "'", conn);
                SqlDataReader sdr = cmd.ExecuteReader();
                sdr.Read();
                if (sdr.HasRows)
                { MessageBox.Show("该用户已注册，请使用其他用户名", "提示"); }
                else if (textBox2.Text != textBox3.Text)
                { MessageBox.Show("两次密码输入不一致", "提示"); }
                else
                {
                    sdr.Close();
                    string myinsert = "insert into Users(UsersId,UsersPwd) values ('" + textBox1.Text + "','" + textBox2.Text + "')";
                    SqlCommand mycom = new SqlCommand(myinsert, conn);           //定义OleDbCommnad对象并连接数据库  
                    mycom.ExecuteNonQuery();                           //执行插入语句  
                    conn.Close();                //关闭对象并释放所占内存空间    
                    conn.Dispose();
                    MessageBox.Show("您已注册成功！");
                    Close();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}