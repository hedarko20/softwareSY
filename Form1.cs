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
    }
}
