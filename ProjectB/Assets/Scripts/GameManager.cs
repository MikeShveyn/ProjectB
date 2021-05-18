using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UTILS;

public class GameManager : Singleton<GameManager>
{
    protected override void Awake()
    {
        base.Awake();
    }

    private void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        UIManager.Instance.LoadLevel("Login");
    }
    
    
    
}
