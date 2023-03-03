using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Data.OleDb;
using System.Windows.Forms;
using System.IO.Ports;
namespace Book_Management
{
    public partial class Form1 : Form
    {
        string received_data;
        string user_ID,user_name;
        string com_choice;
        uint count1, count1_flag;//用于标识操作状态更新
        int book_num;//剩余图书数量
        string book_status;
        OleDbConnection conn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;" + @"Data Source=../../Book_Management.accdb");
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
            timer1.Start();
            cB_Baud_Rate.Text = 9600.ToString();
            string[] PortNames = SerialPort.GetPortNames();    //获取本机串口名称，存入PortNames数组中

            for (int i = 0; i < PortNames.Count(); i++)

            {

                cB_Port_Selection.Items.Add(PortNames[i]);   //将数组内容加载到comboBox控件中

            }
            Update_View1();
            Update_View2();
            user_ID = "00";

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Time_Lab.Text = String.Format("当前时间:{0:d}", DateTime.Now.ToString("yyy-MM-dd HH:mm:ss"));
            if (count1_flag == 1)
            {
                count1++;
                if (count1 > 5)
                {
                    count1 = 0;
                    count1_flag = 0;
                    if (user_ID != "00")
                    {
                        state_flag.Text = "当前操作用户：" + user_name + "，卡号为：" + user_ID;
                    }
                    else
                    {
                         state_flag.Text = "当前无用户正在操作";
                    }
                   
                    BookBox1.Text = "  ";
                    BookBox2.Text = "  ";
                }
            }
        }

        private void Borrow_Btn_Click(object sender, EventArgs e)
        {

            if (BookBox1.Text.Length > 0)
            {
                conn.Open();
                string check = string.Format("select * from Book where BookName = '{0}' ", BookBox1.Text);
                OleDbDataAdapter da = new OleDbDataAdapter(check, conn); //创建适配对象 
                DataTable dt1 = new DataTable();

                da.Fill(dt1); //用适配对象填充表对象            
                book_num = Convert.ToInt16(dt1.Rows[0][2].ToString());//获取图书数量
                conn.Close();
                if (book_num > 0&&user_ID!="  "&&user_ID!="00")
                {
                    conn.Open();
                    string insertStr1 = String.Format("INSERT INTO Book_Record(UserID,User_Name,BorrowBook,BookStatus) VALUES ('{0}','{1}','{2}','{3}')", user_ID, user_name, BookBox1.Text, "已借出");
                    OleDbCommand InsertRecord = new OleDbCommand(insertStr1, conn);
                    InsertRecord.ExecuteNonQuery();
                    conn.Close();

                    conn.Open();
                    string update_tStr = String.Format("update Book set BookNums =  '{0}' where BookName=  '{1}'  ", (book_num-1).ToString(), BookBox1.Text);
                    OleDbCommand Update_Info = new OleDbCommand(update_tStr, conn);
                    Update_Info.ExecuteNonQuery();
                    conn.Close();
                    state_flag.Text = user_name + "，您已成功借阅" + BookBox1.Text+",请爱护公用书籍，并及时归还，谢谢！！";
                    

                }
                else
                if(book_num==0)
                {
                    MessageBox.Show("此书已全部借出，无法借阅！！");
                }
                else
                {
                    MessageBox.Show("未检测到用户，无法进行操作，请连接下位机再操作！！");
                }
            }
            else
            {
                MessageBox.Show("请选择需要借阅的图书！！");
            }
           
            Update_View1();
            Update_View2();
            count1_flag = 1;
        }

        private void Return_Btn_Click(object sender, EventArgs e)
        {
            if (BookBox2.Text.Length > 0)
            {


                conn.Open();
                string check = string.Format("select * from Book where BookName = '{0}' ", BookBox2.Text);
                OleDbDataAdapter da = new OleDbDataAdapter(check, conn); //创建适配对象 
                DataTable dt1 = new DataTable();

                da.Fill(dt1); //用适配对象填充表对象            
                book_num = Convert.ToInt16(dt1.Rows[0][2].ToString());//获取图书数量
                conn.Close();
                try
                {



                    conn.Open();
                    string check_book = string.Format("select * from Book_Record where UserID = '{0}' and BorrowBook = '{1}' ", user_ID,BookBox2.Text);
                    OleDbDataAdapter da1 = new OleDbDataAdapter(check_book, conn); //创建适配对象 
                    DataTable dt2= new DataTable();

                    da1.Fill(dt2); //用适配对象填充表对象            
                    book_status = dt2.Rows[dt2.Rows.Count-1][3].ToString();//获取所借阅图书的状态
                    conn.Close();
                    if (book_status == "已借出")
                    {
                        conn.Open();
                        string update_tStr = String.Format("update Book_Record set BookStatus =  '{0}' where User_Name='{1}' and BorrowBook=  '{2}' ", "已归还", user_name, BookBox2.Text.ToString());
                        OleDbCommand Update_Info = new OleDbCommand(update_tStr, conn);
                        Update_Info.ExecuteNonQuery();
                        conn.Close();
                        state_flag.Text = "您已成功归还"+BookBox2.Text+"，欢迎下次借阅！！";
                        count1_flag = 1;
                        conn.Open();
                        string update_returnBook = String.Format("update Book set BookNums =  '{0}' where BookName=  '{1}'  ", (book_num + 1).ToString(), BookBox2.Text);
                        OleDbCommand Update_Book = new OleDbCommand(update_returnBook, conn);
                        Update_Book.ExecuteNonQuery();
                        conn.Close();
                    }

                    else
                    {
                        MessageBox.Show("此书已归还，无须进行归还操作！！");
                    }


                }
                catch (Exception ex)
                {

                    //MessageBox.Show("请确认是否为本人借阅书籍！！");
                   MessageBox.Show(ex.Message);
                    conn.Close();
                }
           
            }
            Update_View1();
            Update_View2();
        }

