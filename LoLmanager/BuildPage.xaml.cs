using LoLmanager.DB;
using LoLmanager.Models;
using Microsoft.EntityFrameworkCore;
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
    /// Логика взаимодействия для BuildPage.xaml
    /// </summary>
    public partial class BuildPage : Page
    {

        public Build Build { get; set; }
        public Build BuildName { get; set; }
        public BuildPage(Build selectedBuild)
        {
            InitializeComponent();
            DataContext = this;
            BuildName = selectedBuild;
            Build = lolContext.GetInstance().Builds.Include("IdMainRuneNavigation").Include("IdMainSubRune1Navigation").Include("IdMainSubRune2Navigation").
                Include("IdMainSubRune3Navigation").Include("IdSudeSubRune1Navigation").Include("IdSudeSubRune2Navigation").Include("IdSudeSubRune3Navigation").
                Include("IdSummonerSpell1Navigation").Include("IdSummonerSpell2Navigation").Include("IdPassive1Navigation").Include("IdPassive2Navigation").Include("IdPassive3Navigation").FirstOrDefault(s => s.Id == selectedBuild.Id);
        }
        private void Back(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new MainPage());
        }
    }
}
