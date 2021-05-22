using System;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class SignUp : MonoBehaviour
    {
        [SerializeField] private InputField userName;
        [SerializeField] private InputField password;
        [SerializeField] private InputField name;
        [SerializeField] private Text userBug;
        [SerializeField] private Text passBug;
        
        public void TakeInfo()
        {
            //clear text
            userBug.text = "";
            passBug.text = "";
        
            //Cash
            String userN = userName.text.ToString();
            String pass = password.text.ToString();
            String namePass = name.text.ToString();
            //check data base
            if (ValidUserName(userN) && ValidPassword(pass) && namePass!=string.Empty)
            {
                GameManager.Instance.WriteToData(userN,pass,namePass);
            }
        
        
        }
    
        //User Name check---------------------------------------------------------------------------------------------------
        private bool ValidUserName(String name)
        {
            //valid name
            int size = name.Length;
            bool checkSize = (size >= 6 && size <= 8);
            bool numDigits = CountDigit(name) <= 2;
            bool onlyEng = CheckLetters(name);
            if (checkSize && numDigits && onlyEng)
            {
                return true;
            }
            else
            {
                if (checkSize == false)
                {
                    userBug.text += " Need size 6-8 symbols.";
                }
                if (numDigits == false)
                {
                    userBug.text += " Maximum 2 digits. ";
                }
                if (onlyEng == false)
                {
                    userBug.text += " Use only english letters. ";
                }

                return false;
            }
        }
    
        private bool CheckLetters(String name)
        {
            for (int i = 0; i < name.Length; i++)
            {
                if (((name[i] >= 'a' && name[i] <= 'z') || (name[i] >= 'A' && name[i] <= 'Z') || Char.IsDigit(name[i])) == false)
                {
                    return false;
                }
            }

            return true;
        }
    
    
    
    
        //Password check---------------------------------------------------------------------------------------------------
    
        private bool ValidPassword(string name)
        {
            int size = name.Length;
            bool checkSize = (size >= 8 && size <= 10);
            bool numDigits = CountDigit(name) >= 1;
            bool numLetters = CountLetters(name);
            bool specSymbols = CheckSpecialSymbol(name);
            if (checkSize && numDigits && numLetters && specSymbols)
            {
                return true;
            }
            else
            {
                if (checkSize == false)
                {
                    passBug.text += " Need size 8-10 symbols.";
                }
                if (numDigits == false)
                {
                    passBug.text += " At least 1 digit. ";
                }
                if (numLetters == false)
                {
                    passBug.text += " At least 1 letter. ";
                }
                if (specSymbols == false)
                {
                    passBug.text += " At least 1 specSymbol. ";
                }

                return false;
                
            }
        }

        private bool CountLetters(String name)
        {
            int count = 0;
            for (int i = 0; i < name.Length; i++)
            {
                if((name[i] >= 'a' && name[i] <= 'z') || (name[i] >= 'A' && name[i] <= 'Z'))
                {
                    count++;
                }
            }

            if (count >=1)
            {
                return true;
            }

            return false;
        }
    
        private bool CheckSpecialSymbol(String name)
        {
            int count = 0;
            for (int i = 0; i < name.Length; i++)
            {
                if(!Char.IsLetterOrDigit(name[i]))
                {
                    count++;
                }
            }

            if (count >=1)
            {
                return true;
            }

            return false;
        }

        //HELP METHODS------------------------------------------------------------------------------------------------------
        private int CountDigit(String name)
        {
            int count = 0;
            for (int i = 0; i < name.Length; i++)
            {
                if (Char.IsDigit(name[i]))
                {
                    count++;
                }
            }

            return count;
        }

   
    }
    
}
