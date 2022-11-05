using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Xml.Linq;
using System.Data.SqlTypes;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для ListChat.xaml
    /// </summary>
    public partial class ListChat : Window
    {
        private string sqlChat;
        private static string WhenChat;
        private SqlCommand _cm;
        private delegate void DataBind(string TextChat);

        public ListChat(string I, string Comp)
        {
            InitializeComponent(); 
            BtnOut.Background = new SolidColorBrush(Color.FromRgb(0, 113, 188));
            BtnOut.Foreground = new SolidColorBrush(Colors.White);
            BtnOut.BorderBrush = new SolidColorBrush(Color.FromRgb(0, 113, 188));
            b3.BorderBrush = new SolidColorBrush(Color.FromRgb(0, 113, 188));
            WhenChat = I;
            sqlChat = "select * from chatUpdateCheckedSotr where Who = " + sqlCon.ID.ToString() + " and ToWhom= " + WhenChat + " and complaint=" + Comp + " union select * from chatUpdateCheckedClient where Who= " + WhenChat + " and ToWhom = " + sqlCon.ID.ToString() + " and complaint=" + Comp + " ORDER BY WhenTime;";
            LoadBDAsync();
        }

        private void LoadBDAsync()
        {
            SqlConnection con = new SqlConnection(sqlCon.ConString);
            _cm = new SqlCommand(sqlChat, con);
            con.Open();

            _cm.BeginExecuteReader(new AsyncCallback(CallBack), new object(), CommandBehavior.CloseConnection);
        }

        private void CallBack(System.IAsyncResult oResult)
        {
            SqlDataReader read = _cm.EndExecuteReader(oResult);

            string TextChat = "";
            while (read.Read())
            {
                TextChat = TextChat + "👤 " + read[3] +
                    " " + read[0] +
                    " " + read[1] +
                    ":\n" + read[2] + "\n";

            }
            read.Close();
            Dispatcher.Invoke(new DataBind(DataBindProc), TextChat);
        }

        private void DataBindProc(string TextChat)
        {
            chat.Text = TextChat;
            chat.ScrollToEnd();
        }

        private void ClickBack(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void ClickMove(object sender, RoutedEventArgs e)
        {
            this.Cursor = Cursors.Hand;
            (sender as Button).Background = new SolidColorBrush(Colors.White);
            (sender as Button).Foreground = new SolidColorBrush(Color.FromRgb(0, 113, 188));
            (sender as Button).BorderBrush = new SolidColorBrush(Color.FromRgb(0, 113, 188));
        }

        private void ClickLeave(object sender, RoutedEventArgs e)
        {
            this.Cursor = Cursors.Arrow;
            (sender as Button).Background = new SolidColorBrush(Color.FromRgb(0, 113, 188));
            (sender as Button).Foreground = new SolidColorBrush(Colors.White);
            (sender as Button).BorderBrush = new SolidColorBrush(Color.FromRgb(0, 113, 188));
        }
    }
}
