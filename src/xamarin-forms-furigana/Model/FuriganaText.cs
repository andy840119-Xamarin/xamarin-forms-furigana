using Xamarin.Forms;

namespace furigana.Model
{
    /// <summary>
    ///     define each of character
    /// </summary>
    public class FuriganaText
    {
        /// <summary>
        ///     Ctor
        /// </summary>
        public FuriganaText()
        {
        }

        /// <summary>
        ///     Ctor
        /// </summary>
        /// <param name="character"></param>
        /// <param name="furigana"></param>
        /// <param name="romaji"></param>
        public FuriganaText(string character, string furigana = "", string romaji = "")
        {
            Character = character;
            Furigana = furigana;
            Romaji = romaji;
        }

        /// <summary>
        ///     Furigana
        /// </summary>
        public string Furigana { get; set; }

        /// <summary>
        ///     Character
        /// </summary>
        public string Character { get; set; }

        /// <summary>
        ///     Romaji
        /// </summary>
        public string Romaji { get; set; }

        /// <summary>
        /// Text color
        /// </summary>
        public Color? TextColor { get; set; } 
    }
}