using furigana.Model;
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

        private readonly BoxView _furiganaSpacingBox = new BoxView {WidthRequest = 0};

        private FuriganaStyle _furiganaStyle;

        private FuriganaText _furiganaText;

        private readonly Label _romajiLabel = new Label
        {
            HorizontalTextAlignment = TextAlignment.Center
        };

        private readonly BoxView _romajiSpacingBox = new BoxView {WidthRequest = 0};

        /// <summary>
        ///     Ctor
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
    }
}