using System.Reflection.Emit;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int turn = 1;
        int i, j;
        public MainWindow()
        {
            InitializeComponent();
        }

        //(1,2,3)
        //(4,5,6)
        //(7,8,9)
        //(1,4,7)
        //(2,5,8)
        //(3,6,9)
        //(1,5,9)
        //(3,5,7)   
           
        private void win(string btnContent)
        {
            if ((Button1.Content == btnContent & Button2.Content == btnContent &
                 Button3.Content == btnContent)
               | (Button1.Content == btnContent & Button4.Content == btnContent &
                 Button7.Content == btnContent)
               | (Button1.Content == btnContent & Button5.Content == btnContent &
                 Button9.Content == btnContent)
               | (Button2.Content == btnContent & Button5.Content == btnContent &
                 Button8.Content == btnContent)
               | (Button3.Content == btnContent & Button6.Content == btnContent &
                 Button9.Content == btnContent)
               | (Button4.Content == btnContent & Button5.Content == btnContent &
                 Button6.Content == btnContent)
               | (Button7.Content == btnContent & Button8.Content == btnContent &
                 Button9.Content == btnContent)
               | (Button3.Content == btnContent & Button5.Content == btnContent &
                 Button7.Content == btnContent))
            {
                if (btnContent == "O")
                {
                    MessageBox.Show("PLAYER O WINS");
                }
                else if (btnContent == "X")
                {
                    MessageBox.Show("PLAYER X WINS");
                }
                disablebuttons();
            }
            else
            {
                foreach (Button btn in wrapPanel1.Children)
                {
                    if (btn.IsEnabled == true)
                        return;
                }
                MessageBox.Show("GAME OVER NO ONE WINS");
            }
        }
        private void disablebuttons()
        {
            foreach (Button btn in wrapPanel1.Children)
            {
                btn.IsEnabled = false;
            }
        }

        private void Reset_Click(object sender, RoutedEventArgs e)
        {
            foreach (Button btn in wrapPanel1.Children)
            {
                btn.Content = "";
                btn.IsEnabled = true;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            if (turn == 1)
            {
                btn.Content = "O";
            }
            else
            {
                btn.Content = "X";
            }
            btn.IsEnabled = false;
            win(btn.Content.ToString());
            turn += 1;
            if (turn > 2)
                turn = 1;
        }
    }
}