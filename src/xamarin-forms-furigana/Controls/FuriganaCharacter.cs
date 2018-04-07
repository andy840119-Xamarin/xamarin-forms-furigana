﻿using furigana.Model;
using Xamarin.Forms;

namespace furigana.Controls
{
    /// <summary>
    ///     Character
    /// </summary>
    public class FuriganaCharacter : StackLayout
    {
        private readonly Label _characterLabel = new Label
        {
            HorizontalTextAlignment = TextAlignment.Center
        };

        private readonly Label _furiganaLabel = new Label
        {
            HorizontalTextAlignment = TextAlignment.Center
        };

        private readonly Label _romajiLabel = new Label
        {
            HorizontalTextAlignment = TextAlignment.Center
        };

        private readonly BoxView _furiganaSpacingBox = new BoxView { WidthRequest = 0 };
        private readonly BoxView _romajiSpacingBox = new BoxView {WidthRequest = 0};

        private FuriganaStyle _furiganaStyle;
        private FuriganaText _furiganaText;

        /// <summary>
        ///     Ctor
        /// </summary>
        public FuriganaCharacter()
        {
            Spacing = 0;
        }

        /// <summary>
        /// Text
        /// </summary>
        public FuriganaText Text
        {
            get => _furiganaText;
            set
            {
                _furiganaText = value;
                _furiganaLabel.Text = _furiganaText.Furigana;
                _characterLabel.Text = _furiganaText.Character;
                _romajiLabel.Text = _furiganaText.Romaji;

                if (_furiganaText.TextColor != null)
                {
                    _furiganaLabel.TextColor = _furiganaText.TextColor.Value;
                    _characterLabel.TextColor = _furiganaText.TextColor.Value;
                    _romajiLabel.TextColor = _furiganaText.TextColor.Value;
                }
            }
        }

        /// <summary>
        /// Style
        /// </summary>
        public new FuriganaStyle Style
        {
            get => _furiganaStyle;
            set
            {
                _furiganaStyle = value;
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
                //spacing
                _furiganaSpacingBox.HeightRequest = _furiganaStyle.FuriganaSpacing;
                _romajiSpacingBox.HeightRequest = _furiganaStyle.RomajiSpacing;
                //orientation
                ChangeOrientation();
            }
        }

        /// <summary>
        /// Change orientation
        /// </summary>
        protected virtual void ChangeOrientation()
        {
            if (_furiganaStyle.Orientation == StackOrientation.Horizontal)
            {
                Orientation = StackOrientation.Vertical;
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
                //rotate
                _romajiLabel.Rotation = 90;
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
        }
    }
}