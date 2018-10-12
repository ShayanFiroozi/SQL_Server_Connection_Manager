/******************************************************************* 
 *             Forever Persian Gulf , Forever Persia               *
 *                                                                 *
 *                 ----> Singonet.ir <----                         *
 *                                                                 *
 * C# Singnet.ir                                                   *
 *                                                                 *
 * By Shayan Firoozi 2017 Bandar Abbas - Iran                      *
 * EMail : Singonet.ir@gmail.com                                   *
 * Phone : +98 936 517 5800                                        *
 *                                                                 *
 *******************************************************************/

using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
using Microsoft.Win32;  //used for windows registery access



namespace Singonet.ir.UI.SQL_Connection
{
    public partial class SQL_Conn : UserControl
    {

        private RegistryKey reg_key; // holds current registry key (main title)
       


        public event EventHandler Connection_Established;

        // Properties ******************************************************************


        private SqlConnection _sql_conn;
                    public SqlConnection SQL_Connection
                    {
                        get
                        {
                            return _sql_conn;
                        }

                        //set
                        //{
                        //    _sql_conn = value;
                        //}
                    }





                    private string _application_name;
                    public string Application_Name
                    {
                        //get
                        //{
                        //    return _application_name;
                        //}

                        set
                        {
                            _application_name = value;
                        }
                    }



       
       


        //***************************************************************************

        public SQL_Conn()
        {

        
            InitializeComponent();
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
            Environment.Exit(0);
        }

