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
    private Patient _patient;
    private const string pathToDb = "C:/Users/97253/Desktop/ProjectB/Data";

    public Doc GetDoc()
    {
        return _doc;
    }

    public Patient GetPatient()
    {
        return _patient;
    }
    
    private void OnEnable()
    {
        var config = new RealmConfiguration(pathToDb + "/default.realm");
        
        _realm  = Realm.GetInstance(config);
        
    }
    
    private void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        //WINDOWS
        SignUp.SetActive(false);

        //start Level load
        UIManager.Instance.LoadLevel("Login");
    }

    //Doc_____________________________________________________________________________
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
    
    //patient-----------------------------------------------------------------------------
    public bool CheckPatient(string tag)
    {
        _patient = _realm.Find<Patient>(tag);
        if (_patient == null)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    public void PatientWriteToData(string id, string name , string gender, string age)
    {
        _realm.Write(() =>
        {
            _patient = _realm.Add(new Patient(id, name, gender, age));
        });
        print("Patient Write Succeed!");
    }
    
    
    //WINDOWS-----------------------------------------------------------------------------
    public void SignUpPage()
    {
        UIManager.Instance.LoadLevel("SignUp");
    }
    
    private void OnDisable()
    {
        _realm.Dispose();
    }
}
