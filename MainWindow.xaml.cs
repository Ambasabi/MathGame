using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Collections.ObjectModel;
using MathGame.ViewModels;
using System.Media;
using System.IO;

namespace MathGame
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.Closing += MainWindow_Closing;
            this.Loaded += MainWindow_Loaded;
           
        }
        /// <summary>
        /// On loading the program, loads previous high scores from the txt file
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void MainWindow_Loaded(object sender, EventArgs e)
        {
            MainWindowViewModel mwvm = (MainWindowViewModel)this.DataContext;

            using (StreamReader sr = new StreamReader("HighScoresTest.txt"))
            {
                string line;
                //while loop that loops through every line in the existing text file and pushes everything to the high score screen to simulate a save file
                while ((line = sr.ReadLine()) != null)
                {
                    string userName = line;
                    int correctAnswers = Convert.ToInt32(sr.ReadLine());
                    int incorrectAnswers = Convert.ToInt32(sr.ReadLine());
                    string tempTime = sr.ReadLine();
                    int minutes = Convert.ToInt32(tempTime.Split(':')[0]);
                    int seconds = Convert.ToInt32(tempTime.Split(':')[1]);
                    int milliseconds = Convert.ToInt32(tempTime.Split(':')[2]);
                    TimeSpan completionTime = new TimeSpan(0, 0, minutes, seconds, milliseconds);
                    mwvm.HighScoreWindowVM.HighScoresAdd(userName, correctAnswers, incorrectAnswers, completionTime);
                }
            }
        }
        /// <summary>
        /// On closing the main window, pulls all data from the high scores window into a TXT file
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void MainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            MainWindowViewModel mwvm = (MainWindowViewModel)this.DataContext;
            PlayGameViewModel pgw = (((MainWindowViewModel)Application.Current.MainWindow.DataContext).PlayGameWindowVM);
            HighScoreWindowViewModel hsvw = ((MainWindowViewModel)Application.Current.MainWindow.DataContext).HighScoreWindowVM;
            using (System.IO.StreamWriter file = new System.IO.StreamWriter("HighScoresTest.txt"))
            {
                //foreach loop that finds all of the appropriate information from the high screen window and loads it into the txt file
                foreach (HighScoreViewModel highScore in hsvw.HighScores)
                {
                    string[] lines = { "User Name", "Correct Answers", "Incorrect Answers", "Time" };                        
                    file.WriteLine(highScore.UserName);
                    file.WriteLine(highScore.CorrectAnswers);
                    file.WriteLine(highScore.IncorrectAnswers);
                    file.WriteLine(string.Format("{0}:{1}:{2}", highScore.CompletionTime.Minutes, highScore.CompletionTime.Seconds, highScore.CompletionTime.Milliseconds));                      
                }
            }

        }
        /// <summary>
        /// the button that loads the high scores screen. plays a sound when the screen loads.. hides the main window, and shows the high score window dialog
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdHighScores_Click(object sender, RoutedEventArgs e)
        {
            SoundPlayer answerRight = new SoundPlayer("highScores.wav");
            answerRight.Play();
            Grid mainWindowGrid = (Grid)((Button)sender).Parent;
            MainWindow mw = (MainWindow)mainWindowGrid.Parent;
            HighScoresWindow hsWindow = new HighScoresWindow();
            hsWindow.DataContext = ((MainWindowViewModel)mw.DataContext).HighScoreWindowVM;
            mw.Hide();
            hsWindow.ShowDialog();
            mw.Show();       
        }
        /// <summary>
        /// the button that loads the game selection menu. plays a sound when the user gets to choose which game they want to play
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdPlayGame_Click(object sender, RoutedEventArgs e)
        {
            SoundPlayer simpleSound = new SoundPlayer("Breathing.wav");

            simpleSound.Play();
            Grid mainWindowGrid = (Grid)((Button)sender).Parent;
            MainWindow mw = (MainWindow)mainWindowGrid.Parent;
            SelectGameTypeWindow sgt = new SelectGameTypeWindow();
            sgt.DataContext = ((MainWindowViewModel)mw.DataContext).SelectGameTypeVM;
            mw.Hide();
            sgt.ShowDialog();
         
            mw.Show();
            mw.BringIntoView();
        } 

       
        /// <summary>
        /// The button that allows the user to add or update the current user playing the program. plays a sound when the user enters the window. hides the main window and 
        /// shows the data entry window.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdUserInfo_Click(object sender, RoutedEventArgs e)
        {
            SoundPlayer answerRight = new SoundPlayer("addOrUpdate.wav");

            answerRight.Play();
            Grid mainWindowGrid = (Grid)((Button)sender).Parent;
            MainWindow mw = (MainWindow)mainWindowGrid.Parent;
            EnterUserDataWindow dataWindow = new EnterUserDataWindow();
            dataWindow.DataContext = ((MainWindowViewModel)mw.DataContext).EnterUserDataVM;
            mw.Hide();
            dataWindow.ShowDialog();
            mw.Show();
            mw.BringIntoView();
        }
        /// <summary>
        /// An exit button in case the user decides not to play the game
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

   



       
    }
}
