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



            try
            {
                if (SQL_Connection_Class._SQL_Connection.State == System.Data.ConnectionState.Open)
                {
                    Console.WriteLine("Connection sucessfully established.");
                    Console.WriteLine("Your connection string is " + SQL_Connection_Class._SQL_Connection.ConnectionString);

                }
                else
                {
                    Console.WriteLine("Connection error.");

                }

            }

            catch

            {

            }

            finally
            {
                Console.WriteLine("");
                Console.WriteLine("Press any key to exit");
                Console.ReadKey();
            }



            // ----> Here is your Active SQL Connection--> SQL_Connection_Class._SQL_Connection;

        }


    }


}

