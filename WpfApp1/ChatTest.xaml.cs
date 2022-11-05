using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Navigation;
using System.Data.SqlClient;
using System.Data;

namespace WpfApp1
{

    public partial class ChatTest : Page
    {
        private delegate void RefreshData();
        private string checkSum = "ghk";
        private string sqlChat;
        private static int WhenChat;
        private static string sqlCheckSum;
        private SqlCommand _cm;
        private delegate void DataBind(string TextChat);

        private string userName;
        private string homeLink;
        private string text;

        public ChatTest()
        {
            InitializeComponent();

            users.Content = sqlCon.Family + " " + sqlCon.Name;
            posts.Content = sqlCon.Post;
            b2.BorderBrush = new SolidColorBrush(Color.FromRgb(0, 113, 188));
            b3.BorderBrush = new SolidColorBrush(Color.FromRgb(0, 113, 188));
            btnSend.Background = new SolidColorBrush(Color.FromRgb(0, 113, 188));
            BtnOut.Background = new SolidColorBrush(Color.FromRgb(0, 113, 188));
            BtnOut.BorderBrush = new SolidColorBrush(Color.FromRgb(0, 113, 188));
            BtnToHelp.Background = new SolidColorBrush(Color.FromRgb(0, 113, 188));
            BtnToHelp.BorderBrush = new SolidColorBrush(Color.FromRgb(0, 113, 188));
            BtnToActive.Background = new SolidColorBrush(Color.FromRgb(0, 113, 188));
            BtnToActive.BorderBrush = new SolidColorBrush(Color.FromRgb(0, 113, 188));
            if (sqlCon.levelWork != 1)
            {
                BtnToHelp.Visibility = Visibility.Collapsed;
            }
            if (chatFunc.IDcomplaint < 0)
            {
                int WhenComplaint = chatFunc.IDcomplaint;
                SqlConnection con = new SqlConnection(sqlCon.ConString);
                con.Open();
                SqlCommand com = new SqlCommand("select * from chatComplaintChecked where id_complaint = " + -WhenComplaint + ";", con);
                SqlDataReader read = com.ExecuteReader();
                if (read.HasRows)
                {
                    while (read.Read())
                    {
                        userName = read.GetValue(3) + " " + read.GetValue(4);
                        homeLink = read.GetValue(5) + ", " + read.GetValue(6) + ", " + read.GetValue(7);
                        text = read.GetValue(2).ToString();
                        WhenChat = 0-Convert.ToInt32(read.GetValue(1));
                        nameChat.Text = userName;
                        homeChat.Text = homeLink;
                        textError.Text = text;
                    }
                }
            }
            else
            {
                WhenChat = chatFunc.IDsotr;
            }
            sqlChat = "select * from chatUpdateCheckedSotr where Who = " + sqlCon.ID.ToString() + " and ToWhom= " + WhenChat + " and complaint="+-chatFunc.IDcomplaint + " union select * from chatUpdateCheckedClient where Who= " + WhenChat + " and ToWhom = " + sqlCon.ID.ToString() + " and complaint=" + -chatFunc.IDcomplaint + " ORDER BY WhenTime;";
            sqlCheckSum = "exec checkSumChat " + sqlCon.ID.ToString() + ", "+ WhenChat.ToString() + ", " + -chatFunc.IDcomplaint + ";";
            LoadBD();
        }

        private void ClickTo2Level(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Вы подтверждаете выбор?\nДействие не обратимо.", "Отправить заявку на следующий уровень", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                SqlConnection con = new SqlConnection(sqlCon.ConString);
                SqlCommand com = new SqlCommand("update Complaint set Sotr = " + -2 + ", Level = 2 where id_complaint=" + -chatFunc.IDcomplaint + ";", con);
                SqlDataAdapter ad = new SqlDataAdapter(com);
                DataTable dt = new DataTable();
                ad.Fill(dt);
                DateTime dateTimeChat = DateTime.Now;
                com = new SqlCommand("insert into chat values (" + sqlCon.ID.ToString() + ", " + WhenChat.ToString() + ", '" + dateTimeChat.ToString() + "', 'Ваше обращение переведено на старшего сотрудника!', " + -chatFunc.IDcomplaint + ");", con);
                ad = new SqlDataAdapter(com);
                dt = new DataTable();
                ad.Fill(dt);
                btnSend.IsEnabled = false;
                BtnToHelp.IsEnabled = false;
                BtnToActive.IsEnabled = false;
                security.logsInsert("Заявка переведена на следующий уровень - " + -chatFunc.IDcomplaint);
            }
        }

