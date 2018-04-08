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

        private int _totalLines = 1;

        protected StackOrientation Orientation => FuriganaModel?.Style?.Orientation ?? StackOrientation.Horizontal;
        protected double Spacing => FuriganaModel?.Style?.CharacterSpacing ?? 0;

        /// <summary>
        /// Ctor
        /// </summary>
        public FuriganaLabel()
        {
            
        }

        /// <summary>
        /// Model
        /// </summary>
        public FuriganaModel FuriganaModel
        {
            get => _furiganaModel;
            set
            {
                if (value == null)
                    throw new ArgumentNullException(nameof(FuriganaModel) + "Cannot be null");

                if (_furiganaModel != value)
                {
                    _furiganaModel = value;
                    _furiganaModel.PropertyChanged += (a, b) => { PropertyChange(); };
                }

                PropertyChange();
            }
        }

        /// <summary>
        /// Context change
        /// </summary>
        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();

            //change model
            if (BindingContext is FuriganaModel model)
                FuriganaModel = model;
        }

        /// <summary>
        /// property change
        /// now is clean and re-generate everying
        /// TODO : optomize this 
        /// </summary>
        protected virtual void PropertyChange()
        {
            if (FuriganaModel != null)
            {
                //generate list text
                Children.Clear();
                foreach (var singleChar in _furiganaModel.FuriganaTexts ?? new ObservableCollection<FuriganaText>())
                {
                    var furiganaText = new Character();
                    furiganaText.Text = singleChar;
                    furiganaText.Style = _furiganaModel.Style;
                    var width = furiganaText.Width;
                    Children.Add(furiganaText);
                }
            }

            //force layout
            ForceLayout();
        }

        /// <summary>
        /// TODO : IDK what does it means ,this code is from another place
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
        /// TODO : IDK what does it means ,this code is from another place
        /// </summary>
        /// <param name="widthConstraint"></param>
        /// <param name="heightConstraint"></param>
        /// <returns></returns>
        private SizeRequest DoHorizontalMeasure(double widthConstraint, double heightConstraint)
        {
            _totalLines = 1;
            bool newLine = false;

            double width = 0;
            double height = 0;
            double minWidth = 0;
            double minHeight = 0;
            double widthUsed = 0;
            double heightUsed = 0;


            if (Orientation == StackOrientation.Horizontal)
            {
                foreach (var item in Children)
                {
                    var size = item.Measure(widthConstraint, heightConstraint);
                    height = Math.Max(height, size.Request.Height);

                    var newWidth = width + size.Request.Width + Spacing;
                    if (newWidth > widthConstraint || newLine)
                    {
                        _totalLines++;
                        widthUsed = Math.Max(width, widthUsed);
                        width = size.Request.Width;
                        newLine = false;
                    }
                    else
                    {
                        width = newWidth;
                    }

                    //change new line in next character
                    if (item.Text.ChangeNewLine)
                        newLine = true;


                    minHeight = Math.Max(minHeight, size.Minimum.Height);
                    minWidth = Math.Max(minWidth, size.Minimum.Width);
                }

                if (_totalLines > 1)
                {
                    width = Math.Max(width, widthUsed);
                    height = (height + Spacing) * _totalLines - Spacing; // via MitchMilam 
                }

                return new SizeRequest(new Size(width, height), new Size(minWidth, minHeight));
            }
            else
            {
                foreach (var item in Children)
                {
                    var size = item.Measure(widthConstraint, heightConstraint);
                    width = Math.Max(width, size.Request.Width);

                    var newHeight = height + size.Request.Height + Spacing;
                    if (newHeight > heightConstraint || newLine)
                    {
                        _totalLines++;
                        heightUsed = Math.Max(height, heightUsed);
                        height = size.Request.Height;
                        newLine = false;
                    }
                    else
                    {
                        height = newHeight;
                    }

                    //change new line in next character
                    if (item.Text.ChangeNewLine)
                        newLine = true;

                    minHeight = Math.Max(minHeight, size.Minimum.Height);
                    minWidth = Math.Max(minWidth, size.Minimum.Width);
                }

                if (_totalLines > 1)
                {
                    width = Math.Max(width, widthUsed);
                    height = (height + Spacing) * _totalLines - Spacing; // via MitchMilam 
                }

                return new SizeRequest(new Size(width, height), new Size(minWidth, minHeight));
            }
            
        }

        /// <summary>
        /// TODO : IDK what does it means ,this code is from another place
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        protected override void LayoutChildren(double x, double y, double width, double height)
        {
            double rowWidth = 0;
            double rowHeight = 0;
            double yPos = y, xPos = x;
            _totalLines = 1;

            bool newLine = false;

            if (Orientation == StackOrientation.Horizontal)
            {
                foreach (var child in Children.Where(c => c.IsVisible))
                {
                    var request = child.Measure(width, height);

                    var childWidth = request.Request.Width;
                    var childHeight = request.Request.Height;

                    rowHeight = Math.Max(rowHeight, childHeight);

                    if (xPos + childWidth > width || newLine)
                    {
                        xPos = x;
                        yPos += rowHeight + Spacing;
                        rowHeight = 0;
                        newLine = false;
                        _totalLines++;
                    }

                    //change new line in next character
                    if (child.Text.ChangeNewLine)
                        newLine = true;

                    var region = new Rectangle(xPos, yPos, childWidth, childHeight);
                    LayoutChildIntoBoundingRegion(child, region);
                    xPos += region.Width + Spacing;
                }
            }
            else
            {
                //cal the total lines first
                foreach (var child in Children.Where(c => c.IsVisible))
                {
                    var request = child.Measure(width, height);
                    var childWidth = request.Request.Width;
                    var childHeight = request.Request.Height;

                    rowWidth = Math.Max(rowWidth, childWidth);

                    if (yPos + childHeight > height || newLine)
                    {
                        xPos = xPos + rowWidth + Spacing;
                        yPos = y;
                        rowWidth = 0;
                        newLine = false;
                        _totalLines++;
                    }

                    //change new line in next character
                    if (child.Text.ChangeNewLine)
                        newLine = true;

                    var region = new Rectangle(xPos, yPos, childWidth, childHeight);
                    LayoutChildIntoBoundingRegion(child, region);
                    yPos += region.Height + Spacing;
                }

                
                yPos = y;
                xPos = x;

                //adjust the position
                foreach (var child in Children.Where(c => c.IsVisible))
                {
                    var request = child.Measure(width, height);
                    var childWidth = request.Request.Width;
                    var childHeight = request.Request.Height;

                    rowWidth = Math.Max(rowWidth, childWidth);
                    var lineSpacing = rowWidth + Spacing;

                    if (yPos + childHeight > height || newLine)
                    {
                        xPos = xPos - lineSpacing;
                        yPos = y;
                        rowWidth = 0;
                        newLine = false;
                    }

                    //change new line in next character
                    if (child.Text.ChangeNewLine)
                        newLine = true;

                    var region = new Rectangle(xPos + (lineSpacing) * (_totalLines - 1), yPos, childWidth, childHeight);
                    LayoutChildIntoBoundingRegion(child, region);
                    yPos += region.Height + Spacing;
                }
                
            }
                
        }
    }
}