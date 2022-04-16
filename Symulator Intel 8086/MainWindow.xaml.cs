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
            kolejnosc.Items.Add("Działaj na rejestrach");
            kolejnosc.Items.Add("Adresowanie bezpośrednie pamięć do rejestru");
            kolejnosc.Items.Add("Adresowanie bezpośrednie rejestr do pamięci");
            kolejnosc.Items.Add("Adresowanie indeksowe pamięć do rejestru");
            kolejnosc.Items.Add("Adresowanie indeksowe rejestr do pamięci");
            kolejnosc.Items.Add("Adresowanie bazowe pamięć do rejestru");
            kolejnosc.Items.Add("Adresowanie bazowe rejestr do pamięci");
            kolejnosc.Items.Add("Adresowanie Indeksowo-bazowe pamięć do rejestru");
            kolejnosc.Items.Add("Adresowanie Indeksowo-bazowe rejestr do pamięci");
            Rozkaz.Items.Add("INC");
            Rozkaz.Items.Add("DEC");
            Rozkaz.Items.Add("NEG");
            Rozkaz.Items.Add("NOT");
            SBOX.Items.Add("SI");
            SBOX.Items.Add("DI");
            BBOX.Items.Add("BX");
            BBOX.Items.Add("BP");
            SBOX.Visibility = Visibility.Hidden;
            SBlock.Visibility = SBOX.Visibility;
            BBOX.Visibility = Visibility.Hidden;
            BBlock.Visibility = SBOX.Visibility;
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
            bool strona = true;
            if (kolejnosc.Text == "Adresowanie bezpośrednie rejestr do pamięci" || kolejnosc.Text == "Adresowanie indeksowe rejestr do pamięci" || kolejnosc.Text == "Adresowanie bazowe rejestr do pamięci" || kolejnosc.Text == "Adresowanie bazowe rejestr do pamięci")
            {
                strona = false;
            }
            string kolej = kolejnosc.Text;
            string adresvalue = "00";
            if (Adres.Text != "")
            {
                adresvalue = Adres.Text;
            }
            string action = Rozkaz.Text;
            string rej1 = rejestr1.Text;
            string rej2 = rejestr2.Text;
            string SD = SBOX.Text;
            string BP = BPBox.Text;
            
                    try
                    {
                        if (procesor.WhatToDoExtanded(kolej,action, rej1, rej2, adresvalue, strona,SD,BP))
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

        private void kolejnosc_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string element = kolejnosc.SelectedItem.ToString();
            /*if (element != "Działaj na rejestrach")
            {
                rejestr2.Visibility = Visibility.Hidden;
            }
            else
            {
                rejestr2.Visibility = Visibility.Visible;
                rej2Nazwa.Visibility = rejestr2.Visibility;
            }*/
            if (element == "Adresowanie indeksowe pamięć do rejestru" || element == "Adresowanie indeksowe rejestr do pamięci" || element == "Adresowanie Indeksowo-bazowe pamięć do rejestru" || element == "Adresowanie Indeksowo-bazowe rejestr do pamięci")
            {
                SBOX.Visibility = Visibility.Visible;
                SBlock.Visibility = SBOX.Visibility;
            }
            else
            {
                SBOX.Visibility = Visibility.Hidden;
                SBlock.Visibility = SBOX.Visibility;
            }
            if (element == "Adresowanie bazowe pamięć do rejestru" || element == "Adresowanie bazowe rejestr do pamięci" || element == "Adresowanie Indeksowo-bazowe pamięć do rejestru" || element == "Adresowanie Indeksowo-bazowe rejestr do pamięci")
            {
                BBOX.Visibility = Visibility.Visible;
                BBlock.Visibility = BBOX.Visibility;
            }
            else
            {
                BBOX.Visibility = Visibility.Hidden;
                BBlock.Visibility = BBOX.Visibility;
            }
        }
        private void Sprawdz_adres_Click(object sender, RoutedEventArgs e)
        {
            AdresBox.Text = Convert.ToInt32(Adres.Text, 16).ToString("x4").ToUpper();
            ValueBox.Text = Convert.ToString(procesor.mem[Convert.ToInt32(Adres.Text, 16)].MemValue, 16).ToUpper();

        }
    }
}
