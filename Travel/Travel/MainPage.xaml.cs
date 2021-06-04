using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Travel
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {
        public static ObservableCollection<City> Cities { get; set; }
        public MainPage()
        {
            InitializeComponent();
            Cities = new ObservableCollection<City>();
            listView.ItemsSource = Cities;
        }

        private ObservableCollection<City> SearchData(string searchText = null)
        {
            if (String.IsNullOrWhiteSpace(searchText))
            {
                return Cities;
            }

            IEnumerable<City> temp = Cities.Where(c => c.Name.StartsWith(searchText));
            ObservableCollection<City> cities = new ObservableCollection<City>(temp);

            return cities;
        }

        private void Add_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new AddPage());
        }

        private void Delete_Clicked(object sender, EventArgs e)
        {
            var city = (sender as MenuItem).CommandParameter as City;
            Cities.Remove(city);

        }

        private void listView_Refreshing(object sender, EventArgs e)
        {
            //Refresh by calling method (To Do)
            listView.EndRefresh();
        }

        private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            var tempCities = SearchData(e.NewTextValue);
            listView.ItemsSource = tempCities;
        }
    }
}