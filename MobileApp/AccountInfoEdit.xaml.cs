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
    public partial class AccountInfoEdit : ContentPage
    {
        Patients patient;
        AccountInfo AccountInfoPage;
        public AccountInfoEdit(Patients p, AccountInfo page)
        {
            InitializeComponent();
            patientName.Text = p.Name;
            patientSurname.Text = p.Surname;
            patientEmail.Text = p.Email;
            patientAdress.Text = p.Address;
            patientPhone.Text = p.Phone;
            patientBirthDate.Text = p.BirthDate;
            patient = p;
            patient.Id = p.Id;
            AccountInfoPage = page;
        }
        async void SavePatient_Clicked(object sender, EventArgs e)
        {
            patient.Name = patientName.Text;
            patient.Surname = patientSurname.Text;
            patient.Email = patientEmail.Text;
            patient.Address = patientAdress.Text;
            patient.Phone = patientPhone.Text;
            patient.BirthDate = patientBirthDate.Text;

            int number_updated = await App.MyDatabase.UpdatePatient(patient);

            await Navigation.PopAsync(); 
        }
    }
}