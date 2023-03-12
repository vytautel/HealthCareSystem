using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileApp.Control
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SymptomCard : ContentView
    {
        public static readonly BindableProperty IconProperty = BindableProperty.Create(
            nameof(Icon),
            typeof(string),
            typeof(PatientInfoCard),
            default(string)
        );

        public static readonly BindableProperty TitleProperty = BindableProperty.Create(
            nameof(Title),
            typeof(string),
            typeof(PatientInfoCard),
            default(string)
        );

        public string Icon
        {
            get => (string)GetValue(IconProperty);
            set => SetValue(IconProperty, value);
        }

        public string Title
        {
            get => (string)GetValue(TitleProperty);
            set => SetValue(TitleProperty, value);
        }

        public List<Symptoms> Sympt;
        private List<string> symptoms = new List<string>()
        {
            "Fever",
            "Cough",
            "Fatigue",
            "Headache",
            "Loss of smell or taste"
        };

        public SymptomCard() { }
        public SymptomCard(int nr = 1)
        {
            InitializeComponent();
            BindingContext = this;
            SymptomSearchResults.ItemsSource = symptoms;

            SymptomNr.Text = "Simptomas #" + nr.ToString();
        }
       
        async private void SymptomTapEvent(object sender, EventArgs e)
        {
            
        }

        private async void OnSymptomSearchInput(object sender, EventArgs e)
        {
            SymptomSearchResults.IsVisible = true;

            Sympt = await App.MyDatabase.ReadSymptoms();

            string searchTerm = symptomsSearch.Text;

            if (string.IsNullOrWhiteSpace(searchTerm))
            {
                SymptomSearchResults.ItemsSource = Sympt;
            }
            else
            {
                List<Symptoms> filteredSymptoms = Sympt.Where(s => s.Name.ToLower().Contains(searchTerm.ToLower())).ToList();
                SymptomSearchResults.ItemsSource = filteredSymptoms;
            }
        }

        private void SymptomSelected(object sender, SelectedItemChangedEventArgs e)
        {
            // Nothing is selected
            if (e.SelectedItem == null)
            {
                return;
            }

            // Do something with the selected item
            Symptoms selectedSymptom = (Symptoms)e.SelectedItem;
            symptomsSearch.Text = selectedSymptom.Name;
            SymptomSearchResults.IsVisible = false;

            // Clear the selection
            SymptomSearchResults.SelectedItem = null;
        }

        private void OnRemoveClicked(object sender, EventArgs e)
        {
            // e.this = null;
           /* Button button = (Button)sender;
            MyItem item = (MyItem)button.CommandParameter;
            myStackLayout.Children.Remove(item);*/
           // ir sumazinti simptomo skaiciuka (arba nereik, nes jis kitaip pasiduos)
        }
    }
}