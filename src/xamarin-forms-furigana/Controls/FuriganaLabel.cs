using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using furigana.Model;
using Xamarin.Forms;

namespace furigana.Controls
{
    /// <summary>
    /// Label
    /// contain list of <see cref="FuriganaCharacter"/>
    /// </summary>
    public class FuriganaLabel : FuriganaLabel<FuriganaCharacter>
    {

    }

    /// <summary>
    /// Label
    /// contain list of <see cref="FuriganaText"/>
    /// </summary>
    public class FuriganaLabel<Character> : StackLayout where Character : FuriganaCharacter , new ()
    {
        //list drawable text
        private List<FuriganaText> _listText;

        public FuriganaLabel()
        {
            Orientation = StackOrientation.Horizontal;
        }

        private FuriganaModel _furiganaModel;
        public FuriganaModel FuriganaModel
        {
            get => _furiganaModel;
            set
            {
                _furiganaModel = value;
                _furiganaModel.PropertyChanged += (a, b) =>
                {
                    propertyChange();
                };
            }
        }

        private void propertyChange()
        {
            Children.Clear();
            foreach (var singleChar in _furiganaModel.FuriganaTexts ?? new ObservableCollection<Model.FuriganaText>())
            {
                Character furiganaText = new Character();
                furiganaText.Text = singleChar;
                furiganaText.Style = _furiganaModel.Style;
                Children.Add(furiganaText);
            }
        }
    }

    
}
