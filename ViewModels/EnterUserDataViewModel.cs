using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Documents;

namespace MathGame.ViewModels
{
    public class EnterUserDataViewModel : ViewModelBase
    {
        
        /// <summary>
        /// Creates a new user list
        /// </summary>
        private List<UserViewModel> userList = new List<UserViewModel>();
        /// <summary>
        /// Allows the user to add themselves into the game or to update their information
        /// </summary>
        /// <param name="user"></param>
        public void AddOrUpdateUser(UserViewModel user)
        {
            //Brings the current users information up to be edited
            this.userList.Add(user);
            if(userList.Count() == 1)
            {
                this.TheCurrentUser = user;
            }
    
        }
        
        /// <summary>
        /// private method to reference the current user
        /// </summary>
        private UserViewModel theCurrentUser;
        /// <summary>
        /// Public method that references the current user and updates automatically when the user is either added or updated
        /// </summary>
        public UserViewModel TheCurrentUser
        {
            get
            {
                return theCurrentUser;
            }
            private set
            {
                theCurrentUser = value;
                OnPropertyChanged("TheCurrentUser");
            }
        }
        /// <summary>
        /// Replaces user view model with new user view model in place
        /// </summary>
        /// <param name="oldUserInfo"></param>
        /// <param name="newUserInfo"></param>
        public void UpdateUser(UserViewModel oldUserInfo, UserViewModel newUserInfo)
        {
            int oldIndex = this.userList.IndexOf(oldUserInfo);
            this.userList.RemoveAt(oldIndex);
            this.userList.Insert(oldIndex, newUserInfo);
        }
        
        
            

    }
}
