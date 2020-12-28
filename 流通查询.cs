using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryManagement
{
    public partial class 流通查询 : Form
    {
        public 流通查询()
        {
            InitializeComponent();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void 流通查询_Load(object sender, EventArgs e)
        {
       this.init();
        }
        private void init()
        { 
            string connStr = "Data Source=.;Initial Catalog=softwareSY;Integrated Security=True;";
            SqlConnection sqlcon = null;
            try {
                sqlcon = new SqlConnection(connStr);
                sqlcon.Open();
                string sql = "select * from Book";
                SqlDataAdapter da = new SqlDataAdapter(sql,sqlcon);
                DataSet ds = new DataSet();
                da.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
                dataGridView1.Columns[0].HeaderText = "分类号";
                dataGridView1.Columns[1].HeaderText = "书籍名称";
                dataGridView1.Columns[2].HeaderText = "作者";
                dataGridView1.Columns[3].HeaderText = "出版社";
                dataGridView1.Columns[4].HeaderText = "版次";
                dataGridView1.Columns[5].HeaderText = "ISBN号";
                dataGridView1.Columns[6].HeaderText = "书籍状态";
                dataGridView1.Columns[7].HeaderText = "书籍价格";
                dataGridView1.Columns[8].HeaderText = "书目号";
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
            String a = "Select * from Book {0}";
            String b = "where ";
            if (BookID.Text != "")
                b += "BookID="+"'" +BookID.Text + "'"+" and ";
            if (BookName.Text != "")
                b += "BookName=" + "'" + BookName.Text + "'"+ " and ";
            if (BookAuthor.Text != "")
                b += "BookAuthor=" + "'" + BookAuthor.Text + "'"+ " and ";
            if (BookPress.Text != "")
                b += "BookPress=" + "'" + BookPress.Text + "'" + " and ";
            if (Edition.Text != "")
                b += "Edition=" + "'" + Edition.Text + "'" + " and ";
            if (ISBN.Text != "")
                b += "ISBN=" + "'" + ISBN.Text + "'" + " and ";
            if (BookState.Text != "")
                b += "BookState=" + "'" + BookState.Text + "'" + " and ";
            if (BookPrice.Text != "")
                b += "BookPrice=" + "'" + BookPrice.Text + "'" + " and ";
            if (BookNum.Text!= "")
                b += "BookNum=" + "'" + BookNum.Text + "'" + " and ";
            if (b == "where ")
               b = "";
            if (b.EndsWith(" and "))
                b = b.Substring(0,b.Length-5);
            a =String.Format(a, b);
            this.chaxun(a);



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
                dataGridView1.Columns[0].HeaderText = "分类号";
                dataGridView1.Columns[1].HeaderText = "书籍名称";
                dataGridView1.Columns[2].HeaderText = "作者";
                dataGridView1.Columns[3].HeaderText = "出版社";
                dataGridView1.Columns[4].HeaderText = "版次";
                dataGridView1.Columns[5].HeaderText = "ISBN号";
                dataGridView1.Columns[6].HeaderText = "书籍状态";
                dataGridView1.Columns[7].HeaderText = "书籍价格";
                dataGridView1.Columns[8].HeaderText = "书目号";
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
