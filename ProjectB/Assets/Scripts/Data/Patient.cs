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
        public IList<Check> checks {get;}
        

        public Patient()
        {
            
        }

        public Patient(string id, string name, string gender, string age)
        {
            this.id = id;
            this.name = name;
            this.gender = gender;
            this.age = age;
        }

        public override string ToString()
        {
            return " Name: " + this.name + "\r\n Id: " + this.id + "\r\n Gender: " + this.gender + "\r\n Age: " + this.age;

        }
    }
}