using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    [Serializable]
    public class Account
    {
        double _Balance;
        bool _State;
        public string _Account_user;
        public int Account_ID;       
        public Account(string account_id)
        {
            _Balance = 0;
            _State = true;            
            _Account_user = account_id;
            Bank bank = Bank.get_obj();
            if (bank._numList.Count == 0)
            {
                Account_ID = 1;
                bank._numList.Push(1);
            }
            else
            {
                Account_ID = bank._numList.Max() + 1;
                bank._numList.Push(Account_ID);

            }

        }
        public Account()
        {
            _Balance = 0;
            _State=true;
            _Account_user = "";
            Bank bank = Bank.get_obj();
            if (bank._numList.Count == 0)
            {
                Account_ID = 1;
                bank._numList.Push(1);
            }
            else
            {
                Account_ID = bank._numList.Max() + 1;
                bank._numList.Push(Account_ID);
            }
        }
        public static Client CreateObjectOfClientClass()
        {
            Client obj = new Client();
            return obj;
        }
        public Client CreateObjectOfClientClass(string name, string address, string username, string password, int accountnum, string tele)
        {
            Client obj = new Client(name, address, username, password, tele);
            return obj;
        }
        public Account(double balace, bool state)
        {
            _Balance = balace;
            _State = state;
            Bank bank = Bank.get_obj();
            if (bank._numList.Count == 0)
            {
                Account_ID = 1;
                bank._numList.Push(1);
            }
            else
            {
                Account_ID = bank._numList.Max() + 1;
                bank._numList.Push(Account_ID);
            }
        }
        public void Deposite(double n)
        {
            if (!_State)
            {
                ActivateAccount();
            }
            _Balance += n;
            this.SaveAccount();
        }
        public bool Withdrow(double n)//modify 
        {
            if (_Balance - n <= 0)
            {
                return false;
            }
            _Balance -= n;
            SaveAccount();
            return true;
        }
        public string DisplayBalance()
        {
            return (_Balance.ToString());
        }
        public void DeactivateAccount()
        {
            this._State = false;
            this._Balance = 0;
            SaveAccount();
        }
        public void ActivateAccount()
        {
            _State = true;
        }
        public bool IsActive()
        { return _State; }
        ///////////////////////////
        void Update_Account()
        {
            Bank bank = Bank.get_obj();
            if (bank._AccountsList.ContainsKey(this._Account_user))
            {
                bank._AccountsList.Remove(this._Account_user);
                SaveAccount();
            }
        }
        // void SaveAccount() { }
        public void SaveAccount()
        {
            Bank bank = Bank.get_obj();
            if (bank._AccountsList.ContainsKey(this._Account_user))
            {
                bank._AccountsList.Remove(this._Account_user);
                bank._AccountsList[this._Account_user] = this;
                return;
            }
            bank._AccountsList[this._Account_user] = this;
        }
        [Serializable]
        public class Client : Person  // nested class 
        {          
           public string _TelephoneNumber { set; get; }
            public Client(string username, string password)
                : base(username, password)
            {
                this.loginability = new LogInAsClient();
            }
            public Client()
            {
                this.loginability = new LogInAsClient();
            }
            public Client(string name, string address, string username, string password, string tele)
                : base(name, address, username, password)
            {
                this.loginability = new LogInAsClient();
                //_AccountNumber = accountnum;
                _TelephoneNumber = tele;
            }
            public double GetBalance()
            {
                Bank bank = Bank.get_obj();
                return bank._AccountsList[_UserName]._Balance;
            }
            public void DisplayPersonalDetails(ref string name, ref string address, ref string username, ref string password, ref string telenum)
            {
                name = this._Name;
                address = this._Address;
                username = _UserName;
                password = _Password;
                telenum = _TelephoneNumber;
            }
            public void Update(string name, string address, string password, string tele)
            {
                this._Name = name;
                this._Address = address;
                this._Password = password;
                this._TelephoneNumber = tele;
                Bank bank = Bank.get_obj();
                if (bank._ClientsList.ContainsKey(this._UserName))
                {
                    bank._ClientsList.Remove(this._UserName);
                    this.SaveClient();
                }
                
            }
            public bool Register(string name, string address, string username, string password, string telenum)
            {
                // check that user name is not exists
                Bank bank = Bank.get_obj();
                if (bank._ClientsList.ContainsKey(username))
                    return false;
                else
                {
                    Account _Account = new Account(username);
                    Client _client = new Client(name, address, username, password, telenum);
                    bank._ClientsList.Add(username, _client);
                    _Account.SaveAccount();
                }
                return true;
            }
            
            private  void SaveClient()
            {
                Bank bank = Bank.get_obj();
                bank._ClientsList.Remove(this._UserName);
                bank._ClientsList.Add(this._UserName, this);
            }
            public override bool SetUserName(string user_name)
            {
                Bank bank = Bank.get_obj();
                if (!bank._EmployeeList.ContainsKey(user_name))
                    return true;
                return false;
            }
            /////////////////////
            public void Deposite(double n)
            {
                Account account = new Account(this._UserName);
                Bank bank = Bank.get_obj();
                //bank._AccountsList[this._UserName].Deposite(n);
                if (bank._AccountsList.ContainsKey(this._UserName))
                {
                    bank._AccountsList.TryGetValue(this._UserName, out account);    
                    
                    account.Deposite(n);
                }
            }
            public bool Withdraw(double n)
            {
                 Account account = new Account(this._UserName);
                Bank bank = Bank.get_obj();
                if (bank._AccountsList.ContainsKey(this._UserName))
                {
                    bank._AccountsList.TryGetValue(this._UserName, out account);
                    //bank._AccountsList.Remove(this._UserName);
                    return (account.Withdrow(n));
                }
                return false;
            }
            public bool GetStatus()
            {
                 Bank bank = Bank.get_obj();
                return  bank._AccountsList[this._UserName]._State;
            }
        }
    }
}
