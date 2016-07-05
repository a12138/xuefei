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
    public partial class 学生缴费信息 : Form
    {
        public 学生缴费信息()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void 学生缴费信息_Load(object sender, EventArgs e)
        {
            // TODO: 这行代码将数据加载到表“usersDataSet5.Cost”中。您可以根据需要移动或删除它。
            this.costTableAdapter.Fill(this.usersDataSet5.Cost);
            

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("查找学生姓名为空！");
            }
            else
            {
                SqlConnection conn = new SqlConnection("Data Source=.;Initial Catalog=Users;Integrated Security=True");
                conn.Open();
                SqlCommand cmd = new SqlCommand("select * from Cost where Sn like'%" + textBox1.Text.Trim() + "%'", conn);
                SqlDataReader sdr = cmd.ExecuteReader();
                sdr.Read();
                if (sdr.HasRows)
                {
                    sdr.Close();
                    dataGridView1.DataSource = null;
                    DataSet ds = new DataSet();
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    sda.Fill(ds, "table");
                    dataGridView1.DataSource = ds.Tables["table"];
                    // dataGridView1.DataBind();
                }
                else
                {
                    MessageBox.Show("该学生不存在！");
                }
                conn.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            Close();
        }

        private void 学生缴费信息_FormClosed(object sender, FormClosedEventArgs e)
        {
          
        }
    }
}
