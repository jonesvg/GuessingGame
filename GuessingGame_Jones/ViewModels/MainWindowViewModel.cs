using GuessingGame_Jones.Controlers;
using GuessingGame_Jones.Views;
using System.Windows;
using System.Windows.Input;

namespace GuessingGame_Jones.ViewModels
{
    public class MainWindowViewModel
    {
        #region Variables
        private clsControl objGC;
        public Window MainWindow;

        private ICommand _startQuizCommand;

        public ICommand StartQuizCommand
        {
            get
            {
                if (_startQuizCommand == null)
                {
                    _startQuizCommand = new RelayCommand(this.StartQuiz);
                }
                return _startQuizCommand;
            }
        }

        private ICommand _finishQuizCommand;

        public ICommand FinishQuizCommand
        {
            get
            {
                if (_finishQuizCommand == null)
                {
                    _finishQuizCommand = new RelayCommand(this.Finish);
                }
                return _finishQuizCommand;
            }
        }

        #endregion

        public MainWindowViewModel()
        {
            objGC = new clsControl();
        }

        public void StartQuiz()
        {
            QuestionWindowViewModel quizViewModel = new QuestionWindowViewModel(objGC);
            var wnQuestion = new QuestionWindow(quizViewModel);
            wnQuestion.Show();
        }

        public void Finish()
        {
            MainWindow.Close();
        }
    }
}
