
using Realms;
    
namespace Data
{
    public class Doc : RealmObject
    {
        [PrimaryKey]
        public string docTag { get; set; }
        
        public string userName { get; set; }
        public string password { get; set; }
        public string name { get; set; }

        public Doc()
        {
            
        }

        public Doc(string userName, string password, string name)
        {
            this.userName = userName;
            this.password = password;
            this.name = name;
            this.docTag = userName + password;
        }
    }
}
