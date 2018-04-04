using CustomLayoutsDemo.ViewModels;
using furigana.Controls;
using Xamarin.Forms;

namespace CustomLayoutsDemo
{
    public class FuriganaPage : ContentPage
    {
        private readonly FuriganaPageViewModel viewModel;

        public FuriganaPage()
        {
            Title = "Furigana text";
            viewModel = new FuriganaPageViewModel();

            this.BindingContext = viewModel;

            Content = new StackLayout
            {
                Orientation = StackOrientation.Vertical,
                VerticalOptions = LayoutOptions.Center,
                Spacing = 20,
                Children =
                {
                    new FuriganaLabel()
                    {
                        BindingContext = viewModel.FuriganaModel
                    }
                }
            };
        }
    }
}