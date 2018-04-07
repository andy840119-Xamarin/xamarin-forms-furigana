using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using furigana.Model;
using Furigana.Extension;
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
        private List<Character> _listText = new List<Character>();
        private List<StackLayout> _listLayout = new List<StackLayout>();

        public FuriganaLabel()
        {
            //VerticalOptions = LayoutOptions.FillAndExpand;
            //HorizontalOptions = LayoutOptions.FillAndExpand;
        }

        public FuriganaModel FuriganaModel
        {
            get => _furiganaModel;
            set
            {
                _furiganaModel = value;
                _furiganaModel.PropertyChanged += (a, b) => { PropertyChange(); };
                PropertyChange();
            }
        }

        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();
            if (BindingContext is FuriganaModel model)
                FuriganaModel = model;
        }

        protected virtual void PropertyChange()
        {
            if (FuriganaModel != null)
            {
                //generate list text
                _listText.Clear();
                foreach (var singleChar in _furiganaModel.FuriganaTexts ?? new ObservableCollection<FuriganaText>())
                {
                    var furiganaText = new Character();
                    furiganaText.Text = singleChar;
                    furiganaText.Style = _furiganaModel.Style;
                    var width = furiganaText.Width;
                    _listText.Add(furiganaText);
                }
                //update spacing
                Spacing = _furiganaModel?.Style?.CharacterSpacing ?? 0;
                //orientation
                Orientation = _furiganaModel.Style.Orientation.GetOppositeOrientation();
                //TODO : auto change new-line
                ArrangeLayout();
            }
        }

        protected virtual void ArrangeLayout()
        {
            Children.Clear();
            //add all the text into stacklayout
            foreach (var singleChar in _listText)
            {
                //create new line
                if (_listText.IndexOf(singleChar) % 10 == 0)
                {
                    var newlayout = new StackLayout()
                    {
                        //VerticalOptions = LayoutOptions.FillAndExpand,
                        //HorizontalOptions = LayoutOptions.FillAndExpand,
                        Orientation = FuriganaModel.Style.Orientation
                    };
                    Children.Add(newlayout);
                }

                if (Children.LastOrDefault() is StackLayout layout)
                {
                    Debug.WriteLine("width : " + layout.Width + " height : " + layout.Height);
                    layout.Children.Add(singleChar);
                }
            }
        }

        protected override void OnSizeAllocated(double width, double height)
        {
            Debug.WriteLine("width0 : " + Width + " height0 : " + Height);
            base.OnSizeAllocated(width, height);
            if (Width > 0 && Height > 0)
            {
                //if enable auto-change new line
                if (FuriganaModel?.Style?.AutoChangeNewLine ?? false)
                {
                    //ArrangeLayout();
                }   
            }
        }
    }
}