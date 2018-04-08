using CustomLayoutsDemo.ViewModels;
using furigana.Controls;
using Xamarin.Forms;

namespace CustomLayoutsDemo
{
    public class FuriganaPage : ContentPage
    {
        private readonly FuriganaPageViewModel _viewModel;

        /// <summary>
        ///     Ctor
        /// </summary>
        public FuriganaPage()
        {
            Title = "Furigana text";
            _viewModel = new FuriganaPageViewModel();
            BindingContext = _viewModel;

            Content = new FuriganaLabel
            {
                BindingContext = _viewModel.FuriganaModel
            };
        }
    }
}