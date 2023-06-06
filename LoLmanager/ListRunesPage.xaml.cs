using LoLmanager.DB;
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
    /// Логика взаимодействия для ListRunesPage.xaml
    /// </summary>
    public partial class ListRunesPage : Page
    {
        public List<MainRune> MainRunes { get; set; }
        public MainRune SelectedMainRune { get; set; }
        public List<SubRune1> SubRunes1 { get; set; }
        public SubRune1 SelectedSubRune1 { get; set; }
        public List<SubRune2> SubRunes2 { get; set; }
        public SubRune2 SelectedSubRune2 { get; set; }
        public List<SubRune3> SubRunes3 { get; set; }
        public SubRune3 SelectedSubRune3 { get; set; }

        public ListRunesPage()
        {
            InitializeComponent();
            DataContext = this;
            MainRunes = lolContext.GetInstance().MainRunes.ToList();
            SubRunes1 = lolContext.GetInstance().SubRune1s.ToList();
            SubRunes2 = lolContext.GetInstance().SubRune2s.ToList();
            SubRunes3 = lolContext.GetInstance().SubRune3s.ToList();
        }

        private void Back(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new MainPage());
        }

        private void ToDescriptionRunePage(object sender, MouseButtonEventArgs e)
        {
            if(SelectedMainRune != null)
                NavigationService.Navigate(new DescriptionRunePage(SelectedMainRune, SelectedSubRune1, SelectedSubRune2, SelectedSubRune3));
        }

        private void ToDescriptionRunePage1(object sender, MouseButtonEventArgs e)
        {
            if (SelectedSubRune1 != null)
                NavigationService.Navigate(new DescriptionRunePage(SelectedMainRune, SelectedSubRune1, SelectedSubRune2, SelectedSubRune3));
        }

        private void ToDescriptionRunePage2(object sender, MouseButtonEventArgs e)
        {
            if (SelectedSubRune2 != null)
                NavigationService.Navigate(new DescriptionRunePage(SelectedMainRune, SelectedSubRune1, SelectedSubRune2, SelectedSubRune3));
        }

        private void ToDescriptionRunePage3(object sender, MouseButtonEventArgs e)
        {
            if (SelectedSubRune3 != null)
                NavigationService.Navigate(new DescriptionRunePage(SelectedMainRune, SelectedSubRune1, SelectedSubRune2, SelectedSubRune3));
        }
    }
}
