using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Media;
using System.Text;
using System.Timers;
using System.Windows;
using System.Windows.Threading;

namespace MathGame.ViewModels
{
    public class PlayGameViewModel : ViewModelBase
    {
        //CLOCK-----------------------------------------------------------------
       private Timer MyTimer;
        /// <summary>
        /// constructor that initializes timer
        /// </summary>
        public  PlayGameViewModel()
        {
            this.initializeTimer();
            

        }
        /// <summary>
        /// initializes the timer. constructor. elapses timer
        /// </summary>
        private void initializeTimer()
        {
            MyTimer = new Timer(100);
            MyTimer.Elapsed += MyTimer_Tick;
            
        }

        /// <summary>
        /// Track number of minutes seconds and milliseconds for current game sessions
        /// </summary>
        private int minutes = 0, seconds = 0, milliseconds = 0;
        /// <summary>
        /// returns number of minutes seconds and milliseconds for current game sessions as a time span
        /// </summary>
        public TimeSpan gameTime
        {
            get
            {
                TimeSpan result = new TimeSpan(0, 0, minutes, seconds, milliseconds);
                return result;
            }
         
        }
        /// <summary>
        /// returns number of minutes seconds and milliseconds for current game sessions as a string
        /// </summary>
        public string TimeElapsed
        {
            get
            {
                return string.Format("{0}:{1}.{2}", minutes, seconds, milliseconds/100);
            }
        }

