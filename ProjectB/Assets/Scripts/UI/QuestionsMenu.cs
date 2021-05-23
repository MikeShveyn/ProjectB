using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class QuestionsMenu : MonoBehaviour
    {
        [SerializeField] private InputField wbc;
        [SerializeField] private InputField neutrophil;
        [SerializeField] private InputField lymphocytes;
        [SerializeField] private InputField redBloodCells;
        [SerializeField] private InputField htc;
        [SerializeField] private InputField urea;
        [SerializeField] private InputField hemoblogin;
        [SerializeField] private InputField creatinine;
        [SerializeField] private InputField iron;
        [SerializeField] private InputField hdLipoprotein;
        [SerializeField] private InputField alkalinePhospatase;
        
        
        
        public string Wbc => wbc.text;

        public string Neutrophil => neutrophil.text;

        public string Lymphocytes => lymphocytes.text;

        public string RedBloodCells => redBloodCells.text;

        public string Htc => htc.text;

        public string Urea => urea.text;

        public string Hemoblogin => hemoblogin.text;

        public string Creatinine => creatinine.text;

        public string Iron => iron.text;

        public string HdLipoprotein => hdLipoprotein.text;

        public string AlkalinePhospatase => alkalinePhospatase.text;
        
        
        
        
    }
}