using LoLmanager.DB;
using LoLmanager.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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
    /// Логика взаимодействия для ListBuildsPage.xaml
    /// </summary>
    public partial class ListBuildsPage : Page, INotifyPropertyChanged
    {
        public bool Block 
        {
            get => block;
            set
            {
                block = value;
                Signal();
            } 
        }
        public event PropertyChangedEventHandler? PropertyChanged;
        void Signal([CallerMemberName] string prop = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
        private Build selectedBuild;
        private List<MainRune> mainRunes;
        private bool block = false;

        public Hero Hero { get; set; }
        public List<Build> Builds { get; set; }

        public List<SummonerSpell1> SummonerSpells1 { get; set; }
        public SummonerSpell1 SelectedSummonerSpell1 { get; set; }

        public List<SummonerSpell2> SummonerSpells2 { get; set; }
        public SummonerSpell2 SelectedSummonerSpell2 { get; set; }

        public List<SubRune1> MainSubRunes1 { get; set; }
        public SubRune1 SelectedMainSubRune1 { get; set; }

        public List<SubRune2> MainSubRunes2 { get; set; }
        public SubRune2 SelectedMainSubRune2 { get; set; }

        public List<SubRune3> MainSubRunes3 { get; set; }
        public SubRune3 SelectedMainSubRune3 { get; set; }

        public List<MainRune> MainRunes
        {
            get => mainRunes; set
            {
                mainRunes = value;
                Signal();
            }
        }
        public MainRune SelectedMainRune { get; set; }

        public List<SubRune1> SudeSubRunes1 { get; set; }
        public SubRune1 SelectedSudeSubRune1 { get; set; }

        public List<SubRune2> SudeSubRunes2 { get; set; }
        public SubRune2 SelectedSudeSubRune2 { get; set; }

        public List<SubRune3> SudeSubRunes3 { get; set; }
        public SubRune3 SelectedSudeSubRune3 { get; set; }

        public List<Passive1> Passives1 { get; set; }
        public Passive1 SelectedPassive1 { get; set; }

        public List<Passive2> Passives2 { get; set; }
        public Passive2 SelectedPassive2 { get; set; }

        public List<Passive3> Passives3 { get; set; }
        public Passive3 SelectedPassive3 { get; set; }
        public Build SelectedBuild
        {
            get => selectedBuild;
            set
            {
                selectedBuild = value;
                Signal();
            }
        }

        public string Password { get; set; }
        public ListBuildsPage(Models.Hero selectedHero)
        {
            InitializeComponent();
            DataContext = this;
            Hero = selectedHero;
            //SelectedBuild.IdPassive1
            Builds = lolContext.GetInstance().Builds.Where(s => s.IdHero == selectedHero.Id).ToList();
            SummonerSpells1 = lolContext.GetInstance().SummonerSpell1s.ToList();
            SummonerSpells2 = lolContext.GetInstance().SummonerSpell2s.ToList();

            MainSubRunes1 = lolContext.GetInstance().SubRune1s.ToList();
            MainSubRunes2 = lolContext.GetInstance().SubRune2s.ToList();
            MainSubRunes3 = lolContext.GetInstance().SubRune3s.ToList();

            MainRunes = lolContext.GetInstance().MainRunes.ToList();

            SudeSubRunes1 = lolContext.GetInstance().SubRune1s.ToList();
            SudeSubRunes2 = lolContext.GetInstance().SubRune2s.ToList();
            SudeSubRunes3 = lolContext.GetInstance().SubRune3s.ToList();

            Passives1 = lolContext.GetInstance().Passive1s.ToList();
            Passives2 = lolContext.GetInstance().Passive2s.ToList();
            Passives3 = lolContext.GetInstance().Passive3s.ToList();
        }

        private void ToBuildPage(object sender, MouseButtonEventArgs e)
        {
            if (SelectedBuild != null)
            {
                NavigationService.Navigate(new BuildPage(SelectedBuild));
            }
            else
            {
                MessageBox.Show("Выберите билд!");
                return;
            }

        }
        private void UpdateBuild(object sender, RoutedEventArgs e)
        {
            if (SelectedSummonerSpell1 == null || SelectedSummonerSpell2 == null || SelectedMainSubRune1 == null || SelectedMainSubRune2 == null || SelectedMainSubRune3 == null ||
            SelectedMainRune == null || SelectedSudeSubRune1 == null || SelectedSudeSubRune2 == null || SelectedSudeSubRune3 == null || SelectedPassive1 == null || SelectedPassive2 == null ||
            SelectedPassive3 == null)
            {
                MessageBox.Show("Заполните все поля!");
                return;
            }
            else
            {
                SelectedBuild.IdSummonerSpell1 = SelectedSummonerSpell1.Id;
                SelectedBuild.IdSummonerSpell2 = SelectedSummonerSpell2.Id;
                SelectedBuild.IdMainSubRune1 = SelectedMainSubRune1.Id;
                SelectedBuild.IdMainSubRune2 = SelectedMainSubRune2.Id;
                SelectedBuild.IdMainSubRune3 = SelectedMainSubRune3.Id;
                SelectedBuild.IdMainRune = SelectedMainRune.Id;
                SelectedBuild.IdSudeSubRune1 = SelectedSudeSubRune1.Id;
                SelectedBuild.IdSudeSubRune2 = SelectedSudeSubRune2.Id;
                SelectedBuild.IdSudeSubRune3 = SelectedSudeSubRune3.Id;
                SelectedBuild.IdPassive1 = SelectedPassive1.Id;
                SelectedBuild.IdPassive2 = SelectedPassive2.Id;
                SelectedBuild.IdPassive3 = SelectedPassive3.Id;
                lolContext.GetInstance().Update(SelectedBuild);
                lolContext.GetInstance().SaveChanges();
            }

        }

        private void Next(object sender, RoutedEventArgs e)
        {
            if(Password == "1")
            {
                Block = true;
            }
            else
            {
                MessageBox.Show("Проаваливай отсюда!");
            }
        }
    }
}
