using System;
using Singonet.ir.UI.SQL_Connection;



namespace SQL_Connection_UI_Test
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]



        static void Main()
        {




              SQL_Connection_Class.Show_SQL_Connection_Manager("TestApp", SQL_Connection_Class.UI_Theme.Default_Theme);



            //Console.ReadKey();

        }


    }


}

