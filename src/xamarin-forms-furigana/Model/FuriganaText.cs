using System;
using System.Collections.Generic;
using System.Text;

namespace furigana.Model
{
    /// <summary>
    /// define each of character
    /// </summary>
    public class FuriganaText
    {
        /// <summary>
        /// Furigana
        /// </summary>
        public string Furigana { get; set; }

        /// <summary>
        /// Character
        /// </summary>
        public string Character { get; set; }

        /// <summary>
        /// Romaji
        /// </summary>
        public string Romaji { get; set; }
    }
}
