using System.ComponentModel;
using System.Runtime.CompilerServices;
using furigana.Annotations;

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
        ///     spacing between chatacters
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