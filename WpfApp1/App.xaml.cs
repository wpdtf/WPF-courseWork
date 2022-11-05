using System;
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;
using System.Windows;

namespace WpfApp1
{
    public class sqlCon
    {
        public static string ConString = @"Data Source=10.160.160.2,1433\SQLEXPRESS;Initial Catalog=NevaLink;Persist Security Info=True;User ID=dmitryHome;Password=wpdtf1234";

        public static int ID;
        public static string Family;
        public static string Name;
        public static string Post;
        public static int levelWork;
        public static int levelPrivil;
    }

    public class chatFunc
    {
        public static int IDsotr = -1;
        public static int IDcomplaint = 1;
    }

    public class security
    {
        //функция для записи логов
        public static void logsInsert(string wtf)
        {
            SqlConnection con = new SqlConnection(sqlCon.ConString);
            SqlCommand com = new SqlCommand("insert into logs values (" + sqlCon.ID + ", '"+wtf+"')", con);
            SqlDataAdapter adapter = new SqlDataAdapter(com);
            DataTable dat = new DataTable();
            adapter.Fill(dat);
        }


        public static string getHash(string text)
        {
            using (var sha256 = SHA256.Create())
            {
                //получение хеша
                var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(text));

                return BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
            }
        }
    }

    public partial class App : Application
    {
    }
}
