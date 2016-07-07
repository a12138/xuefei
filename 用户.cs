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
    public partial class 用户 : Form
    {
        public 用户()
        {
            InitializeComponent();
        }

        private void 用户_Load(object sender, EventArgs e)
        {
            // TODO: 这行代码将数据加载到表“usersDataSet5.Users”中。您可以根据需要移动或删除它。
            this.usersTableAdapter.Fill(this.usersDataSet5.Users);
           

            
        }

        private void button2_Click(object sender, EventArgs e)
        {           
            if (MessageBox.Show("确实要删除该行吗?", "询问", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
               
                string str = "server=.;database=Users;Integrated Security=true";
                SqlConnection con = new SqlConnection(str);
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = " Delete from  Users where UsersId = '" + dataGridView1.SelectedRows[0].Cells[0].Value.ToString() + "'";
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                cmd = null;
                MessageBox.Show("删除成功！", "恭喜");
                this.usersTableAdapter.Fill(this.usersDataSet5.Users);
            }         
            else
            {
                MessageBox.Show("放弃删除！");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string str = "server=.;database=Users;Integrated Security=true";
            SqlConnection con = new SqlConnection(str);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = " Update  Users set UsersId='" + dataGridView1.SelectedRows[0].Cells[0].Value.ToString() + "',UsersPwd='" + dataGridView1.SelectedRows[0].Cells[1].Value.ToString() + "'where UsersId = '" + dataGridView1.SelectedRows[0].Cells[0].Value.ToString() + "'";
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            cmd = null;
            MessageBox.Show("修改成功！", "恭喜");
        }

        private void 用户_FormClosed(object sender, FormClosedEventArgs e)
        {
          
        }
    }
}
