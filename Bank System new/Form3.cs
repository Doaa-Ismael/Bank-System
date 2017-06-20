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
    public partial class Form3 : Form
    {
        string sss;
        Bank bank;
        Account.Client _CurrentClient = new Account.Client();
        public Form3(string s)
        {
            InitializeComponent();
            sss = s;         
            bank = Bank.get_obj();
            bank._ClientsList.TryGetValue(sss, out _CurrentClient);             
        }
        private void Form3_Load(object sender, EventArgs e)
        {
            label1.Text = "Welcome " + sss + " your balance is ";
            textBox1.Text = _CurrentClient.GetBalance().ToString();
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox2.TextLength > 0)
            {
                _CurrentClient.Deposite(double.Parse(textBox2.Text));
                textBox1.Text = _CurrentClient.GetBalance().ToString();
                textBox3.Visible = true;
                textBox3.Text = "you deposite " + textBox2.Text + " successfully your balance now is" + _CurrentClient.GetBalance().ToString();
            }
            textBox2.Text = string.Empty;
            //textBox3.Text = string.Empty;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox4.TextLength>0)
            {	 
            if (!_CurrentClient.Withdraw(double.Parse(textBox4.Text)))
            {
                //MessageBox.Show("your Balace less than the sum you want to withdraw ");
                textBox5.Text = "your Balace less than the sum you want to withdraw ";
                //textBox5.Visible = true;
            }
            else
            {
                textBox1.Text = _CurrentClient.GetBalance().ToString();
                textBox5.Text = "you withdraw " + textBox4.Text + " successfully your balance now is" + _CurrentClient.GetBalance().ToString();
              //  MessageBox.Show(" done ");               
            }
            textBox4.Text = string.Empty;
            //textBox5.Text = string.Empty;
            }
        }
        private void button4_Click(object sender, EventArgs e)
        {
            textBox6.Text = _CurrentClient._Name;
            textBox7.Text = _CurrentClient._Address;
            textBox8.Text = _CurrentClient._TelephoneNumber;
            textBox9.Text = _CurrentClient._Password;
        }
        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox9.Text.Length < 8)
            {
                textBox10.Text = "password must be at least 8 character";
            }
            else
            {
                _CurrentClient.Update(textBox6.Text, textBox7.Text, textBox9.Text, textBox8.Text);
                textBox6.Clear();
                textBox7.Clear();
                textBox8.Clear();
                textBox9.Clear();
                textBox10.Text = "done";               
            }
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void tabPage4_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox11.Text = _CurrentClient.GetBalance().ToString();
            if (_CurrentClient.GetStatus())
            {
                textBox12.Text = "Active";
            }
            else
            {
                textBox12.Text = "InActive";
            }
            textBox13.Text = bank._AccountsList[_CurrentClient.GetUserName()].Account_ID.ToString();
        }

        private void Form3_FormClosing(object sender, FormClosingEventArgs e)
        {
            bank.Save();
            Application.Exit();
        }
        private void button6_Click(object sender, EventArgs e)
        {
            bank.Save();
            this.Close();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            test t = new test();
            t.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.Hide();
            bank.Save();
            Application.Exit();
        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void textBox3_Click(object sender, EventArgs e)
        {
           
          
        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

    }
}
