namespace Book_Management
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.User_Lab = new System.Windows.Forms.Label();
            this.btnSerialPort = new System.Windows.Forms.Button();
            this.cB_Port_Selection = new System.Windows.Forms.ComboBox();
            this.cB_Baud_Rate = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.Time_Lab = new System.Windows.Forms.Label();
            this.Port1 = new System.IO.Ports.SerialPort(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Borrow_Btn = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.BookBox1 = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.BookBox2 = new System.Windows.Forms.ComboBox();
            this.Return_Btn = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.book_ManagementDataSet = new Book_Management.Book_ManagementDataSet();
            this.bookBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.bookTableAdapter = new Book_Management.Book_ManagementDataSetTableAdapters.BookTableAdapter();
            this.iDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bookNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bookNumsDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.book_ManagementDataSet1 = new Book_Management.Book_ManagementDataSet1();
            this.bookRecordBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.book_RecordTableAdapter = new Book_Management.Book_ManagementDataSet1TableAdapters.Book_RecordTableAdapter();
            this.state_flag = new System.Windows.Forms.Label();
            this.book_ManagementDataSet2 = new Book_Management.Book_ManagementDataSet2();
            this.bookRecordBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.book_RecordTableAdapter1 = new Book_Management.Book_ManagementDataSet2TableAdapters.Book_RecordTableAdapter();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.book_ManagementDataSet3 = new Book_Management.Book_ManagementDataSet3();
            this.bookRecordBindingSource2 = new System.Windows.Forms.BindingSource(this.components);
            this.book_RecordTableAdapter2 = new Book_Management.Book_ManagementDataSet3TableAdapters.Book_RecordTableAdapter();
            this.userIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.userNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.borrowBookDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bookStatusDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.book_ManagementDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bookBindingSource)).BeginInit();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.book_ManagementDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bookRecordBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.book_ManagementDataSet2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bookRecordBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.book_ManagementDataSet3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bookRecordBindingSource2)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.User_Lab);
            this.groupBox2.Controls.Add(this.btnSerialPort);
            this.groupBox2.Controls.Add(this.cB_Port_Selection);
            this.groupBox2.Controls.Add(this.cB_Baud_Rate);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(270, 225);
            this.groupBox2.TabIndex = 33;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "图书刷卡器连接";
            // 
            // User_Lab
            // 
            this.User_Lab.AutoSize = true;
            this.User_Lab.Location = new System.Drawing.Point(6, 196);
            this.User_Lab.Name = "User_Lab";
            this.User_Lab.Size = new System.Drawing.Size(79, 13);
            this.User_Lab.TabIndex = 34;
            this.User_Lab.Text = "当前用户为：";
            // 
            // btnSerialPort
            // 
            this.btnSerialPort.Location = new System.Drawing.Point(9, 137);
            this.btnSerialPort.Name = "btnSerialPort";
            this.btnSerialPort.Size = new System.Drawing.Size(238, 40);
            this.btnSerialPort.TabIndex = 9;
            this.btnSerialPort.Text = "点击连接";
            this.btnSerialPort.UseVisualStyleBackColor = true;
            this.btnSerialPort.Click += new System.EventHandler(this.btnSerialPort_Click);
            // 
            // cB_Port_Selection
            // 
            this.cB_Port_Selection.FormattingEnabled = true;
            this.cB_Port_Selection.Location = new System.Drawing.Point(90, 87);
            this.cB_Port_Selection.Name = "cB_Port_Selection";
            this.cB_Port_Selection.Size = new System.Drawing.Size(157, 21);
            this.cB_Port_Selection.TabIndex = 6;
            // 
            // cB_Baud_Rate
            // 
            this.cB_Baud_Rate.FormattingEnabled = true;
            this.cB_Baud_Rate.Items.AddRange(new object[] {
            "1200",
            "2400",
            "4800",
            "9600",
            "14400",
            "19200",
            "57600",
            "76800",
            "115200",
            "128000"});
            this.cB_Baud_Rate.Location = new System.Drawing.Point(89, 47);
            this.cB_Baud_Rate.Name = "cB_Baud_Rate";
            this.cB_Baud_Rate.Size = new System.Drawing.Size(158, 21);
            this.cB_Baud_Rate.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "通信波特率：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 90);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "通信端口号：";
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Time_Lab
            // 
            this.Time_Lab.AutoSize = true;
            this.Time_Lab.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Time_Lab.Location = new System.Drawing.Point(18, 240);
            this.Time_Lab.Name = "Time_Lab";
            this.Time_Lab.Size = new System.Drawing.Size(83, 16);
            this.Time_Lab.TabIndex = 34;
            this.Time_Lab.Text = "现在时刻：";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.Borrow_Btn);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.BookBox1);
            this.groupBox1.Location = new System.Drawing.Point(407, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(330, 112);
            this.groupBox1.TabIndex = 36;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "借书操作";
            // 
            // Borrow_Btn
            // 
            this.Borrow_Btn.Location = new System.Drawing.Point(139, 57);
            this.Borrow_Btn.Name = "Borrow_Btn";
            this.Borrow_Btn.Size = new System.Drawing.Size(185, 39);
            this.Borrow_Btn.TabIndex = 37;
            this.Borrow_Btn.Text = "确认借阅";
            this.Borrow_Btn.UseVisualStyleBackColor = true;
            this.Borrow_Btn.Click += new System.EventHandler(this.Borrow_Btn_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(6, 29);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(113, 16);
            this.label3.TabIndex = 36;
            this.label3.Text = "选择借阅图书：";
            // 
            // BookBox1
            // 
            this.BookBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BookBox1.FormattingEnabled = true;
            this.BookBox1.Items.AddRange(new object[] {
            "西游记",
            "红楼梦",
            "水浒传",
            "三国演义"});
            this.BookBox1.Location = new System.Drawing.Point(139, 23);
            this.BookBox1.Name = "BookBox1";
            this.BookBox1.Size = new System.Drawing.Size(185, 28);
            this.BookBox1.TabIndex = 35;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(6, 18);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(113, 16);
            this.label4.TabIndex = 37;
            this.label4.Text = "选择归还图书：";
            // 
            // BookBox2
            // 
            this.BookBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BookBox2.FormattingEnabled = true;
            this.BookBox2.Items.AddRange(new object[] {
            "西游记",
            "红楼梦",
            "水浒传",
            "三国演义"});
            this.BookBox2.Location = new System.Drawing.Point(139, 12);
            this.BookBox2.Name = "BookBox2";
            this.BookBox2.Size = new System.Drawing.Size(185, 28);
            this.BookBox2.TabIndex = 38;
            // 
            // Return_Btn
            // 
            this.Return_Btn.Location = new System.Drawing.Point(139, 51);
            this.Return_Btn.Name = "Return_Btn";
            this.Return_Btn.Size = new System.Drawing.Size(185, 40);
            this.Return_Btn.TabIndex = 38;
            this.Return_Btn.Text = "确认归还";
            this.Return_Btn.UseVisualStyleBackColor = true;
            this.Return_Btn.Click += new System.EventHandler(this.Return_Btn_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.iDDataGridViewTextBoxColumn,
            this.bookNameDataGridViewTextBoxColumn,
            this.bookNumsDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.bookBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(9, 19);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(343, 184);
            this.dataGridView1.TabIndex = 37;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.dataGridView1);
            this.groupBox3.Location = new System.Drawing.Point(12, 259);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(364, 215);
            this.groupBox3.TabIndex = 38;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "书架图书";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.BookBox2);
            this.groupBox4.Controls.Add(this.label4);
            this.groupBox4.Controls.Add(this.Return_Btn);
            this.groupBox4.Location = new System.Drawing.Point(407, 130);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(330, 107);
            this.groupBox4.TabIndex = 39;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "还书操作";
            // 
            // book_ManagementDataSet
            // 
            this.book_ManagementDataSet.DataSetName = "Book_ManagementDataSet";
            this.book_ManagementDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // bookBindingSource
            // 
            this.bookBindingSource.DataMember = "Book";
            this.bookBindingSource.DataSource = this.book_ManagementDataSet;
            // 
            // bookTableAdapter
            // 
            this.bookTableAdapter.ClearBeforeFill = true;
            // 
            // iDDataGridViewTextBoxColumn
            // 
            this.iDDataGridViewTextBoxColumn.DataPropertyName = "ID";
            this.iDDataGridViewTextBoxColumn.HeaderText = "ID";
            this.iDDataGridViewTextBoxColumn.Name = "iDDataGridViewTextBoxColumn";
            // 
            // bookNameDataGridViewTextBoxColumn
            // 
            this.bookNameDataGridViewTextBoxColumn.DataPropertyName = "BookName";
            this.bookNameDataGridViewTextBoxColumn.HeaderText = "BookName";
            this.bookNameDataGridViewTextBoxColumn.Name = "bookNameDataGridViewTextBoxColumn";
            // 
            // bookNumsDataGridViewTextBoxColumn
            // 
            this.bookNumsDataGridViewTextBoxColumn.DataPropertyName = "BookNums";
            this.bookNumsDataGridViewTextBoxColumn.HeaderText = "BookNums";
            this.bookNumsDataGridViewTextBoxColumn.Name = "bookNumsDataGridViewTextBoxColumn";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.dataGridView2);
            this.groupBox5.Location = new System.Drawing.Point(382, 259);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(456, 213);
            this.groupBox5.TabIndex = 40;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "借阅记录";
            // 
            // book_ManagementDataSet1
            // 
            this.book_ManagementDataSet1.DataSetName = "Book_ManagementDataSet1";
            this.book_ManagementDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // bookRecordBindingSource
            // 
            this.bookRecordBindingSource.DataMember = "Book_Record";
            this.bookRecordBindingSource.DataSource = this.book_ManagementDataSet1;
            // 
            // book_RecordTableAdapter
            // 
            this.book_RecordTableAdapter.ClearBeforeFill = true;
            // 
            // state_flag
            // 
            this.state_flag.AutoSize = true;
            this.state_flag.Location = new System.Drawing.Point(297, 238);
            this.state_flag.Name = "state_flag";
            this.state_flag.Size = new System.Drawing.Size(67, 13);
            this.state_flag.TabIndex = 41;
            this.state_flag.Text = "当前无操作";
            // 
            // book_ManagementDataSet2
            // 
            this.book_ManagementDataSet2.DataSetName = "Book_ManagementDataSet2";
            this.book_ManagementDataSet2.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // bookRecordBindingSource1
            // 
            this.bookRecordBindingSource1.DataMember = "Book_Record";
            this.bookRecordBindingSource1.DataSource = this.book_ManagementDataSet2;
            // 
            // book_RecordTableAdapter1
            // 
            this.book_RecordTableAdapter1.ClearBeforeFill = true;
            // 
            // dataGridView2
            // 
            this.dataGridView2.AutoGenerateColumns = false;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.userIDDataGridViewTextBoxColumn,
            this.userNameDataGridViewTextBoxColumn,
            this.borrowBookDataGridViewTextBoxColumn,
            this.bookStatusDataGridViewTextBoxColumn});
            this.dataGridView2.DataSource = this.bookRecordBindingSource2;
            this.dataGridView2.Location = new System.Drawing.Point(6, 17);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.Size = new System.Drawing.Size(431, 184);
            this.dataGridView2.TabIndex = 0;
            // 
            // book_ManagementDataSet3
            // 
            this.book_ManagementDataSet3.DataSetName = "Book_ManagementDataSet3";
            this.book_ManagementDataSet3.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // bookRecordBindingSource2
            // 
            this.bookRecordBindingSource2.DataMember = "Book_Record";
            this.bookRecordBindingSource2.DataSource = this.book_ManagementDataSet3;
            // 
            // book_RecordTableAdapter2
            // 
            this.book_RecordTableAdapter2.ClearBeforeFill = true;
            // 
            // userIDDataGridViewTextBoxColumn
            // 
            this.userIDDataGridViewTextBoxColumn.DataPropertyName = "UserID";
            this.userIDDataGridViewTextBoxColumn.HeaderText = "UserID";
            this.userIDDataGridViewTextBoxColumn.Name = "userIDDataGridViewTextBoxColumn";
            // 
            // userNameDataGridViewTextBoxColumn
            // 
            this.userNameDataGridViewTextBoxColumn.DataPropertyName = "User_Name";
            this.userNameDataGridViewTextBoxColumn.HeaderText = "User_Name";
            this.userNameDataGridViewTextBoxColumn.Name = "userNameDataGridViewTextBoxColumn";
            // 
            // borrowBookDataGridViewTextBoxColumn
            // 
            this.borrowBookDataGridViewTextBoxColumn.DataPropertyName = "BorrowBook";
            this.borrowBookDataGridViewTextBoxColumn.HeaderText = "BorrowBook";
            this.borrowBookDataGridViewTextBoxColumn.Name = "borrowBookDataGridViewTextBoxColumn";
            // 
            // bookStatusDataGridViewTextBoxColumn
            // 
            this.bookStatusDataGridViewTextBoxColumn.DataPropertyName = "BookStatus";
            this.bookStatusDataGridViewTextBoxColumn.HeaderText = "BookStatus";
            this.bookStatusDataGridViewTextBoxColumn.Name = "bookStatusDataGridViewTextBoxColumn";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(854, 489);
            this.Controls.Add(this.state_flag);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.Time_Lab);
            this.Controls.Add(this.groupBox2);
            this.Name = "Form1";
            this.Text = "图书管理系统";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.book_ManagementDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bookBindingSource)).EndInit();
            this.groupBox5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.book_ManagementDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bookRecordBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.book_ManagementDataSet2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bookRecordBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.book_ManagementDataSet3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bookRecordBindingSource2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label User_Lab;
        private System.Windows.Forms.Button btnSerialPort;
        private System.Windows.Forms.ComboBox cB_Port_Selection;
        private System.Windows.Forms.ComboBox cB_Baud_Rate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label Time_Lab;
        private System.IO.Ports.SerialPort Port1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button Borrow_Btn;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox BookBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox BookBox2;
        private System.Windows.Forms.Button Return_Btn;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private Book_ManagementDataSet book_ManagementDataSet;
        private System.Windows.Forms.BindingSource bookBindingSource;
        private Book_ManagementDataSetTableAdapters.BookTableAdapter bookTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn iDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn bookNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn bookNumsDataGridViewTextBoxColumn;
        private System.Windows.Forms.GroupBox groupBox5;
        private Book_ManagementDataSet1 book_ManagementDataSet1;
        private System.Windows.Forms.BindingSource bookRecordBindingSource;
        private Book_ManagementDataSet1TableAdapters.Book_RecordTableAdapter book_RecordTableAdapter;
        private System.Windows.Forms.Label state_flag;
        private Book_ManagementDataSet2 book_ManagementDataSet2;
        private System.Windows.Forms.BindingSource bookRecordBindingSource1;
        private Book_ManagementDataSet2TableAdapters.Book_RecordTableAdapter book_RecordTableAdapter1;
        private System.Windows.Forms.DataGridView dataGridView2;
        private Book_ManagementDataSet3 book_ManagementDataSet3;
        private System.Windows.Forms.BindingSource bookRecordBindingSource2;
        private Book_ManagementDataSet3TableAdapters.Book_RecordTableAdapter book_RecordTableAdapter2;
        private System.Windows.Forms.DataGridViewTextBoxColumn userIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn userNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn borrowBookDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn bookStatusDataGridViewTextBoxColumn;
    }
}

