using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ConsoleApplication1;
namespace Bank_System_new
{
    public partial class test : Form
    {
        public test()
        {
            InitializeComponent();
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
                     
        }
        private void test_Load(object sender, EventArgs e)
        {
            Bank bank = Bank.get_obj();      
        dataGridView1.Columns.Add("Key", "KEY");
        dataGridView1.Columns.Add("Values", "VALUES");
        foreach (KeyValuePair<string,Account.Client> item in  bank._ClientsList)
        {
            dataGridView1.Rows.Add(item.Key, item.Value._Password);
        }
        foreach (KeyValuePair<string, Account> item in bank._AccountsList)
        {
            dataGridView1.Rows.Add(item.Key, item.Value.Account_ID);
        }
        foreach (KeyValuePair<string, Employee> item in bank._EmployeeList)
        {
            dataGridView1.Rows.Add(item.Key, item.Value._Password);
        }
        }
    }
}