        private void btnSerialPort_Click(object sender, EventArgs e)
        {
            if (btnSerialPort.Text == "点击连接")
            {

                btnSerialPort.Text = "点击关闭";
                Port1 = new SerialPort();
                Port1.BaudRate = Convert.ToInt32(cB_Baud_Rate.Text);
                com_choice = cB_Port_Selection.Text;
                Port1.PortName = com_choice;
                Port1.Parity = Parity.None;
                Port1.DataBits = 8;
                Port1.StopBits = StopBits.One;
                Port1.DataReceived += Port_DataReceived;
                try
                {
                    Port1.Open();
                }
                catch (Exception ex1)
                {
                    MessageBox.Show(ex1.Message, "未找到该串口");
                }
            }
            else
            {
                btnSerialPort.Text = "点击关闭";
                try
                {
                    Port1.Close();
                    btnSerialPort.Text = "点击连接";
                }
                catch (Exception ex2)
                {
                    MessageBox.Show(ex2.Message, "串口关闭失败");
                }
            }
        }

        void Port_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                received_data = Port1.ReadLine();

            }
            catch (Exception ex2)
            {
                MessageBox.Show(ex2.Message, "未收到任何数据！！");
            }


            this.Invoke(new EventHandler(display_data_event));
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void display_data_event(object sender, EventArgs e)
        {
            // Time_Lab.Text = String.Format("当前时间为:{0:d}", DateTime.Now.ToString("yyy-MM-dd HH:mm:ss"));
            if (received_data.Substring(0, 4).ToString() == "book")
            {
                user_ID = received_data.Substring(4, 2).ToString();
            }

            try
            {

                conn.Open();
                string iSInsert = string.Format("select * from User_Info where ID = '{0}'", user_ID);
                OleDbCommand InsertCmd = new OleDbCommand(iSInsert, conn);
                OleDbDataReader reader1 = InsertCmd.ExecuteReader();

                if (reader1.Read())//数据库读取到ID
                {
                    conn.Close();
                    conn.Open();
                    string check = string.Format("select * from User_Info where ID = '{0}' ", user_ID);
                    OleDbDataAdapter da = new OleDbDataAdapter(check, conn); //创建适配对象 
                    DataTable dt1 = new DataTable();

                    da.Fill(dt1); //用适配对象填充表对象            
                    user_name = dt1.Rows[0][2].ToString();//获取操作用户
                    state_flag.Text = "当前操作用户：" + user_name+"，卡号为："+user_ID;
                    count1_flag = 1;
                    conn.Close();
                }
                else
                {
                    conn.Close();
                    state_flag.Text ="ID="+user_ID+ "的用户不存在，请您在登记之后再进行操作";
                    count1_flag = 1;
                }

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Wrong operation!!!");

            }




        }




        /// <summary>
        /// 更新datagridview显示数据
        /// </summary>
        public void Update_View1()
        {
            string sql_upload = "select * from Book";//DataGridView1数据查询
            OleDbDataAdapter da_load = new OleDbDataAdapter(sql_upload, conn); //创建适配对象 
            conn.Open();
            DataTable dt_load = new DataTable(); //新建表对象
            da_load.Fill(dt_load); //用适配对象填充表对象            
            dataGridView1.DataSource = dt_load; //将表对象作为DataGridView的数据源
            conn.Close();
        }

        public void Update_View2()
        {
            string sql6 = "select * from Book_Record";
            OleDbDataAdapter da = new OleDbDataAdapter(sql6, conn); //创建适配对象 
            conn.Open();
            DataTable dt = new DataTable(); //新建表对象
            da.Fill(dt); //用适配对象填充表对象
            dataGridView2.DataSource = dt; //将表对象作为DataGridView的数据源
            conn.Close();
        }






    }
}
