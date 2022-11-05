using System.Data.SqlClient;
using System.Data;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для EditRate.xaml
    /// </summary>
    public partial class EditRate : Window
    {
        public EditRate(int I)
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
                SqlCommand com = new SqlCommand("select * from rateEditChecked where name like '%" + (sender as TextBox).Text + "%' or discription like '%" + (sender as TextBox).Text + "%';", con);
                SqlDataReader read = com.ExecuteReader();
                if (read.Read())
                {

                    stackEdit.Visibility = Visibility.Visible;
                    name.Text = read[1].ToString();
                    discription.Text = read[2].ToString();
                    price.Text = read[3].ToString();
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

            if (name.Text != "" && name.Text != " " && discription.Text != "" && discription.Text != " " && price.Text != "" && price.Text != " ")
            {
                if (MessageBox.Show("Вы подтверждаете добавление?", "Добавление тарифа", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                {
                    SqlConnection con = new SqlConnection(sqlCon.ConString);
                    SqlCommand com = new SqlCommand("insert into rate values ('" + name.Text + "', '" + discription.Text + "', '" + price.Text + "');", con);
                    SqlDataAdapter ad = new SqlDataAdapter(com);
                    DataTable dt = new DataTable();
                    ad.Fill(dt);
                    security.logsInsert("Добавление тарифа - " + ID + " " + name.Text + " " + discription.Text + " " + price.Text);
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
                SqlCommand com = new SqlCommand("update rate set name = '" + name.Text + "', discription = '" + discription.Text + "', price = " + price.Text + " where id_rate=" + ID + ";", con);

                SqlDataAdapter ad = new SqlDataAdapter(com);
                DataTable dt = new DataTable();
                ad.Fill(dt);
                security.logsInsert("Изменение для тарифа - " + ID + " " + name.Text + " " + discription.Text + " " + price.Text);
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
