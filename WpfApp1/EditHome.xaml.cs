using System.Data.SqlClient;
using System.Data;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для EditHome.xaml
    /// </summary>
    public partial class EditHome : Window
    {
        public EditHome(int I)
        {
            InitializeComponent();
            BtnOut.Background = new SolidColorBrush(Color.FromRgb(0, 113, 188));
            BtnOut.Foreground = new SolidColorBrush(Colors.White);
            BtnOut.BorderBrush = new SolidColorBrush(Color.FromRgb(0, 113, 188));
            BtnEdit.Background = new SolidColorBrush(Color.FromRgb(0, 113, 188));
            BtnEdit.Foreground = new SolidColorBrush(Colors.White);
            BtnEdit.BorderBrush = new SolidColorBrush(Color.FromRgb(0, 113, 188));
            BtnNow.Background = new SolidColorBrush(Color.FromRgb(0, 113, 188));
            BtnNow.Foreground = new SolidColorBrush(Colors.White);
            BtnNow.BorderBrush = new SolidColorBrush(Color.FromRgb(0, 113, 188));
            b3.BorderBrush = new SolidColorBrush(Color.FromRgb(0, 113, 188));

            if (I == 1)
            {
                BtnNow.Visibility = Visibility.Collapsed;
                stackEdit.Visibility = Visibility.Collapsed;
            }
            else
            {
                up.Visibility = Visibility.Collapsed;
                BtnEdit.Visibility = Visibility.Collapsed;
            }
        }

        private string ID;

        private void textUpdate(object sender, RoutedEventArgs e)
        {
            if ((sender as TextBox).Text != "" && (sender as TextBox).Text != " ")
            {
                SqlConnection con = new SqlConnection(sqlCon.ConString);
                con.Open();
                SqlCommand com = new SqlCommand("select * from homeEditChecked where city like '%" + (sender as TextBox).Text + "%' or street like '%" + (sender as TextBox).Text + "%' or home like '%" + (sender as TextBox).Text + "%';", con);
                SqlDataReader read = com.ExecuteReader();
                if (read.Read())
                {
                    
                    stackEdit.Visibility = Visibility.Visible;
                    city.Text = read[1].ToString();
                    street.Text = read[2].ToString();
                    home.Text = read[3].ToString();
                    ID = read[0].ToString();
                }
                else
                {
                    stackEdit.Visibility = Visibility.Collapsed;
                }
            }
            else
            {
                stackEdit.Visibility = Visibility.Collapsed;
            }
        }

        private void nowSotr(object sender, RoutedEventArgs e)
        {

            if (city.Text != "" && city.Text != " " && street.Text != "" && street.Text != " " && home.Text != "" && home.Text != " ")
            {
                if (MessageBox.Show("Вы подтверждаете добавление?", "Добавление сотрудника", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                {
                    SqlConnection con = new SqlConnection(sqlCon.ConString);
                    SqlCommand com = new SqlCommand("insert into HomeLink values ('" + city.Text + "', '" + street.Text + "', '" + home.Text + "');", con);
                    SqlDataAdapter ad = new SqlDataAdapter(com);
                    DataTable dt = new DataTable();
                    ad.Fill(dt);
                    security.logsInsert("Добавление адреса - " + ID + " " + city.Text + " " + street.Text + " " + home.Text);
                }
            }
            else
            {
                MessageBox.Show("Заполните поля!");
            }

        }


        private void updateSotr(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Вы подтверждаете изменение?", "Изменение сотрудника", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                SqlConnection con = new SqlConnection(sqlCon.ConString);
                SqlCommand com = new SqlCommand("update HomeLink set city = '" + city.Text + "', street = '" + street.Text + "', home = '" + home.Text + "' where id_home=" + ID + ";", con);
                
                SqlDataAdapter ad = new SqlDataAdapter(com);
                DataTable dt = new DataTable();
                ad.Fill(dt);
                security.logsInsert("Изменение для адреса - " + ID + " " + city.Text + " " + street.Text + " " + home.Text);
            }
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
