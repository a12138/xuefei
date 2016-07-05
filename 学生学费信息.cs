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
    public partial class frmxuefei : Form
    {
        public frmxuefei()
        {
            InitializeComponent();
        }

        private void frmxuefei_Load(object sender, EventArgs e)
        {
            // TODO: 这行代码将数据加载到表“usersDataSet5.S”中。您可以根据需要移动或删除它。
            this.sTableAdapter.Fill(this.usersDataSet5.S);
            
            dataGridView1.Sort(dataGridView1.Columns[1], ListSortDirection.Ascending);

            int row = dataGridView1.Rows.Count;
            for (int i = 0; i < row; i++)
            {
                TimeSpan ts = DateTime.Now - Convert.ToDateTime(dataGridView1.Rows[i].Cells[1].Value);
                int z = ts.Days / 7;
                int k = z * 4 + ts.Days % 7 / 2;
                int c = k * 30;
                if (dataGridView1.Rows[i].Cells[2].Value.ToString().Trim()=="数学")
                {
                   
                    dataGridView1.Rows[i].Cells[3].Value = c-c/500*10;
                }
                else if (dataGridView1.Rows[i].Cells[2].Value.ToString().Trim()=="自习")
                {                   
                    dataGridView1.Rows[i].Cells[3].Value = ts.Days * 14-ts.Days*14/400*20;
                }
                else
                {
                    dataGridView1.Rows[i].Cells[3].Value = c - c / 500 * 10 + ts.Days * 14 - ts.Days * 14 / 400 * 20;                   
                }
               
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
                SqlCommand cmd = new SqlCommand("select * from S where Sn like'%" + textBox1.Text.Trim() + "%'", conn);
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
                    int row = dataGridView1.Rows.Count;
                    for (int i = 0; i < row; i++)
                    {
                        TimeSpan ts = DateTime.Now - Convert.ToDateTime(dataGridView1.Rows[i].Cells[1].Value);
                        int z = ts.Days / 7;
                        int k = z * 4 + ts.Days % 7 / 2;
                        int c = k * 30;
                        if (dataGridView1.Rows[i].Cells[2].Value.ToString().Trim() == "数学")
                        {

                            dataGridView1.Rows[i].Cells[3].Value = c - c / 500 * 10;
                        }
                        else if (dataGridView1.Rows[i].Cells[2].Value.ToString().Trim() == "自习")
                        {
                            dataGridView1.Rows[i].Cells[3].Value = ts.Days * 14 - ts.Days * 14 / 400 * 20;
                        }
                        else
                        {
                            dataGridView1.Rows[i].Cells[3].Value = c - c / 500 * 10 + ts.Days * 14 - ts.Days * 14 / 400 * 20;
                        }

                    }
                    // dataGridView1.DataBind();
                }
                else
                {
                    MessageBox.Show("该学生不存在！");
                }
                conn.Close();
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           

        }

        private void frmxuefei_FormClosed(object sender, FormClosedEventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
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
            int row = dataGridView1.Rows.Count;
            for (int i = 0; i < row; i++)
            {
                TimeSpan ts = DateTime.Now - Convert.ToDateTime(dataGridView1.Rows[i].Cells[1].Value);
                int z = ts.Days / 7;
                int k = z * 4 + ts.Days % 7 / 2;
                int c = k * 30;
                if (dataGridView1.Rows[i].Cells[2].Value.ToString().Trim() == "数学")
                {

                    dataGridView1.Rows[i].Cells[3].Value = c - c / 500 * 10;
                }
                else if (dataGridView1.Rows[i].Cells[2].Value.ToString().Trim() == "自习")
                {
                    dataGridView1.Rows[i].Cells[3].Value = ts.Days * 14 - ts.Days * 14 / 400 * 20;
                }
                else
                {
                    dataGridView1.Rows[i].Cells[3].Value = c - c / 500 * 10 + ts.Days * 14 - ts.Days * 14 / 400 * 20;
                }

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("是否提交本次学费共"+dataGridView1.SelectedRows[0].Cells[3].Value + "元", "询问", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                SqlConnection conn = new SqlConnection("Data Source=.;Initial Catalog=Users;Integrated Security=True");
                conn.Open();
                string myinsert = "insert into Cost(Sn,C_date,C_num,KC) values ('" + dataGridView1.SelectedRows[0].Cells[0].Value + "','" + DateTime.Now + "','" + dataGridView1.SelectedRows[0].Cells[3].Value + "','" + dataGridView1.SelectedRows[0].Cells[2].Value + "')";
                SqlCommand mycom = new SqlCommand(myinsert, conn);
                string myup = "Update S set L_date='" + DateTime.Now + "'where Sn = '" + dataGridView1.SelectedRows[0].Cells[0].Value.ToString() + "'";
                SqlCommand myc = new SqlCommand(myup, conn);
                myc.ExecuteNonQuery();
                mycom.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("学生学费提交成功！");

                this.sTableAdapter.Fill(this.usersDataSet5.S);
                dataGridView1.Sort(dataGridView1.Columns[1], ListSortDirection.Ascending);
                int row = dataGridView1.Rows.Count;
                for (int i = 0; i < row; i++)
                {
                    TimeSpan ts = DateTime.Now - Convert.ToDateTime(dataGridView1.Rows[i].Cells[1].Value);
                    int z = ts.Days / 7;
                    int k = z * 4 + ts.Days % 7 / 2;
                    int c = k * 30;
                    if (dataGridView1.Rows[i].Cells[2].Value.ToString().Trim() == "数学")
                    {
                        dataGridView1.Rows[i].Cells[3].Value = c - c / 500 * 10;
                    }
                    else if (dataGridView1.Rows[i].Cells[2].Value.ToString().Trim() == "自习")
                    {
                        dataGridView1.Rows[i].Cells[3].Value = ts.Days * 14 - ts.Days * 14 / 400 * 20;
                    }
                    else
                    {
                        dataGridView1.Rows[i].Cells[3].Value = c - c / 500 * 10 + ts.Days * 14 - ts.Days * 14 / 400 * 20;
                    }

                }
            }
            else
            {
                MessageBox.Show("放弃学生学费提交！");
            }
        }
    }
}
