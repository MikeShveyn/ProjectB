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
        public IList<Check> checks {get;}
        
    
        public Patient()
        {
            
        }

        public Patient(string id, string name, string gender, string age, string smoke)
        {
            this.id = id;
            this.name = name;
            this.gender = gender;
            this.age = age;
            this.smoke = smoke;
        }

        public override string ToString()
        {
            string temp =  "<b> Name: </b>" + this.name + "\r\n<b> Id: </b>" + this.id + "\r\n<b> Gender: </b>" + this.gender + "\r\n<b> Age: </b>" + this.age + "\r\n<b> Smoke: </b>" + this.smoke;
            if (checks.Count > 0)
            {
                temp += "\r\n<b> LastCheck: </b>" + this.checks[checks.Count - 1].date;
            }
            
            return temp;

        }
    }
}