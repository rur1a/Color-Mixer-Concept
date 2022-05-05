using System.Collections.Generic;
using Code.Logic;
using Code.Produces;
using Code.Produces.ProduceSpawn;

namespace Code.UI
{
    public class UIMediator : ICleanUp
    {
        private readonly FridgeView _fridgeView;
        private readonly ScoreView _scoreView;
        public EndLevelMessage WinScreen { get; private set; }
        public EndLevelMessage LooseScreen { get; private set; }

        public UIMediator(FridgeView fridgeView, ScoreView scoreView, EndLevelMessage winScreen, EndLevelMessage looseScreen)
        {
            _fridgeView = fridgeView;
            _scoreView = scoreView;
            WinScreen = winScreen;
            LooseScreen = looseScreen;
        }

        public void HideFridge()      => _fridgeView.gameObject.SetActive(false);
        public void ShowFridge()      => _fridgeView.gameObject.SetActive(true);
        public void ShowWinScreen()   => WinScreen.gameObject.SetActive(true);
        public void HideWinScreen()   => WinScreen.gameObject.SetActive(false);
        public void ShowLooseScreen() => LooseScreen.gameObject.SetActive(true);
        public void HideLooseScreen() => LooseScreen.gameObject.SetActive(false);

        public void UpdateFridge(Fridge fridge, ProduceProvider produceProvider) => 
            _fridgeView.Init(produceProvider.All(), fridge);

        public void CleanUp()
        {
            _fridgeView.CleanUp();
            _scoreView.CleanUp();
            ShowFridge();
            HideWinScreen();
            HideLooseScreen();
        }
    }
}