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
            SqlConnection conn = new SqlConnection("Data Source=.;Initial Catalog=Users;Integrated Security=True");
            conn.Open();
            SqlDataAdapter daAuthors = new SqlDataAdapter("Select * From Users", conn);

            DataSet dsPubs = new DataSet("Pubs");
            daAuthors.FillSchema(dsPubs, SchemaType.Source, "Users"); //FillSchema加载表的架构和数据,有了架构，表就知道哪个列是它的主键，同时 Rows 集合的 Find 方法也就可用了。


            daAuthors.Fill(dsPubs, "Users");
            DataTable tblAuthors;
            tblAuthors = dsPubs.Tables["Users"];


            if (MessageBox.Show("确实要删除该行吗?", "询问", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                DataRow drCurrent;
                string Row_zhi = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();//获取第一个单元格的值            
                //MessageBox.Show(Row_zhi);            
                drCurrent = tblAuthors.Rows.Find(Row_zhi);
                drCurrent.Delete();

                SqlCommandBuilder objCommandBuilder = new SqlCommandBuilder(daAuthors); //SqlCommandBuilder 提供自动生成单表命令的一种方式，这些命令用于协调使用关联的 SQL Server 数据库对 DataSet 执行的更改。              
                daAuthors.Update(dsPubs, "Users"); //数据适配器.Update()方法                
                //MessageBox.Show("数据库更新成功！");

                //-------重新绑定dataGridView的数据源，以便重新显示-------
                daAuthors.Fill(dsPubs, "Users");
                DataTable tblAuthors1;
                tblAuthors1 = dsPubs.Tables["Users"];
                dataGridView1.DataSource = tblAuthors1;
                conn.Close();
                conn.Dispose();
            }         
            else
            {
                MessageBox.Show("修改删除！");
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
            MessageBox.Show("更新成功！", "恭喜");
        }

        private void 用户_FormClosed(object sender, FormClosedEventArgs e)
        {
          
        }
    }
}
