using System;
using System.Collections.Generic;
using System.Text;
using furigana.Model;
using Xamarin.Forms;

namespace furigana.Controls
{
    /// <summary>
    /// Character
    /// </summary>
    public class FuriganaCharacter : StackLayout
    {
        private Label _furiganaLabel = new Label()
        {
            HorizontalTextAlignment = TextAlignment.Center,
        };
        private Label _characterLabel = new Label()
        {
            HorizontalTextAlignment = TextAlignment.Center,
        };
        private Label _romajiLabel = new Label()
        {
            HorizontalTextAlignment = TextAlignment.Center,
        };

        private BoxView _furiganaSpacingBox = new BoxView{WidthRequest = 0};
        private BoxView _romajiSpacingBox = new BoxView{WidthRequest = 0};

        private FuriganaText _furiganaText;
        public FuriganaText Text
        {
            get => _furiganaText;
            set
            {
                _furiganaText = value;
                _furiganaLabel.Text = _furiganaText.Furigana;
                _characterLabel.Text = _furiganaText.Character;
                _romajiLabel.Text = _furiganaText.Romaji;
            }
        }

        private FuriganaStyle _furiganaStyle;
        public FuriganaStyle Style
        {
            get => _furiganaStyle;
            set
            {
                _furiganaStyle = value;
                _furiganaLabel.FontSize = _furiganaStyle.FuriganaFontSize;
                _characterLabel.FontSize = _furiganaStyle.CharacterFontSize;
                _romajiLabel.FontSize = _furiganaStyle.RomajiFontSize;
                _furiganaSpacingBox.HeightRequest = _furiganaStyle.FuriganaSpacing;
                _romajiSpacingBox.HeightRequest = _furiganaStyle.RomajiSpacing;
            }
        }

        /// <summary>
        /// Ctor
        /// </summary>
        public FuriganaCharacter()
        {
            Spacing = 0;

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
    }
}
