using System;
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
        [SerializeField] private Text erroF;
        
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


        public void ReduceMinus(InputField inp)
        {
            if (inp.text.Length > 0 && inp.text[0] == '-')
            {
                inp.text = inp.text.Remove(0, 1);
                print(inp.text);
            }
        }

        public bool CheckFieldsNotEmpty()
        {
            erroF.text = "";
            if (wbc.text == String.Empty)
            {
                erroF.text = "Wbc is empty!!!";
                return false;
            }

            if (this.neutrophil.text == String.Empty)
            {
                erroF.text = "Neutrophil is empty!!!";
                return false;
            }

            if (this.lymphocytes.text == String.Empty)
            {
                erroF.text = "Lymphocytes is empty!!!";
                return false;
            }

            if (this.redBloodCells.text == String.Empty)
            {
                erroF.text = "RedBloodCells is empty!!!";
                return false;
            }

            if (this.htc.text == String.Empty)
            {
                erroF.text = "HTC is empty!!!";
                return false;
            }


            if (this.urea.text == String.Empty)
            {
                erroF.text = "UREA is empty!!!";
                return false;
            }

            if (this.hemoblogin.text == String.Empty)
            {
                erroF.text = "HEMOGLOBIN is empty!!!";
                return false;
            }

            if (this.creatinine.text == String.Empty)
            {
                erroF.text = "Creatine is empty!!!";
                return false;
            }


            if (this.iron.text == String.Empty)
            {
                erroF.text = "IRON is empty!!!";
                return false;
            }

            if (this.hdLipoprotein.text == String.Empty)
            {
                erroF.text = "HDLipoprotein is empty!!!";
                return false;
            }

            if (this.alkalinePhospatase.text == String.Empty)
            {
                erroF.text = "AlkalinePhospatase is empty!!!";
                return false;
            }
                
            
            return true;
        }
        
        
        private void ClearFields()
        {
            this.wbc.text = "";
            this.creatinine.text = "";
            this.hemoblogin.text = "";
            this.htc.text = "";
            this.lymphocytes.text = "";
            this.iron.text = "";
            this.urea.text = "";
            this.neutrophil.text = "";
            this.alkalinePhospatase.text = "";
            this.hdLipoprotein.text = "";
            this.redBloodCells.text = "";
        }

        private void OnDisable()
        {
            erroF.text = "";
            ClearFields();
        }
        
    }
}