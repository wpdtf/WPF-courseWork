using System.Data.SqlClient;
using System.Data;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;


namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для editClient.xaml
    /// </summary>
    public partial class editClient : Window
    {
        private string ID;

        private string id_rate;
        private string id_home;

        public editClient()
        {
            InitializeComponent();
            BtnOut.Background = new SolidColorBrush(Color.FromRgb(0, 113, 188));
            BtnOut.Foreground = new SolidColorBrush(Colors.White);
            BtnOut.BorderBrush = new SolidColorBrush(Color.FromRgb(0, 113, 188));
            BtnEdit.Background = new SolidColorBrush(Color.FromRgb(0, 113, 188));
            BtnEdit.Foreground = new SolidColorBrush(Colors.White);
            BtnEdit.BorderBrush = new SolidColorBrush(Color.FromRgb(0, 113, 188));
            b3.BorderBrush = new SolidColorBrush(Color.FromRgb(0, 113, 188));
            stackEdit.Visibility = Visibility.Collapsed;
            if (sqlCon.levelWork == 3)
            {
                city.Visibility = Visibility.Collapsed;
            }

        }

        private void UpdateComboRate(string i)
        {
            comboRate.Items.Clear();
            SqlConnection con = new SqlConnection(sqlCon.ConString);
            con.Open();
            SqlCommand com = new SqlCommand("select * from rate;", con);
            SqlDataReader read = com.ExecuteReader();
            while (read.Read())
            {
                ComboBoxItem it = new ComboBoxItem();
                it.Name = "rat_" + read[0];
                it.Content = read[1];
                it.FontFamily = new FontFamily("/source/bold.otf");

                if (read[0].ToString() == i)
                    it.IsSelected = true;

                comboRate.Items.Add(it);
            }
            con.Close();
        }

        private void UpdateComboCity(string i)
        {
            comboCity.Items.Clear();
            SqlConnection con = new SqlConnection(sqlCon.ConString);
            con.Open();
            SqlCommand com = new SqlCommand("select * from HomeLink;", con);
            SqlDataReader read = com.ExecuteReader();
            while (read.Read())
            {
                ComboBoxItem it = new ComboBoxItem();
                it.Name = "cit_" + read[0];
                it.Content = read[1]+", "+ read[2] + ", "+ read[3];
                it.FontFamily = new FontFamily("/source/bold.otf");

                if (read[0].ToString() == i)
                    it.IsSelected = true;

                comboCity.Items.Add(it);
            }
            con.Close();
        }

        private void textUpdate(object sender, RoutedEventArgs e)
        {
            if ((sender as TextBox).Text != "" && (sender as TextBox).Text != " ")
            {
                SqlConnection con = new SqlConnection(sqlCon.ConString);
                con.Open();
                SqlCommand com = new SqlCommand("select * from clientEditChecked where Name like '" + (sender as TextBox).Text + "%' or Family like '" + (sender as TextBox).Text + "%' or login like '" + (sender as TextBox).Text + "%';", con);
                SqlDataReader read = com.ExecuteReader();
                if (read.Read())
                {
                    password.Text = "";
                    stackEdit.Visibility = Visibility.Visible;
                    name.Text = read[2].ToString();
                    family.Text = read[3].ToString();
                    MiddleName.Text = read[4].ToString();
                    ID = read[0].ToString();

                    login.Text = read[1].ToString();

                    UpdateComboRate(read[5].ToString());
                    UpdateComboCity(read[6].ToString());
                }
                else
                {
                    stackEdit.Visibility = Visibility.Collapsed;
                }
                con.Close();
            }
            else
            {
                stackEdit.Visibility = Visibility.Collapsed;
            }
        }



        private void updateSotr(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Вы подтверждаете изменение?", "Изменение клиента", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {

                ComboBox comboBox1 = comboRate;
                ComboBoxItem selectedItem1 = (ComboBoxItem)comboBox1.SelectedItem;
                id_rate = selectedItem1.Name.ToString().Split('_')[1];


                ComboBox comboBox2 = comboCity;
                ComboBoxItem selectedItem2 = (ComboBoxItem)comboBox2.SelectedItem;
                id_home = selectedItem2.Name.ToString().Split('_')[1];

                if (password.Text == "" && password.Text == " ")
                {
                    sqlCon.sqlServer("update Client set Family = '" + family.Text + "', Name = '" + name.Text + "', MiddleName = '" + MiddleName.Text + "', login = '" + login.Text + "', password='" + security.getHash(password.Text) + "', rate = " + id_rate + ", home = " + id_home + " where id_client=" + ID + ";");
                }
                else
                {
                    sqlCon.sqlServer("update Client set Family = '" + family.Text + "', Name = '" + name.Text + "', MiddleName = '" + MiddleName.Text + "', login = '" + login.Text + "', rate = " + id_rate + ", home = " + id_home + " where id_client=" + ID + ";");
                }
                security.logsInsert("Изменение для клиента - " + ID);
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
