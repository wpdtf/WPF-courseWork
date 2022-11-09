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
using System.IO;

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
            CallBack();
        }

        private Border whatBords()
        {
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
                    if (read[2].ToString() == "IMAGESSEND")
                    {
                        Image imageBl = new Image();
                        imageBl.Width = 200;
                        string ImageS = read[9].ToString();
                        byte[] imageByte = ImageS.Split(';').Select(a => byte.Parse(a)).ToArray();
                        MemoryStream ms = new MemoryStream(imageByte);
                        imageBl.Source = BitmapFrame.Create(ms, BitmapCreateOptions.None, BitmapCacheOption.OnLoad);

                        TextBlock textTitle = new TextBlock();
                        textTitle.FontSize = 10;
                        textTitle.TextAlignment = TextAlignment.Right;
                        textTitle.Text = "вы " + hours + ":" + minute;

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
            Window imagesWindow = new imageOpens((sender as Button).Name);
            imagesWindow.Show();
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
