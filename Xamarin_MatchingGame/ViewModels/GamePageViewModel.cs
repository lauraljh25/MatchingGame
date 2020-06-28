using System;
using System.Collections.Generic;
using System.Text;
using Xamarin_MatchingGame.Models;

namespace Xamarin_MatchingGame.ViewModels
{
    public class GamePageViewModel
    {
        public GameGrid gameGrid {get; set;}
        public GamePageViewModel(GameGrid gameGrid)
        {
            this.gameGrid = gameGrid;
        }
    }
}
