using Android.Service.Controls;
using MobileApp.Models;
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
    public partial class AccountInfo : ContentPage
    {
        public AccountInfo()
        {
            InitializeComponent();
            OnAppearing();
        }
        protected override async void OnAppearing()
        {
            try
            {
                base.OnAppearing();
                // get name of first patient in a database
                var list = await App.MyDatabase.ReadPatients();
                Pacients p = list[0];
                patientId.Text = p.Id.ToString();
                patientName.Text = p.Name;
                patientSurname.Text = p.Surname;
                patientEmail.Text = p.Email;
                patientAdress.Text = p.Address;
                patientPhone.Text = p.Phone;
                patientBirthDate.Text = p.BirthDate;

            }
            catch { }
        }

        async void EditPatient_Clicked(object sender, EventArgs e)
        {
            Pacients p = new Pacients();
            p.Id = int.Parse(patientId.Text);
            p.Name = patientName.Text;
            p.Surname = patientSurname.Text;
            p.Email = patientEmail.Text;
            p.Address = patientAdress.Text;
            p.Phone = patientPhone.Text;
            p.BirthDate = patientBirthDate.Text;
            await Navigation.PushAsync(new AccountInfoEdit(p, this));
        }
    }
}