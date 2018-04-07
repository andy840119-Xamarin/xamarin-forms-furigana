using furigana.Annotations;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Xamarin.Forms;

namespace furigana.Model
{
    /// <summary>
    ///     FuriganaModel
    ///     Contains all the FuriganaCharacter need
    /// </summary>
    public class FuriganaModel : INotifyPropertyChanged
    {
        private bool _autoChangeNewLine = true;
        private StackOrientation _orientation;

        /// <summary>
        ///     Ctor
        /// </summary>
        public FuriganaModel()
        {
            FuriganaTexts.CollectionChanged += (a, b) =>
            {
                OnPropertyChanged();
            };

            Style.PropertyChanged += (a, b) => { OnPropertyChanged(); };
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