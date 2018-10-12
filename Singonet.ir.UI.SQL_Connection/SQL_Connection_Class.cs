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
using System.Data.SqlClient;

namespace Singonet.ir.UI.SQL_Connection
{
    public static class SQL_Connection_Class
    {
        private static frm_theme_default _frm_connection;
      

        // main sql connection for user
        public static SqlConnection _SQL_Connection { get; internal set; }



        public enum UI_Theme
        {
      
            Default_Theme = 0,

      
            
         
        }




        public static void Show_SQL_Connection_Manager(string ApplicationName,UI_Theme _UI_Theme = UI_Theme.Default_Theme)
        {
           


            if (string.IsNullOrEmpty(ApplicationName)==true)
            {
                throw new Exception("Invalid Application Name.");

               
            }



           

            // Theme selection
            if (_UI_Theme == UI_Theme.Default_Theme)
            {

                _frm_connection = new frm_theme_default(ApplicationName);

                _frm_connection.ShowDialog();

            }




        }


    }
}
