using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    [Serializable]
    public class Employee : Person
    {
        string _Position;
        string _College;
        string _Total_Grade;
        int _YearGraduate;
        public Employee()
        {
            this.loginability = new LogInAsEmployee();
        }
        public Employee(string username, string password)
            : base(username, password)
        {
            this.loginability = new LogInAsEmployee();

        }
        public Employee(string name, string address, string username, string password, string pos, string coll, string grade, int year)
            : base(name, address, username, password)
        {
            this.loginability = new LogInAsEmployee();
            _Position = pos;
            _College = coll;
            _Total_Grade = grade;
            _YearGraduate = year;
        }
        public void AssigmentOperator(ref Employee obj)
        {
            this._Name = obj._Name;
            this._Address = obj._Address;
            this._College = obj._College;
            this._UserName = obj._UserName;
            this._Password = obj._Password;
            this._Position = obj._Position;
            this._YearGraduate = obj._YearGraduate;
            this._Total_Grade = obj._Total_Grade;
        }
        public string GetPosition()
        {
            return _Position;
        }
        public string GetCollege()
        {
            return _College;
        }
        public string GetYearGraduate()
        {
            return _YearGraduate.ToString();
        }
        public string GetGrade()
        {
            return _Total_Grade;
        }
        public bool CloseAccount(int accountID)
        {
            Bank bank = Bank.get_obj();
            foreach (KeyValuePair<string,Account> p in bank._AccountsList)
            {
                if (p.Value.Account_ID==accountID)
                {
                    p.Value.DeactivateAccount();
                    return true;
                }
            }
            return false;     
        }                
    /////
        //public void Delete (string name){}
        public bool Delete(string name)
        {
            Bank bank = Bank.get_obj();
            if (bank._EmployeeList.ContainsKey(name))
            {
                bank._EmployeeList.Remove(name);
                return true;
            }
            return false;
            
        }
        //public void Add(Employee newemployee) { }
        public bool Add(Employee newemployee)
        {
            Bank bank = Bank.get_obj();
            if (bank._EmployeeList.ContainsKey(newemployee._UserName))
            {
                return false;
            }
            else
            {
                return (newemployee.SaveEmployee());
            }

        }
        // public void SaveEmployee() { }
        public bool SaveEmployee()
        {
            Bank bank = Bank.get_obj();
            if (!bank._EmployeeList.ContainsKey(this._UserName))
            {
                bank._EmployeeList.Add(this._UserName, this);
                return true;
            }
            return false;
        }
        public override bool SetUserName(string user_name)
        {
            Bank bank = Bank.get_obj();
            if (!bank._EmployeeList.ContainsKey(user_name))
                return true;
            return false;
        }
    }
}
