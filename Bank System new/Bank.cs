using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Runtime.Serialization;
using System.Threading;
namespace ConsoleApplication1
{
    public class Bank
    {
        public Dictionary<string, Account> _AccountsList;
        public Dictionary<string, Employee> _EmployeeList ;
        public Dictionary<string, Account.Client> _ClientsList ;
        public Stack<int> _numList; 
        public static Bank bank_obj;
        private static readonly object syncLock = new object();
        private Bank()
        {
            _AccountsList=new Dictionary<string, Account>();
            _EmployeeList = new Dictionary<string, Employee>();
            _ClientsList = new Dictionary<string, Account.Client>();
            _numList = new Stack<int>();
            Load();
        }       
        public void Load()
        {
            FileStream Account_file = new FileStream("Account.txt", FileMode.OpenOrCreate);
            FileStream Employee_file = new FileStream("Employee.txt", FileMode.OpenOrCreate);
            FileStream Client_file = new FileStream("client.txt", FileMode.OpenOrCreate);
            FileStream number_file = new FileStream("num.txt", FileMode.OpenOrCreate);
            Account_file.Seek(0, SeekOrigin.Begin);
            Employee_file.Seek(0, SeekOrigin.Begin);
            Client_file.Seek(0, SeekOrigin.Begin);
            BinaryFormatter Formatter = new BinaryFormatter();
            _AccountsList.Clear();
            _ClientsList.Clear();
            _EmployeeList.Clear();
            try
            {
                _AccountsList = (Dictionary<string, Account>)Formatter.Deserialize(Account_file);
                _ClientsList = (Dictionary<String, Account.Client>)Formatter.Deserialize(Client_file);
                _EmployeeList = (Dictionary<string, Employee>)Formatter.Deserialize(Employee_file);
                _numList = (Stack<int>)Formatter.Deserialize(number_file);
            }
            catch (SerializationException e)
            {
                //Console.WriteLine("Failed to serialize. Reason: " + e.Message);
               // Console.WriteLine("Load method ");
                ;
            }
            Account_file.Close();
            Client_file.Close();
            Employee_file.Close();
            number_file.Close();
        }
        //public void SaveINTOHardDisk(){ 1: clear all 3 file 2:save in file}
        public void Save()
        {
            FileStream Account_file = new FileStream("Account.txt", FileMode.Create);
            FileStream Employee_file = new FileStream("Employee.txt", FileMode.Create);
            FileStream Client_file = new FileStream("client.txt", FileMode.Create);
            FileStream number_file = new FileStream("num.txt", FileMode.Create);
            BinaryFormatter Formatter = new BinaryFormatter();
            try
            {
                Formatter.Serialize(Account_file, _AccountsList);
                Formatter.Serialize(Client_file, _ClientsList);
                Formatter.Serialize(Employee_file, _EmployeeList);
                Formatter.Serialize(number_file, _numList);
            }
            catch (SerializationException e)
            {                
            }
            Account_file.Close();
            Client_file.Close();
            Employee_file.Close();
            number_file.Close();
        }
        ///      
        public static Bank get_obj()
        {
            lock (syncLock)
            {
                if (bank_obj == null)
                {
                    bank_obj = new Bank();
                }
            }
            return bank_obj;
        }

    }


}
