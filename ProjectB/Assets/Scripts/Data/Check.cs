using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using Realms;
using UnityEngine;
using UnityEngine.UI;

namespace Data
{
    public class Check: RealmObject
    {
        [PrimaryKey]
        public string date { get; set; }
        
        public string wbc { get; set; }
        public string neut { get; set; }
        public string lymph { get; set; }
        public string rbc { get; set; }
        public string htc { get; set; }
        
        public string urea { get; set; }
        public string hb { get; set; }
        public string criatine { get; set; }
        public string iron { get; set; }
        public string hdl { get; set; }
        public string alkalinePhosphatase { get; set; }
        
        public IList<string> possibleDiagnosise { get;}
        
        public Check()
        {
            
        }
        
        public Check(string wbc,string neut, string lymph, string rbc, string htc, string urea, string hb, 
            string criatine, string iron, string hdl, string alkalinePhosphatase)
        {
            this.date = DateTime.Now.ToString("G");
            this.wbc = wbc;
            this.neut = neut;
            this.lymph = lymph;
            this.rbc = rbc;
            this.htc = htc;
            this.urea = urea;
            this.hb = hb;
            this.criatine = criatine;
            this.iron = iron;
            this.hdl = hdl;
            this.alkalinePhosphatase = alkalinePhosphatase;
            
            AnalyzeD();
            
        }

        
        private void AnalyzeD()
        {

            Patient localP = GameManager.Instance.GetPatient();
            //ANALYZE AND ADD TO LIST
           List<string> temp = new List<string>();
           string value = "";
            
           //Wbc-------------------------------------------------
           if (int.Parse(localP.age) >= 18)
           {
               if(int.Parse(wbc) > 11000)
                   value = "High";
               else if (int.Parse(wbc) < 4500)
                   value = "Low";
               else
                   value = "Ok";
           }
           else if(int.Parse(localP.age) <= 3)
           {
               if(int.Parse(wbc) > 17500)
                   value = "High";
               else if (int.Parse(wbc) < 6500)
                   value = "Low";
               else
                   value = "Ok";
           }
           else
           {
               if(int.Parse(wbc) > 15500)
                   value = "High";
               else if (int.Parse(wbc) < 5500)
                   value = "Low";
               else
                   value = "Ok";
           }
           
           temp.AddRange(DBank.wbc[value]);
           //Neut-------------------------------------------------
           if(int.Parse(this.neut) > 54)
               value = "High";
           else if (int.Parse(this.neut) < 28)
               value = "Low";
           else
               value = "Ok";
           
           temp.AddRange(DBank.neut[value]);
           
           //Lymph-------------------------------------------------
           if(int.Parse(this.lymph) > 52)
               value = "High";
           else if (int.Parse(this.lymph) < 36)
               value = "Low";
           else
               value = "Ok";
           
           temp.AddRange(DBank.lymph[value]);
           
           //RBC-------------------------------------------------
           if(double.Parse(this.rbc) > 6)
               value = "High";
           else if (double.Parse(this.rbc) < 4.5)
               value = "Low";
           else
               value = "Ok";
           temp.AddRange(DBank.rbc[value]);
           
           //HTC-------------------------------------------------
           if (localP.gender == "M" || localP.gender == "m")
           {
               if(int.Parse(this.htc) > 54)
                   value = "High";
               else if (int.Parse(this.htc) < 37)
                   value = "Low";
               else
                   value = "Ok";
           }
           else
           {
               if(int.Parse(this.htc) > 47)
                   value = "High";
               else if (int.Parse(this.htc) < 33)
                   value = "Low";
               else
                   value = "Ok";
           }
           
           temp.AddRange(DBank.htc[value]);
           //Urea--------------------------------------------------
           if (localP.ethnicity == "Mizrahi")
           {
               if(double.Parse(this.urea) > 47.3)
                   value = "High";
               else if (double.Parse(this.urea) < 18.7)
                   value = "Low";
               else
                   value = "Ok";
           }
           else
           {
               if(double.Parse(this.urea) > 47)
                   value = "High";
               else if (double.Parse(this.urea) < 33)
                   value = "Low";
               else
                   value = "Ok";
           }
           
           temp.AddRange(DBank.urea[value]);
           //HB-------------------------------------------------
           if (int.Parse(localP.age) < 18)
           {
               if(double.Parse(this.hb) > 15.5)
                   value = "High";
               else if (int.Parse(this.hb) < 11.5)
                   value = "Low";
               else
                   value = "Ok";
           }
           else
           {
               if (localP.gender == "M" || localP.gender == "m")
               {
                   if(double.Parse(this.hb) > 18)
                       value = "High";
                   else if (int.Parse(this.hb) < 12)
                       value = "Low";
                   else
                       value = "Ok";
               }
               else
               {
                   if(double.Parse(this.hb) > 16)
                       value = "High";
                   else if (int.Parse(this.hb) < 12)
                       value = "Low";
                   else
                       value = "Ok";
               }
           }
           temp.AddRange(DBank.hb[value]);
           //Creatine-------------------------------------------------
           if (int.Parse(localP.age) >= 60)
           {
               if(double.Parse(this.criatine) > 1.2)
                   value = "High";
               else if (double.Parse(this.criatine) < 0.6)
                   value = "Low";
               else
                   value = "Ok";
           }
           else if (int.Parse(localP.age) <= 59 && int.Parse(localP.age) >= 18)
           {
               if(double.Parse(this.criatine) > 1)
                   value = "High";
               else if (double.Parse(this.criatine) < 0.6)
                   value = "Low";
               else
                   value = "Ok";
           }
           else if (int.Parse(localP.age) <= 17 && int.Parse(localP.age) >= 3)
           {
               if(double.Parse(this.criatine) > 1)
                   value = "High";
               else if (double.Parse(this.criatine) < 0.5)
                   value = "Low";
               else
                   value = "Ok";
           }
           else
           {
               if(double.Parse(this.criatine) > 0.5)
                   value = "High";
               else if (double.Parse(this.criatine) < 0.2)
                   value = "Low";
               else
                   value = "Ok";
           }
           
           temp.AddRange(DBank.creatin[value]);
           //Iron-------------------------------------------------
           if (localP.gender == "M" || localP.gender == "m")
           {
               if(int.Parse(this.iron) > 160)
                   value = "High";
               else if (int.Parse(this.iron) < 60)
                   value = "Low";
               else
                   value = "Ok";
           }
           else
           {
               if(int.Parse(this.iron) > 128)
                   value = "High";
               else if (int.Parse(this.iron) < 48)
                   value = "Low";
               else
                   value = "Ok";
           }
           
           temp.AddRange(DBank.iron[value]);
           //Hdl-------------------------------------------------
           if (localP.ethnicity == "Ethiopian")
           {
               if (localP.gender == "M" || localP.gender == "m")
               {
                   if(double.Parse(this.hdl) > 74.4)
                       value = "High";
                   else if (double.Parse(this.hdl) < 34.8)
                       value = "Low";
                   else
                       value = "Ok";
               }
               else
               {
                   if(double.Parse(this.hdl) > 98.3)
                       value = "High";
                   else if (double.Parse(this.hdl) < 40.8)
                       value = "Low";
                   else
                       value = "Ok";
               }
           }
           else
           {
               if (localP.gender == "M" || localP.gender == "m")
               {
                   if(double.Parse(this.hdl) > 62)
                       value = "High";
                   else if (double.Parse(this.hdl) < 29)
                       value = "Low";
                   else
                       value = "Ok";
               }
               else
               {
                   if(double.Parse(this.hdl) > 82)
                       value = "High";
                   else if (double.Parse(this.hdl) < 34)
                       value = "Low";
                   else
                       value = "Ok";
               }
           }
           temp.AddRange(DBank.hdl[value]);
           //AlcP-------------------------------------------------
           if (localP.ethnicity == "Mizrahi")
           {
               if(int.Parse(this.alkalinePhosphatase) > 120)
                   value = "High";
               else if (int.Parse(this.alkalinePhosphatase) < 60)
                   value = "Low";
               else
                   value = "Ok";
           }
           else
           {
               if(int.Parse(this.alkalinePhosphatase) > 90)
                   value = "High";
               else if (int.Parse(this.alkalinePhosphatase) < 30)
                   value = "Low";
               else
                   value = "Ok";
           }
           
           temp.AddRange(DBank.alcP[value]);
            
           //Setup and fill relevant data------------------------------------------------
           GameManager.Instance.DSize = temp.Count;
           foreach (var t in temp)
           {
               if (t == String.Empty)
               {
                   continue;
               }
               else if (!GameManager.Instance.DAnalzye.ContainsKey(t))
               {
                   GameManager.Instance.DAnalzye[t] = 1;
                   //possibleDiagnosise.Add(t);
               }
               else
               {
                   GameManager.Instance.DAnalzye[t] += 1;
               }
               
           }
            
           
        }
        
        public override string ToString()
        {
            string temp =  " Date: " + this.date + "\r\n Conclusion: ";
            foreach (var checks in possibleDiagnosise)
            {
             
                temp += "\r\n" + checks;
            }

            return temp;

        }

    }
}