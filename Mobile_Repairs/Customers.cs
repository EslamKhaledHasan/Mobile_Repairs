using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using Mobile_Repairs;

namespace Mobile_Repairs_M_S
{
    public partial class Customers : Form
    {
           Funcation Con;

        public Customers()
        {
            InitializeComponent();
            Con = new Funcation();
            ShowCustomers();
        }
        private void ShowCustomers()
        {
            string Query = "select * From CustomerTb1";
            CustomersList.DataSource = Con.GetData(Query);
        }
        private void SaveBtn_Click(object sender, EventArgs e)
        {
            if (CustNameTb.Text == "" || CustPhoneTb.Text == "" || CustPhoneTb.Text == "")
            {
                MessageBox.Show("Messing Data !!!");
            }
            else
            {
                try
                {
                    string CName = CustNameTb.Text;
                    string CPhone = CustPhoneTb.Text;
                    string CAdd = CustAddTb.Text;

                    string Query = "insert into CustomerTb1 values('{0}','{1}','{2}')";
                    Query = string.Format(Query, CName, CPhone, CAdd);
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
        int key = 0;

        private void CustomersList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            CustNameTb.Text = CustomersList.SelectedRows[0].Cells[1].Value.ToString();
            CustPhoneTb.Text = CustomersList.SelectedRows[0].Cells[2].Value.ToString();
            CustAddTb.Text = CustomersList.SelectedRows[0].Cells[3].Value.ToString();
            if (CustNameTb.Text == "")
            {
                key = 0;
            }
            else
            {
                key = Convert.ToInt32(CustomersList.SelectedRows[0].Cells[0].Value.ToString());
            }

        }

        private void CustNameTb_TextChanged(object sender, EventArgs e)
        {

        }

        private void UpdateBtn_Click(object sender, EventArgs e)
        {
            if (CustNameTb.Text == "" || CustPhoneTb.Text == "" || CustPhoneTb.Text == "")
            {
                MessageBox.Show("Messing Data !!!");
            }
            else
            {
                try
                {
                    string CName = CustNameTb.Text;
                    string CPhone = CustPhoneTb.Text;
                    string CAdd = CustAddTb.Text;

                    string Query = "Update CustomerTb1 set CustNameTb1 = '{0}', CustPhone = '{1}',CustAdd = '{2}' where CustCode = {3}";
                    Query = string.Format(Query, CName, CPhone, CAdd, key);
                    Con.setData(Query);
                    MessageBox.Show("Customer Updated!!!");
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
            key = 0;
        }
        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            if (key == 0)
            {
                MessageBox.Show("Select a Customer !!!");
            }
            else
            {
                try
                {


                    string Query = "delete from CustomerTb1 where CustCode = {0}";
                    Query = string.Format(Query, key);
                    Con.setData(Query);
                    MessageBox.Show("Customer Deleted !!!");
                    ShowCustomers();
                    Clear();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }
    }
}