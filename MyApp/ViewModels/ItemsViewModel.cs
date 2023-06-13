using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;

using Xamarin.Forms;

using MyApp.Models;
using MyApp.Views;

namespace MyApp.ViewModels
{
    public class ItemsViewModel : BaseViewModel
    {
        private Article _selectedItem;

        public ObservableCollection<Article> Items { get; }
        public Command LoadItemsCommand { get; }
        public Command AddItemCommand { get;  }
        public Command EditItemCommand { get; }

        public Command<Article> ItemTapped { get; }
        public Command<Article> EditTapped { get; }

        public Command<Article> ItemDelete { get; }


        public ItemsViewModel()
        {
            Title = "Details";
            Items = new ObservableCollection<Article>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

            ItemTapped = new Command<Article>(OnItemSelected);

            EditTapped = new Command<Article>(OnItemEditSelected);

            ItemDelete = new Command<Article>(OnItemdeleted);



            AddItemCommand = new Command(OnAddItem);
        }

        async Task ExecuteLoadItemsCommand()
        {
            IsBusy = true;

            try
            {
                Items.Clear();
                var items = await DataStore.GetItemsAsync(true);
                foreach (var item in items)
                {
                    Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }

        public void OnAppearing()
        {
            IsBusy = true;
            SelectedItem = null;
        }

        public Article SelectedItem
        {
            get => _selectedItem;
            set
            {
                SetProperty(ref _selectedItem, value);
                OnItemSelected(value);
            }
        }

        private async void OnAddItem(object obj)
        {
            await Shell.Current.GoToAsync(nameof(NewItemPage));
        }

    

        async void OnItemSelected(Article item)
        {
            if (item == null)
                return;

            // This will push the ItemDetailPage onto the navigation stack
            await Shell.Current.GoToAsync($"{nameof(ItemDetailPage)}?{nameof(ItemDetailViewModel.ItemId)}={item.Reference}");
        }

        async void OnItemdeleted(Article item)
        {
            if (item == null)
                return;

            await DataStore.DeleteItemAsync(item.Reference);
            await ExecuteLoadItemsCommand();

        }

        async void OnItemEditSelected(Article item)
        {
            if (item == null)
                return;

            await Shell.Current.GoToAsync($"{nameof(ItemEditPage)}?{nameof(ItemEditViewModel.ItemId)}={item.Reference}");

        }
    }
}
