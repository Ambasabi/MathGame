using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace MathGame.ViewModels
{
    /// <summary>
    /// Collection of high score view models that allow the UI to be notified when any of the collection's children change. 
    /// </summary>
    public class HighScoreWindowViewModel : ViewModelBase
    {
        private ObservableCollection<HighScoreViewModel> highScores = new ObservableCollection<HighScoreViewModel>();
        public ObservableCollection<HighScoreViewModel> HighScores
        {
            get
            {
                return highScores;
            }
            set
            {
                highScores = value;
                OnPropertyChanged("HighScores");
            }
        }
        /// <summary>
        /// Using the observable collection, create a method that inserts the users name, correct answers, incorrect answers, and total completion time into
        /// the high scores screen
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="correctAnswers"></param>
        /// <param name="incorrectAnswers"></param>
        /// <param name="completionTime"></param>
        public void HighScoresAdd(string userName, int correctAnswers, int incorrectAnswers, TimeSpan completionTime)
        {

            HighScores.Add(new HighScoreViewModel()
            {   //variable that holds the username entered in the user window             
                UserName = userName,
                //variable that holds the amount of correct answers guessed by the user
                CorrectAnswers = correctAnswers,
                //variable that holds the amount of incorrect answers guessed by the user
                IncorrectAnswers = incorrectAnswers,
                //variable that holds the amount of time it took for the user to guess all 10 questions
                CompletionTime = completionTime
            });
            //Takes the high scores observable collection and sorts everything in the window by score then by time
            HighScores = new ObservableCollection<HighScoreViewModel>(HighScores.OrderByDescending(score => score.CorrectAnswers).ThenBy(time => time.CompletionTime));
        }
    }
}
