using System;
using System.IO;
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
    public partial class 图书流通信息表备份还原 : Form
    {
        public 图书流通信息表备份还原()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            {
                string path = null;
                
                string connStr = "Data Source=.;Initial Catalog=softwareSY;Integrated Security=True;";
                SqlConnection sqlcon = null;
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.Title = "选择备份文件所在路径";
                ofd.InitialDirectory = @"c:\";
                ofd.Filter = "文本文件(*.txt) |*.txt|所有文件(*.*)|*.*";
                ofd.FilterIndex = 1;
                ofd.RestoreDirectory = false;
                if (ofd.ShowDialog() == DialogResult.OK)
                {   path= System.IO.Path.GetFullPath(ofd.FileName); //绝对路径
                    textBox1.Text = path;
                    try {
                        sqlcon = new SqlConnection(connStr);
                        sqlcon.Open();
                        SqlCommand cmd = new SqlCommand("select * from Book",sqlcon);
                        SqlDataReader dr = cmd.ExecuteReader();
                        FileStream fs = null;
                        fs = new FileStream(path, FileMode.Create);
                        StreamWriter sw = null;
                        sw = new StreamWriter(fs);
                        while (dr.Read())
                        {
                            string tem=null;
                            for(int i=0;i<9;i++)
                                {
                                tem +="'"+ dr[i].ToString()+"'" + ",";
                            }
                            if (tem.EndsWith(","))
                               tem = tem.Substring(0, tem.Length - 1);
                            tem += "\r\n";
                            //开始写入
                            sw.Write(tem);
                           
                          
                        }  
                        
                        //清空缓冲区
                        sw.Flush();
                            //关闭流
                            sw.Close();
                            fs.Close();
                        dr.Close();
                        MessageBox.Show("备份成功");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error");
                    }
                }

            }
        }

        private void 图书流通信息表备份还原_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

            {
                string path = null;

                string connStr = "Data Source=.;Initial Catalog=softwareSY;Integrated Security=True;";
                SqlConnection sqlcon = null;
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.Title = "选择备份文件所在路径";
                ofd.InitialDirectory = @"c:\";
                ofd.Filter = "文本文件(*.txt) |*.txt|所有文件(*.*)|*.*";
                ofd.FilterIndex = 1;
                ofd.RestoreDirectory = false;
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    path = System.IO.Path.GetFullPath(ofd.FileName); //绝对路径
                    textBox1.Text = path;
                    try
                    {
                        sqlcon = new SqlConnection(connStr);
                        sqlcon.Open();
                       

                        StreamReader sr = null;
                        sr = new StreamReader(path);
                        string temstr = null;
                        string sqlcmd = null;
                        SqlCommand cmd = null;
                        sqlcmd = "delete from Book";
                        cmd = new SqlCommand(sqlcmd, sqlcon);
                        int judge=cmd.ExecuteNonQuery();
                        if (judge != -1)
                            MessageBox.Show("删除成功");
                        while (sr.Peek()!=-1) {
                            temstr = sr.ReadLine();
                       sqlcmd = "insert into Book values({0})";
                            sqlcmd = string.Format(sqlcmd, temstr);
                            cmd = new SqlCommand(sqlcmd,sqlcon);
                            judge = cmd.ExecuteNonQuery();
                            if (judge == -1)
                                MessageBox.Show("Error");
                        
                        }
                       
                        
                       
                      

                        //清空缓冲区
                      
                        //关闭流
                        sr.Close();
                       
                       
                        MessageBox.Show("还原成功");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }

            }



        }
    }
}
