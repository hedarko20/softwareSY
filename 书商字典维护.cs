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
    public partial class 书商字典维护 : Form
    {
        public 书商字典维护()
        {
            InitializeComponent();
        }

        private void 书商字典维护_Load(object sender, EventArgs e)
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
                string sql = "select * from 书商字典表";
                SqlDataAdapter da = new SqlDataAdapter(sql, sqlcon);
                DataSet ds = new DataSet();
                da.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
                dataGridView1.Columns[0].HeaderText = "书商";
                dataGridView1.Columns[1].HeaderText = "地址";
                dataGridView1.Columns[2].HeaderText = "联系人";
                dataGridView1.Columns[3].HeaderText = "电话";
                dataGridView1.Columns[4].HeaderText = "邮编";
                dataGridView1.Columns[5].HeaderText = "开户行";
                dataGridView1.Columns[6].HeaderText = "网址";
                dataGridView1.Columns[7].HeaderText = "信誉度";
                dataGridView1.Columns[8].HeaderText = "传真";
                dataGridView1.Columns[9].HeaderText = "电子邮件";
                dataGridView1.Columns[10].HeaderText = "书商账号";

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
                MessageBox.Show(ex.Message);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection sqlcon = null;
            SqlCommand cmd = null;
            string sqlstr = null;
            string cmdstr = null;
            int judge;
            try {
                sqlstr = "Data Source=.;Initial Catalog=softwareSY;Integrated Security=True;";
                sqlcon = new SqlConnection(sqlstr);
                sqlcon.Open();
                cmdstr = "insert into 书商字典表 values({0})";
                string temstr = null; 
                   
                temstr += "'" + SellerName.Text + "',";
                temstr += "'" + Address.Text + "',";
                temstr += "'" + Contact.Text + "',";
                temstr += "'" + Tel.Text + "',";
                temstr += "'" + PostCode.Text + "',";
                temstr += "'" + BankName.Text + "',";
                temstr += "'" + WebSite.Text + "',";
                temstr += "'" + Credit.Text + "',";
                temstr += "'" + Fax.Text + "',";
                temstr += "'" + EMAIL.Text + "',";
                temstr += "'" + SellerID.Text + "'";
                cmdstr = string.Format(cmdstr,temstr);
                cmd = new SqlCommand(cmdstr,sqlcon);
                judge = cmd.ExecuteNonQuery();
                if (judge != -1)
                    MessageBox.Show("插入成功");
                else MessageBox.Show("插入失败");
                init();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection sqlcon = null;
            SqlCommand cmd = null;
            string sqlstr = null;
            string cmdstr = null;
            int judge;
            try
            {
                sqlstr = "Data Source=.;Initial Catalog=softwareSY;Integrated Security=True;";
                sqlcon = new SqlConnection(sqlstr);
                sqlcon.Open();
                cmdstr = "update 书商字典表 set {0} where {1}";
                string temstr = null;
                temstr += "SellerName='"+ SellerName.Text+"',";
                temstr += "Address='" + Address.Text + "',";
                temstr += "Contact='" + Contact.Text + "',";
                temstr += "Tel='" + Tel.Text + "',";
                temstr += "PostCode='" + PostCode.Text + "',";
                temstr += "BankName='" + BankName.Text + "',";
                temstr += "WebSite='" + WebSite.Text + "',";
                temstr += "Credit='" + Credit.Text + "',";
                temstr += "Fax='" + Fax.Text + "',";
                temstr += "EMAIL='" + EMAIL.Text +"'";
                cmdstr = string.Format(cmdstr,temstr, "SellerID='"+ SellerID.Text+"'");
                cmd = new SqlCommand(cmdstr,sqlcon);
                judge = cmd.ExecuteNonQuery();
                if (judge != -1)
                    MessageBox.Show("修改成功");
                else MessageBox.Show("修改失败");

                init();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection sqlcon = null;
            SqlCommand cmd = null;
            string sqlstr = null;
            string cmdstr = null;
            int judge;
            try
            {
                sqlstr = "Data Source=.;Initial Catalog=softwareSY;Integrated Security=True;";
                sqlcon = new SqlConnection(sqlstr);
                sqlcon.Open();
                cmdstr = "delete from 书商字典表 where {0}";
                string temstr = null;
                if (SellerID.Text != "")
                    temstr += "SellerID='" + SellerID.Text+"' and ";
                if(SellerName.Text!="")
                temstr += "SellerName='" + SellerName.Text + "' and ";
                if (Address.Text != "")
                    temstr += "Address='" + Address.Text + "' and ";
                if (Contact.Text != "")
                    temstr += "Contact='" + Contact.Text + "' and ";
                if (Tel.Text !="")
                    temstr += "Tel='" + Tel.Text + "' and ";
                if (PostCode.Text != "")
                    temstr += "PostCode='" + PostCode.Text + "' and ";
                if (BankName.Text != "")
                    temstr += "BankName='" + BankName.Text + "' and ";
                if (WebSite.Text != "")
                    temstr += "WebSite='" + WebSite.Text + "' and ";
                if (Credit.Text != "")
                    temstr += "Credit='" + Credit.Text + "' and ";
                if (Fax.Text != "")
                    temstr += "Fax='" + Fax.Text + "' and ";
                if (EMAIL.Text != "")
                    temstr += "EMAIL='" + EMAIL.Text+ "' and ";
                if(temstr.EndsWith("and "))
                temstr = temstr.Substring(0,temstr.Length-4);
                cmdstr = string.Format(cmdstr, temstr);
                cmd = new SqlCommand(cmdstr, sqlcon);
                judge = cmd.ExecuteNonQuery();
                if (judge != -1)
                    MessageBox.Show("删除成功");
                else MessageBox.Show("删除失败");

                init();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string connStr = "Data Source=.;Initial Catalog=softwareSY;Integrated Security=True;";
            SqlConnection sqlcon = null;
            try
            {
                sqlcon = new SqlConnection(connStr);
                sqlcon.Open();
                string sql = "select * from 书商字典表 where {0}";
                string temstr = null;
                if (SellerID.Text != "")
                    temstr += "SellerID='" + SellerID.Text + "' and ";
                if (SellerName.Text != "")
                    temstr += "SellerName='" + SellerName.Text + "' and ";
                if (Address.Text != "")
                    temstr += "Address='" + Address.Text + "' and ";
                if (Contact.Text != "")
                    temstr += "Contact='" + Contact.Text + "' and ";
                if (Tel.Text != "")
                    temstr += "Tel='" + Tel.Text + "' and ";
                if (PostCode.Text != "")
                    temstr += "PostCode='" + PostCode.Text + "' and ";
                if (BankName.Text != "")
                    temstr += "BankName='" + BankName.Text + "' and ";
                if (WebSite.Text != "")
                    temstr += "WebSite='" + WebSite.Text + "' and ";
                if (Credit.Text != "")
                    temstr += "Credit='" + Credit.Text + "' and ";
                if (Fax.Text != "")
                    temstr += "Fax='" + Fax.Text + "' and ";
                if (EMAIL.Text != "")
                    temstr += "EMAIL='" + EMAIL.Text + "' and ";
                if (temstr.EndsWith("and "))
                    temstr = temstr.Substring(0, temstr.Length -4);
                sql = string.Format(sql, temstr);


                SqlDataAdapter da = new SqlDataAdapter(sql, sqlcon);
                DataSet ds = new DataSet();
                da.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
                dataGridView1.Columns[0].HeaderText = "书商";
                dataGridView1.Columns[1].HeaderText = "地址";
                dataGridView1.Columns[2].HeaderText = "联系人";
                dataGridView1.Columns[3].HeaderText = "电话";
                dataGridView1.Columns[4].HeaderText = "邮编";
                dataGridView1.Columns[5].HeaderText = "开户行";
                dataGridView1.Columns[6].HeaderText = "网址";
                dataGridView1.Columns[7].HeaderText = "信誉度";
                dataGridView1.Columns[8].HeaderText = "传真";
                dataGridView1.Columns[9].HeaderText = "电子邮件";
                dataGridView1.Columns[10].HeaderText = "书商账号";

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
                MessageBox.Show(ex.Message);
            }
        }
    }
}
