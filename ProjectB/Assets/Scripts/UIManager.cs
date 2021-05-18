using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UTILS;

public class UIManager : Singleton<UIManager>
{
    public void LoadLevel(string level)
    {
        SceneManager.LoadScene(level);
        
    }
    
    
}
