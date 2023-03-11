using Android;
using Android.Views;
using Android.Widget;
using MobileApp.Control;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : ContentPage
    {
        ObservableCollection<SymptomCard> cardItems;
        int nr = 1;
        public HomePage()
        {
            InitializeComponent();
            
           // cardItems = new ObservableCollection<SymptomCard>();
          //  myListView.ItemsSource = cardItems;
        }

        private void OnAddSymptomClicked(object sender, EventArgs e)
        {
            var newElement = new SymptomCard(nr++)
            {
                Title = "Card Title added",
                Icon = "Card Body Icon added"
            };

            SymptomCardsLayout.Children.Insert(0, newElement);
        }
    }
}