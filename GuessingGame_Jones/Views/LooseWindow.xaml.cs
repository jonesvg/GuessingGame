using GuessingGame_Jones.Controlers;
using GuessingGame_Jones.ViewModels;
using System.Windows;

namespace GuessingGame_Jones.Views
{
    /// <summary>
    /// Interaction logic for LooseWindow.xaml
    /// </summary>
    public partial class LooseWindow : Window
    {

        #region constructor
        public LooseWindow(LooseWindowViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
        }
        #endregion

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!(DataContext as LooseWindowViewModel).blnNotOpenMain)
                Application.Current.MainWindow.Show();
        }
    }
}
