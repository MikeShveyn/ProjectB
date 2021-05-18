using System;
using System.Collections;
using System.Collections.Generic;
using Data;
using Realms;
using UnityEngine;
using UTILS;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] private GameObject SignUp; 
    
    private Realm _realm;
    private Doc _doc;
    
    protected override void Awake()
    {
        base.Awake();
    }


    private void OnEnable()
    {
        _realm = Realm.GetInstance();
    }

    private void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        SignUp.SetActive(false);
        UIManager.Instance.LoadLevel("Login");
    }


    public void CheckDoc(string tag)
    {
        _doc = _realm.Find<Doc>(tag);
        if (_doc == null)
        {
            SignUp.SetActive(true);
        }
        else
        {
            UIManager.Instance.LoadLevel("Analize");
        }
    }

    public void WriteToData(string userName,string password, string name)
    {
        _realm.Write(() =>
            {
                _doc = _realm.Add(new Doc(userName, password, name));
            });
        print("Succeed!");
        UIManager.Instance.LoadLevel("Login");
    }

    //SignUpWindow
    public void SignUpPage()
    {
        UIManager.Instance.LoadLevel("SignUp");
    }
    
    private void OnDisable()
    {
        _realm.Dispose();
    }
}
