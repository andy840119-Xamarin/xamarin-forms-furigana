using System.ComponentModel;

namespace furigana.Model
{
    /// <summary>
    ///     define the size and position of text
    /// </summary>
    public class FuriganaStyle : INotifyPropertyChanged
    {
        /// <summary>
        ///     size
        /// </summary>
        public double FuriganaFontSize { get; set; } = 8;

        /// <summary>
        ///     size
        /// </summary>
        public double CharacterFontSize { get; set; } = 15;

        /// <summary>
        ///     size
        /// </summary>
        public double RomajiFontSize { get; set; } = 7;

        /// <summary>
        ///     spacing between chatacters
        /// </summary>
        public double CharacterSpacing { get; set; } = 1;

        /// <summary>
        ///     spacing between furigana and character
        /// </summary>
        public double FuriganaSpacing { get; set; } = 0;

        /// <summary>
        ///     spacing between romaji and character
        /// </summary>
        public double RomajiSpacing { get; set; } = 0;

        public event PropertyChangedEventHandler PropertyChanged;
    }
}