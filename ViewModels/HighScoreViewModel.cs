using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace MathGame.ViewModels
{
    public class HighScoreViewModel : ViewModelBase
    {
        /// <summary>
        /// private string to reference the user name
        /// </summary>
        private string userName;
        /// <summary>
        /// public string to reference the username and updates automatically if changed by the user
        /// </summary>
        public string UserName
        {
            get
            {
                return userName;
            }
            set
            {
                userName = value;
                OnPropertyChanged("UserName");
            }
        }

        /// <summary>
        /// Private int that references the amount of correct answers
        /// </summary>
        private int correctAnswers;
        /// <summary>
        /// public int that references the amount of times the user guessed a question correctly. updates automatically as the game progresses.
        /// </summary>
        public int CorrectAnswers
        {
            get
            {
                return correctAnswers;
            }
            set
            {
                correctAnswers = value;
                OnPropertyChanged("CorrectAnswers");
            }
        }
        /// <summary>
        /// private int that referecnes the amount of incorrect answers
        /// </summary>
        private int incorrectAnswers;
        /// <summary>
        /// public int that references the amount of times the user guessed the question incorrectly. updates automatically as the game progresses.
        /// </summary>
        public int IncorrectAnswers
        {
            get
            {
                return incorrectAnswers;
            }
            set
            {
                incorrectAnswers = value;
                OnPropertyChanged("IncorrectAnswers");
            }
        }
        /// <summary>
        /// private timespan that reference the amount of time it took to complete the game
        /// </summary>
        private TimeSpan completionTime;
        /// <summary>
        /// public timespan that references the amount of time it took the compelte the game and automatically updates when the user completes the game
        /// </summary>
        public TimeSpan CompletionTime
        {
            get
            {
                return completionTime;
            }
            set
            {
                completionTime = value;
                OnPropertyChanged("CompletionTime");
            }
        }
     
    }
}