        private void ClickToBackActive(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Вы подтверждаете выбор?\nДействие не обратимо.", "Закрыть обращение", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                SqlConnection con = new SqlConnection(sqlCon.ConString);
                DateTime dateTimeChat = DateTime.Now;
                SqlCommand com = new SqlCommand("update Complaint set Active = " + 0 + ", dateElimination = '" + dateTimeChat.ToString() + "' where id_complaint=" + -chatFunc.IDcomplaint + ";", con);
                SqlDataAdapter ad = new SqlDataAdapter(com);
                DataTable dt = new DataTable();
                ad.Fill(dt);
                
                com = new SqlCommand("insert into chat values (" + sqlCon.ID.ToString() + ", " + WhenChat.ToString() + ", '" + dateTimeChat.ToString() + "', 'Ваше обращение было закрыто!', " + -chatFunc.IDcomplaint + ");", con);
                ad = new SqlDataAdapter(com);
                dt = new DataTable();
                ad.Fill(dt);
                btnSend.IsEnabled = false;
                BtnToHelp.IsEnabled = false;
                BtnToActive.IsEnabled = false;
                security.logsInsert("Заявка закрыта - " + -chatFunc.IDcomplaint);
            }
        }

        private void LoadBD()
        {
            SqlConnection con = new SqlConnection(sqlCon.ConString);
            SqlCommand com = new SqlCommand(sqlCheckSum, con);
            SqlDataAdapter adapter = new SqlDataAdapter(com);
            DataTable dat = new DataTable();

            SqlDependency sd = new SqlDependency(com);
            sd.OnChange += new OnChangeEventHandler(ContackInfoChanged);
            SqlDependency.Start(sqlCon.ConString);
            adapter.Fill(dat);
            string test = dat.Rows[0].Field<string>("checkSum");
            if (checkSum != test)
            {
                checkSum = test;
                LoadBDAsync();
            }
        }

        private void ContackInfoChanged(object callar, SqlNotificationEventArgs e)
        {
            Dispatcher.Invoke(new RefreshData(LoadBD));
        }

        private void SendMessage(object sender, RoutedEventArgs e)
        {
            if (textSend.Text != "" && textSend.Text != " ")
            {
                DateTime dateTimeChat = DateTime.Now;
                SqlConnection con = new SqlConnection(sqlCon.ConString);
                SqlCommand com = new SqlCommand("insert into chat values ("+ sqlCon.ID.ToString() + ", " + WhenChat.ToString() + ", '"+ dateTimeChat.ToString() + "', '"+textSend.Text+"', "+ -chatFunc.IDcomplaint + ");", con);
                SqlDataAdapter adapter = new SqlDataAdapter(com);
                DataTable dat = new DataTable();
                adapter.Fill(dat);
                textSend.Text = "";
            }
            else
            {
                MessageBox.Show("Пустое сообщение", "Внимание", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            
        }

        private void ClickLeave(object sender, RoutedEventArgs e)
        {
            this.Cursor = Cursors.Arrow;
            (sender as Button).Background = new SolidColorBrush(Color.FromRgb(0, 113, 188));
            (sender as Button).Foreground = new SolidColorBrush(Colors.White);
        }

        private void ClickLeaveForm(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Menu.xaml", UriKind.Relative));
        }


        private void ClickMove(object sender, RoutedEventArgs e)
        {
            this.Cursor = Cursors.Hand;
            (sender as Button).Background = new SolidColorBrush(Colors.White);
            (sender as Button).Foreground = new SolidColorBrush(Color.FromRgb(0, 113, 188));
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


    }
}
