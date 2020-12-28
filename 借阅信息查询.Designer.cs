
namespace LibraryManagement
{
    partial class 借阅信息查询
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.CardID = new System.Windows.Forms.TextBox();
            this.BookNum = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.BorrowDate = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.DefaultTime = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.ReturnState = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.DefaultTime);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.ReturnState);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.BorrowDate);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.BookNum);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.CardID);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(25, 27);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(440, 187);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "卡号";
            // 
            // CardID
            // 
            this.CardID.Location = new System.Drawing.Point(87, 23);
            this.CardID.Name = "CardID";
            this.CardID.Size = new System.Drawing.Size(100, 21);
            this.CardID.TabIndex = 1;
            // 
            // BookNum
            // 
            this.BookNum.Location = new System.Drawing.Point(87, 69);
            this.BookNum.Name = "BookNum";
            this.BookNum.Size = new System.Drawing.Size(100, 21);
            this.BookNum.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "书目号";
            // 
            // BorrowDate
            // 
            this.BorrowDate.Location = new System.Drawing.Point(87, 118);
            this.BorrowDate.Name = "BorrowDate";
            this.BorrowDate.Size = new System.Drawing.Size(100, 21);
            this.BorrowDate.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(26, 121);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "借阅日期";
            // 
            // DefaultTime
            // 
            this.DefaultTime.Location = new System.Drawing.Point(299, 72);
            this.DefaultTime.Name = "DefaultTime";
            this.DefaultTime.Size = new System.Drawing.Size(100, 21);
            this.DefaultTime.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(238, 75);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 10;
            this.label5.Text = "超期时长";
            // 
            // ReturnState
            // 
            this.ReturnState.Location = new System.Drawing.Point(299, 23);
            this.ReturnState.Name = "ReturnState";
            this.ReturnState.Size = new System.Drawing.Size(100, 21);
            this.ReturnState.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(238, 26);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 8;
            this.label4.Text = "还书状态";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(25, 260);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(729, 180);
            this.dataGridView1.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(240, 121);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(159, 23);
            this.button1.TabIndex = 12;
            this.button1.Text = "查询";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // 借阅信息查询
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel1);
            this.Name = "借阅信息查询";
            this.Text = "借阅信息查询";
            this.Load += new System.EventHandler(this.借阅信息查询_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox CardID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox DefaultTime;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox ReturnState;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox BorrowDate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox BookNum;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button1;
    }
}