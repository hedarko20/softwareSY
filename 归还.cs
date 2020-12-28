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

namespace LibraryManagement
{
    public partial class 归还 : Form
    {
        private string CardID;
        public 归还()
        {
            InitializeComponent();
        }
        public 归还(string CardID)
        {
            InitializeComponent();
            this.CardID = CardID;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void 归还_Load(object sender, EventArgs e)
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
            try
            {
                sqlcon = new SqlConnection(connStr);
                sqlcon.Open();
                cmdstr = "select * from BorrowTable where BookNum='{0}'and CardID='{1}' and ReturnState='未还'";
                cmdstr = string.Format(cmdstr, BookNum.Text,CardID);
                cmd = new SqlCommand(cmdstr, sqlcon);
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    dr.Close();
                    cmdstr = "update BorrowTable set ReturnState='已还' where BookNum='{0}'and CardID='{1}'";
                    cmdstr = string.Format(cmdstr,BookNum.Text,CardID);
                    cmd = new SqlCommand(cmdstr, sqlcon);
                    int tem;
                    tem = cmd.ExecuteNonQuery();
                    if (tem != -1)
                    {
                        MessageBox.Show("还书成功");
                    }
                    cmdstr = "select * from BorrowTable where BookNum='{0}'and CardID='{1}'";
                    cmdstr = string.Format(cmdstr, BookNum.Text, CardID);
                    cmd = new SqlCommand(cmdstr, sqlcon);
                    dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        string temtime = dr[2].ToString();
                        DateTime dt = Convert.ToDateTime(temtime);
                        DateTime now = DateTime.Now;
                        TimeSpan c = now - dt;
                        int defaulttime = c.Days;
                        if (defaulttime > 25)//此处填规定的超期时间
                        {
                            dr.Close();
                            cmdstr = "update BorrowTable set DefaultTime={2} where BookNum='{0}'and CardID='{1}'";
                            cmdstr = string.Format(cmdstr, BookNum.Text, CardID, defaulttime);
                            cmd = new SqlCommand(cmdstr, sqlcon);
                            int tem1;
                            tem1 = cmd.ExecuteNonQuery();
                            if (tem1 != -1)
                            {
                                MessageBox.Show("超期");
                            }
                        }
                    }


                }
                else MessageBox.Show("此书未被借");
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
