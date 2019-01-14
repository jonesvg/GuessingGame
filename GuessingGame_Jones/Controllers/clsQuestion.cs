using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessingGame_Jones.Controlers
{
    public class clsQuestion
    {
        #region variables
        private string strAnimalName;
        private string strCharacteristic;
        private clsQuestion qtnNextQuestionYes;
        private clsQuestion qtnNextQuestionNo;
        private bool blnIsRoot;
        #endregion
        #region constructor
        /// <summary>
        /// Construtor da classe, recebe nome de animal, caracteristica e se este pertence ou não a raiz
        /// </summary>
        /// <param name="_animalName"></param>
        /// <param name="_characteristic"></param>
        /// <param name="_root"></param>
        public clsQuestion(string _animalName, string _characteristic, bool _root)
        {
            strAnimalName = _animalName;
            strCharacteristic = _characteristic;
            blnIsRoot = _root;
        }
        #endregion
        #region Properties
        public string AnimalName
        {
            get
            {
                return strAnimalName;
            }
            set
            {
                strAnimalName = value;
            }
        }

        public string Characteristic
        {
            get
            {
                return strCharacteristic;
            }
            set
            {
                strCharacteristic = value;
            }
        }

        public clsQuestion NextPositiveQuestion
        {
            get
            {
                return qtnNextQuestionYes;
            }
            set
            {
                qtnNextQuestionYes = value;
            }
        }

        public clsQuestion NextNegativeQuestion
        {
            get
            {
                return qtnNextQuestionNo;
            }
            set
            {
                qtnNextQuestionNo = value;
            }
        }

        public bool Root
        {
            get
            {
                return blnIsRoot;
            }
            set
            {
                blnIsRoot = value;
            }
        }
        #endregion
    }
}
