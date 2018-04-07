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
        ///     Event
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        ///     Invoke
        /// </summary>
        /// <param name="propertyName"></param>
        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}