using MathGame.ViewModels;
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
using System.Windows.Shapes;

namespace MathGame
{
    /// <summary>
    /// Interaction logic for EnterUserDataWindow.xaml
    /// </summary>
    public partial class EnterUserDataWindow : Window
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public EnterUserDataWindow()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Closes the user data entry window and brings the main window back up
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdCloseEnterUserDataWindow_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// Submits the user input and stores the information to be used later. requires that the user fill in all fields before continuing
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdSubmitEnterUserData_Click(object sender, RoutedEventArgs e)
        {
            //return and skip all future code if any of the text boxes are blank
            if (String.IsNullOrEmpty(this.txtFirstLast.Text) || String.IsNullOrEmpty(this.txtPhone.Text) || String.IsNullOrEmpty(this.txtPhone.Text) || String.IsNullOrEmpty(this.txtAge.Text))
            {
                MessageBox.Show("Please fill in all fields.");
                return;
            }        
            UserViewModel newUser = new UserViewModel();
            newUser.UserName = this.txtFirstLast.Text;
            int temp =0;
            //Makes sure the input is an int, otherwise a messagebox displays
            if (!Int32.TryParse(this.txtAge.Text, out temp))
            {
                MessageBox.Show("Please enter a valid age.");
                return;
            }
            newUser.Age = temp;
            newUser.Phone = this.txtPhone.Text;
            newUser.Email = this.txtEmail.Text;
            ((EnterUserDataViewModel)this.DataContext).AddOrUpdateUser(newUser);
            MainWindowViewModel mwvm = (MainWindowViewModel)Application.Current.MainWindow.DataContext;
            mwvm.HasEnteredData = true;
            this.Close();
            Application.Current.MainWindow.BringIntoView();
           
            
        }
    }
}
