using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MathGame.ViewModels
{
    public class UserViewModel : ViewModelBase
    {
        public UserViewModel()
        {
            this.id = new Guid();
        }
        /// <summary>
        /// private reference to the unique ID generated for the user
        /// </summary>
        private Guid id;
        /// <summary>
        /// Unique ID to keep track of this user
        /// </summary>
        public Guid Id 
        {
            get
            {
                return id;
            }
            private set
            {
                id = value;
                OnPropertyChanged("Id");
            }
        }
        /// <summary>
        /// private reference to the user name the user enters
        /// </summary>
        private string userName;
        /// <summary>
        /// public reference to the name the user enters that updates as the user chnages the name
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
        /// private reference to the age of the user
        /// </summary>
        private int age;
        /// <summary>
        /// public reference to the age of the user that updates as the user changes the age
        /// </summary>
        public int Age
        {
            get
            {
                return age;
            }
            set
            {
                age = value;
                OnPropertyChanged("Age");
            }
        }
        /// <summary>
        /// private reference to the phone number of the user
        /// </summary>
        private string phone;
        /// <summary>
        /// public reference to the phone number the user enters that updates as the user changes it
        /// </summary>
        public string Phone
        {
            get
            {
                return phone;
            }
            set
            {
                phone = value;
                OnPropertyChanged("Phone");
            }
        }
        /// <summary>
        /// private reference to the email the user enters.
        /// </summary>
        private string email;
        /// <summary>
        /// public reference to the email the user enters that updates as the user changes it
        /// </summary>
        public string Email
        {
            get
            {
                return email;
            }
            set
            {
                email = value;
                OnPropertyChanged("Email");
            }
        }
    }
}
