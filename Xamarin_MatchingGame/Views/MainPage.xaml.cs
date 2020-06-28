using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Xamarin_MatchingGame
{
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            LevelLabel.Text = $"Level: {LevelSlider.Value - 3}";
        }

        private void LevelSlider_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            double StepValue = 1.0;
            var newStep = Math.Round(e.NewValue / StepValue);
            
            LevelSlider.Value = newStep * StepValue;
            LevelLabel.Text = $"Level: {LevelSlider.Value - 3}";
        }
    }
}
