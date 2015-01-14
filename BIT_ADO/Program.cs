using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data.Common;

namespace BIT_ADO
{
    class Program
    {

        public static string ConnectionString
        {
            get;
            set;
        }

        private static void printResults(DbDataReader dr)
        {

            StringBuilder readerData = new StringBuilder();

            while (dr.Read())
            {

                int total = dr.FieldCount;
                for (int i = 0; i < total; ++i)
                {
                    readerData.Append(dr.GetName(i).ToUpper() + ": ");
                    readerData.Append(dr[dr.GetName(i)]);
                    Console.WriteLine(readerData.ToString());
                    readerData.Clear();
                }
                readerData.Append(Environment.NewLine);
            }
        }
        private static void ListClients()
        {
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "SELECT * FROM dbo.Cliente";
                cmd.Connection = con;
                printResults(cmd.ExecuteReader());
            }
        }


        static void Main(string[] args)
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();

            builder.UserID = "User1";
            builder.Password = "benficas";
            builder.InitialCatalog = "BIT";
            builder.DataSource = "(local)";
            builder.Pooling = true;
            builder.MaxPoolSize = 10;
            ConnectionString = builder.ToString();
            ListClients();

            Console.ReadLine();

        }
    }
}
