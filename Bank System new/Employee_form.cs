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
    public partial class Employee_form : Form
    {
        string _Employee_username;
        Bank bank = Bank.get_obj();
        Employee emp;
        public Employee_form(string emp_username)
        {
            InitializeComponent();
            _Employee_username = emp_username;

            if (bank._EmployeeList.ContainsKey(_Employee_username))
            {
                bank._EmployeeList.TryGetValue(_Employee_username, out emp);
            }          
        }

        private void button1_Click(object sender, EventArgs e)
        {           
            if (bank._EmployeeList.ContainsKey(emp_user_name.Text)) 
            {
                if (_Employee_username == emp_user_name.Text)
                {
                    if (emp.Delete(emp_user_name.Text))
                    {
                        MessageBox.Show("Employee is deleted!");
                        Form1 f = new Form1();
                        f.Show();
                        this.Hide();
                    }
                }
                else
                {
                    if(emp.Delete(emp_user_name.Text))
                    MessageBox.Show("Employee is deleted!");
                    
                       
                }
                
            }
            else MessageBox.Show("Employee dosen't exist!");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            Employee new_emp = new Employee(name_txt.Text, address_txt.Text, username_txt.Text, password_txt.Text, position_txt.Text, college_txt.Text, grade_txt.Text, int.Parse(year_txt.Text));
            if (new_emp.SaveEmployee())
            {
                //message_txt.Text = "Added!";
                //message_txt.Visible = true;
                MessageBox.Show("Added!");
            }
            else
            {
               /* message_txt.Visible = true;
                message_txt.Text = "try another user name !";
                message_txt.Clear();
                username_txt.Clear();*/
                MessageBox.Show("Try another username");

            }
            /*
            name_txt.Clear();
            address_txt.Clear();
            username_txt.Clear();
            password_txt.Clear();
            position_txt.Clear();
            college_txt.Clear();
            year_txt.Clear();
            grade_txt.Clear();
            message_txt.Clear();
            */
            
        }
        private void tabPage3_Click(object sender, EventArgs e)
        {

        }

        private void Employee_form_Load(object sender, EventArgs e)
        {

        }

        private void Employee_form_FormClosing(object sender, FormClosingEventArgs e)
        {
            bank.Save();
            Application.Exit();
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (emp.CloseAccount(int.Parse(textBox8.Text)))
            { //message_txt.Text = "Closed!";
                MessageBox.Show("Closed!");
            }
            else
            {
                //message_txt.Text = "the account dose not exist!";
                //message_txt.Clear();
                MessageBox.Show("The account dose not exist!");
            }
                  
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void year_txt_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void tabPage4_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            name__txt.Text = emp._Name;
            position__txt.Text = emp.GetPosition();
            year__txt.Text = emp.GetYearGraduate().ToString();
            coll_txt.Text = emp.GetCollege();
            user__txt.Text = emp.GetUserName();
            add_txt.Text = emp._Address;
            grade_txt.Text = emp.GetGrade();

        }

        private void textBox8_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
    }
}
