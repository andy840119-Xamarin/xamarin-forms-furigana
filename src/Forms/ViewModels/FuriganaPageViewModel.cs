using furigana.Model;

namespace CustomLayoutsDemo.ViewModels
{
    public class FuriganaPageViewModel : BaseViewModel
    {
        public FuriganaModel FuriganaModel = new FuriganaModel();

        public FuriganaPageViewModel()
        {
            FuriganaModel.Style = new FuriganaStyle
            {
                FuriganaFontSize = 10,
                CharacterFontSize = 20,
                RomajiFontSize = 12
            };
            FuriganaModel.FuriganaTexts.Clear();
            FuriganaModel.FuriganaTexts.Add(new FuriganaText("終", "お", "o"));
            FuriganaModel.FuriganaTexts.Add(new FuriganaText("わ", "", "wa"));
            FuriganaModel.FuriganaTexts.Add(new FuriganaText("る", "", "ru"));
            FuriganaModel.FuriganaTexts.Add(new FuriganaText("ま", "", "ma"));
            FuriganaModel.FuriganaTexts.Add(new FuriganaText("で", "", "de"));
            FuriganaModel.FuriganaTexts.Add(new FuriganaText("は", "", "waaaaaaaaa"));
            FuriganaModel.FuriganaTexts.Add(new FuriganaText("終", "おおおおおお"));
            FuriganaModel.FuriganaTexts.Add(new FuriganaText("わ"));
            FuriganaModel.FuriganaTexts.Add(new FuriganaText("ら"));
            FuriganaModel.FuriganaTexts.Add(new FuriganaText("な"));
            FuriganaModel.FuriganaTexts.Add(new FuriganaText("い"));
            FuriganaModel.FuriganaTexts.Add(new FuriganaText("よ"));
            FuriganaModel.FuriganaTexts.Add(new FuriganaText("..."));
            //demo for multi-line
            //FuriganaModel.FuriganaTexts.Add(new FuriganaText("終", "お", "o"));
            //FuriganaModel.FuriganaTexts.Add(new FuriganaText("わ", "", "wa"));
            //FuriganaModel.FuriganaTexts.Add(new FuriganaText("る", "", "ru"));
            //FuriganaModel.FuriganaTexts.Add(new FuriganaText("ま", "", "ma"));
            //FuriganaModel.FuriganaTexts.Add(new FuriganaText("で", "", "de"));
            //FuriganaModel.FuriganaTexts.Add(new FuriganaText("は", "", "waaaaaaaaa"));
            //FuriganaModel.FuriganaTexts.Add(new FuriganaText("終", "おおおおおお"));
            //FuriganaModel.FuriganaTexts.Add(new FuriganaText("わ"));
            //FuriganaModel.FuriganaTexts.Add(new FuriganaText("ら"));
            //FuriganaModel.FuriganaTexts.Add(new FuriganaText("な"));
            //FuriganaModel.FuriganaTexts.Add(new FuriganaText("い"));
            //FuriganaModel.FuriganaTexts.Add(new FuriganaText("よ"));
        }
    }
}