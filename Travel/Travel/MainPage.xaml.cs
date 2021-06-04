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

        private void Add_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new AddPage());
        }

        private void Delete_Clicked(object sender, EventArgs e)
        {
            var city = (sender as MenuItem).CommandParameter as City;
            Cities.Remove(city);

        }
    }
}