using System;
using System.Diagnostics;
using System.Threading.Tasks;
using MyApp.Models;
using Xamarin.Forms;

namespace MyApp.ViewModels
{
    [QueryProperty(nameof(ItemId), nameof(ItemId))]
    public class ItemEditViewModel : BaseViewModel
    {
        private int itemId;
        private double prix;
        private int reference;

        private int qt;
        public string nom;

        public Command ModifyItemCommand { get; }


        public string Nom
        {
            get => nom;
            set => SetProperty(ref nom, value);
        }


        public double Prix
        {
            get => prix;
            set => SetProperty(ref prix, value);
        }

        public int Qt
        {
            get => qt;
            set => SetProperty(ref qt, value);
        }
        public int Reference
        {
            get => reference;
            set => SetProperty(ref reference, value);
        }

        public int ItemId
        {
            get
            {
                return itemId;
            }
            set
            {
                itemId = value;
                LoadItemId(value);
            }
        }        

        public async void LoadItemId(int itemId)
        {
            try
            {
                var item = await DataStore.GetItemAsync(itemId);
                Reference = item.Reference;
                Nom = item.Nom;
                Prix = item.Prix;
                Qt = item.Qt;
            }
            catch (Exception)
            {
                Debug.WriteLine("Failed to Load Item");
            }
        }

       
    }
}

