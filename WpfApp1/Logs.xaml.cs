using System;
using System.Data.SqlClient;
using System.Data;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Navigation;

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
                    ThreadStart writeSecon = new ThreadStart(dtUpdate);
                    Thread thread = new Thread(writeSecon);
                    thread.Start();
                }
            }
        }

        private void dtUpdate()
        {
            SqlConnection con = new SqlConnection(sqlCon.ConString);
            SqlCommand com = new SqlCommand("select * from logsChecked;", con);
            SqlDataAdapter ad = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            ad.Fill(dt);
            this.Dispatcher.Invoke(() => {
                dataGrids.ItemsSource = null;
                dataGrids.ItemsSource = dt.DefaultView;
            });
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
