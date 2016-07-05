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
            // dataGridView1.SelectedRows[0].Cells[1].Value.ToString("yyyy-MM-dd");
            
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
            SqlConnection conn = new SqlConnection("Data Source=.;Initial Catalog=Users;Integrated Security=True");
            conn.Open();
            SqlDataAdapter daAuthors = new SqlDataAdapter("Select * From S", conn);

            DataSet dsPubs = new DataSet("Pubs");
            daAuthors.FillSchema(dsPubs, SchemaType.Source, "S"); //FillSchema加载表的架构和数据,有了架构，表就知道哪个列是它的主键，同时 Rows 集合的 Find 方法也就可用了。


            daAuthors.Fill(dsPubs, "S");
            DataTable tblAuthors;
            tblAuthors = dsPubs.Tables["S"];


            if (MessageBox.Show("该操作会删除学生所有信息，是否继续?", "询问", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                DataRow drCurrent;
                string Row_zhi = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();//获取第一个单元格的值            
                //MessageBox.Show(Row_zhi);            
                drCurrent = tblAuthors.Rows.Find(Row_zhi);
                drCurrent.Delete();

                SqlCommandBuilder objCommandBuilder = new SqlCommandBuilder(daAuthors); //SqlCommandBuilder 提供自动生成单表命令的一种方式，这些命令用于协调使用关联的 SQL Server 数据库对 DataSet 执行的更改。              
                daAuthors.Update(dsPubs, "S"); //数据适配器.Update()方法                
                //MessageBox.Show("数据库更新成功！");

                //-------重新绑定dataGridView的数据源，以便重新显示-------
                daAuthors.Fill(dsPubs, "S");
                DataTable tblAuthors1;
                tblAuthors1 = dsPubs.Tables["S"];
                dataGridView1.DataSource = tblAuthors1;
                dataGridView1.Sort(dataGridView1.Columns[1], ListSortDirection.Ascending);
                conn.Close();
                conn.Dispose();
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
