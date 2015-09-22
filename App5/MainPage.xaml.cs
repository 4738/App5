using System;
using System.Collections;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// Die Vorlage "Leere Seite" ist unter http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409 dokumentiert.

namespace App5
{
    /// <summary>
    /// Eine leere Seite, die eigenständig verwendet werden kann oder auf die innerhalb eines Rahmens navigiert werden kann.
    /// </summary>
    
    public sealed partial class MainPage : Page
    {
        public enum elements
        {
            Gli,
            H,
            He,
            Li,
            Be,
            B,
            C,
            N,
            O,
            F,
            Ne,
            Na,
            Mg,
            Al,
            Si,
            P,
            S,
            Cl,
            Ar,
            K,
            Ca,
            Sc,
            Ti,
            V,
            Cr,
            Mn,
            Fe,
            Co,
            Ni,
            Cu,
            Zn,
            Ga,
            Ge,
            As,
            Se,
            Br,
            Kr,
            Rb,
            Sr,
            Y,
            Zr,
            Nb,
            Mo,
            Tc,
            Ru,
            Rh,
            Pd,
            Ag,
            Cd,
            In,
            Sn,
            Sb,
            Te,
            I,
            Xe,
            Cs,
            Ba,
            La,
            Ce,
            Pr,
            Nd,
            Pm,
            Sm,
            Eu,
            Gd,
            Tb,
            Dy,
            Ho,
            Er,
            Tm,
            Yb,
            Lu,
            Hf,
            Ta,
            W,
            Re,
            Os,
            Ir,
            Pt,
            Au,
            Hg,
            Tl,
            Pb,
            Bi,
            Po,
            At,
            Rn,
            Fr,
            Ra,
            Ac,
            Th,
            Pa,
            U,
            Np,
            Pu,
            Am,
            Cm,
            Bk,
            Cf,
            Es,
            Fm,
            Md,
            No,
            Lr,
            Rf,
            Db,
            Sg,
            Bh,
            Hs,
            Mt,
            Ds,
            Rg,
            Cp,
            Uut,
            Fl,
            Uup,
            Lv,
            Uus,
            Uuo,
        }

        public enum elementNames
        {
            Glitzereinhorn,
            Wasserstoff,
            Helium,
            Lithium,
            Beryllium,
            Bor,
            Kohlenstoff,
            Stickstoff,
            Sauerstoff,
            Fluor,
            Neon,
            Natrium,
            Magnesium,
            Aluminium,
            Silicium,
            Phosphor,
            Schwefel,
            Chlor,
            Argon,
            Kalium,
            Calcium,
            Scandium,
            Titan,
            Vanadium,
            Chrom,
            Mangan,
            Eisen,
            Cobalt,
            Nickel,
            Kupfer,
            Zink,
            Gallium,
            Germanium,
            Arsen,
            Selen,
            Brom,
            Krypton,
            Rubidium,
            Strontium,
            Yttrium,
            Zirconium,
            Niob,
            Molybdän,
            Technetium,
            Ruthenium,
            Rhodium,
            Palladium,
            Silber,
            Cadmium,
            Indium,
            Zinn,
            Antimon,
            Tellur,
            Iod,
            Xenon,
            Caesium,
            Barium,
            Lanthan,
            Cer,
            Praseodym,
            Neodym,
            Promethium,
            Samarium,
            Europium,
            Gadolinium,
            Terbium,
            Dysprosium,
            Holmium,
            Erbium,
            Thulium,
            Ytterbium,
            Lutetium,
            Hafnium,
            Tantal,
            Wolfram,
            Rhenium,
            Osmium,
            Iridium,
            Platin,
            Gold,
            Quecksilber,
            Thallium,
            Blei,
            Bismut,
            Polonium,
            Astat,
            Radon,
            Francium,
            Radium,
            Actinium,
            Thorium,
            Protactinium,
            Uran,
            Neptunium,
            Plutonium,
            Americium,
            Curium,
            Berkelium,
            Californium,
            Einsteinium,
            Fermium,
            Mendelevium,
            Nobelium,
            Lawrencium,
            Rutherfordium,
            Dubnium,
            Seaborgium,
            Bohrium,
            Hassium,
            Meitnerium,
            Darmstadtium,
            Roentgenium,
            Copernicium,
            Ununtrium,
            Flerovium,
            Ununpentium,
            Livermorium,
            Ununseptium,
            Ununoctium
        }
        public Hashtable groups = new Hashtable();
        public int remain = new int();
        public int currentGuess = new int();
        public int[] currentOrder;
        public int errors = new int();

        public MainPage()
        {
            groups.Add(1, new int[] { 1, 3, 11, 19, 37, 55, 87 });
            groups.Add(2, new int[] { 4, 12, 20, 38, 56, 88 });
            groups.Add(3, new int[] { 5, 13, 31, 49, 81 });
            groups.Add(4, new int[] { 6, 14, 32, 50, 82 });
            groups.Add(5, new int[] { 7, 15, 33, 51, 83 });
            groups.Add(6, new int[] { 8, 16, 34, 52, 84 });
            groups.Add(7, new int[] { 9, 17, 35, 53, 85 });
            groups.Add(8, new int[] { 2, 10, 18, 36, 54, 86 });
            this.InitializeComponent();
            gBox.Focus(FocusState.Pointer);
        }

        private void gBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                int chosenGroup = gBox.SelectedIndex + 1;
                ComboBoxItem selected = (ComboBoxItem)gBox.SelectedItem;
                titleText.Content = "Abfrage der " + selected.Content;
                currentOrder = (int[])groups[chosenGroup];
                currentGuess = 0;
                remain = currentOrder.Length;
                longBlock.Text = "Noch " + remain + " Elemente";
                elementBlock.Text = "?";
                errors = 0;
            }
            catch
            {
                titleText.Content = "Etwas ist schief gelaufen";
            }
            ansBox.Select(0,100);
            ansBox.Focus(FocusState.Pointer);
        }

        private void ansBox_KeyUp(object sender, KeyRoutedEventArgs e)
        {
            if (e.Key == Windows.System.VirtualKey.Enter)
            {
                if (ansBox.Text == Enum.GetName(typeof(elements), currentOrder[currentGuess]))
                {
                    if (remain > 1)
                    {
                        currentGuess++;
                        remain--;
                        elementBlock.Text = Enum.GetName(typeof(elements), currentOrder[currentGuess - 1]);
                        fullName.Text = Enum.GetName(typeof(elementNames), currentOrder[currentGuess - 1]);
                        longBlock.Text = "Noch " + remain + " Elemente";
                        ansBox.Text = "";
                    }
                    else
                    {
                        elementBlock.Text = "!";
                        fullName.Text = "";
                        titleText.Content = "Bitte wähle eine andere Hauptgruppe aus";
                        gBox.Focus(FocusState.Pointer);
                        if (errors == 0)
                        {
                            longBlock.Text = "Glückwunsch, das war fehlerfrei!";
                        }
                        else
                        {
                            longBlock.Text = "Fehleranzahl: " + errors;
                        }
                    }
                }
                else
                {
                    longBlock.Text = "Nein, noch " + remain + " Elemente";
                    errors++;
                }
            }
        }
    }
}
