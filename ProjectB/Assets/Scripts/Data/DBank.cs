using System;
using System.Collections.Generic;

namespace Data
{
    public static class DBank
    {
        //public static string[] ResForEach = {"Ok", "High", "Low"};

        public static Dictionary<string, string> DiseasesDict = new Dictionary<string, string>()
        {
            {"Anemia", "2 pills(10mg) per day for a month"},
            {"Diet", "Appointment with a nutritionist"},
            {"Bleeding"," Urgent evacuation to the hospital"},
            {"Hyperlipidemia","Appointment with a nutritionist and pill(simovil 5 mg) per day for a week"},
            {"Disorder of blood","pill(10mg of B12 per day for a month, pill(5mg) of folic acid per day for a month"},
            {"Hematologic Disorder","Injection of a hormone to encourage red blood cell production"},
            {"Iron poisoning","Evacuate to hospital"},
            {"Dehydration","Complete rest,lying down, returning fluids by drinking"},
            {"Infection","Antibiotics"},
            {"Vitamin deficiency","Referral for a blood test to identify the missing vitamins"},
            {"Viral disease","Rest at home"},
            {"Diseases of the biliary tract","Referral to surgical treatment"},
            {"Heart diseases","Schedule an appointment with a nutritionist"},
            {"Blood disease","A combination of cyclophosphamide and corticosteroids"},
            {"Liver disease","Referral to a specific diagnosis for the purpose of determining treatment"},
            {"Kidney disease","Balance blood sugar levels"},
            {"Iron deficiency","2 pills(10mg) per day for a month"},
            {"Muscle diseases","2(5 mg) pills of Altman C3 turmeric per day for a month. Smokers quit smoking"},
            {"Smokers","Stop smoking."},
            {"Lung disease","Stop smoking / refer to X-ray of the lungs. "},
            {"Overactive thyroid gland","Propylthiouracil for decrease activity."},
            {"Adult diabetes", "Insulin adjustment for the patient"},
            {"Cancer","Make an appointment with an oncologist for future treatment and Entrectinib."},
            {"Increased consumption of meat","Appointment with a nutritionist"},
            {"Use of various medications","Refer to the family doctor for a match between the medications"},
            {"Malnutrition","Appointment with a nutritionist"},
            {"Pregnancy","Make an appointment with a gynecologist."}
            
        };

        public static Dictionary<string, string[]> wbc = new Dictionary<string, string[]>()
        {
            {"High", new string[] {"Infection", "Blood disease", "Cancer"}},
            {"Low", new string[] {"Viral disease", "Cancer"}},
            {"Ok", new string[] {String.Empty}}
        };
        
        public static Dictionary<string, string[]> neut = new Dictionary<string, string[]>()
        {
            {"High", new string[] {"Infection"}},
            {"Low", new string[] {"Disorder of blood", "Infection", "Cancer"}},
            {"Ok", new string[] {String.Empty}}
        };
        
        public static Dictionary<string, string[]> lymph = new Dictionary<string, string[]>()
        {
            {"High", new string[] {"Infection", "Cancer"}},
            {"Low", new string[] {"Disorder of blood"}},
            {"Ok", new string[] {String.Empty}}
        };
        
        public static Dictionary<string, string[]> rbc= new Dictionary<string, string[]>()
        {
            {"High", new string[] {"Disorder of blood", "Lung disease","Smokers"}},
            {"Low", new string[] {"Anemia", "Bleeding"}},
            {"Ok", new string[] {String.Empty}}
        };
        
        public static Dictionary<string, string[]> htc = new Dictionary<string, string[]>()
        {
            {"High", new string[] {"Smokers"}},
            {"Low", new string[] {"Anemia", "Bleeding"}},
            {"Ok", new string[] {String.Empty}}
        };
        
        public static Dictionary<string, string[]> urea = new Dictionary<string, string[]>()
        {
            {"High", new string[] {"Kidney disease", "Dehydration", "Increased consumption of meat"}},
            {"Low", new string[] {"Malnutrition", "Diet", "Liver disease", "Pregnancy"}},
            {"Ok", new string[] {String.Empty}}
        };
        
        public static Dictionary<string, string[]> hb = new Dictionary<string, string[]>()
        {
            {"High", new string[] {String.Empty}},
            {"Low", new string[] {"Anemia", "Hematologic Disorder", "Iron deficiency", "Bleeding"}},
            {"Ok", new string[] {String.Empty}}
        };
        
        
        public static Dictionary<string, string[]> creatin = new Dictionary<string, string[]>()
        {
            {"High", new string[] {"Kidney disease", "Diseases of the biliary tract","Overactive thyroid gland", "Muscle diseases", "Increased consumption of meat"}},
            {"Low", new string[] {"Malnutrition"}},
            {"Ok", new string[] {String.Empty}}
        };

        
        public static Dictionary<string, string[]> iron = new Dictionary<string, string[]>()
        {
            {"High", new string[] {"Iron poisoning"}},
            {"Low", new string[] {"Diet", "Bleeding"}},
            {"Ok", new string[] {String.Empty}}
        };
        
        public static Dictionary<string, string[]> hdl = new Dictionary<string, string[]>()
        {
            {"High", new string[] {String.Empty}},
            {"Low", new string[] {"Heart diseases", "Hyperlipidemia", "Adult diabetes"}},
            {"Ok", new string[] {String.Empty}}
        };
        
        public static Dictionary<string, string[]> alcP = new Dictionary<string, string[]>()
        {
            {"High", new string[] {"Liver disease", "Diseases of the biliary tract", "Pregnancy", "Overactive thyroid gland",
                "Use of various medications"}},
            {"Low", new string[] {"Diet"}},
            {"Ok", new string[] {String.Empty}}
        };
        
        

        
        

    }
}