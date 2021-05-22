using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class QuestionsMenu : MonoBehaviour
    {
        [SerializeField] private Dropdown wbc;
        [SerializeField] private Dropdown neutrophil;
        [SerializeField] private Dropdown lymphocytes;
        [SerializeField] private Dropdown redBloodCells;
        [SerializeField] private Dropdown htc;
        [SerializeField] private Dropdown urea;
        [SerializeField] private Dropdown hemoblogin;
        [SerializeField] private Dropdown creatinine;
        [SerializeField] private Dropdown iron;
        [SerializeField] private Dropdown hdLipoprotein;
        [SerializeField] private Dropdown alkalinePhospatase;
        
        
        public string Wbc => wbc.options[wbc.value].text;

        public string Neutrophil => neutrophil.options[neutrophil.value].text;

        public string Lymphocytes => lymphocytes.options[lymphocytes.value].text;

        public string RedBloodCells => redBloodCells.options[redBloodCells.value].text;

        public string Htc => htc.options[htc.value].text;

        public string Urea => urea.options[urea.value].text;

        public string Hemoblogin => hemoblogin.options[hemoblogin.value].text;

        public string Creatinine => creatinine.options[creatinine.value].text;

        public string Iron => iron.options[iron.value].text;

        public string HdLipoprotein => hdLipoprotein.options[hdLipoprotein.value].text;

        public string AlkalinePhospatase => alkalinePhospatase.options[alkalinePhospatase.value].text;
    }
}