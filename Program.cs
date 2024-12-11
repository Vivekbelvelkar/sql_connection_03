using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Threading;

namespace sql_connection_03
{
    internal class Program
    {
        string name;
        int contact;
        int roll;
        string branch;
        string cs = "Data Source=localhost\\sqlexpress;Initial Catalog=myDB;Integrated Security=True;Encrypt=True;TrustServerCertificate=True";

        static void Main(string[] args)
        {
            Program pg = new Program();
            // pg.insertdata();
            // pg.update();
            //pg.delete();
            //pg.select();
            pg.branchwise();
        }
        public void select()
        {
            SqlConnection con = new SqlConnection(cs);
            con.Open();
            SqlCommand cmd = new SqlCommand(" slt");
            cmd.Connection = con;
            SqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                Console.WriteLine(rdr["roll"] + "   " + rdr["name"] + "    " + rdr["contact"]+"  " + rdr["branch"]);
            }
        }
        public   void insertdata()
        {
            
            Console.WriteLine("Enter new admission");
            Console.WriteLine("enter roll number to add");
            roll = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter name to add");
            name = Console.ReadLine();
            Console.WriteLine("Enter number to add");
            contact = int.Parse(Console.ReadLine());
            SqlConnection sqcon = new SqlConnection(cs);
            sqcon.Open();
            SqlCommand cmd = new SqlCommand($"insert into student values ({roll},'{name}',{contact})");
            cmd.Connection = sqcon;
            int n=cmd.ExecuteNonQuery();
            if (n > 0)
            {
                Console.WriteLine("command succesful");
            }
            else
            {
                Console.WriteLine("failed to insert data");
            }
        }
        public void update()
        {
            
            Console.Write("update details at id: ");
            roll = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter name");
            name= Console.ReadLine();
            Console.WriteLine("enter contact");
            contact = int.Parse(Console.ReadLine());

            SqlConnection sqcon = new SqlConnection(cs);
            sqcon.Open();
            SqlCommand cmd = new SqlCommand("udt");
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Connection = sqcon;
            cmd.Parameters.AddWithValue("@name", name);
            cmd.Parameters.AddWithValue("@contact", contact);
            cmd.Parameters.AddWithValue("@roll", roll);
            int n=cmd.ExecuteNonQuery();
            if (n > 0)
            {
                Console.WriteLine("record updated");
            }
            else
            {
                Console.WriteLine("invalid operation");
            }
        }
        public void delete()
        {
            Console.WriteLine("record to delete");
            //roll = int.Parse(Console.ReadLine());
            name = Console.ReadLine();
            SqlConnection sqcon = new SqlConnection(cs);
            sqcon.Open();
            SqlCommand cmd = new SqlCommand($"delete from student where name ='{name}'");
            cmd.Connection = sqcon;
            int n=cmd.ExecuteNonQuery();
            if (n > 0)
            {
                Console.WriteLine("record deleted ");
            }
            else
            {
                Console.WriteLine("Record not found");
            }
        }
        public void branchwise()
        {
            Console.Write("students in branch :");
            branch= Console.ReadLine();

            SqlConnection sqcon = new SqlConnection(cs);
            sqcon.Open();
            SqlCommand cmd = new SqlCommand($"select * from student where branch='{branch}'");
            cmd.Connection = sqcon;
            SqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                Console.WriteLine(rdr["roll"] + "   " + rdr["name"] + "    " + rdr["contact"] + "  " + rdr["branch"]);
            }
            sqcon.Close();
        }
    }
}
