using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    [Serializable]
    public class Person
    {
        public LogInClass loginability;
        public string _Name;
        public string _Address;
        protected string _UserName;
        public string _Password;
        public string GetUserName()
        {
            return _UserName;
        }
        public string GetPassword()
        {
            return _Password;
        }
        public bool SetPassword(string password)
        {
            if (password.Length < 8)
            {
                return false;
            }
            _Password = password;
            return true;
        }
        // bool SetUserName() { } must be unique so must check the hash table       
        virtual public bool SetUserName(string user_name)
        {
            return false;
        }
        public Person(string name)
        {
            _Name = name;
        }
        public Person()
        {
        }
        public Person(string name, string address, string username, string password)
        {
            _Name = name;
            _UserName = username;
            _Address = address;
            _Password = password;
        }
        public Person(string username, string password)
        {
            _UserName = username;
            _Password = password;
        }
        public bool LogInWhoEver(string username, string password)
        {
            return loginability.LogIn(username, password);
        }
    }
}
