using System;
using System.Collections.Generic;
using System.Linq;
using Data;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class Analize : MonoBehaviour
    {
        
        [SerializeField] private Text titleName;
        
        //Menus
        [SerializeField] private GameObject menuCheck;
        [SerializeField] private GameObject menuSignUp;
        [SerializeField] private GameObject menuQuestions;
        [SerializeField] private GameObject menuConclusion;
        //Buttons
        [SerializeField] private Button startCheckButton;
        //Code r
        private MenuCheckP _menuCheckP;
        private MenuSignUp _menuSignUp;
        private QuestionsMenu _questionsMenu;
        private MenuConcl _menuConcl;
        private 
        // Start is called before the first frame update
        void Start()
        {
            titleName.text += GameManager.Instance.GetDoc().name;
            _menuCheckP = menuCheck.GetComponent<MenuCheckP>();
            _menuSignUp = menuSignUp.GetComponent<MenuSignUp>();
            _questionsMenu = menuQuestions.GetComponent<QuestionsMenu>();
            _menuConcl = menuConclusion.GetComponent<MenuConcl>();
            //Windows
            menuSignUp.SetActive(false);
            startCheckButton.gameObject.SetActive(false);
            menuQuestions.gameObject.SetActive(false);
            menuConclusion.gameObject.SetActive(false);
            menuCheck.gameObject.SetActive(true);
        }
        
        //MeuCheckP button---------------------------------------------------------------
        public void LogInPatient()
        {
            
            _menuCheckP.ClearError();
            string id = _menuCheckP.PatientId();
            if (ValidId(id, false))
            {
                if(GameManager.Instance.CheckPatient(id))
                {
                    _menuCheckP.PatientData(GameManager.Instance.GetPatient().ToString());
                    _menuSignUp.gameObject.SetActive(false);
                    startCheckButton.gameObject.SetActive(true);
                }
                else
                {
                    _menuCheckP.PrintError("There is no such patient!!!");
                    menuSignUp.gameObject.SetActive(true);
                    startCheckButton.gameObject.SetActive(false);
                }
                
            }
       

        }
        
        
        //SignUpMenu----------------------------------------------------------
        public void SignUpPatient()
        {
            _menuSignUp.ClearError();
            string id = _menuSignUp.Id();
            string name = _menuSignUp.Name();
            string age = _menuSignUp.Age();
            string gender= _menuSignUp.Gender();
            string smoke = _menuSignUp.Smoke();
            
            if (ValidId(id, true) && ValidAge(age) && ValidGender(gender) && ValidName(name))
            {
                GameManager.Instance.PatientWriteToData(id, name, gender, age, smoke);
                _menuSignUp.gameObject.SetActive(false);
            }
        }
        
        
        //MenuQuestions--------------------------------------------------------
        public void CreateCheck()
        {    
       
            GameManager.Instance.CheckWriteToData(_questionsMenu.Wbc, _questionsMenu.Neutrophil,
                _questionsMenu.Lymphocytes,
                _questionsMenu.RedBloodCells, _questionsMenu.Htc, _questionsMenu.Hemoblogin, _questionsMenu.Creatinine,
                _questionsMenu.Iron, _questionsMenu.HdLipoprotein, _questionsMenu.AlkalinePhospatase);
            
            OpenMenuConcl();
        }
        
        //Menu Conclusion-----------------------------------------------------------
        private void FillData()
        {
            Dictionary<string, int> temp = new Dictionary<string, int>(GameManager.Instance.DAnalzye);
            int tempSize = GameManager.Instance.DSize;
            string pData = "";
            //Calc
            foreach (var t in temp.Keys.ToList())
            {
                if(t == "Smokers" && GameManager.Instance.GetPatient().smoke == "No")
                    continue;
                
                temp[t] = (int)((temp[t] / (float)tempSize) * 100);
                pData += t + " with " + temp[t] + "% probability, recommended treatment: " +
                         DBank.DiseasesDict[t] + "\r\n";
            }

            //Get concl menu field and edit
            
            _menuConcl.ConclText += pData;
        }

        public void PrintPatient()
        {
            GameManager.Instance.PrintPatient();
        }

        //Windows Management-----------------------------------------------------------
        public void OpenMenuQuestions()
        {
            _menuCheckP.gameObject.SetActive(false);
            menuQuestions.gameObject.SetActive(true);
        }

        private void OpenMenuConcl()
        {
            menuQuestions.gameObject.SetActive(false);
            menuConclusion.gameObject.SetActive(true);
            FillData();
        }

        public void OpenMenuPatientLog()
        {
            _menuCheckP.gameObject.SetActive(true);
            _menuConcl.gameObject.SetActive(false);
            GameManager.Instance.ResetPatient();
        }

        public void EndSession()
        {
            GameManager.Instance.ResetAll();
            UIManager.Instance.LoadLevel("Login");
        }
        
        //Patient valid data check--------------------------------------------------
        private bool ValidId(string id, bool signUp)
        {
            if (id.Length != 9)
            {
                if(signUp)
                    _menuSignUp.PrintError("Non valid size, should be 9 digits", "", "", "");
                else
                    _menuCheckP.PrintError("Non valid size, should be 9 digits");
                return false;
                
            }

            for (int i = 0; i < id.Length; i++)
            {
                if (!Char.IsDigit(id[i]))
                {
                    _menuCheckP.PrintError("Non valid id, should be only digits");
                    return false;
                }
            }

            return true;
        }
        
        
        //valid name
        private bool ValidName(string name)
        {
            for (int i = 0; i < name.Length; i++)
            {
                if(((name[i] >= 'a' && name[i] <= 'z') || (name[i] >= 'A' && name[i] <= 'Z'))==false)
                {
                    _menuSignUp.PrintError("", "Should consist only letters", "", "");
                    return false;
                }
            }

            return true;
        }

        //valid age
        private bool ValidAge(string age)
        {
            if (age == String.Empty)
            {
                return false;
            }
            
            for (int i = 0; i < age.Length; i++)
            {
                if(Char.IsDigit(age[i]) == false)
                {
                    _menuSignUp.PrintError("", "", "", "Age includes only digits");
                    return false;
                }
            }

            return true;
        }

        //valid gender

        private bool ValidGender(string gender)
        {
            if (gender.Equals("F") || gender.Equals("f") || gender.Equals("M") || gender.Equals("m"))
            {
                return true;
            }
            _menuSignUp.PrintError("", "", "F/f-for women, M/m-for men", "");
            return false;
        }

    }
}
