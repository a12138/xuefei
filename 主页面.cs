using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 登录界面
{
    public partial class c : Form
    {
        public c()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            //实例化一个窗口
            frmzengjia m = new frmzengjia();
            //打开这个窗口
            m.ShowDialog();
            
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //实例化一个窗口
            frmxinxi m = new frmxinxi();
            //打开这个窗口
            m.ShowDialog();
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //实例化一个窗口
            frmxuefei m = new frmxuefei();
            //打开这个窗口
            m.ShowDialog();
           
        }

        private void button4_Click(object sender, EventArgs e)
        {
            学生缴费信息 xs = new 学生缴费信息();
            xs.ShowDialog();
           
        }

        private void button6_Click(object sender, EventArgs e)
        {
            用户 yh = new 用户();
            yh.ShowDialog();
            
        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void frmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmdenglu dl = new frmdenglu();
            //dl.Visible=true;
            dl.Close();
            Application.Exit();
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("是否要退出?", "询问", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                frmdenglu dl = new frmdenglu();
                //dl.Visible=true;
                dl.Close();
               // Application.Exit();
            }
            else
            {
                e.Cancel = true;
            }
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            Close();
        }
    }
}
