using GuessingGame_Jones.Controlers;
using System.Windows;
using System.Windows.Input;

namespace GuessingGame_Jones.ViewModels
{
    public class WinWindowViewModel
    {
        #region Variables
        public Window WinWindow;


        private ICommand _closeCommand;

        public ICommand CloseCommand
        {
            get
            {
                if (_closeCommand == null)
                {
                    _closeCommand = new RelayCommand(this.CloseWindow);
                }
                return _closeCommand;
            }
        }

        #endregion

        #region Methods
        public void CloseWindow()
        {
            WinWindow.Close();
        }
        #endregion
    }
}
