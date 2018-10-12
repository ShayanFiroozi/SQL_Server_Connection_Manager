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
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Singonet.ir.UI.SQL_Connection
{
    public partial class frm_theme_default : Form
    {
        public frm_theme_default(string _Application_Name)
        {


        


           


            InitializeComponent();

            sqL_Conn1.Application_Name = _Application_Name;


        }

        private void sqL_Conn1_Load(object sender, EventArgs e)
        {
            
            sqL_Conn1.ConnectToDatabase();
        }

        private void sqL_Conn1_Connection_Established(object sender, EventArgs e)
        {
            
            this.Visible = false;



            try
            {
                // create new instance for user to use in his application as a global connection
                SQL_Connection_Class._SQL_Connection = new SqlConnection(sqL_Conn1.SQL_Connection.ConnectionString);

                SQL_Connection_Class._SQL_Connection.Open();


                this.Close();
            }

            catch
            {
                
                this.Visible = true;
            }
            

        }
    }
}
