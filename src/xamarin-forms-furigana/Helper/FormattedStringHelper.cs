using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Furigana.Helper
{
    /// <summary>
    /// Convert text to FormattedString
    /// </summary>
    public static class FormattedStringHelper
    {
        /// <summary>
        /// Gemerate Vertical text
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static FormattedString MakeTextVertical(string str)
        {
            FormattedString formattedString = new FormattedString();
            
            //generate lise spans
            for(int i=0;i<str.Length;i++)
            {
                //text
                formattedString.Spans.Add(new Span() { Text = str[i].ToString() });
                //new line
                if(i< str.Length-1)
                    formattedString.Spans.Add(new Span { Text = Environment.NewLine });

            }

            return formattedString;
        }

        /// <summary>
        /// Gemerate Vertical text
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static FormattedString MakeTextHorizontal(string str)
        {
            return new FormattedString
            {
                Spans =
                {
                    new Span { Text = str },        
                }
            };
        }
    }
}
