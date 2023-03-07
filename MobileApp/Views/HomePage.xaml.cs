using MobileApp.Components;
using System;
using System.Collections.Generic;
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
        public HomePage()
        {
            InitializeComponent();
        }

        private void OnAddSymptomClicked(object sender, EventArgs e)
        {
            var newElement = new SymptomCard
            {
                Title = "Card Title added", 
                Body = "Card Body Text added"
            };

            pageView.Children.Add(newElement);
        }

    }
}