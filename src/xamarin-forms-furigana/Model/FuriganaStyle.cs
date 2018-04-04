using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using Xamarin.Forms;

namespace furigana.Model
{
    /// <summary>
    /// define the size and position of text
    /// </summary>
    public class FuriganaStyle : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// size
        /// </summary>
        public double FuriganaFontSize { get; set; }

        /// <summary>
        /// size
        /// </summary>
        public double CharacterFontSize { get; set; }

        /// <summary>
        /// size
        /// </summary>
        public double RomajiFontSize { get; set; }
    }
}
