using System;
using System.Text;
using System.Data.SqlClient;
using System.IO;
using System.IO.Compression;

namespace _9_sep_2022_Bhavna_Corp_Task
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Main:
            Console.WriteLine("====================================================\n Hi Welcome to the Bhavna Corp \n====================================================\n\n");
            Console.WriteLine("\t==========    In this page you can register the Employee details   ==========    \n\n\n ");
            star:
            Console.WriteLine("\t==========       Press 1 to login to the Bhavna Corp DataBase      ==========    \n\n\n ");
            string Username = "admin@123";
            string Password = "admin@123";
            Console.WriteLine("Enter your Password : ");
            string UI = Console.ReadLine();
            Console.WriteLine("Enter your Password : ");
            string UP = Console.ReadLine();

            string EmpFile = @"D:\Employee.txt";
            if (Username == UI & Password ==UP)
            {
                //-------------------------------for DB record-----------------------------------//
                Console.WriteLine("\t==========     You have sucessfully log in to the server     ==========    \n\n\n ");
                Console.WriteLine("\t==========     Press 1 to insert details in the Database     ========== \n\n\n ");

                SqlConnection con = new SqlConnection("server=localhost;database=Employee;integrated security=true");

                emp_details em = new emp_details();

                //Console.WriteLine("Enter Employee ID");
                //em.id = int.Parse(Console.ReadLine());
                insert:
                Console.WriteLine("Enter Employee name : ");
                em.name = Console.ReadLine();
                Console.WriteLine("Enter department name");
                em.department = Console.ReadLine();
                Console.WriteLine("Enter employee geder");
                em.gender = Console.ReadLine();
                Console.WriteLine("Enter Salary : ");
                em.salary = int.Parse(Console.ReadLine());

                SqlCommand cmd = new("insert into emp_details values('" + em.name + "','" + em.department + "','" + em.gender + "'," + em.salary + ")", con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                Console.WriteLine("\t ==========          Employee registered sucessfully         ========== \n\n\n");
                //-------------------------------------------------for file record------------------------------//

                if (!File.Exists(EmpFile))
                    using (StreamWriter sw = File.CreateText(EmpFile))
                    {
                        sw.WriteLine($" {em.name} / {em.department} / {em.gender} / {em.salary}");
                    }
                else
                    using (StreamWriter sw = File.AppendText(EmpFile))
                    {
                        sw.WriteLine($"{em.name} / {em.department} / {em.salary} / {em.gender}");
                    }
                Console.WriteLine("\n\nHere are the updated records:\n");

                using (StreamReader sr = File.OpenText(EmpFile))
                {
                    string s = "";
                    while ((s = sr.ReadLine()) != null)
                    {
                        Console.WriteLine(s);
                    }
                }

                //------------------end
                int A = int.Parse(Console.ReadLine());

                invalid:
                Console.WriteLine("\t  Press 1 for register another Employee Details\n ,press 2 for exit \n press 3 to main menu \n\n\n");
                switch (A)
                {
                    case 1:
                        goto insert;
                        break;
                    case 2:
                        Environment.Exit(0);
                        break;
                    case 3:
                        goto Main;
                        break;
                    default:
                        Console.WriteLine("Please Enter Something Valid.");
                        Console.Clear();
                        goto invalid;
                }
            }
            else
            {
                Console.WriteLine("\\t    <-----------     WARNING : PLEASE ENTER SOMETHING VALID      ----------->    \\n\\n\\n \"");
                Console.WriteLine("\\t    <-----------           ID or Password are Incorrect          ----------->    \\n\\n\\n \"");
                Console.WriteLine("\\t    <-----------                Enter Password Again              ----------->    \\n\\n\\n \"");
            }
            goto star;





        }
    }
}