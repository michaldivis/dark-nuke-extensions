using SampleApp.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace SampleApp.Views
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