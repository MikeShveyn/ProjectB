using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class MenuConcl : MonoBehaviour
    {
        [SerializeField] private Text conclText;
        
        public string ConclText
        {
            get => conclText.text;
            set => conclText.text = value;
        }
    }
}