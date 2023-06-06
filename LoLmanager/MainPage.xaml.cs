using LoLmanager.DB;
using LoLmanager.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Логика взаимодействия для MainPage.xaml
    /// </summary>
    public partial class MainPage : Page, INotifyPropertyChanged
    {
        private string search;
        private ObservableCollection<Hero> heroes;
        private Difficult selectedDifficult;
        private Role selectedRole;
        private Class selectedClasses;
        private TypeDamage selectedTypeDamage;
        private Visibility visible = Visibility.Hidden;

        public event PropertyChangedEventHandler? PropertyChanged;
        void Signal([CallerMemberName] string prop = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }

        public string Search //Свойство поиска по имени героя
        {
            get => search;
            set
            {
                search = value;
                DoSearch();
            }
        }
        public ObservableCollection<Hero> Heroes //Свойство с типом данных коллекция героев
        {
            get => heroes;
            set
            {
                heroes = value;
                Signal();
            }
        }

        public List<Difficult> Difficults { get; set; } //Свойство с типом данных коллекция сложностей
        public Hero SelectedHero { get; set; } //Свойство с типом данных герой, хранящее в себе выбранного героя
        public Difficult SelectedDifficult //Свойство с типом данных сложность, хранящее в себе выбранную сложность
        {
            get => selectedDifficult;
            set
            {
                selectedDifficult = value;
                DoSearch();
            }
        }

        public List<Role> Roles { get; set; } //Свойство с типом данных коллекция ролей
        public Role SelectedRole //Свойство с типом данных роль, хранящее в себе выбранную роль
        {
            get => selectedRole;
            set
            {
                selectedRole = value;
                DoSearch();
            }
        }

        public List<Class> Classes { get; set; } //Свойство с типом данных коллекция классов
        public Class SelectedClasses
        {
            get => selectedClasses;
            set
            {
                selectedClasses = value;
                DoSearch();
            }
        }

        public List<TypeDamage> TypeDamages { get; set; } //Свойство с типом данных коллекция типов урона
        public TypeDamage SelectedTypeDamage
        {
            get => selectedTypeDamage;
            set
            {
                selectedTypeDamage = value;
                DoSearch();
            }
        }
        public Visibility Visible 
        {
            get => visible;
            set
            {
                visible = value;
                Signal();
            }
        }
        public string Password { get; set; }
        public MainPage()
        {
            InitializeComponent();
            DataContext = this;
            Visible = Visibility.Hidden;
            Heroes = new ObservableCollection<Hero>(lolContext.GetInstance().Heroes.Include("IdDifficultNavigation").Include("IdTypeDamageNavigation").Include("IdRoleNavigation").Include("IdClassNavigation").ToList()); //Заполнение коллекции героев

            Difficults = new List<Difficult> { new Difficult { Id = 0, Name = "Все сложности" } }; //Добавление нового элемента, который не хранится в бд, в коллекцию
            Difficults.AddRange(lolContext.GetInstance().Difficults);//Заполнение коллекции сложностей
            SelectedDifficult = Difficults[0];//Присваивание изначально выбранной сложности свойству отвечающее за хранение выбранной сложности

            Roles = new List<Role> { new Role { Id = 0, Name = "Все роли" } };
            Roles.AddRange(lolContext.GetInstance().Roles);
            SelectedRole = Roles[0];

            Classes = new List<Class> { new Class { Id = 0, Name = "Все классы" } };
            Classes.AddRange(lolContext.GetInstance().Classes);
            SelectedClasses = Classes[0];

            TypeDamages = new List<TypeDamage> { new TypeDamage { Id = 0, Name = "Все типы урона" } };
            TypeDamages.AddRange(lolContext.GetInstance().TypeDamages);
            SelectedTypeDamage = TypeDamages[0];
        }


        private void ToListHeroesPage(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new MainPage());
        }

        private void ToListRunesPage(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ListRunesPage());
        }

        private void ToListBuildsPage(object sender, MouseButtonEventArgs e)
        {
            if (SelectedHero != null)
                NavigationService.Navigate(new ListBuildsPage(SelectedHero));
        }

        private void DoSearch()
        {
            IQueryable<Hero> searchRequest = lolContext.GetInstance().Heroes;

            if (!string.IsNullOrEmpty(Search))
                searchRequest = searchRequest.Where(s => s.Name.Contains(Search));

            if (SelectedDifficult != null)
                searchRequest = searchRequest.Where(s => s.IdDifficult == SelectedDifficult.Id || SelectedDifficult.Id == 0);

            if (SelectedRole != null)
                searchRequest = searchRequest.Where(s => s.IdRole == SelectedRole.Id || SelectedRole.Id == 0);

            if (SelectedClasses != null)
                searchRequest = searchRequest.Where(s => s.IdClass == SelectedClasses.Id || SelectedClasses.Id == 0);

            if (SelectedTypeDamage != null)
                searchRequest = searchRequest.Where(s => s.IdTypeDamage == SelectedTypeDamage.Id || SelectedTypeDamage.Id == 0);

            Heroes = new ObservableCollection<Hero>(searchRequest);
        }

        private void Admin(object sender, RoutedEventArgs e)
        {
            if (Password == "1")
            {
                Visible = Visibility.Visible;
            }
            else
            {
                MessageBox.Show("Тебе здесь не рады!");
                return;
            }
        }

        private void ToCreateBuildPage(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new CreateBuildPage(SelectedHero));
        }
    }
}
