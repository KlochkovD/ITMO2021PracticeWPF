using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Lab1._2_WpfHello_
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window

    {
        public MyWindow myWin { get; set; }

        bool isDataDirty = false;
        public MainWindow()

        {
            InitializeComponent();
            lbl.Content = "Добрый день!";
            setBut.IsEnabled = false;
            retBut.IsEnabled = false;
            bool isDataDirty = false;
            


        }

        private void setBut_Click(object sender, RoutedEventArgs e)
        {
            System.IO.StreamWriter sw = null;
            bool isDataDirty = false;
            try
            {
                sw = new System.IO.StreamWriter("username.txt");
                sw.WriteLine(setText.Text);
                retBut.IsEnabled = true;
                isDataDirty = false;



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (sw != null)
                    sw.Close();

            }
        }

        private void retBut_Click(object sender, RoutedEventArgs e)
        {
            System.IO.StreamReader sr = null;

            try
            {
                using (sr = new System.IO.StreamReader("username.txt"))
                    retLabel.Content = "Приветствую Вас, уважаемый " + sr.ReadToEnd();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (sr != null)
                    sr.Close();
            }

        }


        private void setText_TextChanged(object sender, TextChangedEventArgs e)
        {
            setBut.IsEnabled = true;
            isDataDirty = true;



        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {

            if (this.isDataDirty)
            {
                string msg = "Данные были изменены, но не сохранены!\n Закрыть окно без сохранения ? ";

                MessageBoxResult result = MessageBox.Show(msg, "Контроль данных", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                if (result == MessageBoxResult.No)
                {
                    e.Cancel = true;
                }
            }

        }

        private void New_Win_Click(object sender, RoutedEventArgs e)
        {
            if (myWin == null)
            myWin = new MyWindow();
            myWin.Owner = this;
            var location = New_Win.PointToScreen(new Point(0, 0));
            myWin.Left = location.X + New_Win.Width;
            myWin.Top = location.Y;
            myWin.Show();
        }
    }
}