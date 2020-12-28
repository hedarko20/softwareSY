using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryManagement
{
    public partial class 借阅 : Form
    {
        private string CardID;
        public 借阅()
        {
            InitializeComponent();
        }
        public 借阅(string CardID)
        {
            InitializeComponent();
            this.CardID = CardID;
        }


        private void 借阅_Load(object sender, EventArgs e)
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
                string sql = "select * from BorrowTable where CardID='{0}'";
                sql = String.Format(sql, this.CardID);
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
            string connStr = "Data Source=.;Initial Catalog=softwareSY;Integrated Security=True;";
            SqlConnection sqlcon = null;
            string cmdstr = null;
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            try {
                sqlcon = new SqlConnection(connStr);
                sqlcon.Open();
                cmdstr = "select * from BorrowTable where BookNum='{0}' and ReturnState='未还'";
                cmdstr = string.Format(cmdstr,BookNum.Text);
                cmd = new SqlCommand(cmdstr, sqlcon);
                dr = cmd.ExecuteReader();
                if (!dr.Read())
                {
                    dr.Close();
                    cmdstr = "insert into BorrowTable(CardID,BookNum,BorrowDate,ReturnState) values('{0}','{1}','{2}','未还')";
                    cmdstr = string.Format(cmdstr, CardID, BookNum.Text, DateTime.Now.ToString("yyyy/MM/dd"));
                    cmd = new SqlCommand(cmdstr, sqlcon);
                    int tem;
                      tem=cmd.ExecuteNonQuery();
                    if (tem != -1)
                    {
                        MessageBox.Show("借书成功");
                    }
                }
              else  MessageBox.Show("此书已被借");
                dr.Close();
                init();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error");
            }



        }
    }
}
