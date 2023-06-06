using LoLmanager.Models;
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

namespace LoLmanager
{
    /// <summary>
    /// Логика взаимодействия для DescriptionRunePage.xaml
    /// </summary>
    public partial class DescriptionRunePage : Page
    {
        public MainRune MainRune { get; set; }
        public SubRune1 SubRune1 { get; set; }
        public SubRune2 SubRune2 { get; set; }
        public SubRune3 SubRune3 { get; set; }

        public DescriptionRunePage(Models.MainRune selectedMainRune, Models.SubRune1 selectedSubRune1, SubRune2 selectedSubRune2, SubRune3 selectedSubRune3)
        {
            InitializeComponent();
            DataContext = this;
            MainRune = selectedMainRune;
            SubRune1 = selectedSubRune1;
            SubRune2 = selectedSubRune2;
            SubRune3 = selectedSubRune3;
        }

        private void Back(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ListRunesPage());
        }
    }
}
