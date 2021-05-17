using MvvmTestApp.Models;
using MvvmTestApp.Services;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MvvmTestApp.ViewModels
{
    [QueryProperty(nameof(ItemId), nameof(ItemId))]
    public class ItemDetailViewModel : BaseViewModel
    {
        private int itemId;
        private string text;
        private string description;
        private string photo;
        public int Id { get; set; }

        public string Photo
        {
            get => photo;
            set => SetProperty(ref photo, value);
        }
        public string Text
        {
            get => text;
            set => SetProperty(ref text, value);
        }

        public string Description
        {
            get => description;
            set => SetProperty(ref description, value);
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
                var localdb = await ItemDatabase.Instance;
                var item = await localdb.GetItemAsync(itemId);
                //var item = await DataStore.GetItemAsync(itemId);
                Photo = item.Photo;
                Id = item.Id;
                Text = item.Text;
                Description = item.Description;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("ex message = "+ex.Message);
                Debug.WriteLine("ex trace = " + ex.StackTrace);
                Debug.WriteLine("Failed to Load Item");
            }
        }
    }
}
