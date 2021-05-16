using MvvmTestApp.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace MvvmTestApp.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}