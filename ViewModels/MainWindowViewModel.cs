using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;

namespace MathGame.ViewModels
{
    /// <summary>
    /// Creates a main window view model
    /// </summary>
    public class MainWindowViewModel : ViewModelBase
    {
        /// <summary>
        /// creates the high score window view model
        /// </summary>
        private HighScoreWindowViewModel highScoreWindowVM = new HighScoreWindowViewModel();
        /// <summary>
        /// References the high score window view model for later use
        /// </summary>
        public HighScoreWindowViewModel HighScoreWindowVM
        {
            
            get
            {
                return highScoreWindowVM;
            }
            set
            {
                highScoreWindowVM = value;
                OnPropertyChanged("HighScoreWindowVM");
            }
        }
        /// <summary>
        /// Creates the play games window view model
        /// </summary>
        private PlayGameViewModel playGameWindowVM = new PlayGameViewModel();
        /// <summary>
        /// Easily accessible play game window view model from anywhere in the program
        /// </summary>
        public PlayGameViewModel PlayGameWindowVM
        {

            get
            {
                return playGameWindowVM;
            }
            set
            {
                playGameWindowVM = value;
                OnPropertyChanged("PlayGameWindowVM");
            }
        }
        /// <summary>
        /// private reference to enter user data view model
        /// </summary>
        private EnterUserDataViewModel enterUserDataVM = new EnterUserDataViewModel();
        /// <summary>
        /// Easily accessible Enter User Data View Model from anywhere in the program
        /// </summary>
        public EnterUserDataViewModel EnterUserDataVM
        {

            get
            {
                return enterUserDataVM;
            }
            set
            {
                enterUserDataVM = value;
                OnPropertyChanged("EnterUserDataVM");
            }
        }
        /// <summary>
        /// private reference to select game type view model
        /// </summary>
        private SelectGameTypeViewModel selectGameTypeVM = new SelectGameTypeViewModel();
        /// <summary>
        /// Easily accessible select game type view model from anywhere in the program
        /// </summary>
        public SelectGameTypeViewModel SelectGameTypeVM
        {
            get
            {
                return selectGameTypeVM;
            }
            set
            {
                selectGameTypeVM = value;
                OnPropertyChanged("SelectGameTypeVM");
            }
        }
        /// <summary>
        /// private reference to has entered data
        /// </summary>
        private bool hasEnteredData = false;
        /// <summary>
        /// Used to determine whether or not they have registered themselves as users. if they have, we then allow them to proceed through the game.
        /// </summary>
        public bool HasEnteredData
        {
            get
            {
                return hasEnteredData;
            }
            set
            {
                hasEnteredData = value;
                OnPropertyChanged("HasEnteredData");
            }
        }

    }   
    
}
