using MathGame.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace MathGame
{
    /// <summary>
    /// Interaction logic for SubtractionGame.xaml
    /// </summary>
    public partial class SubtractionGameWindow : Window
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public SubtractionGameWindow()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Closes the game and brings the main window back into view
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdCloseSubtractionGame(object sender, RoutedEventArgs e)
        {
            
            this.Close();
            Application.Current.MainWindow.BringIntoView();
        }
        /// <summary>
        /// Starts the subtraction game and enables the submit button for use. starts the timer
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdStartSubtractionGame(object sender, RoutedEventArgs e)
        {
            PlayGameViewModel pgw = (PlayGameViewModel)this.DataContext;
            pgw.StartTimer();
            pgw.DisplayQuestion();
        }
        /// <summary>
        /// calls check and display answer after the user clicks submit to answer a question
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdSubmitAnswerSubtraction(object sender, RoutedEventArgs e)
        {
            this.checkAndDisplayAnswer();
        }
        /// <summary>
        /// calls check and display answer after the user hits enter to answer a question
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void difference_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                this.checkAndDisplayAnswer();
            }
        }
        /// <summary>
        /// Check and display answer method. This method determines whether the game is over based on the question number the user is on. plays a sound if the answer is right 
        /// or plays a sound if the answer is wrong. after the game is over pushes the data into the high scores window. resets the time and the current question number
        /// shows the high score window dialog. calls the check answer function to see if the answer is right or wrong and increment the appropriate variables. Shows a message
        /// box if the user made it to the top 10 highest scores or not. removes the bottom user from the list if more 10 or more and a new high score is added
        /// displays the next question.
        /// </summary>
        private void checkAndDisplayAnswer()
        {


            PlayGameViewModel pgw = (PlayGameViewModel)this.DataContext;
            QuestionResultViewModel qrvm = new QuestionResultViewModel(pgw.QuestionResults.Count + 1);



            this.difference.Text = String.Empty;
            if (pgw.currentQuestionNumber >= pgw.maximumQuestionNumber)
            {
                pgw.QuestionResults.Add(qrvm);
                pgw.checkAnswer();


                SoundPlayer answerRight = new SoundPlayer("highScores.wav");
                answerRight.Play();
                EnterUserDataViewModel eudv = ((MainWindowViewModel)Application.Current.MainWindow.DataContext).EnterUserDataVM;
                HighScoreWindowViewModel hsvw = ((MainWindowViewModel)Application.Current.MainWindow.DataContext).HighScoreWindowVM;
                pgw.StopTimer();
                HighScoresWindow hsw = new HighScoresWindow();
                hsw.DataContext = ((MainWindowViewModel)Application.Current.MainWindow.DataContext).HighScoreWindowVM;
                if (hsvw.HighScores.Count() >= 10 && pgw.QuestionResults.Count(x => x.IsCorrect == true) <= hsvw.HighScores.ToArray()[9].CorrectAnswers)
                {
                    MessageBox.Show("I am sorry, but you did not make it to the top 10 highest scores. Please click OK to advance to the High Score Screen.");

                }
                else
                {
                    if (hsvw.HighScores.Count() < 10)
                    {
                        hsvw.HighScoresAdd(eudv.TheCurrentUser.UserName, pgw.QuestionResults.Count(x => x.IsCorrect == true), pgw.QuestionResults.Count(x => x.IsCorrect == false), pgw.gameTime);
                        MessageBox.Show("Congratulations! You made it to the top 10 highest scores! Please click OK to view your score and compare it to the other top 10 players.");

                    }
                    else
                    {
                        hsvw.HighScores.Remove(hsvw.HighScores.ToArray()[9]);
                        hsvw.HighScoresAdd(eudv.TheCurrentUser.UserName, pgw.QuestionResults.Count(x => x.IsCorrect == true), pgw.QuestionResults.Count(x => x.IsCorrect == false), pgw.gameTime);
                        MessageBox.Show("Congratulations! You made it to the top 10 highest scores! Please click OK to view your score and compare it to the other top 10 players.");

                    }

                }
                pgw.ResetTimer();

                pgw.currentQuestionNumber = 0;
                pgw.Product = 0;
                pgw.QuestionResults.Clear();
                hsw.ShowDialog();
                this.Close();
                return;
            }
            pgw.QuestionResults.Add(qrvm);
            pgw.checkAnswer();
            pgw.DisplayQuestion();

        }
    
    }
}
