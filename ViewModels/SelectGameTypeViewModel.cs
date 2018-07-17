using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MathGame.ViewModels
{
    public class SelectGameTypeViewModel : ViewModelBase
    {
        /// <summary>
        /// private reference to the game type selected by the user
        /// </summary>
        private GameTypesEnum selectedGameType;
        /// <summary>
        /// public reference to the game type selected by the user
        /// </summary>
        public GameTypesEnum SelectedGameType
        {
            get
            {
                return selectedGameType;
            }
            set
            {
                selectedGameType = value;
                OnPropertyChanged("SelectedGameType");
            }
        }
        /// <summary>
        /// String that holds all game types and displays them in a drop down for the user.
        /// </summary>
        public string[] AvailableGameTypes
        {
            get
            {
                return Enum.GetNames(typeof(GameTypesEnum));
            }
        }
    }
}
