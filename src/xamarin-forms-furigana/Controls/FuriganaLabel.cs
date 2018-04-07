using System;
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
    public class FuriganaLabel<Character> : Layout<Character> where Character : FuriganaCharacter, new()
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
                Children.Clear();
                foreach (var singleChar in _furiganaModel.FuriganaTexts ?? new ObservableCollection<FuriganaText>())
                {
                    var furiganaText = new Character();
                    furiganaText.Text = singleChar;
                    furiganaText.Style = _furiganaModel.Style;
                    var width = furiganaText.Width;
                    _listText.Add(furiganaText);
                    Children.Add(furiganaText);
                }
            }
            //force layout
            ForceLayout();
        }

        /*
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
        */

        /*
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
        */

        /// <summary>
        /// TODO : IDK what does it means 
        /// </summary>
        /// <param name="widthConstraint"></param>
        /// <param name="heightConstraint"></param>
        /// <returns></returns>
        protected override SizeRequest OnSizeRequest(double widthConstraint, double heightConstraint)
        {
            if (WidthRequest > 0)
                widthConstraint = Math.Min(widthConstraint, WidthRequest);
            if (HeightRequest > 0)
                heightConstraint = Math.Min(heightConstraint, HeightRequest);

            var internalWidth = double.IsPositiveInfinity(widthConstraint)
                ? double.PositiveInfinity
                : Math.Max(0, widthConstraint);
            var internalHeight = double.IsPositiveInfinity(heightConstraint)
                ? double.PositiveInfinity
                : Math.Max(0, heightConstraint);

            return DoHorizontalMeasure(internalWidth, internalHeight);
        }

        /// <summary>
        /// TODO : IDK what does it means
        /// </summary>
        /// <param name="widthConstraint"></param>
        /// <param name="heightConstraint"></param>
        /// <returns></returns>
        private SizeRequest DoHorizontalMeasure(double widthConstraint, double heightConstraint)
        {
            var rowCount = 1;

            double width = 0;
            double height = 0;
            double minWidth = 0;
            double minHeight = 0;
            double widthUsed = 0;

            var Spacing = FuriganaModel?.Style?.CharacterSpacing ?? 0;

            foreach (var item in Children)
            {
                var size = item.GetSizeRequest(widthConstraint, heightConstraint);
                height = Math.Max(height, size.Request.Height);

                var newWidth = width + size.Request.Width + Spacing;
                if (newWidth > widthConstraint)
                {
                    rowCount++;
                    widthUsed = Math.Max(width, widthUsed);
                    width = size.Request.Width;
                }
                else
                {
                    width = newWidth;
                }

                minHeight = Math.Max(minHeight, size.Minimum.Height);
                minWidth = Math.Max(minWidth, size.Minimum.Width);
            }

            if (rowCount > 1)
            {
                width = Math.Max(width, widthUsed);
                height = (height + Spacing) * rowCount - Spacing; // via MitchMilam 
            }

            return new SizeRequest(new Size(width, height), new Size(minWidth, minHeight));
        }

        /// <summary>
        /// TODO : IDK what does it means
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        protected override void LayoutChildren(double x, double y, double width, double height)
        {
            var Spacing = FuriganaModel?.Style?.CharacterSpacing ?? 10;

            double rowHeight = 0;
            double yPos = y, xPos = x;

            foreach (var child in Children.Where(c => c.IsVisible))
            {
                var request = child.GetSizeRequest(width, height);

                var childWidth = request.Request.Width;
                var childHeight = request.Request.Height;

                rowHeight = Math.Max(rowHeight, childHeight);

                if (xPos + childWidth > width)
                {
                    xPos = x;
                    yPos += rowHeight + Spacing;
                    rowHeight = 0;
                }

                var region = new Rectangle(xPos, yPos, childWidth, childHeight);
                LayoutChildIntoBoundingRegion(child, region);
                xPos += region.Width + Spacing;
            }
        }
    }
}