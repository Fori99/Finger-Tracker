using App1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : ContentPage
    {
        Place mock => DependencyService.Get<Place>();

        public HomePage()
        {
            InitializeComponent();
            getData();
        }

        public async void getData()
        {
            List<PlaceModel> newItem = new List<PlaceModel>();
            newItem = await mock.getplaces();
            myItem.ItemsSource = newItem;
        }
    }
}