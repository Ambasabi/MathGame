using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MathGame.ViewModels
{
    public class QuestionResultViewModel : ViewModelBase
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="questionNumber"></param>
        public QuestionResultViewModel(int questionNumber)
        {
            this.questionNumber = questionNumber;
        }
        /// <summary>
        /// private reference to see if question has been answered yet
        /// </summary>
        private bool isAnsweredYet;
        /// <summary>
        /// public reference to see if question has been answered yet
        /// </summary>
        public bool IsAnsweredYet
        {
            get
            {
                return isAnsweredYet;
            }
            set
            {
                isAnsweredYet = value;
                OnPropertyChanged("IsAnsweredYet");
            }
        }
        /// <summary>
        /// private reference to store whether the answer was correct or not
        /// </summary>
        private bool isCorrect;
        /// <summary>
        /// public reference to store whether the answer was correct or not
        /// </summary>
        public bool IsCorrect
        {
            get
            {
                return isCorrect;
            }
            set
            {
                isCorrect = value;
                OnPropertyChanged("IsCorrect");
            }
        }
        /// <summary>
        /// private reference to the question number the user is on
        /// </summary>
        private readonly int questionNumber;
        /// <summary>
        /// public reference to the question number the user is on
        /// </summary>
        public int QuestionNumber
        {
            get
            {
                return questionNumber;
            }
        }


    }
}
