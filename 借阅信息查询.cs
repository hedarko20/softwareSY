using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryManagement
{
    public partial class 借阅信息查询 : Form
    {
        public 借阅信息查询()
        {
            InitializeComponent();
        }

        private void 借阅信息查询_Load(object sender, EventArgs e)
        {
            init();
        }
        private void init()
        {
            string connStr = "Data Source=.;Initial Catalog=softwareSY;Integrated Security=True;";
            SqlConnection sqlcon = null;
            try
            {
                sqlcon = new SqlConnection(connStr);
                sqlcon.Open();
                string sql = "select * from BorrowTable";
                SqlDataAdapter da = new SqlDataAdapter(sql, sqlcon);
                DataSet ds = new DataSet();
                da.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
                dataGridView1.Columns[0].HeaderText = "卡号";
                dataGridView1.Columns[1].HeaderText = "书目号";
                dataGridView1.Columns[2].HeaderText = "借阅日期";
                dataGridView1.Columns[3].HeaderText = "还书状态";
                dataGridView1.Columns[4].HeaderText = "超期时长";

                //设置数据表格为只读
                dataGridView1.ReadOnly = true;
                //不允许添加行
                dataGridView1.AllowUserToAddRows = false;
                //背景为白色
                dataGridView1.BackgroundColor = Color.White;
                //只允许选中单行
                dataGridView1.MultiSelect = false;
                //整行选中
                dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error!");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String a = "Select * from BorrowTable {0}";
            String b = "where ";
            if (CardID.Text != "")
                b += "CardID=" + "'" + CardID.Text + "'" + " and ";
            if (BookNum.Text != "")
                b += "BookNum=" + "'" + BookNum.Text + "'" + " and ";
            if (BorrowDate.Text != "")
                b += "BorrowDate=" + "'" + BorrowDate.Text + "'" + " and ";
            if (ReturnState.Text != "")
                b += "ReturnState=" + "'" + ReturnState.Text + "'" + " and ";
            if (DefaultTime.Text != "")
                b += "DefaultTime=" + "'" + DefaultTime.Text + "'" + " and ";
            if (b.EndsWith(" and "))
                b = b.Substring(0, b.Length - 5);
            a = String.Format(a, b);
            chaxun(a);
        }

        private void chaxun(String sql)
        {
            string connStr = "Data Source=.;Initial Catalog=softwareSY;Integrated Security=True;";
            SqlConnection sqlcon = null;
            try
            {
                sqlcon = new SqlConnection(connStr);
                sqlcon.Open();
                SqlDataAdapter da = new SqlDataAdapter(sql, sqlcon);
                DataSet ds = new DataSet();
                da.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
                dataGridView1.Columns[0].HeaderText = "卡号";
                dataGridView1.Columns[1].HeaderText = "书目号";
                dataGridView1.Columns[2].HeaderText = "借阅日期";
                dataGridView1.Columns[3].HeaderText = "还书状态";
                dataGridView1.Columns[4].HeaderText = "超期时长";

                //设置数据表格为只读
                dataGridView1.ReadOnly = true;
                //不允许添加行
                dataGridView1.AllowUserToAddRows = false;
                //背景为白色
                dataGridView1.BackgroundColor = Color.White;
                //只允许选中单行
                dataGridView1.MultiSelect = false;
                //整行选中
                dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error!");
            }

        }
    }
}