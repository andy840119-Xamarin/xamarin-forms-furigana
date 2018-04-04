using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace furigana.Controls
{
    /// <summary>
    /// Label
    /// contain list of <see cref="FuriganaCharacter"/>
    /// </summary>
    public class FuriganaLabel : FuriganaLabel<FuriganaCharacter>
    {

    }

    /// <summary>
    /// Label
    /// contain list of <see cref="FuriganaText"/>
    /// </summary>
    public class FuriganaLabel<FuriganaText> : StackLayout
    {
        //list drawable text
        private List<FuriganaText> _listText;

        public FuriganaLabel()
        {
            Orientation = StackOrientation.Horizontal;
        }
    }
}
