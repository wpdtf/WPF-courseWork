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
    /// <summary>
    /// Логика взаимодействия для Authorization.xaml
    /// </summary>
    public partial class Authorization : Page
    {
        public Authorization()
        {
            InitializeComponent();
            ButtonAut.Background = new SolidColorBrush(Color.FromRgb(0, 113, 188));
            ButtonAut.Foreground = new SolidColorBrush(Colors.White);
            ButtonAut.BorderBrush = new SolidColorBrush(Color.FromRgb(0, 113, 188));
            ln1.Stroke = new SolidColorBrush(Color.FromRgb(0, 113, 188));

        }

        private void ClickClick(object sender, RoutedEventArgs e)
        {

                Errors.Visibility = Visibility.Hidden;
            if (Logins.Text != "" && Password.Password != "" && Logins.Text != " " && Password.Password != " ")
            {
                try
                {
                    DataTable dat = sqlCon.sqlServer("select * from sotrAuthorChecked where login = '" + Logins.Text + "' and password = '" + security.getHash(Password.Password) + "';");
                    if (dat.Rows.Count != 0)
                    {
                        sqlCon.ID = dat.Rows[0].Field<Int32>("id_sotr");
                        sqlCon.Family = dat.Rows[0].Field<string>("Family");
                        sqlCon.Name = dat.Rows[0].Field<string>("Name");
                        sqlCon.Post = dat.Rows[0].Field<string>("PostName");
                        sqlCon.levelWork = dat.Rows[0].Field<int>("levelWork");
                        sqlCon.levelPrivil = dat.Rows[0].Field<int>("Privilegies");

                        security.logsInsert("Авторизация");

                        NavigationService.Navigate(new Uri("/Menu.xaml", UriKind.Relative));
                    }
                    else
                    {
                        Errors.Visibility = Visibility.Visible;
                        Errors.Text = "Не верный логин/пароль";
                        Password.Password = "";
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка подключения"+ex);
                }
            }
            else
            {
                Errors.Visibility = Visibility.Visible;
                Errors.Text = "Заполните поля";
                Logins.Text = "";
                Password.Password = "";
            } 
        }

        private void ClickMove(object sender, RoutedEventArgs e)
        {
            this.Cursor = Cursors.Hand;
            (sender as Button).Background = new SolidColorBrush(Colors.White);
            (sender as Button).Foreground = new SolidColorBrush(Color.FromRgb(0, 113, 188));
        }

        private void ClickLeave(object sender, RoutedEventArgs e)
        {
            this.Cursor = Cursors.Arrow;
            (sender as Button).Background = new SolidColorBrush(Color.FromRgb(0, 113, 188));
            (sender as Button).Foreground = new SolidColorBrush(Colors.White);
        }

    }
}
