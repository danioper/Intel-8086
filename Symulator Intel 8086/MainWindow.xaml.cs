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
using Procesor__Biblioteka;

namespace Symulator_Intel_8086
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Procesor procesor; 
        public MainWindow()
        {
            procesor = new Procesor();
            InitializeComponent();
        }

        private void Przypisz_Click(object sender, RoutedEventArgs e)
        {
            string[] insert = new string[8];
            insert[0] = AHinput.Text;
            insert[1] = ALinput.Text;
            insert[2] = BHinput.Text;
            insert[3] = BLinput.Text;
            insert[4] = CHinput.Text;
            insert[5] = CLinput.Text;
            insert[6] = DHinput.Text;
            insert[7] = DLinput.Text;

            AHbox.Text = insert[0];
            ALbox.Text = insert[1];
            BHbox.Text = insert[2];
            BLbox.Text = insert[3];
            CHbox.Text = insert[4];
            CLbox.Text = insert[5];
            DHbox.Text = insert[6];
            DLbox.Text = insert[7];


            procesor = new Procesor(insert);
        }
    }
}
