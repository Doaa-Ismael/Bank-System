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
    public partial class Form1 : Form
    {
        Bank bank;
        public Form1()
        {
            InitializeComponent();
             bank = Bank.get_obj();
             Employee emp = new Employee("Emp", "Emp");
             emp.SaveEmployee();
        }
        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                Account.Client client = Account.CreateObjectOfClientClass();
                if (!client.LogInWhoEver (textBox1.Text, textBox2.Text))
                {
                    textBox3.Visible = true;                
                    textBox3.Text = "sorry you have not an account please try again ! ";
                }
                else
                {
                    textBox3.Visible = true;
                    textBox3.Text = "welcome ";                  
                     Form f = new Form3(textBox1.Text);
                    f.Show();
                    this.Visible = false;                   
                }
            }
            else if (radioButton2.Checked == true)
            {
                Employee employee = new Employee(textBox1.Text, textBox2.Text);
                if (!employee.LogInWhoEver(textBox1.Text, textBox2.Text))
                {
                    textBox3.Visible = true;
                    textBox3.Text = "Sorry you can't login please try again ! ";

                }
                else
                {                 
                    Employee_form e_form = new Employee_form(textBox1.Text);                
                    e_form.Show();
                    this.Hide();
                }
            }
            else
            {
                textBox3.Visible = true;
                textBox3.Text = "please you must determine you are client or employee";
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            string ss = textBox8.Text;
            if (bank._ClientsList.ContainsKey(textBox7.Text))
            {
                textBox10.Visible = true;
                textBox10.Text = "this handle is already exist try another one";
            }
            else if (textBox8.Text != textBox9.Text)
            {
                textBox10.Visible = true;
                textBox10.Text = "the two passwords are not the same try again !";
            }
            else
            {
                Account.Client Client = new Account.Client();
                Client.Register(textBox4.Text, textBox5.Text, textBox7.Text, textBox8.Text, textBox6.Text);
                textBox10.Visible = true;
                textBox10.Text = "you registered successfully";              
                 Form f = new Form3(textBox7.Text);
                f.Show();
                this.Visible = false;
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
