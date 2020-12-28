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

namespace LibraryManagement
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(); //创建连接对象
            conn.ConnectionString = "Data Source=.;Initial Catalog=softwareSY;Integrated Security=True;";   //连接字符串
            conn.Open();  //建立连接
            SqlCommand com = new SqlCommand();
            com.Connection = conn;
            com.CommandText = "select * from InterList";
            SqlDataReader reader = com.ExecuteReader();
            //用循环语句读取SQL查询获得的数据集。.
            while (reader.Read())   //读取一条数据

            {
                MessageBox.Show(reader[0].ToString()+' '+ reader[1].ToString());
            }
            reader.Close();
            conn.Close();
        }

        private void 编目传送ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 流通数目查询ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            流通查询 hf1 = new 流通查询();
            hf1.Show();
        }

        private void 借阅书目查询ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            借阅信息查询 hf2 = new 借阅信息查询();
            hf2.Show();
        }

        private void 借阅ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            借阅 hf3 = new 借阅("201809000");//此处改为登录者的卡号
            hf3.Show();
        }

        private void 归还ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            归还 hf4 = new 归还("201809000");//此处改为登录者的卡号
            hf4.Show();
        }

        private void 图书流通信息表备份ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            图书流通信息表备份还原 hf5 = new 图书流通信息表备份还原();
            hf5.Show();
        }

        private void 借阅信息表备份ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            借阅信息表备份 hf6 = new 借阅信息表备份();
            hf6.Show();
        }

        private void 用户信息表备份ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            用户信息表备份 hf7 = new 用户信息表备份();
            hf7.Show();
        }
    }
}
