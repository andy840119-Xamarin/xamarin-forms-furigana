using System.Collections.Generic;
using System.Collections.ObjectModel;
using furigana.Model;
using Xamarin.Forms;

namespace furigana.Controls
{
    /// <summary>
    ///     Label
    ///     contain list of <see cref="FuriganaCharacter" />
    /// </summary>
    public class FuriganaLabel : FuriganaLabel<FuriganaCharacter>
    {

    }

    /// <summary>
    ///     Label
    ///     contain list of <see cref="FuriganaText" />
    /// </summary>
    public class FuriganaLabel<Character> : StackLayout where Character : FuriganaCharacter, new()
    {
        private FuriganaModel _furiganaModel;

        //list drawable text
        private List<FuriganaText> _listText;

        public FuriganaLabel()
        {
            Orientation = StackOrientation.Horizontal;
        }

        public FuriganaModel FuriganaModel
        {
            get => _furiganaModel;
            set
            {
                _furiganaModel = value;
                _furiganaModel.PropertyChanged += (a, b) => { propertyChange(); };
                propertyChange();
            }
        }

        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();
            if (BindingContext is FuriganaModel model)
                FuriganaModel = model;
        }

        private void propertyChange()
        {
            Children.Clear();
            foreach (var singleChar in _furiganaModel.FuriganaTexts ?? new ObservableCollection<FuriganaText>())
            {
                var furiganaText = new Character();
                furiganaText.Text = singleChar;
                furiganaText.Style = _furiganaModel.Style;
                Children.Add(furiganaText);
            }

            //update spacing
            Spacing = _furiganaModel?.Style?.CharacterSpacing ?? 0;
            //TODO : orientation

            //TODO : auto change new-line
        }
    }
}