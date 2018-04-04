using System.Collections.Generic;
using System.Linq;
using furigana.Model;
using Xamarin.Forms;

namespace CustomLayoutsDemo.ViewModels
{
    public class FuriganaPageViewModel : BaseViewModel
    {
        public FuriganaPageViewModel()
        {
            FuriganaModel.Style = new FuriganaStyle()
            {
                FuriganaFontSize = 8,
                CharacterFontSize = 16,
                RomajiFontSize = 6,
            };
            FuriganaModel.FuriganaTexts.Clear();
            FuriganaModel.FuriganaTexts.Add(new FuriganaText("終", "お"));
            FuriganaModel.FuriganaTexts.Add(new FuriganaText("わ"));
            FuriganaModel.FuriganaTexts.Add(new FuriganaText("る"));
            FuriganaModel.FuriganaTexts.Add(new FuriganaText("ま"));
            FuriganaModel.FuriganaTexts.Add(new FuriganaText("で"));
            FuriganaModel.FuriganaTexts.Add(new FuriganaText("は"));
            FuriganaModel.FuriganaTexts.Add(new FuriganaText("終", "お"));
            FuriganaModel.FuriganaTexts.Add(new FuriganaText("わ"));
            FuriganaModel.FuriganaTexts.Add(new FuriganaText("ら"));
            FuriganaModel.FuriganaTexts.Add(new FuriganaText("な"));
            FuriganaModel.FuriganaTexts.Add(new FuriganaText("い"));
            FuriganaModel.FuriganaTexts.Add(new FuriganaText("よ"));
        }

        public FuriganaModel FuriganaModel = new FuriganaModel();
    }
}