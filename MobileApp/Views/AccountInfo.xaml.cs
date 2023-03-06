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
                patientId.Text = (await App.MyDatabase.ReadPatients())[0].Id.ToString();
                patientName.Text = (await App.MyDatabase.ReadPatients())[0].Name;
                patientSurname.Text = (await App.MyDatabase.ReadPatients())[0].Surname;
                patientEmail.Text = (await App.MyDatabase.ReadPatients())[0].Email;
                patientAdress.Text = (await App.MyDatabase.ReadPatients())[0].Address;
                patientPhone.Text = (await App.MyDatabase.ReadPatients())[0].Phone;
                patientBirthDate.Text = (await App.MyDatabase.ReadPatients())[0].BirthDate;

            }
            catch { }
        }

        async void EditPatient_Clicked(object sender, EventArgs e)
        {
            Patients p = new Patients();
            p.Id = int.Parse(patientId.Text);
            p.Name = patientName.Text;
            p.Surname = patientSurname.Text;
            p.Email = patientEmail.Text;
            p.Address = patientAdress.Text;
            p.Phone = patientPhone.Text;
            p.BirthDate = patientBirthDate.Text;
           // await Shell.Current.GoToAsync(new AccountInfoEdit(p, this));
            await Navigation.PushAsync(new AccountInfoEdit(p, this));

            /*patientAdress.IsEnabled = true;

            Patients p = new Patients();
            p.Name = patientName.Text;
            p.Surname = patientSurname.Text;
            p.Email = patientEmail.Text;
            p.Address = patientAdress.Text;
            p.Phone = patientPhone.Text;
            p.BirthDate = patientBirthDate.Text;

            await App.MyDatabase.UpdatePatient(p);*/
        }
    }
}