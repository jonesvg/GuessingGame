using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessingGame_Jones.Controlers
{
    public class clsControl
    {
        #region variables
        public List<clsQuestion> lstRootQuestion; // Lista com todas as caracteristicas e nomes de animais
        private bool blnLastState; // Ultimo status dos botões se foi pressionado sim ou não - False para não e true para sim
        #endregion
        #region constructor
        /// <summary>
        /// Construtor da classe, aqui á crio os primeiros tipos Sharl e monkey com ono exemplo
        /// </summary>
        public clsControl()
        {
            lstRootQuestion = new List<clsQuestion>();
            lstRootQuestion.Add(new clsQuestion("Shark", "Live in water", true));
            lstRootQuestion.Add(new clsQuestion("Monkey", "", true));
            blnLastState = false;
        }
        #endregion
        #region Properties
        public bool LastState
        {
            get
            {
                return blnLastState;
            }
            set
            {
                blnLastState = value;
            }
        }
        #endregion
        #region Public Functions
        /// <summary>
        /// Função que coloca na lista raiz o proximo elemento de raiz. Considerei como elementos de raiz aqueles que iniciam uma arvore de questões, o novo elemento fica sempre em penultimo.
        /// </summary>
        /// <param name="_tmpQuestion"></param>
        public void PlaceQuestionInRoot(clsQuestion _tmpQuestion)
        {
            clsQuestion lastQuestion = lstRootQuestion[lstRootQuestion.Count() - 1];
            lstRootQuestion.Remove(lastQuestion);
            lstRootQuestion.Add(_tmpQuestion);
            lstRootQuestion.Add(lastQuestion); //Para que Monkey sempre seja o ultimo do root
        }
        /// <summary>
        /// Busca uma Question pelo indice dele na lista raiz. 
        /// </summary>
        /// <param name="_index"></param>
        /// <returns></returns>
        public clsQuestion GetQuestionByIndex(int _index)
        {
            return lstRootQuestion[_index];
        }
        /// <summary>
        /// Seta dentro daquela question uma nova question não raiz cujo ultimo botão pressionado foi Yes, ou seja, este animal possui a mesma caracteristica do seu antecessor
        /// </summary>
        /// <param name="_nextPositive"></param>
        /// <param name="_characteristic"></param>
        public void SetNextQuestionYes(clsQuestion _nextPositive, string _characteristic)
        {
            lstRootQuestion.Where(x => x.Characteristic == _characteristic).FirstOrDefault().NextPositiveQuestion = _nextPositive;
        }
        /// <summary>
        /// Seta dentro daquela question uma nova question não raiz cujo ultimo botão pressionado foi o NO, ou seja, este animal possui pelo menos uma caracteristica igual a de seu antecessor, porém a ultima caracteristica é não é igual.
        /// por exemplo vive na água mas não come carne
        /// </summary>
        /// <param name="_nextNegative"></param>
        /// <param name="_characteristic"></param>
        public void SetNextQuestionNo(clsQuestion _nextNegative, string _characteristic)
        {
            lstRootQuestion.Where(x => x.Characteristic == _characteristic).FirstOrDefault().NextNegativeQuestion = _nextNegative;
        }
        #endregion
    }
}
