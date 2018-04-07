using System.ComponentModel;
using System.Runtime.CompilerServices;
using furigana.Annotations;
using Xamarin.Forms;

namespace furigana.Model
{
    /// <summary>
    ///     define the size and position of text
    /// </summary>
    public class FuriganaStyle : INotifyPropertyChanged
    {
        private double _furiganaFontSize = 8;
        private double _characterFontSize = 15;
        private double _romajiFontSize = 7;
        private double _characterSpacing = 1;
        private double _furiganaSpacing;
        private double _romajiSpacing;
        private Color? _textColor;
        private bool _autoChangeNewLine = true;
        private StackOrientation _orientation = StackOrientation.Vertical;

        /// <summary>
        ///     size
        /// </summary>
        public double FuriganaFontSize
        {
            get => _furiganaFontSize;
            set
            {
                _furiganaFontSize = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        ///     size
        /// </summary>
        public double CharacterFontSize
        {
            get => _characterFontSize;
            set
            {
                _characterFontSize = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        ///     size
        /// </summary>
        public double RomajiFontSize
        {
            get => _romajiFontSize;
            set
            {
                _romajiFontSize = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        ///     spacing between two chatacters
        /// </summary>
        public double CharacterSpacing 
        {
            get => _characterSpacing;
            set
            {
                _characterSpacing = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        ///     spacing between furigana and character
        /// </summary>
        public double FuriganaSpacing
        {
            get => _furiganaSpacing;
            set
            {
                _furiganaSpacing = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        ///     spacing between romaji and character
        /// </summary>
        public double RomajiSpacing
        {
            get => _romajiSpacing;
            set
            {
                _romajiSpacing = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Text color
        /// </summary>
        public Color? TextColor
        {
            get => _textColor;
            set
            {
                _textColor = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// auto change new-line
        /// </summary>
        public bool AutoChangeNewLine
        {
            get => _autoChangeNewLine;
            set
            {
                if (_autoChangeNewLine != value)
                {
                    _autoChangeNewLine = value;
                    OnPropertyChanged();
                }
            }
        }

        /// <summary>
        /// orientation
        /// </summary>
        public StackOrientation Orientation
        {
            get => _orientation;
            set
            {
                if (_orientation != value)
                {
                    _orientation = value;
                    OnPropertyChanged();
                }
            }
        }

        /// <summary>
        /// Event
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// invoke
        /// </summary>
        /// <param name="propertyName"></param>
        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}