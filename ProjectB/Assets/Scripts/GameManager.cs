using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
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
    private Check _check;
    private Dictionary<string, int> dAnalzye;
    private int dSize;
    private const string pathToDb = "C:/Users/97253/Desktop/ProjectB/Data";

    public int DSize
    {
        get => dSize;
        set => dSize = value;
    }

    public Doc GetDoc()
    {
        return _doc;
    }

    public Patient GetPatient()
    {
        return _patient;
    }

    public Dictionary<string, int> DAnalzye
    {
        get => dAnalzye;
        set => dAnalzye = value;
    }

    public Check GetCheck()
    {
        return _check;
    }
    
    //-----------------------------------------------------------------------------------
    private void OnEnable()
    {
        //Build
        //var config = new RealmConfiguration(Application.dataPath + "/DataBase/default.realm");
        //Editor
        var config = new RealmConfiguration(pathToDb + "/default.realm");
        _realm  = Realm.GetInstance(config);
       // _realm  = Realm.GetInstance();
        
    }
    
    private void Start()
    {
        DAnalzye = new Dictionary<string, int>();
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

    public void PatientWriteToData(string id, string name , string gender, string age, string smoke)
    {
        _realm.Write(() =>
        {
            _patient = _realm.Add(new Patient(id, name, gender, age, smoke));
        });
        print("Patient Write Succeed!");
    }
    
    
    //check-----------------------------------------------------------------------------
    public void CheckWriteToData(string wbc,string neut, string lymph, string rbc, string htc, string hb, 
        string criatine, string iron, string hdl, string alkalinePhosphatase)
    {
        _realm.Write(() =>
        {
            _check = _realm.Add(new Check(wbc,neut,lymph,rbc,htc,hb, criatine,iron,hdl,alkalinePhosphatase));
            _patient.checks.Add(_check);
        });
        print("Check Write Succeed and added to patient!");
    }
    
    
    //WINDOWS-----------------------------------------------------------------------------
    public void SignUpPage()
    {
        UIManager.Instance.LoadLevel("SignUp");
    }


    public void PrintPatient()
    {
        //Print to file
        string path = Application.dataPath +  "/PatientLogs/" + _patient.id + ".txt";
        
        if (!File.Exists(path))
        {
            File.WriteAllText(path, "Patients lOGS\n\n");
        }

        string content = _patient.ToString();

        try
        {
            File.AppendAllText(path, content);
        }
        catch
        {
            // ignored
        }
    }
    
    public void ResetPatient()
    {
        _patient = null;
        _check = null;
    }

    public void ResetAll()
    {
        _patient = null;
        _check = null;
        _doc = null;
    }
    
    //-----------------------------------------------------------------------------------------
    
    private void OnDisable()
    {
        _realm.Dispose();
    }

    public void Quite()
    {
        Application.Quit();
    }
}