        private void btn_apply_Click(object sender, EventArgs e)
        {


       


            if (string.IsNullOrEmpty(_application_name) == true)
            {
                MessageBox.Show("نام برنامه مشخص نشده است", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                throw new Exception("Invalid Application Name");
            }



        


            if(reg_key == null)
            {
                MessageBox.Show("خطا در دسترسی به رجیستری ویندوز", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                throw new Exception("Windows registry access failed.");

            }



            if (string.IsNullOrEmpty(cmb_database.Text))
            {
                MessageBox.Show("نام بانک معتبر نمیباشد", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                return;
            }


            if (cmb_database.Text.ToLower() == "master")
            {
                MessageBox.Show("بانک master نمیتواند انتخاب شود", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                return;
            }



            try

            {
                // connect to the master database
                _sql_conn = new SqlConnection("Data Source=" + txt_server_name.Text +
                                             ";Initial Catalog=" + cmb_database.Text +
                                             ";Persist Security Info=True;User ID=" + txt_username.Text +
                                             ";Password=" + txt_password.Text);

                _sql_conn.Open();


            }

            catch (Exception ex)
            {

                if (ex.Message.Contains("Cannot open database") == true)
                {
                    MessageBox.Show("بانک انتخابی شما در دسترس نمیباشد", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                  //  throw;


                }


                if (ex.Message.Contains("Login failed") == true)
                {
                    MessageBox.Show("نام کاربری و یا کلمه عبور توسط سرور تایید نشد", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                   // throw;


                }


            }


            finally
            {


                if (_sql_conn.State == ConnectionState.Open)

                {

                  

                    // load databases and close _sql_conn


                    try
                    {
                        //save connection string in registery


                        reg_key.SetValue("SQLServer", txt_server_name.Text);
                        reg_key.SetValue("UserName", txt_username.Text);
                        reg_key.SetValue("Password", txt_password.Text);
                        reg_key.SetValue("Database", cmb_database.Text);


                        MessageBox.Show("اتصال برقرار شد" +
                      Environment.NewLine + "لطفا نرم افزار را مجددا اجرا نمایید", "اتصال", MessageBoxButtons.OK, MessageBoxIcon.Information);


                    }
                    catch
                    {
                       
                      //  throw;
                    }

                    finally
                    {
                        _sql_conn.Close();
                    }
                }

                else
                {
                    MessageBox.Show("اتصال موفقیت آمیز نبود", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

                _sql_conn.Close();

            }

        }



    private void txt_server_name_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar==(char)13)
            {
                if(string.IsNullOrWhiteSpace(txt_server_name.Text)==false)
                {
                    txt_username.Focus();
                }
            }
        }

        private void txt_username_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                if (string.IsNullOrWhiteSpace(txt_username.Text) == false)
                {
                    txt_password.Focus();
                }
            }
        }

        private void txt_password_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                if (string.IsNullOrWhiteSpace(txt_password.Text) == false)
                {
                    btn_load_databases_Click(null, null);
                }
            }
        }

        private void pic_info_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Examples : " + Environment.NewLine + Environment.NewLine  +  "." + 
                                        Environment.NewLine + ".\\MSSQLSERVER" +   Environment.NewLine + 
                ".\\SQL2008R2" + Environment.NewLine + "192.168.100.1" + Environment.NewLine  + "192.168.100.1\\SQLSERVER2008R2" +
                Environment.NewLine +  "192.168.100.1\\MSSQLSERVER2008" 
                , "اتصال به سرور", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btn_load_databases_Click(object sender, EventArgs e)
        {

         





            if (string.IsNullOrEmpty(_application_name) == true)
            {
                MessageBox.Show("نام برنامه مشخص نشده است", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                throw new Exception("Invalid Application Name");
            }



            if (string.IsNullOrWhiteSpace(txt_username.Text) == true)

            {
                MessageBox.Show("نام سرور معتبر نمیباشد", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                return;
            }


            if (string.IsNullOrWhiteSpace(txt_username.Text) == true)

            {
                MessageBox.Show("نام کاربری معتبر نمیباشد", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                return;
            }



            if (string.IsNullOrWhiteSpace(txt_password.Text) == true)

            {
                MessageBox.Show("کلمه عبور معتبر نمیباشد", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                return;
            }


            btn_load_databases.Enabled = false;
            txt_password.Enabled = false;
            txt_server_name.Enabled = false;
            txt_username.Enabled = false;
            
            cmb_database.Items.Clear();



            try

            {
                // connect to the master database
                _sql_conn = new SqlConnection("Data Source=" + txt_server_name.Text +
                                             ";Initial Catalog=" + "master" +
                                             ";Persist Security Info=True;User ID=" + txt_username.Text +
                                             ";Password=" + txt_password.Text);

                _sql_conn.Open();


            }

            catch (Exception ex)
            {

                if (ex.Message.Contains("Cannot open database") == true)
                {
                    MessageBox.Show("بانک انتخابی شما در دسترس نمیباشد", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                 //   throw;


                }

                if (ex.Message.Contains("Login failed") == true)
                {
                    MessageBox.Show("نام کاربری و یا کلمه عبور توسط سرور تایید نشد", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                  //  throw;

                }


            }


            finally
            {





                if (_sql_conn.State == ConnectionState.Open)

                {

                    MessageBox.Show("اتصال برقرار شد" +
                        Environment.NewLine + "لطفا نام بانک مورد نظر را از لیست انتخاب نموده و دکمه تایید را فشار دهید", "اتصال", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // load databases and close _sql_conn
                    try
                    {
                        _load_master_databases();

                        cmb_database.Enabled = true;

                        cmb_database.Focus();

                        cmb_database.DroppedDown = true;


                    }
                    catch
                    {
                        //MessageBox.Show("خطا در بارگذاری بانک ها", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                       // throw;
                    }

                    finally
                    {
                        _sql_conn.Close();
                        
                    }
                }

                else
                {
                    MessageBox.Show("اتصال موفقیت آمیز نبود", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

                _sql_conn.Close();

                btn_load_databases.Enabled = true;
                txt_password.Enabled = true;
                txt_server_name.Enabled = true;
                txt_username.Enabled = true;

            }

        }



        private void _load_master_databases()
        {
            try
            {


                SqlCommand sqlCmd = new SqlCommand("select [name] from master.sys.databases", _sql_conn);

                SqlDataReader sqlReader = sqlCmd.ExecuteReader();


                while (sqlReader.Read())
                {
                    if (sqlReader["name"].ToString().Contains("$") == false)
                    {
                        cmb_database.Items.Add(sqlReader["name"].ToString());
                    }
                }

                sqlReader.Close();




                sqlCmd.Dispose();


                sqlCmd = null;

                
                
                             
            }

            catch
            {
         
              //  throw ex;
            }
        }



        private void cmb_database_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(string.IsNullOrWhiteSpace(cmb_database.Text) == false && cmb_database.Text.ToLower() != "master")
            {
                btn_apply.Enabled = true;
            }
            else

            {
                btn_apply.Enabled = false;

            }
        }

        public void ConnectToDatabase()
        {

     


            // check if we have a connection in windows registery


            try

            {
                // connect to the master database
                _sql_conn = new SqlConnection("Data Source=" + reg_key.GetValue("SQLServer").ToString() +
                                             ";Initial Catalog=" + reg_key.GetValue("Database").ToString() +
                                             ";Persist Security Info=True;User ID=" + reg_key.GetValue("UserName").ToString() +
                                             ";Password=" + reg_key.GetValue("Password").ToString());







                _sql_conn.Open();


            }

            catch (Exception ex)
            {

                if (ex.Message.Contains("Cannot open database") == true)
                {
                    MessageBox.Show("بانک انتخابی شما در دسترس نمیباشد", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                   // throw;


                }

                if (ex.Message.Contains("Login failed") == true)
                {
                    MessageBox.Show("نام کاربری و یا کلمه عبور توسط سرور تایید نشد", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                   // throw;


                }


            }


            finally
            {

                if (_sql_conn != null)
                {
                    if (_sql_conn.State == ConnectionState.Open)

                    {


                        try
                        {

                            // Hoooray !! we got the connection and we should go further(Login page) and raise an event



                            Connection_Established?.Invoke(null, null);


                         





                        }
                        catch
                        {

                           // throw;
                        }


                    }

                    else
                    {
                        MessageBox.Show("اتصال موفقیت آمیز نبود", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                     

                    }

                }

            }

        }

        private void SQL_Conn_Load(object sender, EventArgs e)
        {




            // initialize registery key



            //if (string.IsNullOrEmpty(_application_name) == true)
            //{
            //    MessageBox.Show("نام برنامه مشخص نشده است", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            //    throw new Exception("Invalid Application Name");
            //}


            // initialize registery key

            try
            {

                reg_key = Registry.CurrentUser.CreateSubKey(@"Software\" + _application_name + @"\SQLConnection");
            }

            catch
            {
                MessageBox.Show("خطا در دسترسی به رجیستری ویندوز", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                throw new Exception("Windows registry access failed.");


            }



       


            try
            {


                // connect to the master database

                txt_server_name.Text = reg_key.GetValue("SQLServer").ToString();
                txt_username.Text = reg_key.GetValue("UserName").ToString();
                txt_password.Text = reg_key.GetValue("Password").ToString();
                cmb_database.Text = reg_key.GetValue("Database").ToString();

            }

            catch
            {

            }




        }

        private void cmb_database_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar) == (char)13)
            {
                btn_apply_Click(null, null);
            }
        }

        private void pic_info_MouseEnter(object sender, EventArgs e)
        {
            pic_info.BackColor = System.Drawing.Color.LavenderBlush;
        }

        private void pic_info_MouseLeave(object sender, EventArgs e)
        {
            pic_info.BackColor = System.Drawing.Color.White;
        }



    }
}
