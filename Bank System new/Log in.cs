using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    [Serializable]
    public abstract class LogInClass
    {
        public virtual bool LogIn(string username, string password)
        {
            return false;
        }
    }
    [Serializable]
    public class LogInAsClient : LogInClass
    {
        //public override bool LogIn(string username, string password)
        public override bool LogIn(string username, string password)
        {
            Bank bank = Bank.get_obj();
            if (bank._ClientsList.ContainsKey(username))
            {
                Account.Client _client;
                bank._ClientsList.TryGetValue(username, out _client);
                if (_client.GetPassword() == password)
                {
                    
                    return true;
                }
            }
            return false;
        }
    }
    [Serializable]
    public class LogInAsEmployee : LogInClass
    {
        public override bool LogIn(string username, string password)
        {

            Bank bank = Bank.get_obj();
            if (bank._EmployeeList.ContainsKey(username))
            {
                Employee _Employee;
                bank._EmployeeList.TryGetValue(username, out _Employee);
                if (_Employee.GetPassword() == password)
                {

                    return true;
                }
            }
            return false;
        }
    }

}
