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
        private Label _furiganaLabel;
        private Label _characterLabel;
        private Label _romajiLabel;

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
            }
        }

        /// <summary>
        /// Ctor
        /// </summary>
        public FuriganaCharacter()
        {
            Spacing = 5;

            Children.Clear();
            //furigana
            Children.Add(_furiganaLabel);
            //character
            Children.Add(_characterLabel);
            //romaji
            Children.Add(_romajiLabel);
        }
    }
}
