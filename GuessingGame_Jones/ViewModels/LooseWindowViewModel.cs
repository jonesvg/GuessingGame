using GuessingGame_Jones.Controlers;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;

namespace GuessingGame_Jones.ViewModels
{
    public class LooseWindowViewModel : INotifyPropertyChanged
    {
        #region variables
        private clsControl objGC { get; set; }
        private clsQuestion qtnTmp { get; set; }
        public bool blnNotOpenMain { get; set; }
        private bool blnAnimalThought { get; set; }
        private clsQuestion qtnNewQuestion { get; set; }
        public string strTmpAnimalName { get; set; }
        public string strTmpAnimalCharacteristics { get; set; }

        public Window looseWindow;


        private ICommand _finishClickCommand;

        public ICommand FinishClickCommand
        {
            get
            {
                if (_finishClickCommand == null)
                {
                    _finishClickCommand = new RelayCommand(this.OnClick);
                }
                return _finishClickCommand;
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
        protected void OnPropertyChanged(string value)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(value));
            }
        }
        
        private string placeText;
        public string txtPlaceText
        {
            get { return placeText; }
            set
            {
                placeText = value;
                OnPropertyChanged("txtPlaceText");
            }
        }
        #endregion

        #region Events
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        #region Contructor
        public LooseWindowViewModel(clsControl _objGC, clsQuestion _qtnTmp)
        {
            objGC = _objGC;
            qtnTmp = _qtnTmp;
            blnNotOpenMain = false;
            lblQuestion = "What was the animal you \n thought about?";
            blnAnimalThought = false;
        }
        #endregion

        public void OnClick()
        {
            if (!string.IsNullOrEmpty(txtPlaceText))
            {
                if (!blnAnimalThought)
                {
                    strTmpAnimalName = txtPlaceText;
                    blnAnimalThought = true;
                    txtPlaceText = "";
                    lblQuestion = string.Format("A {0} _______ but {1} does not (Fill it with \n an animal trait, like \"Lives in water\")", strTmpAnimalName, qtnTmp.AnimalName);
                }
                else
                {
                    strTmpAnimalCharacteristics = txtPlaceText;
                    if (qtnTmp.AnimalName == "Monkey")
                    {
                        qtnNewQuestion = new clsQuestion(strTmpAnimalName, strTmpAnimalCharacteristics, true);
                        objGC.PlaceQuestionInRoot(qtnNewQuestion);
                    }
                    else
                    {
                        qtnNewQuestion = new clsQuestion(strTmpAnimalName, strTmpAnimalCharacteristics, false);
                        if (objGC.LastState)
                        {
                            qtnTmp.NextPositiveQuestion = qtnNewQuestion;
                        }
                        else
                        {
                            qtnTmp.NextNegativeQuestion = qtnNewQuestion;
                        }
                    }
                    blnNotOpenMain = true;
                    looseWindow.Close();
                }
            }else
            {
                if(string.IsNullOrEmpty(strTmpAnimalName))
                {
                    lblQuestion = "We need an Answer, what was the animal you \n thought about?";
                }
                else
                {
                    lblQuestion = string.Format("We need and Answer: A {0} _______ but {1} \n does not (Fill it with an animal trait, like \n \"Lives in water\")", strTmpAnimalName, qtnTmp.AnimalName);
                }
            }
        }
    }
}
