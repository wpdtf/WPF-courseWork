using System;
using System.Data.SqlClient;
using System.Data;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Navigation;
using Windows.Devices.Sensors;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для Logs.xaml
    /// </summary>
    public partial class Logs : Page
    {
        public Logs()
        {
            InitializeComponent();

            bdChecked();
            users.Content = sqlCon.Family + " " + sqlCon.Name;
            posts.Content = sqlCon.Post;
            b3.BorderBrush = new SolidColorBrush(Color.FromRgb(0, 113, 188));

            BtnOut.Background = new SolidColorBrush(Color.FromRgb(0, 113, 188));
            BtnOut.Foreground = new SolidColorBrush(Colors.White);
            BtnOut.BorderBrush = new SolidColorBrush(Color.FromRgb(0, 113, 188));
            dataGrids.VerticalGridLinesBrush = new SolidColorBrush(Color.FromRgb(0, 113, 188));
            dataGrids.HorizontalGridLinesBrush = new SolidColorBrush(Color.FromRgb(0, 113, 188));
        }

        private delegate void RefreshData();
        private bool SqlDepen = true;
        private string sheckSum = "exec checkSumLogs;";
        private string checkSumBD = "";

        private string auth = " ";
        private string update = " ";
        private string now = " ";
        private string delete = " ";

        private void bdChecked()
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

                string resultsql = dt.Rows[0].Field<string>("checkSum");

                if (checkSumBD != resultsql)
                {
                    checkSumBD = resultsql;
                    Thread writeSecon = new Thread(dtUpdate);
                    writeSecon.Start();
                }
            }
        }

        private void dtUpdate()
        {
            DataTable dt = sqlCon.sqlServer("select * from logsChecked where id_logs>0 " + auth+" " + update + " " + now + " "+delete+";");
            this.Dispatcher.Invoke(() => {
                dataGrids.ItemsSource = null;
                dataGrids.ItemsSource = dt.DefaultView;
            });
        }

        private void checkDls(object sender, EventArgs e)
        {
            if ((sender as CheckBox).Name == "avtoris")
                auth = "and [Выполненое действие] not like 'Авторизация' ";
            if ((sender as CheckBox).Name == "editDls")
                update = "and [Выполненое действие] not like 'Изменение%' ";
            if ((sender as CheckBox).Name == "nowDls")
                now = "and [Выполненое действие] not like 'Добавление%' ";
            if ((sender as CheckBox).Name == "deleteDls")
                delete = "and [Выполненое действие] not like 'Удаление%' ";
            Thread writeSecon = new Thread(dtUpdate);
            writeSecon.Start();
        }

        private void checkSDls(object sender, EventArgs e)
        {
            if ((sender as CheckBox).Name == "avtoris")
                auth = " ";
            if ((sender as CheckBox).Name == "editDls")
                update = " ";
            if ((sender as CheckBox).Name == "nowDls")
                now = " ";
            if ((sender as CheckBox).Name == "deleteDls")
                delete = " ";
            Thread writeSecon = new Thread(dtUpdate);
            writeSecon.Start();
        }

        private void ContackInfoChanged(object callar, SqlNotificationEventArgs e)
        {
            Dispatcher.Invoke(new RefreshData(bdChecked));
        }

        private void ClickBack(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Menu.xaml", UriKind.Relative));
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
