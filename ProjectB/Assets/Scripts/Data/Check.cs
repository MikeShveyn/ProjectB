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
        public string hb { get; set; }
        public string criatine { get; set; }
        public string iron { get; set; }
        public string hdl { get; set; }
        public string alkalinePhosphatase { get; set; }
        
        public IList<string> possibleDiagnosise { get;}
        
        public Check()
        {
            
        }
        
        public Check(string wbc,string neut, string lymph, string rbc, string htc, string hb, 
            string criatine, string iron, string hdl, string alkalinePhosphatase)
        {
            this.date = DateTime.Now.ToString("g");
            this.wbc = wbc;
            this.neut = neut;
            this.lymph = lymph;
            this.rbc = rbc;
            this.htc = htc;
            this.hb = hb;
            this.criatine = criatine;
            this.iron = iron;
            this.hdl = hdl;
            this.alkalinePhosphatase = alkalinePhosphatase;
            
            AnalyzeD();
            
        }

        
        private void AnalyzeD()
        {
            
            //ANALYZE AND ADD TO LIST
           List<string> temp = new List<string>();
           
           temp.AddRange(DBank.wbc[wbc]);
           temp.AddRange(DBank.neut[neut]);
           temp.AddRange(DBank.lymph[lymph]);
           temp.AddRange(DBank.rbc[rbc]);
           temp.AddRange(DBank.htc[htc]);
           temp.AddRange(DBank.creatin[criatine]);
           temp.AddRange(DBank.iron[iron]);
           temp.AddRange(DBank.hdl[hdl]);
           temp.AddRange(DBank.alcP[alkalinePhosphatase]);

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
                   possibleDiagnosise.Add(t);
               }
               else
               {
                   GameManager.Instance.DAnalzye[t] += 1;
               }
               
           }
            
           
        }

    }
}