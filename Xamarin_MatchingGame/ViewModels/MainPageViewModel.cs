using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;
using Xamarin_MatchingGame.Models;
using Xamarin_MatchingGame.Views;

namespace Xamarin_MatchingGame.ViewModels
{
    public class MainPageViewModel : INotifyPropertyChanged
    {   
        public event PropertyChangedEventHandler PropertyChanged;
        double _SliderLevel = 4; //starting value
        public double SliderLevel
        {
            get
            {
                return _SliderLevel;
            }
            set
            {
                _SliderLevel = value;
                var args = new PropertyChangedEventArgs(nameof(SliderLevel));
                PropertyChanged?.Invoke(this, args);
            }
        }

        public Command BeginGameCommand { get; }

        public MainPageViewModel()
        {
            BeginGameCommand = new Command(async () =>
            {
                var gameGrid = new GameGrid() { SliderValue = SliderLevel };
                var gameViewModel = new GamePageViewModel(gameGrid);
                var gamePage = new GamePage(gameViewModel);
                gamePage.BindingContext = gameViewModel;

                await Application.Current.MainPage.Navigation.PushAsync(gamePage);
            });
        }
    }
}
