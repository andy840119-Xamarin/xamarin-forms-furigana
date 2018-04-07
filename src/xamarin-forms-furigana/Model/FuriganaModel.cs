using System.Collections.ObjectModel;
using System.ComponentModel;

namespace furigana.Model
{
    /// <summary>
    ///     FuriganaModel
    ///     Contains all the FuriganaCharacter need
    /// </summary>
    public class FuriganaModel : INotifyPropertyChanged
    {
        private bool _autoChangeNewLine = true;

        /// <summary>
        ///     Ctor
        /// </summary>
        public FuriganaModel()
        {
            FuriganaTexts.CollectionChanged += (a, b) =>
            {
                PropertyChanged?.Invoke(a, new PropertyChangedEventArgs("喵"));
            };

            Style.PropertyChanged += (a, b) => { PropertyChanged?.Invoke(a, b); };
        }

        /// <summary>
        ///     list character set
        /// </summary>
        public ObservableCollection<FuriganaText> FuriganaTexts { get; set; } =
            new ObservableCollection<FuriganaText>();

        /// <summary>
        ///     Style
        /// </summary>
        public FuriganaStyle Style { get; set; } = new FuriganaStyle();

        /// <summary>
        /// auto change new-line
        /// </summary>
        public bool AutoChangeNewLine {
            get => _autoChangeNewLine;
            set
            {
                if (_autoChangeNewLine != value)
                {
                    _autoChangeNewLine = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("喵"));
                }
            }
        } 

        public event PropertyChangedEventHandler PropertyChanged;
    }
}