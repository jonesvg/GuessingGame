using GuessingGame_Jones.ViewModels;
using System.Windows;

namespace GuessingGame_Jones.Views
{
    /// <summary>
    /// Interaction logic for QuestionWindow.xaml - Esta tela comanda todas as mensagens de verificação de nome e caracteristica do animal.
    /// </summary>
    public partial class QuestionWindow : Window
    {
        #region Constructor
        public QuestionWindow(QuestionWindowViewModel viewModel)
        {
            InitializeComponent();
            this.DataContext = viewModel;
            (this.DataContext as QuestionWindowViewModel).QuestionWindow = this;
        }
        #endregion
        #region Private functions        
        /// <summary>
        /// Evento de fechamento da tela que pode ou não dar show na main window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void QuestionWindow_Close(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!(DataContext as QuestionWindowViewModel).blnNotOpenMain)
                Application.Current.MainWindow.Show();
        }
        #endregion
    }
}