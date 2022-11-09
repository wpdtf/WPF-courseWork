using System;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.IO;
using f = System.Windows.Forms;

namespace WpfApp1
{

    public partial class ChatTest : Page
    {
        private delegate void RefreshData();
        private string checkSum = "ghk";
        private string sqlChat;
        private static int WhenChat;
        private static string sqlCheckSum;


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
            btnSendImage.Background = new SolidColorBrush(Color.FromRgb(0, 113, 188));
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
                sqlCon.sqlServer("update Complaint set Sotr = " + -2 + ", Level = 2 where id_complaint=" + -chatFunc.IDcomplaint + ";");
                DateTime dateTimeChat = DateTime.Now;
                sqlCon.sqlServer("insert into chat values (" + sqlCon.ID.ToString() + ", " + WhenChat.ToString() + ", '" + dateTimeChat.ToString() + "', 'Ваше обращение переведено на старшего сотрудника!', " + -chatFunc.IDcomplaint + ", null);");
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
                DateTime dateTimeChat = DateTime.Now;
                sqlCon.sqlServer("update Complaint set Active = " + 0 + ", dateElimination = '" + dateTimeChat.ToString() + "' where id_complaint=" + -chatFunc.IDcomplaint + ";");
                sqlCon.sqlServer("insert into chat values (" + sqlCon.ID.ToString() + ", " + WhenChat.ToString() + ", '" + dateTimeChat.ToString() + "', 'Ваше обращение было закрыто!', " + -chatFunc.IDcomplaint + ", null);");
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
                CallBack();
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
                sqlCon.sqlServer("insert into chat values (" + sqlCon.ID.ToString() + ", " + WhenChat.ToString() + ", '" + dateTimeChat.ToString() + "', '" + textSend.Text + "', " + -chatFunc.IDcomplaint + ", NULL);");
                textSend.Text = "";
            }
            else
            {
                MessageBox.Show("Пустое сообщение", "Внимание", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            
        }

        private void SendImage(object sender, RoutedEventArgs e)
        {
            f.OpenFileDialog o = new f.OpenFileDialog();
            o.Filter = "Ваше изображение | *.png; *.jpg; *.jpeg;";
            if (o.ShowDialog() == f.DialogResult.OK)
            {
                BitmapImage bi = new BitmapImage();
                bi.BeginInit();
                bi.UriSource = new Uri(o.FileName, UriKind.Relative);
                bi.CacheOption = BitmapCacheOption.OnLoad;
                bi.EndInit();

                PngBitmapEncoder pe = new PngBitmapEncoder();
                MemoryStream ms = new MemoryStream();

                StringBuilder sb = new StringBuilder();

                pe.Frames.Add(BitmapFrame.Create(bi));
                pe.Save(ms);
                byte[] imgB = ms.ToArray();
                foreach (byte b in imgB)
                {
                    sb.Append(b).Append(';');
                }
                sb.Remove(sb.Length - 1, 1);
                DateTime dateTimeChat = DateTime.Now;
                sqlCon.sqlServer("insert into chat values (" + sqlCon.ID.ToString() + ", " + WhenChat.ToString() + ", '" + dateTimeChat.ToString() + "', 'IMAGESSEND', " + -chatFunc.IDcomplaint + ", '"+ sb.ToString() + "');");
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

        public static Border whatBords()
        {
            //Создает кнопку
            Border bd = new Border();
            bd.CornerRadius = new CornerRadius(10, 10, 5, 5);
            bd.BorderBrush = new SolidColorBrush(Color.FromRgb(0, 113, 188));
            bd.BorderThickness = new Thickness(2);
            bd.Padding = new Thickness(5);
            bd.Margin = new Thickness(3);
            bd.Width = 200;

            return bd;
        }

        private Button buttonOpen()
        {
            //Создает кнопку
            Button bt = new Button();
            bt.Content = "увеличить";
            bt.Height = Double.NaN;
            bt.Margin = new Thickness(2, 4, 2, 2);
            bt.Background = new SolidColorBrush(Color.FromRgb(255, 255, 255));
            bt.Click += (s, e) => imageOpen(s, e);

            return bt;
        }

        
        private void CallBack()
        {
            //очищает чат
            while (chats.Children.Count > 0)
                chats.Children.RemoveAt(0);
            SqlConnection con = new SqlConnection(sqlCon.ConString);
            con.Open();
            SqlCommand com = new SqlCommand(sqlChat, con);
            SqlDataReader read = com.ExecuteReader();
            while (read.Read())
            {
                Border bd = whatBords();
                StackPanel pn = new StackPanel();
                string hours = read[3].ToString();
                string minute = read[4].ToString();
                if (hours.Length == 1)
                    hours = "0" + hours;
                if (minute.Length == 1)
                    minute = "0" + minute;

                if (read[5].ToString() == sqlCon.ID.ToString())
                {
                    bd.HorizontalAlignment = HorizontalAlignment.Right;
                    if (read[2].ToString()== "IMAGESSEND")
                    {
                        //Создает блок картинки
                        Image imageBl = new Image();
                        imageBl.Width = 200;
                        string ImageS = read[9].ToString();
                        byte[] imageByte = ImageS.Split(';').Select(a => byte.Parse(a)).ToArray();
                        MemoryStream ms = new MemoryStream(imageByte);
                        imageBl.Source = BitmapFrame.Create(ms, BitmapCreateOptions.None, BitmapCacheOption.OnLoad);

                        TextBlock textTitle = new TextBlock();
                        textTitle.FontSize = 10;
                        textTitle.TextAlignment = TextAlignment.Right;
                        textTitle.Text = "вы " + hours+":"+minute;

                        Button bt = buttonOpen();
                        bt.Name = "id" + read[10];

                        pn.Children.Add(imageBl);
                        pn.Children.Add(bt);
                        pn.Children.Add(textTitle);
                        bd.Child = pn;
                        chats.Children.Add(bd);
                    }
                    else
                    {
                        TextBlock textBl = new TextBlock();
                        textBl.Text = read[2].ToString();
                        textBl.TextWrapping = TextWrapping.Wrap;


                        TextBlock textTitle = new TextBlock();
                        textTitle.FontSize = 10;
                        textTitle.TextAlignment = TextAlignment.Right;
                        textTitle.Text = "вы " + hours + ":" + minute;

                        pn.Children.Add(textBl);
                        pn.Children.Add(textTitle);
                        bd.Child = pn;
                        chats.Children.Add(bd);
                    }
                }
                else
                {
                    bd.HorizontalAlignment = HorizontalAlignment.Left;
                    if (read[2].ToString() == "IMAGESSEND")
                    {
                        //Создает блок картинки
                        Image imageBl = new Image();
                        imageBl.Width = 200;
                        string ImageS = read[9].ToString();
                        byte[] imageByte = ImageS.Split(';').Select(a => byte.Parse(a)).ToArray();
                        MemoryStream ms = new MemoryStream(imageByte);
                        imageBl.Source = BitmapFrame.Create(ms, BitmapCreateOptions.None, BitmapCacheOption.OnLoad);



                        TextBlock textTitle = new TextBlock();
                        textTitle.FontSize = 10;
                        textTitle.TextAlignment = TextAlignment.Left;
                        textTitle.Text = read[0] + " " + read[1] + " " + hours + ":" + minute;

                        Button bt = buttonOpen();
                        bt.Name = "id" + read[10];

                        pn.Children.Add(imageBl);
                        pn.Children.Add(bt);
                        pn.Children.Add(textTitle);
                        bd.Child = pn;
                        chats.Children.Add(bd);
                    }
                    else
                    {
                        TextBlock textBl = new TextBlock();
                        textBl.Text = read[2].ToString();
                        textBl.TextWrapping = TextWrapping.Wrap;


                        TextBlock textTitle = new TextBlock();
                        textTitle.FontSize = 10;
                        textBl.TextAlignment = TextAlignment.Right;
                        textTitle.TextAlignment = TextAlignment.Left;
                        textTitle.Text = read[0] + " " + read[1] + " " + hours + ":" + minute;

                        pn.Children.Add(textBl);
                        pn.Children.Add(textTitle);
                        bd.Child = pn;
                        chats.Children.Add(bd);
                    }
                }

            }
            scrolling.ScrollToEnd();
            read.Close();
        }
        private void imageOpen(object sender, EventArgs e)
        {
            //Открывает форму с картинкой
            Window imagesWindow = new imageOpens((sender as Button).Name);
            imagesWindow.Show();
        }
    }
}
