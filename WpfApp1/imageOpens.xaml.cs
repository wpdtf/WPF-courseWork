using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Data;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.IO;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для imageOpens.xaml
    /// </summary>
    public partial class imageOpens : Window
    {
        public imageOpens(string I)
        {
            InitializeComponent();
            DataTable dat = sqlCon.sqlServer("select * from chat where id_message = "+ I.Substring(2) + ";");
            string test = dat.Rows[0].Field<string>("image");
            byte[] imageByte = test.Split(';').Select(a => byte.Parse(a)).ToArray();
            MemoryStream ms = new MemoryStream(imageByte);
            Images.Source = BitmapFrame.Create(ms, BitmapCreateOptions.None, BitmapCacheOption.OnLoad);
        }
    }
}
