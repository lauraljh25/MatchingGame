using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin_MatchingGame.Models;
using Xamarin_MatchingGame.ViewModels;

namespace Xamarin_MatchingGame.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GamePage : ContentPage
    {
        int? buttonPressed_1;
        int? buttonPressed_2;
        List<Button> Buttons;

        public GamePage(GamePageViewModel gamePageViewModel)
        {
            InitializeComponent();

            buttonPressed_1 = null;
            buttonPressed_2 = null;

            FillGrid(gamePageViewModel.gameGrid); 
        }

        private void FillGrid(GameGrid gameGrid)
        {
            Grid grid = new Grid();
            Buttons = GenerateButtonList(gameGrid);

            int columnsNum = gameGrid.GridColumns;
            int rowsNum = gameGrid.GridRows;
            int index = 0;

            for (int x = 0; x < columnsNum; x++)
            {
                for (int y = 0; y < rowsNum; y++)
                {
                    Button b = Buttons[index];
                    index++;
                    grid.Children.Add(b, x, y);
                }
            }

            Content = grid;
        }

        private List<Button> GenerateButtonList(GameGrid gameGrid)
        {
            var randomLetterGenerator = new RandomLetterGenerator();
            var buttons = new List<Button>();

            for (int i = 0; i < gameGrid.NumberOfGridSections / 2; i++)
            {
                string letter = randomLetterGenerator.GetAndRemoveRandomLetter();
                buttons.Add(GenerateButton(letter));
                buttons.Add(GenerateButton(letter));
            }

            return shuffleList(buttons);
        }

        private List<Button> shuffleList(List<Button> list)
        {
            Random random = new Random();

            for (int i = list.Count - 1; i > 1; i--)
            {
                int rnd = random.Next(i + 1);

                Button value = list[rnd];
                list[rnd] = list[i];
                list[i] = value;
            }

            return list;
        }

        private Button GenerateButton(string Text)
        {
            Button button = new Button();

            button.BackgroundColor = Color.LightSkyBlue;
            button.Margin = 5;
            button.Text = Text;
            button.FontSize = 50;
            button.TextColor = Color.Transparent;
            button.Clicked += OnButtonClicked;
            button.HorizontalOptions = LayoutOptions.Fill;
            button.VerticalOptions = LayoutOptions.Fill;

            return button;
        }

        private void OnButtonClicked(object sender, EventArgs args)
        {
            var button = sender as Button; 
            if(buttonPressed_1 != null && buttonPressed_2 != null)
            {
                return;
            }

            if(button.TextColor != Color.White)
            {
                if (buttonPressed_1 == null)
                {
                    buttonPressed_1 = Buttons.IndexOf(button);
                    SelectedButtonChange(button);
                }
                else
                {
                    SelectedButtonChange(button);

                    if (button.Text.Equals(Buttons[buttonPressed_1.Value].Text))
                    {
                        MatchingButtonChange(button);
                    }
                    else
                    {
                        buttonPressed_2 = Buttons.IndexOf(button);
                        Pause();
                    }
                }
            }
        }

        private void SelectedButtonChange(Button button)
        {
            button.TextColor = Color.White;
            button.BackgroundColor = Color.Red;
        }

        private void MatchingButtonChange(Button button)
        {
            Buttons[buttonPressed_1.Value].BackgroundColor = Color.Green;
            button.BackgroundColor = Color.Green;

            buttonPressed_1 = null;
        }


        private void Pause()
        {
            Device.StartTimer(new TimeSpan(0, 0, 1), () =>
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    RestButtons();
                });
                return false;
            });
        }

        private void RestButtons()
        {
            Buttons[buttonPressed_1.Value].TextColor = Color.Transparent;
            Buttons[buttonPressed_2.Value].TextColor = Color.Transparent;

            Buttons[buttonPressed_1.Value].BackgroundColor = Color.LightSkyBlue;
            Buttons[buttonPressed_2.Value].BackgroundColor = Color.LightSkyBlue;

            buttonPressed_1 = null;
            buttonPressed_2 = null;
        }
    }
}