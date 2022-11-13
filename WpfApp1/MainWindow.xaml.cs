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

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string[] data;

        bool isAltered = false;
         
        
        public MainWindow()
        {
            InitializeComponent();
            data = new string[] { "", "", "","" };
            string[] s = new string[] { "+7(921)", "+7(981)", "+38(067)","+374(093)","+48(055)"};
        foreach(var x in s)
            {
                codePhonP3.Items.Add(x);
            }
            if (MotherBoard.SelectedIndex > 0) { isAltered = true; }
        }
        private void Save_Click(Object sender,EventArgs e)
        {
            MotherBoard.Items.Add(addDataPanel());
            
        }
        private void Canc_click(Object sender, EventArgs e)
        {
            fNameP3.Text = "";
            lNameP3.Text = "";

            mPhoneP3.Text = "";
            emailP3.Text = "";
        }
        private Canvas addDataPanel()
        {
            Canvas c = new Canvas(); c.Height = 30;c.Width = 480;
            c.Style = (Style)Resources["CanvStyle"];
            Label SNlabel = new Label();SNlabel.FontWeight = FontWeights.Bold;
            SNlabel.FontSize = 15; SNlabel.Width = 93; SNlabel.Height = 28;
            SNlabel.HorizontalAlignment = HorizontalAlignment.Left;
            SNlabel.VerticalContentAlignment = VerticalAlignment.Center;
            SNlabel.Content = fNameP3.Text + " " + lNameP3.Text;

            Label EMlabel = new Label();
            EMlabel.FontSize = 15;EMlabel.Width =130;EMlabel.Height = 28;
            EMlabel.HorizontalAlignment = HorizontalAlignment.Left;
            EMlabel.VerticalContentAlignment = VerticalAlignment.Center;
            EMlabel.Margin = new Thickness(90, 0, 0, 0); EMlabel.Content = emailP3.Text;
            Label NUMBlabel = new Label();
            NUMBlabel.FontSize = 15;
            NUMBlabel.Width = 130;NUMBlabel.Height = 28;
            NUMBlabel.HorizontalAlignment = HorizontalAlignment.Left;
            NUMBlabel.VerticalContentAlignment = VerticalAlignment.Center;
            NUMBlabel.Margin = new Thickness(223, 0, 0, 0);
            NUMBlabel.Content = codePhonP3.SelectedItem.ToString() +" "+ mPhoneP3.Text;
            
            Button EditBut = new Button();
            EditBut.Style = (Style)Resources["EditButStyle"]; 

            Button DelBut = new Button();
            DelBut.Style = (Style)Resources["DelButStyle"];
            c.Children.Add(SNlabel);
            c.Children.Add(EMlabel);
            c.Children.Add(NUMBlabel);
            c.Children.Add(EditBut);
            c.Children.Add(DelBut);
            string[] ss = SNlabel.Content.ToString().Split(' ');
            data[0] = ss[0];
            data[1] = ss[1];
            data[2] = EMlabel.ToString();
            data[3] = NUMBlabel.ToString();
            return c;
        }
       
      
        private bool isEmpty()
        {
            if (fNameP3.Text.Length > 0 || fNameP3.Text.Length > 0 || mPhoneP3.Text.Length > 0 || emailP3.Text.Length > 0)
            {
                
                return true;
            }
            else return false;
        }
       void editCl(object sender, RoutedEventArgs e)
        {
            Button b = e.Source as Button;
            if (isEmpty()) { fNameP3.Text = ""; fNameP3.Text = ""; mPhoneP3.Text = ""; emailP3.Text = ""; }

            
            fNameP3.Text = data[0];
            lNameP3.Text = data[1];
            
            mPhoneP3.Text = data[3];
            emailP3.Text = data[2];
            
        }
        void canD(object sender, RoutedEventArgs e)
        {

            isAltered = true;
                nameP2.Content = data[0] + " " + data[1];
                mobileP2.Content = data[3];
                emailP2.Content = data[2];
           
               
        }
        void delCl(object sender, RoutedEventArgs e)
        {
            MotherBoard.Items.Remove(MotherBoard.SelectedItem);
        }
    }
}


