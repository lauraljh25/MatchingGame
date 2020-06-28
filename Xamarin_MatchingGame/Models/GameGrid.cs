using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Text;

namespace Xamarin_MatchingGame.Models
{
    public class GameGrid
    {
        public double SliderValue { get; set; }
        public int GridSliderLevel { get 
            {
                double StepValue = 1.0;
                var newStep = Math.Round(SliderValue / StepValue);
                return (int)(newStep * StepValue);
            } 
        }


        public int GridRows 
        {
            get
            {
                return GridSliderLevel;
            }

        }
        public int GridColumns 
        { 
            get
            {
                if(GridSliderLevel <= 7)
                {
                    if (isEven(GridSliderLevel))
                    {
                        return GridSliderLevel;
                    }
                    else
                    {
                        return GridSliderLevel - 1;
                    }
                }    
                else
                {
                    return 6;
                }
            }
        }

        public int NumberOfGridSections
        {
            get
            {
                return GridColumns * GridRows;
            }
        }

        private bool isEven(int number)
        {
            return number % 2 == 0;
        }

    }
}
