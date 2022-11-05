using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Navigation;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Toolkit.Uwp.Notifications;


namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для Menu.xaml
    /// </summary>
    /// 

    public partial class Menu : Page
    {
        private string sheckSum = "exec checkSumCompplaint "+sqlCon.levelWork+ ", " + sqlCon.ID + ", 1;";
        private delegate void RefreshData();
        private string checkSumT = "";
        private string checkSumV = "";
        private int colV = 0;
        private SqlCommand _cm;
        private delegate void DataBind(string TextChat, string TextId, int StackWhat);
        private delegate void UpdateBind();
        private int UpdateMessage =0;
        private bool SqlDepen = true;

        public Menu()
        {
            InitializeComponent();
            users.Content = sqlCon.Family + " " + sqlCon.Name;
            posts.Content = sqlCon.Post;
            BtnOut.Background = new SolidColorBrush(Color.FromRgb(0, 113, 188));
            BtnOut.Foreground = new SolidColorBrush(Colors.White);
            BtnOut.BorderBrush = new SolidColorBrush(Color.FromRgb(0, 113, 188));
            BtnHistory.Background = new SolidColorBrush(Color.FromRgb(0, 113, 188));
            BtnHistory.Foreground = new SolidColorBrush(Colors.White);
            BtnHistory.BorderBrush = new SolidColorBrush(Color.FromRgb(0, 113, 188));
            BtnHome.Background = new SolidColorBrush(Color.FromRgb(0, 113, 188));
            BtnHome.Foreground = new SolidColorBrush(Colors.White);
            BtnHome.BorderBrush = new SolidColorBrush(Color.FromRgb(0, 113, 188));

            BtnRate.Background = new SolidColorBrush(Color.FromRgb(0, 113, 188));
            BtnRate.Foreground = new SolidColorBrush(Colors.White);
            BtnRate.BorderBrush = new SolidColorBrush(Color.FromRgb(0, 113, 188));
            BtnSotr.Background = new SolidColorBrush(Color.FromRgb(0, 113, 188));
            BtnSotr.Foreground = new SolidColorBrush(Colors.White);
            BtnSotr.BorderBrush = new SolidColorBrush(Color.FromRgb(0, 113, 188));
            BtnLogi.Background = new SolidColorBrush(Color.FromRgb(0, 113, 188));
            BtnLogi.Foreground = new SolidColorBrush(Colors.White);
            BtnLogi.BorderBrush = new SolidColorBrush(Color.FromRgb(0, 113, 188));
            BtnClient.Background = new SolidColorBrush(Color.FromRgb(0, 113, 188));
            BtnClient.Foreground = new SolidColorBrush(Colors.White);
            BtnClient.BorderBrush = new SolidColorBrush(Color.FromRgb(0, 113, 188));

            if (sqlCon.levelPrivil == 4)
            {
                BtnHome.Visibility = Visibility.Collapsed;
                BtnRate.Visibility = Visibility.Collapsed;
                BtnSotr.Visibility = Visibility.Collapsed;
                BtnLogi.Visibility = Visibility.Collapsed;
                BtnClient.Visibility = Visibility.Collapsed;
                updateBD();
            }
            else if (sqlCon.levelPrivil == 5)
            {
                BtnRate.Visibility = Visibility.Collapsed;
                BtnSotr.Visibility = Visibility.Collapsed;
                BtnLogi.Visibility = Visibility.Collapsed;
                updateBD();
            }
            else if (sqlCon.levelPrivil == 6)
            {
                BtnHome.Visibility = Visibility.Collapsed;
                BtnSotr.Visibility = Visibility.Collapsed;
                BtnLogi.Visibility = Visibility.Collapsed;
                updateBD();
            }
            else if (sqlCon.levelPrivil == 1)
            {
                sl1.Visibility = Visibility.Collapsed;
                sl2.Visibility = Visibility.Collapsed;
            }

            b1.BorderBrush = new SolidColorBrush(Color.FromRgb(0, 113, 188));
            b2.BorderBrush = new SolidColorBrush(Color.FromRgb(0, 113, 188));
            b3.BorderBrush = new SolidColorBrush(Color.FromRgb(0, 113, 188));
        }

        private void updateBD() 
        {
            if (SqlDepen)
            {
                SqlConnection con = new SqlConnection(sqlCon.ConString);
                SqlCommand com = new SqlCommand(sheckSum, con);
                SqlDataAdapter ad = new SqlDataAdapter(com);

                SqlDependency dep = new SqlDependency(com);
                dep.OnChange += new OnChangeEventHandler(ContackInfoChanged);
                SqlDependency.Start(sqlCon.ConString);

                DataTable dt = new DataTable();
                ad.Fill(dt);
                try
                {
                    string[] resultsql = dt.Rows[0].Field<string>("checkSum").Split(new char[] { '|' });
                }
                catch
                {
                    MessageBox.Show(dt.Rows[0].Field<string>("checkSum"));
                }
                finally
                {
                    UpdateMessage += 1;
                    string[] resultsql = dt.Rows[0].Field<string>("checkSum").Split(new char[] { '|' });
                    if (checkSumV != resultsql[0])
                    {

                        checkSumV = resultsql[0];
                        while (StackBoxV.Children.Count > 0)
                            StackBoxV.Children.RemoveAt(0);
                        LoadBDAsync("select * from complaintChecked where Sotr = -" + sqlCon.levelWork + ";");
                    }
                    else if (checkSumT != resultsql[1])
                    {
                        checkSumT = resultsql[1];
                        while (StackBoxT.Children.Count > 0)
                        {
                            StackBoxT.Children.RemoveAt(0);
                        }
                        LoadBDAsync("select * from complaintChecked where Sotr = " + sqlCon.ID + ";");
                    }
                }
            }
            
            
        }

        private void ContackInfoChanged(object callar, SqlNotificationEventArgs e)
        {
            Dispatcher.Invoke(new RefreshData(updateBD));
        }

        private void sotrChecked(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/SotrChecked.xaml", UriKind.Relative));
        }

        private void historyCheched(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/History.xaml", UriKind.Relative));
        }

        private void clientChecked(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/clientChecked.xaml", UriKind.Relative));
        }

        private void logsChecked(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Logs.xaml", UriKind.Relative));
        }

        private void homeCheched(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/homeLink.xaml", UriKind.Relative));
        }

        private void rateCheched(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Rate.xaml", UriKind.Relative));
        }

        private void LoadBDAsync(string sqlChat)
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
            string TextId = "";
            int What = 0;

            if (read.HasRows)
            {
                while (read.Read())
                {
                    if (Convert.ToInt32(read[1]) > 0)
                    {
                        TextChat = "Текущая заявка - "+ read.GetValue(0) + "\nИмя клиента - " + read.GetValue(4) + " " + read.GetValue(5) + "\n\nТекст заявки - " + read.GetValue(3) + "\n\nДата обращения - " + read.GetValue(2);

                        TextId = "текущая_" + read.GetValue(0);
                        What = 1;
                    }
                    else
                    {
                        TextChat = "Свободная заявка - " + read.GetValue(0) + "\nИмя клиента - " + read.GetValue(4) + " " + read.GetValue(5) + "\n\nТекст заявки - " + read.GetValue(3) + "\n\nДата обращения - " + read.GetValue(2);
                        TextId = "возможная_" + read.GetValue(0);
                        What = 2;
                    }
                    Dispatcher.Invoke(new DataBind(DataBindProc), TextChat, TextId, What);

                }
            }
            if (What == 2)
                Dispatcher.Invoke(new UpdateBind(UpdateBox));
                    

            read.Close();
        }

        private void DataBindProc(string TextChat, string TextId, int StackWhat)
        {
            TextBox btn = FuncBtnAdd(TextId, TextChat);
            btn.MouseDoubleClick += (s, e) => complaintTek(s, e);
            btn.MouseEnter += (s, e) => EnterBtn(s, e);
            btn.MouseLeave += (s, e) => LeaveBtn(s, e);
            if (StackWhat == 1)
            {
                btn.ToolTip = "Двойной клик для принятия заявки";
                StackBoxT.Children.Add(btn);
                colV = StackBoxV.Children.Count;
            }
            else if (StackWhat == 2)
            {
                btn.ToolTip = "Двойной клик откроект чат с пользователем";
                StackBoxV.Children.Add(btn);
            }
            
        }

        private void UpdateBox()
        {
            if (UpdateMessage > 1) 
                if (colV < StackBoxV.Children.Count)
                {
                    colV = StackBoxV.Children.Count;
                    new ToastContentBuilder()
                 .AddText("Новая заявка!")
                 .Show();
                } 
        }


        private static TextBox FuncBtnAdd(string id, string text)
        {
            TextBox btn = new TextBox();
            btn.Text = text;
            btn.Name = id;
            btn.Margin = new Thickness(5);
            btn.Width = Double.NaN;
            btn.Height = Double.NaN;
            btn.Padding = new Thickness(10);
            btn.FontSize = 15;
            btn.TextWrapping = TextWrapping.Wrap;
            btn.AcceptsReturn = true;
            btn.IsReadOnly = true;
            btn.TextAlignment = TextAlignment.Left;
            //btn.Background =  new SolidColorBrush(Colors.White);
            //btn.Foreground = new SolidColorBrush(Colors.Black);
            btn.BorderThickness = new Thickness(3);
            //btn.BorderBrush = new SolidColorBrush(Color.FromRgb(0, 113, 188));

            btn.Background = new SolidColorBrush(Color.FromRgb(0, 113, 188));
            btn.Foreground = new SolidColorBrush(Colors.White);
            btn.BorderBrush = new SolidColorBrush(Color.FromRgb(0, 113, 188));

            return btn;
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

        private void ClickLeaveForm(object sender, RoutedEventArgs e)
        {
            SqlDepen = false;
            NavigationService.Navigate(new Uri("/Authorization.xaml", UriKind.Relative));
        }

        private void complaintTek(object sender, RoutedEventArgs e)
        {
            if ((sender as TextBox).Name.IndexOf("текущая_")>-1)
            {
                string[] masId = (sender as TextBox).Name.Split(new char[] { '_' }); ;
                string textId = masId[1];
                chatFunc.IDcomplaint = 0-Convert.ToInt32(textId);
                SqlDepen = false;
                NavigationService.Navigate(new Uri("/ChatTest.xaml", UriKind.Relative));
            } 
            else
            {
                if (MessageBox.Show("Вы подтверждаете выбор заявки?\nОтказаться от выполнения заявки нельзя.", "Ответ на заявку", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                {
                    string[] masId = (sender as TextBox).Name.Split(new char[] { '_' }); ;
                    string textId = masId[1];
                    SqlConnection con = new SqlConnection(sqlCon.ConString);
                    SqlCommand com = new SqlCommand("update Complaint set Sotr = " + sqlCon.ID + " where id_complaint=" + textId+ ";", con);
                    SqlDataAdapter ad = new SqlDataAdapter(com);
                    DataTable dt = new DataTable();
                    ad.Fill(dt);
                }    
            }
        }

        private void LeaveBtn(object sender, RoutedEventArgs e)
        {
            this.Cursor = Cursors.Arrow;
        }

        private void EnterBtn(object sender, RoutedEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }


    }
}
