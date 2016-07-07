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
    public partial class frmxinxi : Form
    {
        public frmxinxi()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void frmxinxi_Load(object sender, EventArgs e)
        {
            // TODO: 这行代码将数据加载到表“usersDataSet5.S”中。您可以根据需要移动或删除它。
            this.sTableAdapter1.Fill(this.usersDataSet5.S);          
            dataGridView1.Sort(dataGridView1.Columns[1], ListSortDirection.Ascending);            
            
            int row = dataGridView1.Rows.Count;
            for (int i = 0; i < row; i++)
            {
                 dataGridView1.Rows[i].Cells[1].Value= Convert.ToDateTime(dataGridView1.Rows[i].Cells[1].Value).ToShortDateString();
               
            }
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
                SqlCommand cmd = new SqlCommand("select * from S where Sn like '%" + textBox1.Text.Trim()+ "%'", conn);
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
                }
                else
                {
                    MessageBox.Show("该学生不存在！");
                }
                conn.Close();
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {


            if (MessageBox.Show("该操作会删除学生所有信息，是否继续?", "询问", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                string str = "server=.;database=Users;Integrated Security=true";
                SqlConnection con = new SqlConnection(str);
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = " Delete from  S where Sn= '" + dataGridView1.SelectedRows[0].Cells[0].Value.ToString() + "'";
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                cmd = null;
                MessageBox.Show("删除成功！", "恭喜");
                this.sTableAdapter1.Fill(this.usersDataSet5.S);
                dataGridView1.Sort(dataGridView1.Columns[1], ListSortDirection.Ascending);
            }
            else
            {
                MessageBox.Show("放弃删除！");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("是否要修改?", "询问", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                string str = "server=.;database=Users;Integrated Security=true";
                SqlConnection con = new SqlConnection(str);
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = " Update  S set Sn='" + dataGridView1.SelectedRows[0].Cells[0].Value.ToString() + "',Date='" + dataGridView1.SelectedRows[0].Cells[1].Value.ToString() + "',KC='" + dataGridView1.SelectedRows[0].Cells[2].Value.ToString() + "',Ptel = '" + dataGridView1.SelectedRows[0].Cells[3].Value.ToString() + "',Stel = '" + dataGridView1.SelectedRows[0].Cells[4].Value.ToString() + "'where Sn = '" + dataGridView1.SelectedRows[0].Cells[0].Value.ToString() + "'";
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                cmd = null;
                MessageBox.Show("修改成功！", "恭喜");
            }
            else
            {
                MessageBox.Show("放弃修改！");
                this.sTableAdapter1.Fill(this.usersDataSet5.S);
            }
        }

        private void frmxinxi_FormClosed(object sender, FormClosedEventArgs e)
        {
           
        }

        private void button4_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            string str = "server=.;database=Users;Integrated Security=true";
            SqlConnection con = new SqlConnection(str);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "select * from S ";
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            sda.Fill(ds, "S");
            dataGridView1.DataSource = ds.Tables["S"];
            dataGridView1.Sort(dataGridView1.Columns[1], ListSortDirection.Ascending);
        }
    }
}
