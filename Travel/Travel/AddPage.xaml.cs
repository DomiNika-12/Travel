using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Travel
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddPage : ContentPage
    {
        public AddPage()
        {
            InitializeComponent();
        }

        private void Save_Button_Clicked(object sender, EventArgs e)
        {
            City city = new City
            {
                Name = nameEntry.Text,
                Country = countryEntry.Text,
                Continent = continentEntry.Text
            };

            MainPage.Cities.Add(city);
            Navigation.PopAsync();
        }
    }
}