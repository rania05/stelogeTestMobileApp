using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using MyApp.Models;
using Xamarin.Forms;

namespace MyApp.ViewModels
{
    public class NewItemViewModel : BaseViewModel
    {
        private string nom;
        private double prix;
        private int qt;


        public NewItemViewModel()
        {
            SaveCommand = new Command(OnSave, ValidateSave);
            CancelCommand = new Command(OnCancel);
            this.PropertyChanged += 
                (_, __) => SaveCommand.ChangeCanExecute();
        }

        private bool ValidateSave()
        {
            return !String.IsNullOrWhiteSpace(nom)
                && !Double.IsNaN(prix);
        }

        public string Nom
        {
            get => nom;
            set => SetProperty(ref nom, value);
        }

      
        public int Qt
        {
            get => qt;
            set => SetProperty(ref qt, value);
        }
        public double Prix
        {
            get => prix;
            set => SetProperty(ref prix, value);
        }


        public Command SaveCommand { get; }
        public Command CancelCommand { get; }

        private async void OnCancel()
        {
            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
        }

        private async void OnSave()
        {
            Random random = new Random();

            Article newItem = new Article(reference: random.Next(), nom: nom , prix:Prix, qt:Qt);


            await DataStore.AddItemAsync(newItem);

            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
        }
    }
}

