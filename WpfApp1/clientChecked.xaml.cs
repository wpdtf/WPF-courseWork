using System;
using System.Data.SqlClient;
using System.Data;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Navigation;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для clientChecked.xaml
    /// </summary>
    public partial class clientChecked : Page
    {
        private delegate void RefreshData();
        private bool SqlDepen = true;
        private string sheckSum = "exec checkSumClient;";
        private string checkSumBD = "";

        public clientChecked()
        {
            InitializeComponent();
            bdChecked();
            users.Content = sqlCon.Family + " " + sqlCon.Name;
            posts.Content = sqlCon.Post;
            b3.BorderBrush = new SolidColorBrush(Color.FromRgb(0, 113, 188));
            b2.BorderBrush = new SolidColorBrush(Color.FromRgb(0, 113, 188));

            BtnOut.Background = new SolidColorBrush(Color.FromRgb(0, 113, 188));
            BtnOut.Foreground = new SolidColorBrush(Colors.White);
            BtnOut.BorderBrush = new SolidColorBrush(Color.FromRgb(0, 113, 188));
            BtnEdit.Background = new SolidColorBrush(Color.FromRgb(0, 113, 188));
            BtnEdit.Foreground = new SolidColorBrush(Colors.White);
            BtnEdit.BorderBrush = new SolidColorBrush(Color.FromRgb(0, 113, 188));
            dataGrids.VerticalGridLinesBrush = new SolidColorBrush(Color.FromRgb(0, 113, 188));
            dataGrids.HorizontalGridLinesBrush = new SolidColorBrush(Color.FromRgb(0, 113, 188));
        }

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
                    dataGrids.ItemsSource = null;
                    com = new SqlCommand("exec viewClient;", con);
                    ad = new SqlDataAdapter(com);
                    dt = new DataTable();
                    ad.Fill(dt);
                    dataGrids.ItemsSource = dt.DefaultView;
                }
            }
        }


        private void ContackInfoChanged(object callar, SqlNotificationEventArgs e)
        {
            Dispatcher.Invoke(new RefreshData(bdChecked));
        }

        private void ClickBack(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Menu.xaml", UriKind.Relative));
        }

        private void deleteClick(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Вы подтверждаете удаление?", "Удаление клиента", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                DataRowView row = (DataRowView)dataGrids.SelectedItems[0];
                string ID = row["ID"].ToString();
                SqlConnection con = new SqlConnection(sqlCon.ConString);
                SqlCommand com = new SqlCommand("delete from Client where id_client = " + ID + ";", con);
                SqlDataAdapter ad = new SqlDataAdapter(com);
                DataTable dt = new DataTable();
                ad.Fill(dt);
                security.logsInsert("Удаление клиента - " + ID);
            }
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

        private void ViewEdit(object sender, RoutedEventArgs e)
        {
            Window edit = new editClient();
            edit.Show();
        }
    }
}