       /// <summary>
       /// When 100 milliseconds elapse increments the clock
       /// </summary>
       /// <param name="sender"></param>
       /// <param name="e"></param>
        private void MyTimer_Tick(object sender, EventArgs e)
        {
            milliseconds = milliseconds + 100;
            if(milliseconds>=1000)
            {
                seconds++;
                milliseconds = 0;
            }
            if(seconds >= 60)
            {
                minutes++;
                seconds = 0;
            }
            
            OnPropertyChanged("TimeElapsed");

        }
        /// <summary>
        /// private reference to the desired game type of the user
        /// </summary>
        private  GameTypesEnum desiredGameType;
        /// <summary>
        /// public reference to the desired game type from the user that updates as the user changes it
        /// </summary>
        public  GameTypesEnum DesiredGameType
        {
            get
            {
                return desiredGameType;
            }
            set
            {
                desiredGameType = value;
                OnPropertyChanged("DesiredGameType");
            }
        }
        /// <summary>
        /// Public method that starts the timer and initializes it if necessary
        /// </summary>
        public void StartTimer()
        {
            if (this.MyTimer == null)
            {
                this.initializeTimer();
            }
            this.MyTimer.Start();
            this.IsGameStarted = true;
        }
        /// <summary>
        /// Public method that resets the timer when necessary
        /// </summary>
        public void ResetTimer()
        {
            this.MyTimer.Stop();
            this.minutes = 0;
            this.milliseconds = 0;
            this.seconds = 0;           
            this.IsGameStarted = false;
        }
        /// <summary>
        /// public method that stops the timer so the proper score can be calculated
        /// </summary>
        public void StopTimer()
        {
            this.MyTimer.Stop();
        }
        /// <summary>
        /// public method that displays the question based on the game type the user chose.
        /// </summary>
        public void DisplayQuestion()
        {
            Random r = new Random();
            //generates random number for addition game
            if(desiredGameType == GameTypesEnum.Addition)
            {          
                this.AddendOne = r.Next(0, 10);
                this.AddendTwo = r.Next(0, 10);
                
              
            }
                //generates random number for subtraction game
            else if(desiredGameType == GameTypesEnum.Subtraction)
            {
                this.SubtrahendOne = r.Next(0, 10);
                this.SubtrahendTwo = r.Next(0, this.SubtrahendOne);
            }
                //generates random number for multiplication game
            else if(desiredGameType == GameTypesEnum.Multiplication)
            {
                this.MultiplicandOne = r.Next(0, 10);
                this.MultiplicandTwo = r.Next(0, 10);
            }
                //generates random number for division game and ensures that the user can never divide by 0 and only gets a question that is easy to answer.
            else if(desiredGameType == GameTypesEnum.Division)
            {
                int testDividend = 0;
                int testDivisor = 0;
                do
                {
                    testDividend = r.Next(0, 10);
                    testDivisor = r.Next(1, 10);
                    //modulus to make sure the user can only divide and get whole answers.
                } while (testDividend % testDivisor != 0);
                this.Dividend = testDividend;
                this.Divisor = testDivisor;
                
            }
          
        }
        /// <summary>
        /// Keeps track of the current question the user is on
        /// </summary>
        public int currentQuestionNumber = 0;
        /// <summary>
        /// stores the maximum amount of questions the user is required to answer
        /// </summary>
        public int maximumQuestionNumber = 9;
        /// <summary>
        /// Checks to see if the answer is true. if it is, it feeds to the appropriate game type, plays a sound, pushes whether it was true or false into the game,
        /// if it was wrong plays a sound, and returns
        /// </summary>
        /// <returns></returns>
        public bool checkAnswer()
        {
            int thisQuestionNumber = currentQuestionNumber;
         
            this.QuestionResults[thisQuestionNumber].IsAnsweredYet = true;
            
                if (desiredGameType == GameTypesEnum.Addition)
                {
                    if (this.Sum == (this.AddendOne + this.AddendTwo))
                    {
                        currentQuestionNumber++;
                        SoundPlayer answerRight = new SoundPlayer("answerRight.wav");
                        answerRight.Play();
                        this.QuestionResults[thisQuestionNumber].IsCorrect = true;
                        return true;
                    }
                }
                else if (desiredGameType == GameTypesEnum.Subtraction)
                {
                    if (this.Difference == (this.SubtrahendOne - this.SubtrahendTwo))
                    {
                        currentQuestionNumber++;
                        SoundPlayer answerRight = new SoundPlayer("answerRight.wav");
                        answerRight.Play();
                        this.QuestionResults[thisQuestionNumber].IsCorrect = true;
                        return true;
                    }
                }
                else if (desiredGameType == GameTypesEnum.Multiplication)
                {
                    if (this.Product == (this.MultiplicandOne * this.MultiplicandTwo))
                    {
                        currentQuestionNumber++;
                        SoundPlayer answerRight = new SoundPlayer("answerRight.wav");
                        answerRight.Play();
                        this.QuestionResults[thisQuestionNumber].IsCorrect = true;
                        return true;
                    }

                }
                else if (desiredGameType == GameTypesEnum.Division)
                {
                    if (this.Quotient == (this.Dividend / this.Divisor))
                    {
                        currentQuestionNumber++;
                        SoundPlayer answerRight = new SoundPlayer("answerRight.wav");
                        answerRight.Play();
                        this.QuestionResults[thisQuestionNumber].IsCorrect = true;
                        return true;
                    }
                }
                currentQuestionNumber++;
                SoundPlayer answerWrong = new SoundPlayer("answerWrong.wav");
                answerWrong.Play();
                this.QuestionResults[thisQuestionNumber].IsCorrect = false;
                return false;
            
            
        }
        /// <summary>
        /// private reference to list of question results
        /// </summary>
        private ObservableCollection<QuestionResultViewModel> questionResults = new ObservableCollection<QuestionResultViewModel>();
        /// <summary>
        /// List of questions results to track the response of the user while they play
        /// </summary>
        public ObservableCollection<QuestionResultViewModel> QuestionResults
        {
            get
            {
                return questionResults;
            }
            set
            {
                questionResults = value;
                OnPropertyChanged("QuestionResults");
            }
        }
        //ADDITION--------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// private reference to the left number for addition game
        /// </summary>
        private int addendOne;
        /// <summary>
        /// public reference that updates after each question is submitted for left number of addition game
        /// </summary>
        public int AddendOne
        {
            get
            {
                return addendOne;
            }
            set
            {
                addendOne = value;
                OnPropertyChanged("AddendOne");
            }
        }
        /// <summary>
        /// private reference that updates after each question is submitted for left number of addition game
        /// </summary>
        private int addendTwo;
        /// <summary>
        /// public reference that updates after each question is submitted for right number of addition game
        /// </summary>
        public int AddendTwo
        {
            get
            {
                return addendTwo;
            }
            set
            {
                addendTwo = value;
                OnPropertyChanged("AddendTwo");
            }
        }
        /// <summary>
        /// private reference to the sum which is the answer to the question
        /// </summary>
        private int sum;
        /// <summary>
        /// public reference to the sum which is the answer to the question
        /// </summary>
        public int Sum
        {
            get
            {
                return sum;
            }
            set
            {
                sum = value;
                OnPropertyChanged("Sum");
            }
        }
        //SUBTRACTION-------------------------------------------------------------------------------------
        /// <summary>
        /// private reference that updates after each question is submitted for left number of subtraction game
        /// </summary>
        private int subtrahendOne;
        /// <summary>
        /// public reference that updates after each question is submitted for left number of subtraction game
        /// </summary>
        public int SubtrahendOne
        {
            get
            {
                return subtrahendOne;
            }
            set
            {
                subtrahendOne = value;
                OnPropertyChanged("SubtrahendOne");
            }
        }
        /// <summary>
        /// private reference that updates after each question is submitted for right number of subtrction game
        /// </summary>
        private int subtrahendTwo;
        /// <summary>
        /// public reference that updates after each question is submitted for right number of subtraction game
        /// </summary>
        public int SubtrahendTwo
        {
            get
            {
                return subtrahendTwo;
            }
            set
            {
                subtrahendTwo = value;
                OnPropertyChanged("SubtrahendTwo");
            }
        }
        /// <summary>
        /// private reference to the answer of the question
        /// </summary>
        private int difference;
        /// <summary>
        /// public reference to the answer of the question
        /// </summary>
        public int Difference
        {
            get
            {
                return difference;
            }
            set
            {
                difference = value;
                OnPropertyChanged("Difference");
            }
        }
        //MULTIPLICATION-----------------------------------------------------------------------------------------------
        /// <summary>
        /// private reference that updates after each question is submitted for left number of multiplication game
        /// </summary>
        private int multiplicandOne;
        /// <summary>
        /// public reference that updates after each question is submitted for left number of multiplication game
        /// </summary>
        public int MultiplicandOne
        {
            get
            {
                return multiplicandOne;
            }
            set
            {
                multiplicandOne = value;
                OnPropertyChanged("MultiplicandOne");
            }
        }
        /// <summary>
        /// private reference that updates after each question is submitted for right number of multiplication game
        /// </summary>
        private int multiplicandTwo;
        /// <summary>
        /// public reference that updates after each question is submitted for right number of multiplication game
        /// </summary>
        public int MultiplicandTwo
        {
            get
            {
                return multiplicandTwo;
            }
            set
            {
                multiplicandTwo = value;
                OnPropertyChanged("MultiplicandTwo");
            }
        }
        /// <summary>
        /// private reference to the answer for the question for the multiplcation game
        /// </summary>
        private int product;
        /// <summary>
        /// public reference to the answer for the question for the multiplication game
        /// </summary>
        public int Product
        {
            get
            {
                return product;
            }
            set
            {
                product = value;
                OnPropertyChanged("Product");
            }

        }
        //DIVISION------------------------------------------------------------------------------------------------------
        /// <summary>
        /// private reference that updates after each question is submitted for left number of division game
        /// </summary>
        private int dividend;
        /// <summary>
        /// public reference that updates after each question is submitted for left number of division game
        /// </summary>
        public int Dividend
        {
            get
            {
                return dividend;
            }
            set
            {
                dividend = value;
                OnPropertyChanged("Dividend");
            }
        }
        /// <summary>
        /// private reference that updates after each question is submitted for right number of division game
        /// </summary>
        private int divisor;
        /// <summary>
        /// public reference that updates after each question is submitted for right number of division game
        /// </summary>
        public int Divisor
        {
            get
            {
                return divisor;
            }
            set
            {
                divisor = value;
                OnPropertyChanged("Divisor");
            }
        }
        /// <summary>
        /// private reference to answer of division game
        /// </summary>
        private int quotient;
        /// <summary>
        /// public reference to answer of division game
        /// </summary>
        public int Quotient
        {
            get
            {
                return quotient;
            }
            set
            {
                quotient = value;
                OnPropertyChanged("Quotient");
            }
        }
        /// <summary>
        /// private reference to see if the game has started yet
        /// </summary>
        private bool isGameStarted;
        /// <summary>
        /// public reference to see if the game has started yet
        /// </summary>
        public bool IsGameStarted
        {
            get
            {
                return isGameStarted;
            }
            set
            {
                isGameStarted = value;
                OnPropertyChanged("IsGameStarted");
            }
        }

        
    }
}
