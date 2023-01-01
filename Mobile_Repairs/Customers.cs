using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mobile_Repairs
{
    public partial class Customers : Form
    {
       
        public Customers()
        {
            InitializeComponent();
            Con = new Functions();
            ShowCustomers();
        }
        private void ShowCustomers()
        {
            String Query = "Select * from CustomerTb1";
            CustomersList.DataSource = Con.GetData(Query);
        }
        internal Functions Con { get; }

        private void Customers_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }


        
        private void SaveBtn_Click(object sender, EventArgs e)
        {

            if (CustNameTb.Text == "" || CustPhoneTb.Text == "" || CustAddTb.Text == "")
            {
                MessageBox.Show("Missing Data!!!");

            }
            else
            {
                try
                {
                    string CustName = CustNameTb.Text;
                    string CustPhone = CustPhoneTb.Text;
                    string CustAdd = CustAddTb.Text;
                    string Query = "insert into CustomerTb1 values('{0}','{1}','{2}')";
                    Query = string.Format(Query, CustName, CustPhone, CustAdd);
                    Con.setData(Query);
                    MessageBox.Show("Customer Added!!!");
                    ShowCustomers();
                    Clear();

                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);

                }
            }
        }

        private void UpdateBtn_Click(object sender, EventArgs e)
        {
            if (CustNameTb.Text == "" || CustPhoneTb.Text == "" || CustAddTb.Text == "")
            {
                MessageBox.Show("Missing Data!!!");

            }
            else
            {
                try
                {
                    string CustName = CustNameTb.Text;
                    string CustPhone = CustPhoneTb.Text;
                    string CustAdd = CustAddTb.Text;
                    string Query = "Update CustomerTb1 set CustName = '{0}' ,CustPhone = '{1}',CustAdd = '{2}' where CustCode = {3}";
                    Query = string.Format(Query, CustName, CustPhone, CustAdd, Key);
                    Con.setData(Query);
                    MessageBox.Show("Customer Edited!!!");
                    ShowCustomers();
                    Clear();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);

                }
            }
        }
        
        private void Clear()
        {
            CustNameTb.Text = "";
            CustPhoneTb.Text = "";
            CustAddTb.Text = "";
            Key = 0;

           
        }

        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            if (Key == 0)
            {
                MessageBox.Show("Selected a Customer!!!");

            }
            else
            {
                try
                {

                    string Query = "Delete from CustomerTb1 where CustCode={0}";
                    Query = string.Format(Query, Key);
                    Con.setData(Query);
                    MessageBox.Show("Customer Deleted!!!");
                    ShowCustomers();
                    Clear();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);

                }
            }

            
        }
        int Key = 0;

        private void CustomersList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            CustNameTb.Text = CustomersList.SelectedRows[0].Cells[1].Value.ToString();
            CustPhoneTb.Text = CustomersList.SelectedRows[0].Cells[2].Value.ToString();
            CustAddTb.Text = CustomersList.SelectedRows[0].Cells[3].Value.ToString();
            if (CustNameTb.Text == "")
            {
                Key = 0;

            }
            else
            {
                Key = Convert.ToInt32(CustomersList.SelectedRows[0].Cells[0].Value.ToString());

            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}


