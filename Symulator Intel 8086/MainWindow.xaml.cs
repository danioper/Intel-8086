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
            Rozkaz.Items.Add("INC");
            Rozkaz.Items.Add("DEC");
            Rozkaz.Items.Add("NEG");
            Rozkaz.Items.Add("NOT");
        }

        private void Przypisz_Click(object sender, RoutedEventArgs e)
        {
            string[] insert = new string[12];
            insert[0] = AHinput.Text;
            insert[1] = ALinput.Text;
            insert[2] = BHinput.Text;
            insert[3] = BLinput.Text;
            insert[4] = CHinput.Text;
            insert[5] = CLinput.Text;
            insert[6] = DHinput.Text;
            insert[7] = DLinput.Text;
            insert[8] = SIinput.Text;
            insert[9] = DIinput.Text;
            insert[10] = BPinput.Text;
            insert[11] = BHinput.Text + BLinput.Text;

            procesor = new Procesor(insert);

            AHbox.Text = procesor.rejestr[0].ToString();
            ALbox.Text = procesor.rejestr[1].ToString();
            BHbox.Text = procesor.rejestr[2].ToString();
            BLbox.Text = procesor.rejestr[3].ToString();
            CHbox.Text = procesor.rejestr[4].ToString();
            CLbox.Text = procesor.rejestr[5].ToString();
            DHbox.Text = procesor.rejestr[6].ToString();
            DLbox.Text = procesor.rejestr[7].ToString();
            SIBox.Text = procesor.rejestr[8].ToString(true);
            DIBox.Text = procesor.rejestr[9].ToString(true);
            BPBox.Text = procesor.rejestr[10].ToString(true);
            BXBox.Text = procesor.rejestr[11].ToString(true);

        }

        private void Losuj_Click(object sender, RoutedEventArgs e)
        {
            string[] insert = new string[12];
            insert[0] = procesor.randomRejestr();
            insert[1] = procesor.randomRejestr();
            insert[2] = procesor.randomRejestr();
            insert[3] = procesor.randomRejestr();
            insert[4] = procesor.randomRejestr();
            insert[5] = procesor.randomRejestr();
            insert[6] = procesor.randomRejestr();
            insert[7] = procesor.randomRejestr();
            insert[8] = procesor.randomRejestr("4");
            insert[9] = procesor.randomRejestr("4");
            insert[10] = procesor.randomRejestr("4");
            insert[11] = insert[2] + insert[3];
            procesor = new Procesor(insert);

            AHbox.Text = procesor.rejestr[0].ToString();
            ALbox.Text = procesor.rejestr[1].ToString();
            BHbox.Text = procesor.rejestr[2].ToString();
            BLbox.Text = procesor.rejestr[3].ToString();
            CHbox.Text = procesor.rejestr[4].ToString();
            CLbox.Text = procesor.rejestr[5].ToString();
            DHbox.Text = procesor.rejestr[6].ToString();
            DLbox.Text = procesor.rejestr[7].ToString();
            SIBox.Text = procesor.rejestr[8].ToString(true);
            DIBox.Text = procesor.rejestr[9].ToString(true);
            BPBox.Text = procesor.rejestr[10].ToString(true);
            BXBox.Text = procesor.rejestr[11].ToString(true);
        }

        private void Symuluj_Click(object sender, RoutedEventArgs e)
        {
            string action = Rozkaz.Text;
            string rej1 = rejestr1.Text;
            string rej2 = rejestr2.Text;
            try
            {
                if (procesor.WhatToDo(action, rej1, rej2))
                {
                    AHbox.Text = procesor.rejestr[0].ToString();
                    ALbox.Text = procesor.rejestr[1].ToString();
                    BHbox.Text = procesor.rejestr[2].ToString();
                    BLbox.Text = procesor.rejestr[3].ToString();
                    CHbox.Text = procesor.rejestr[4].ToString();
                    CLbox.Text = procesor.rejestr[5].ToString();
                    DHbox.Text = procesor.rejestr[6].ToString();
                    DLbox.Text = procesor.rejestr[7].ToString();
                }
            }
            catch
            {
                MessageBox.Show("Przypisz lub wylosuj wartości rejestrów");
            }
        }

        private void Rozkaz_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string oneElement = Rozkaz.SelectedItem.ToString();
            if (oneElement == "NOT" || oneElement == "INC" || oneElement == "DEC" || oneElement == "NEG")
                rejestr2.Visibility = Visibility.Hidden;
            else
                rejestr2.Visibility = Visibility.Visible;
            rej2Nazwa.Visibility = rejestr2.Visibility;
        }

        private void Sprawdz_adres_Click(object sender, RoutedEventArgs e)
        {
            AdresBox.Text = Convert.ToInt32(Adres.Text, 16).ToString("x4").ToUpper();
            ValueBox.Text = Convert.ToString(procesor.mem[Convert.ToInt32(Adres.Text, 16)].MemValue, 16).ToUpper();

        }
    }
}
