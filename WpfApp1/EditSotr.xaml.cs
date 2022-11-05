using System.Data;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для EditSotr.xaml
    /// </summary>
    public partial class EditSotr : Window
    {
        private string level;
        private string privil;
        private string post;
        private string ID;


        public EditSotr(int I)
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
                txPass.Content = "Пароль (укажите для изменения)";
            }
            else
            {
                up.Visibility = Visibility.Collapsed;
                BtnEdit.Visibility = Visibility.Collapsed;
                txPass.Content = "Пароль";
            }

        }

        private void textUpdate(object sender, RoutedEventArgs e)
        {
            if ((sender as TextBox).Text != "" && (sender as TextBox).Text != " ")
            {
                SqlConnection con = new SqlConnection(sqlCon.ConString);
                con.Open();
                SqlCommand com = new SqlCommand("select * from sotrEditChecked where Name like '" + (sender as TextBox).Text + "%' or Family like '" + (sender as TextBox).Text + "%' or login like '" + (sender as TextBox).Text + "%';", con);
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

                    if (read[5].ToString() == "1")
                    {
                        level = "1";
                        lv1.IsSelected = true;
                    }
                    else if (read[5].ToString() == "2")
                    {
                        level = "2";
                        lv2.IsSelected = true;
                    }
                    else
                    {
                        level = "3";
                        lv3.IsSelected = true;
                    }

                    if (read[6].ToString() == "1")
                    {
                        post = "1";
                        po1.IsSelected = true;
                    }
                    else if (read[6].ToString() == "2")
                    {
                        post = "2";
                        po2.IsSelected = true;
                    }
                    else if (read[6].ToString() == "3")
                    {
                        post = "3";
                        po3.IsSelected = true;
                    }
                    else
                    {
                        post = "5";
                        po5.IsSelected = true;
                    }

                    if (read[7].ToString() == "1")
                    {
                        privil = "1";
                        pr1.IsSelected = true;
                    }
                    else if (read[7].ToString() == "4")
                    {
                        privil = "4";
                        pr4.IsSelected = true;
                    }
                    else if (read[7].ToString() == "5")
                    {
                        privil = "5";
                        pr5.IsSelected = true;
                    }
                    else
                    {
                        privil = "6";
                        pr6.IsSelected = true;
                    }
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

            if (name.Text != "" && name.Text != " " && family.Text != "" && family.Text != " " && login.Text != "" && login.Text != " " && password.Text != "" && password.Text != " ")
            {
                if (MessageBox.Show("Вы подтверждаете добавление?", "Добавление сотрудника", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                {
                    SqlConnection con = new SqlConnection(sqlCon.ConString);
                    SqlCommand com = new SqlCommand("select * from sotrLoginChecked where login like '" + login.Text + "';", con);
                    SqlDataAdapter ad = new SqlDataAdapter(com);
                    DataTable dt = new DataTable();
                    ad.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        MessageBox.Show("Такой логин уже есть!");
                    }
                    else
                    {
                        com = new SqlCommand("insert into Sotr values ( " + post + ", " + privil + ", '" + family.Text + "', '" + name.Text + "', '" + MiddleName.Text + "', '" + login.Text + "', '" + security.getHash(password.Text) + "', " + level + ");", con);
                        ad = new SqlDataAdapter(com);
                        dt = new DataTable();
                        ad.Fill(dt);
                        security.logsInsert("Добавление сотрудника - " + name.Text + " " + family.Text);
                    }
                }
            }
            else
            {
                MessageBox.Show("Заполните поля!");
            }
                
        }

        private void selLevel(object sender, RoutedEventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            ComboBoxItem selectedItem = (ComboBoxItem)comboBox.SelectedItem;
            level = selectedItem.Content.ToString();
        }

        private void updateSotr(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Вы подтверждаете изменение?", "Изменение сотрудника", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                SqlConnection con = new SqlConnection(sqlCon.ConString);
                SqlCommand com = new SqlCommand("", con);
                if (password.Text == "" && password.Text == " ")
                {
                    com = new SqlCommand("update sotr set Post = " + post + ", Privilegies = " + privil + ", Family = '" + family.Text + "', Name = '" + name.Text + "', MiddleName = '" + MiddleName.Text + "', login = '" + login.Text + "', levelWork = " + level + " where id_sotr=" + ID + ";", con);
                }
                else
                {
                    com = new SqlCommand("update sotr set Post = " + post + ", Privilegies = " + privil + ", Family = '" + family.Text + "', Name = '" + name.Text + "', MiddleName = '" + MiddleName.Text + "', login = '" + login.Text + "', levelWork = " + level + ", password = '"+security.getHash(password.Text)+"' where id_sotr=" + ID + ";", con);
                }
                SqlDataAdapter ad = new SqlDataAdapter(com);
                DataTable dt = new DataTable();
                ad.Fill(dt);
                security.logsInsert("Изменение для сотрудника - " + ID);
            }
        }

        private void selPrivil(object sender, RoutedEventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            ComboBoxItem selectedItem = (ComboBoxItem)comboBox.SelectedItem;
            privil = selectedItem.Content.ToString().Split('-')[0];
        }

        private void selPost(object sender, RoutedEventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            ComboBoxItem selectedItem = (ComboBoxItem)comboBox.SelectedItem;
            post = selectedItem.Content.ToString().Split('-')[0];
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
