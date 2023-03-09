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
    public partial class PatientInfo : ContentPage
    {
        public PatientInfo()
        {
            InitializeComponent();
        }
        protected override async void OnAppearing()
        {
            try
            {
                base.OnAppearing();
                // get name of first patient in a database
                var list = await App.MyDatabase.ReadPatients();
                patientName.Text = "Esate prisijungę kaip: " + list[0].Name + " " + list[0].Surname;

            }
            catch { }
        }
    }
}