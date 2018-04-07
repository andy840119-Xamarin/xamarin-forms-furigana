using furigana.Model;
using Furigana.Extension;
using System;
using Xamarin.Forms;

namespace furigana.Controls
{
    /// <summary>
    ///     Character
    /// </summary>
    public class FuriganaCharacter : StackLayout
    {
        private Label _characterLabel;
        private Label _furiganaLabel;
        private Label _romajiLabel;

        private BoxView _furiganaSpacingBox;
        private BoxView _romajiSpacingBox;

        private FuriganaStyle _furiganaStyle;
        private FuriganaText _furiganaText;

        /// <summary>
        ///     Ctor
        /// </summary>
        public FuriganaCharacter()
        {
            Spacing = 0;
            Orientation = StackOrientation.Horizontal;
            ChangeOrientation(StackOrientation.Vertical);
        }

        /// <summary>
        ///     Text
        /// </summary>
        public FuriganaText Text
        {
            get => _furiganaText;
            set
            {
                if (value == null)
                    throw new ArgumentNullException(nameof(FuriganaText) + "Cannot be null");

                if (_furiganaText != value)
                {
                    _furiganaText = value;
                    _furiganaText.PropertyChanged += (a, b) => { UpdateText(); };
                }
                UpdateText();
            }
        }

        /// <summary>
        ///     Style
        /// </summary>
        public new FuriganaStyle Style
        {
            get => _furiganaStyle;
            set
            {
                _furiganaStyle = value ?? throw new ArgumentNullException(nameof(FuriganaStyle) + "Cannot be null");
                
                //orientation
                var characterOrientation = _furiganaStyle.Orientation.GetOppositeOrientation();
                ChangeOrientation(characterOrientation);

                //style
                UpdateStyle();
            }
        }

        /// <summary>
        ///     Update style
        /// </summary>
        protected void UpdateStyle()
        {
            //font size
            _furiganaLabel.FontSize = _furiganaStyle.FuriganaFontSize;
            _characterLabel.FontSize = _furiganaStyle.CharacterFontSize;
            _romajiLabel.FontSize = _furiganaStyle.RomajiFontSize;
            if (_furiganaStyle.TextColor != null && Text.TextColor == null)
            {
                //color
                _furiganaLabel.TextColor = _furiganaStyle.TextColor.Value;
                _characterLabel.TextColor = _furiganaStyle.TextColor.Value;
                _romajiLabel.TextColor = _furiganaStyle.TextColor.Value;
            }
            if (Orientation == StackOrientation.Vertical)
            {
                //spacing
                _furiganaSpacingBox.HeightRequest = _furiganaStyle.FuriganaSpacing;
                _romajiSpacingBox.HeightRequest = _furiganaStyle.RomajiSpacing;
            }
            else
            {
                //spacing
                _furiganaSpacingBox.WidthRequest = _furiganaStyle.FuriganaSpacing;
                _romajiSpacingBox.WidthRequest = _furiganaStyle.RomajiSpacing;
            }
        }

        /// <summary>
        ///     Update text
        /// </summary>
        protected void UpdateText()
        {
            if (Text != null)
            {
                _furiganaLabel.Text = Text.Furigana;
                _characterLabel.Text = Text.Character;
                _romajiLabel.Text = Text.Romaji;

                if (_furiganaText.TextColor != null)
                {
                    _furiganaLabel.TextColor = Text.TextColor.Value;
                    _characterLabel.TextColor = Text.TextColor.Value;
                    _romajiLabel.TextColor = Text.TextColor.Value;
                }
            }
        }

        /// <summary>
        ///     Change orientation
        /// </summary>
        /// <param name="orientation">Character's oriention,not the string's orientation. They are relativce</param>
        protected virtual void ChangeOrientation(StackOrientation orientation)
        {
            if (Orientation != orientation)
            {
                _characterLabel = new Label
                {
                    HorizontalTextAlignment = TextAlignment.Center,
                    VerticalTextAlignment = TextAlignment.Center,
                };

                _furiganaLabel = new Label
                {
                    HorizontalTextAlignment = TextAlignment.Center,
                    VerticalTextAlignment = TextAlignment.Center,
                };

                _romajiLabel = new Label
                {
                    HorizontalTextAlignment = TextAlignment.Center,
                    VerticalTextAlignment = TextAlignment.Center,
                };

                _furiganaSpacingBox = new BoxView();
                _romajiSpacingBox = new BoxView();

                if (orientation == StackOrientation.Vertical)
                {
                    Orientation = StackOrientation.Vertical;
                    _furiganaSpacingBox.WidthRequest = 0;
                    _romajiSpacingBox.WidthRequest = 0;

                    //rotate
                    _romajiLabel.Rotation = 0;
                    //clear
                    Children.Clear();
                    //furigana
                    Children.Add(_furiganaLabel);
                    //spacing
                    Children.Add(_furiganaSpacingBox);
                    //character
                    Children.Add(_characterLabel);
                    //spacing
                    Children.Add(_romajiSpacingBox);
                    //romaji
                    Children.Add(_romajiLabel);
                }
                else
                {
                    Orientation = StackOrientation.Horizontal;
                    if (Style != null)
                    {
                        _furiganaLabel.WidthRequest = Style.FuriganaFontSize;
                        _characterLabel.WidthRequest = Style.CharacterFontSize;

                        //rotate
                        _romajiLabel.Rotation = 90;
                        //because even rotate 90 degree, width still affect stackLayout,
                        //so add *3 to tricky aviod that(romaji text)
                        _romajiLabel.WidthRequest = Style.RomajiFontSize * 3; 
                    }
                    _furiganaSpacingBox.HeightRequest = 0;
                    _romajiSpacingBox.HeightRequest = 0;
                    //clear
                    Children.Clear();
                    //romaji
                    Children.Add(_romajiLabel);
                    //spacing
                    Children.Add(_romajiSpacingBox);
                    //character
                    Children.Add(_characterLabel);
                    //spacing
                    Children.Add(_furiganaSpacingBox);
                    //furigana
                    Children.Add(_furiganaLabel);
                }
                UpdateText();
            }
        }
    }
}