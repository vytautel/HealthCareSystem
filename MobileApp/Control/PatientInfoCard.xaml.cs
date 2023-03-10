using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileApp.Control
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PatientInfoCard : ContentView
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

        public PatientInfoCard()
        {
            InitializeComponent();
            BindingContext = this;
        }

        async private void ClickEvent(object sender, EventArgs e)
        {
            if (Title == "Vaistai")
            {
                await Navigation.PushAsync(new Views.PatientInfoPages.Medicines());
            }
            else if (Title == "Tyrimai")
            {
                await Navigation.PushAsync(new Views.PatientInfoPages.Examinations());
            }
            else if (Title == "Ligos")
            {
                await Navigation.PushAsync(new Views.PatientInfoPages.Diseases());
            }
            else if (Title == "Alergijos")
            {
                await Navigation.PushAsync(new Views.PatientInfoPages.Allergies());
            }
            else if (Title == "Skiepai")
            {
                await Navigation.PushAsync(new Views.PatientInfoPages.Vaccines());
            }
        }
    }

}