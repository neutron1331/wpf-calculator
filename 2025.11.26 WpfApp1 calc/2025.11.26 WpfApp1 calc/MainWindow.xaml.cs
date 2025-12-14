using System;
using System.CodeDom;
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

namespace _2025._11._26_WpfApp1_calc
{
    /// <summary>
    /// Interakční logika pro MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public string text;
        
        
        public MainWindow()
        {
            InitializeComponent();
            debug.Visibility = Visibility.Hidden;
        }

        public void Zobrazení(char znak)
        {
            if (znak == 'z')
            {
                text = text.Substring(0, text.Length - 1);
            }
            else if (znak == 'd')
            {
                text = "";
            }
            else
            {
                text = text + znak;
            }

            TextBlock_input_output.Text = text;

            if (TextBlock_input_output.Text == "(*)")
            {
                if (debug.Visibility == Visibility.Visible)
                    debug.Visibility = Visibility.Hidden;
                else
                    debug.Visibility = Visibility.Visible;
            }
        }

        private void Button_rovnase_Click(object sender, RoutedEventArgs e)
        {
            bool can_continue = true; //kontrola pro pokračování v programu //check if the program can continue

            Label_debug_can_continue.Content = "can_continue = true";
            Label_debug_error.Content = "error type =";

            int depth = 0, depth_max = 0, text_lenght = 0;

            if (!string.IsNullOrEmpty(text)) //kontrola pro prázdný string //check for empty string
            {
                text_lenght = text.Length;
            }
            else
            {
                can_continue = false;
                Label_debug_can_continue.Content = "can_continue = false";
                TextBlock_input_output.Text = "error 0";
                Label_debug_error.Content = "error type = empty input";
            }

            if (can_continue)
            {
                char[] text_split = new char[text_lenght]; //vytvoří char pole o velikosti celého textu //creates field of chars with size of the entire text

                for (int i = 0; i < text_lenght; i++)
                {
                    text_split[i] = char.Parse(text.Substring(i, 1));   //rozdělí celý text na jednotlivé chary //splits text on single chars
                }

                for (int i = 0; i < text_lenght; i++)  //kontrola pro ( a ) jsetli je jich správný počet a celkový počet //checks for correct amount of ( and )
                {
                    if (text_split[i] == '(')
                        depth++;
                    else if (text_split[i] == ')')
                        depth--;
                    if (depth > depth_max)
                        depth_max++;

                    Label_debug_depth.Content = "max_depth = " + depth_max.ToString();

                }
                if (depth != 0) //vyhodí error pokud text neobsahuje správný počet () //throws an error if theres an incorrect amount of ()
                {
                    TextBlock_input_output.Text = "error 1";
                    Label_debug_error.Content = "error type = incorrect amount of ( )";
                    can_continue = false;
                    Label_debug_can_continue.Content = "can_continue = false";
                }

                /*
                 move to the deepest part of calculation
                 */

                int num_start = 0, num_end = 0;

                for (int i = 0; i < text_lenght; i++)
                {
                    if (Char.IsNumber(text_split[i]) && i != 0)
                        if (!Char.IsNumber(text_split[i - 1]))
                            num_start = (int)char.GetNumericValue(text_split[i]);
                }
            }
        }
        

        

        //vstup z kalkulačky //inputs from calc

        private void Button_1_Click(object sender, RoutedEventArgs e)
        {
            Zobrazení('1');
        }

        private void Button_2_Click(object sender, RoutedEventArgs e)
        {
            Zobrazení('2');
        }

        private void Button_3_Click(object sender, RoutedEventArgs e)
        {
            Zobrazení('3');
        }

        private void Button_4_Click(object sender, RoutedEventArgs e)
        {
            Zobrazení('4');
        }

        private void Button_5_Click(object sender, RoutedEventArgs e)
        {
            Zobrazení('5');
        }

        private void Button_6_Click(object sender, RoutedEventArgs e)
        {
            Zobrazení('6');
        }

        private void Button_7_Click(object sender, RoutedEventArgs e)
        {
            Zobrazení('7');
        }

        private void Button_8_Click(object sender, RoutedEventArgs e)
        {
            Zobrazení('8');
        }

        private void Button_9_Click(object sender, RoutedEventArgs e)
        {
            Zobrazení('9');
        }

        private void Button_0_Click(object sender, RoutedEventArgs e)
        {
            Zobrazení('0');
        }

        private void Button_00_Click(object sender, RoutedEventArgs e)
        {
            Zobrazení('0');
            Zobrazení('0');
        }

        private void Button_plus_Click(object sender, RoutedEventArgs e)
        {
            Zobrazení('+');
        }

        private void Button_minus_Click(object sender, RoutedEventArgs e)
        {
            Zobrazení('-');
        }

        private void Button_krat_Click(object sender, RoutedEventArgs e)
        {
            Zobrazení('*');
        }

        private void Button_delen_Click(object sender, RoutedEventArgs e)
        {
            Zobrazení('/');
        }
        private void Button_exp_Click(object sender, RoutedEventArgs e)
        {
            Zobrazení('^');
        }

        private void Button_mod_Click(object sender, RoutedEventArgs e)
        {
            Zobrazení('%');
        }

        private void Button_otev_závor_Click(object sender, RoutedEventArgs e)
        {
            Zobrazení('(');
        }

        private void Button_uzav_závor_Click(object sender, RoutedEventArgs e)
        {
            Zobrazení(')');
        }

        private void Button_zpet_Click(object sender, RoutedEventArgs e)
        {
            Zobrazení('z');            
        }

        private void Button_del_Click(object sender, RoutedEventArgs e)
        {
            Zobrazení('d');
        }

    }
}
