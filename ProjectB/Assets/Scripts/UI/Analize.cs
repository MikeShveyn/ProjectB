using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class Analize : MonoBehaviour
    {
        [SerializeField] private Text titleName;
        // Start is called before the first frame update
        void Start()
        {
            titleName.text += GameManager.Instance.GetDoc().name;
        }

        
    }
}
