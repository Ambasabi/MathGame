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
    /// Interaction logic for SelectGameTypeWindow.xaml
    /// </summary>
    public partial class SelectGameTypeWindow : Window
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public SelectGameTypeWindow()
        {
            InitializeComponent();
        }
        /// <summary>
        /// The method that is ran when the user is choosing their game type. WHen the user chooses the game type and hits submit, this method
        /// brings the appropriate game window up.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdSelectGameTypeSubmit_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mw = (MainWindow)Application.Current.MainWindow;
            MainWindowViewModel mwvm = (MainWindowViewModel)mw.DataContext;
            PlayGameViewModel pgw = (((MainWindowViewModel)Application.Current.MainWindow.DataContext).PlayGameWindowVM);
            pgw.IsGameStarted = false;
            Window theWindow = null;
            
            if (this.cmbSelectedGame.SelectedValue == Enum.GetName(typeof(GameTypesEnum), GameTypesEnum.Addition))
            {
                theWindow = new AdditionGameWindow();
                mwvm.PlayGameWindowVM.DesiredGameType = GameTypesEnum.Addition;

            }
            else if (this.cmbSelectedGame.SelectedValue == Enum.GetName(typeof(GameTypesEnum), GameTypesEnum.Subtraction))
            {
                theWindow = new SubtractionGameWindow();
                mwvm.PlayGameWindowVM.DesiredGameType = GameTypesEnum.Subtraction;
            }
            else if (this.cmbSelectedGame.SelectedValue == Enum.GetName(typeof(GameTypesEnum), GameTypesEnum.Multiplication))
            {
                theWindow = new MultiplicationGameWindow();
                mwvm.PlayGameWindowVM.DesiredGameType = GameTypesEnum.Multiplication;
            }
            else if (this.cmbSelectedGame.SelectedValue == Enum.GetName(typeof(GameTypesEnum), GameTypesEnum.Division))
            {
                theWindow = new DivisionGameWindow();
                mwvm.PlayGameWindowVM.DesiredGameType = GameTypesEnum.Division;
            }
            if (theWindow == null)
            {
                return;
            }
                     
            //Closes the window select game window and brings the appropriate game window into view.
            Button btn = (Button)sender;
            Grid grid = (Grid)btn.Parent;
            SelectGameTypeWindow sgw = (SelectGameTypeWindow)grid.Parent;           
            theWindow.DataContext = mwvm.PlayGameWindowVM;           
            sgw.Close();
            theWindow.ShowDialog();           
            mw.Show();
            mw.BringIntoView();
  
        }
    }
}
