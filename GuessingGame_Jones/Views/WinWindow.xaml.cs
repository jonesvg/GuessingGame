using GuessingGame_Jones.ViewModels;
using System.Windows;

namespace GuessingGame_Jones.Views
{
    /// <summary>
    /// Interaction logic for WinWindow.xaml
    /// </summary>
    public partial class WinWindow : Window
    {
        #region constructor
        /// <summary>
        /// Construtor da tela de vitoria da maquina
        /// </summary>
        public WinWindow(WinWindowViewModel viewModel)
        {
            InitializeComponent();
            this.DataContext = viewModel;
            (this.DataContext as WinWindowViewModel).WinWindow = this;
        }
        #endregion
        #region Private functions       
        /// <summary>
        /// Evento de fechamento de tela
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
                Application.Current.MainWindow.Show();
        }
        #endregion
    }
}
