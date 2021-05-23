using System;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class MenuSignUp : MonoBehaviour
    {
        [SerializeField] private InputField id;
        [SerializeField] private Text idError;
        [SerializeField] private InputField name;
        [SerializeField] private Text nameError;
        [SerializeField] private InputField gender;
        [SerializeField] private Text genderError;
        [SerializeField] private InputField age;
        [SerializeField] private Text ageError;
        [SerializeField] private Toggle smoke;
        [SerializeField] private Dropdown ethnicity;


        public string Id()
        {
            return id.text;
        }
        
        public string Name()
        {
            return name.text;
        }
        
        public string Gender()
        {
            return gender.text;
        }
        
        public string Age()
        {
            return age.text;
        }


        public string Smoke()
        {
            bool temp = smoke.GetComponent<Toggle>().isOn;
            if (temp)
                return "Yes";
            else
                return "No";
        }

        public string Ethnicity => ethnicity.options[ethnicity.value].text;


        private void Start()
        {
            ClearError();
            
        }
        
        
        
        public void PrintError(string idEr, string nameEr, string genEr, string ageEr)
        {
            idError.text += idEr;
            nameError.text += nameEr;
            genderError.text += genEr;
            ageError.text += ageEr;
        }
        
        public void ClearError()
        {
            idError.text = "";
            nameError.text = "";
            genderError.text = "";
            ageError.text = "";
        }
    }
}