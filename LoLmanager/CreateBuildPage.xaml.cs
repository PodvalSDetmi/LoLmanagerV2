using LoLmanager.DB;
using LoLmanager.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.Xml;
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
using System.Xml.Linq;

namespace LoLmanager
{
    /// <summary>
    /// Логика взаимодействия для CreateBuildPage.xaml
    /// </summary>
    public partial class CreateBuildPage : Page, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        void Signal([CallerMemberName] string prop = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
        public Hero Hero { get; set; }
        public string NameB { get; set; }
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

        public List<MainRune> MainRunes { get; set; }
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

        public Build Build { get; set; }

        public CreateBuildPage(Models.Hero selectedHero)
        {
            InitializeComponent();
            DataContext = this;
            Hero = selectedHero;

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

        private void SaveBuild(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(NameB) || SelectedMainRune != null || SelectedSummonerSpell1 != null ||
                SelectedSummonerSpell2 != null || SelectedMainSubRune1 != null || SelectedMainSubRune2 != null ||
                SelectedMainSubRune3 != null || SelectedSudeSubRune1 != null || SelectedSudeSubRune2 != null ||
                SelectedSudeSubRune3 != null || SelectedPassive1 != null || SelectedPassive2 != null || SelectedPassive3 != null)
            {
                Build = new Build()
                {
                    Name = NameB,
                    IdHero = Hero.Id,
                    IdSummonerSpell1 = SelectedSummonerSpell1.Id,
                    IdSummonerSpell2 = SelectedSummonerSpell2.Id,
                    IdMainSubRune1 =   SelectedMainSubRune1.Id,
                    IdMainSubRune2 =   SelectedMainSubRune2.Id,
                    IdMainSubRune3 =   SelectedMainSubRune3.Id,
                    IdMainRune =       SelectedMainRune.Id,
                    IdSudeSubRune1 =   SelectedSudeSubRune1.Id,
                    IdSudeSubRune2 =   SelectedSudeSubRune2.Id,
                    IdSudeSubRune3 =   SelectedSudeSubRune3.Id,
                    IdPassive1 =       SelectedPassive1.Id,
                    IdPassive2 =       SelectedPassive2.Id,
                    IdPassive3 =       SelectedPassive3.Id
                };
                lolContext.GetInstance().Builds.Add(Build);
                lolContext.GetInstance().SaveChanges();
                MessageBox.Show("Успешно сохранено");
                NameB = "";
                SelectedSummonerSpell1 = null;
                SelectedSummonerSpell2 = null;
                SelectedMainSubRune1 = null;
                SelectedMainSubRune2 = null;
                SelectedMainSubRune3 = null;
                SelectedMainRune = null;
                SelectedSudeSubRune1 = null;
                SelectedSudeSubRune2 = null;
                SelectedSudeSubRune3 = null;
                SelectedPassive1 = null;
                SelectedPassive2 = null;
                SelectedPassive3 = null;
                Signal(nameof(NameB));
                Signal(nameof(SelectedSummonerSpell1));
                Signal(nameof(SelectedSummonerSpell2));
                Signal(nameof(SelectedMainSubRune1));
                Signal(nameof(SelectedMainSubRune2));
                Signal(nameof(SelectedMainSubRune3));
                Signal(nameof(SelectedMainRune));
                Signal(nameof(SelectedSudeSubRune1));
                Signal(nameof(SelectedSudeSubRune2));
                Signal(nameof(SelectedSudeSubRune3));
                Signal(nameof(SelectedPassive1));
                Signal(nameof(SelectedPassive2));
                Signal(nameof(SelectedPassive3));
                return;
            }
            else
            {
                MessageBox.Show("Не все поля заполнены");
                return;
            }
        }

        private void ToMainPage(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new MainPage());
        }
    }
}
