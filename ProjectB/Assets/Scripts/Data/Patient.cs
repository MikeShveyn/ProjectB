using System.Collections.Generic;
using Realms;
namespace Data

{
    public class Patient: RealmObject
    {
        [PrimaryKey]
        public string id { get; set; }
        public string name { get; set; }
        public string gender { get; set; }
        public string age{ get; set; }
        
        public string smoke { get; set;}
        
        public string ethnicity { get; set; }
        public IList<Check> checks {get;}
        
    
        public Patient()
        {
            
        }

        public Patient(string id, string name, string gender, string age, string smoke, string ethnicity)
        {
            this.id = id;
            this.name = name;
            this.gender = gender;
            this.age = age;
            this.smoke = smoke;
            this.ethnicity = ethnicity;
        }

        public override string ToString()
        {
            string temp =  "<b> Name: </b>" + this.name + "\r\n<b> Id: </b>" + this.id + 
                           "\r\n<b> Gender: </b>" + this.gender + "\r\n<b> Age: </b>" + 
                           this.age + "\r\n<b> Smoke: </b>" + this.smoke + "\r\n<b> Ethnicity: </b>" + this.ethnicity;
            if (checks.Count > 0)
            {
                temp += "\r\n<b> LastCheck: </b>" + this.checks[checks.Count - 1];
            }
            
            return temp;

        }
    }
}