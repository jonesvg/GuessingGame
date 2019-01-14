using GuessingGame_Jones.Controlers;
using GuessingGame_Jones.Views;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;

namespace GuessingGame_Jones.ViewModels
{
    public class QuestionWindowViewModel : INotifyPropertyChanged
    {
        #region Events
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        #region Properties
        public bool blnNotOpenMain { get; set; } 

        private clsControl objGC { get; set; }

        private string strMessageCharacteristic { get; set; }
        private string strMessageAnimal { get; set; }
        private int intListIndex { get; set; }
        private clsQuestion qtnTmpQuestion { get; set; }
        private clsQuestion qtnLastAnimal { get; set; }
        private bool blnEnd { get; set; }

        public Window QuestionWindow;

        private ICommand _yesAnswerCommand;

        public ICommand YesAnswerCommand
        {
            get
            {
                if (_yesAnswerCommand == null)
                {
                    _yesAnswerCommand = new RelayCommand(this.YesAnswer);
                }
                return _yesAnswerCommand;
            }
        }

        private ICommand _noAnswerCommand;

        public ICommand NoAnswerCommand
        {
            get
            {
                if (_noAnswerCommand == null)
                {
                    _noAnswerCommand = new RelayCommand(this.NoAnswer);
                }
                return _noAnswerCommand;
            }
        }

        private string question;
        public string lblQuestion
        {
            get { return question; }

            set
            {
                question = value;
                OnPropertyChanged("lblQuestion");
            }
        }

        protected void OnPropertyChanged(string question)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(question));
            }
        }
        #endregion

        #region Constructor

        public QuestionWindowViewModel(clsControl _objGC)
        {
            objGC = _objGC;
            blnNotOpenMain = false;
            strMessageCharacteristic = "Does the animal that you thought about \n {0}?";
            strMessageAnimal = "Is the animal that you thought \n about a {0}?";
            intListIndex = 0;
            qtnTmpQuestion = objGC.GetQuestionByIndex(intListIndex);
            blnEnd = false;
            lblQuestion = string.Format(strMessageCharacteristic, qtnTmpQuestion.Characteristic);
        }
        #endregion
        #region Methods
        public void YesAnswer()
        {
            if (!blnEnd)
            {
                objGC.LastState = true;
                if (qtnTmpQuestion.NextPositiveQuestion != null)
                {
                    qtnLastAnimal = qtnTmpQuestion;
                    lblQuestion = string.Format(strMessageCharacteristic, qtnTmpQuestion.NextPositiveQuestion.Characteristic);
                    qtnTmpQuestion = qtnTmpQuestion.NextPositiveQuestion;
                }
                else
                {
                    lblQuestion = string.Format(strMessageAnimal, qtnTmpQuestion.AnimalName);
                    blnEnd = true;
                }
            }
            else
            {
                WinWindowViewModel newWin = new WinWindowViewModel();
                var wnWin = new WinWindow(newWin);                
                wnWin.Show();
                blnNotOpenMain = true;
                QuestionWindow.Close();
            }
        }

        public void NoAnswer()
        {
            if (!blnEnd)
            {
                objGC.LastState = false;
                if (qtnTmpQuestion.NextNegativeQuestion != null)
                {
                    qtnLastAnimal = qtnTmpQuestion;
                    lblQuestion = string.Format(strMessageCharacteristic, qtnTmpQuestion.NextNegativeQuestion.Characteristic);
                    qtnTmpQuestion = qtnTmpQuestion.NextNegativeQuestion;
                }
                else
                {
                    if (!qtnTmpQuestion.Root)
                    {
                        lblQuestion = string.Format(strMessageCharacteristic, qtnLastAnimal.AnimalName);
                        blnEnd = true;
                    }
                    else
                    {
                        intListIndex++;
                        qtnTmpQuestion = objGC.GetQuestionByIndex(intListIndex);
                        blnEnd = false;
                        lblQuestion = string.Format(strMessageCharacteristic, qtnTmpQuestion.Characteristic);

                        if (qtnTmpQuestion.AnimalName == "Monkey")
                        {
                            lblQuestion = string.Format(strMessageAnimal, qtnTmpQuestion.AnimalName);
                            blnEnd = true;
                        }
                    }
                }
            }
            else
            {
                LooseWindowViewModel newLoose = new LooseWindowViewModel(objGC, qtnTmpQuestion);
                var wnLoose = new LooseWindow(newLoose);
                newLoose.looseWindow = wnLoose;
                wnLoose.Show();
                blnNotOpenMain = true;
                QuestionWindow.Close();
            }            
        }
        #endregion

    }
}
