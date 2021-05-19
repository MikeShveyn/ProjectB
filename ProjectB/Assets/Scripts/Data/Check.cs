using System;
using System.Collections.Generic;
using Realms;
using UnityEngine;

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
            this.date = DateTime.Now.ToString("yyyy/$$anonymous$$$$anonymous$$/dd HH:mm:ss");
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
        }

    }
}