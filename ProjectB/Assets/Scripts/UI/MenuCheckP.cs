using System;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class MenuCheckP : MonoBehaviour
    {
        [SerializeField] private InputField id;
        [SerializeField] private Text patientData;
        [SerializeField] private Text error;
        public void PatientData(string data)
        {
            patientData.text += data;
        }
        
        public string PatientId()
        {
            return id.text;
        }
        private void Start()
        {
            patientData.text = "";
            error.text = "";
        }

        public void PrintError(string er)
        {
            error.text += er;
            
        }

        public void ClearError()
        {
            error.text = "";
            patientData.text = "";
        }
        
    }
}