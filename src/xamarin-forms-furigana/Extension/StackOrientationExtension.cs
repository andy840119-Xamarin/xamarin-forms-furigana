﻿using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Furigana.Extension
{
    public static class StackOrientationExtension
    {
        /// <summary>
        /// get positive orientation
        /// </summary>
        /// <param name="orientation"></param>
        /// <returns></returns>
        public static StackOrientation GetOppositeOrientation(this StackOrientation orientation)
        {
            return orientation == StackOrientation.Vertical ? StackOrientation.Horizontal : StackOrientation.Vertical; ;
        }
    }
}
