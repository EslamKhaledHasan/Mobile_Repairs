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
      
    public partial class Repairs : Form
    {
        public Repairs()
        {
            InitializeComponent();
            Con = new Functions();
            ShowRepairs();
            GetCustomer();
            GetSpare();
        }

        private void GetCustomer()
        {
            string Query = "Select * from CustomerTb1";
            CustCb.ValueMember = Con.GetData(Query).Columns["CustCode"].ToString();
            CustCb.DataSource = Con.GetData(Query);


        }

        private void GetCost()
        {
            String Query = "Select * from SpareTb1 Where SpCode={0}";
            Query = String.Format(Query, SpareCb.SelectedValue.ToString());
            foreach (DataRow dr in Con.GetData(Query).Rows)
            {
                SpareCostTb.Text = dr["SpCost"].ToString();
            }
          //  MessageBox.Show("hello");
        }
        private void ShowRepairs()
        {

            String Query = "Select * from RepairTb1";
            SparesList.DataSource = Con.GetData(Query);
        }
        private void GetSpare()
        {
            string Query = "Select * from SpareTb1";
            SpareCb.DisplayMember = Con.GetData(Query).Columns["SpName"].ToString();
            SpareCb.ValueMember = Con.GetData(Query).Columns["SpCode"].ToString();
            SpareCb.DataSource = Con.GetData(Query);


        }

        internal Functions Con { get; }

        private void Repairs_Load(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            if (CustCb.SelectedIndex == -1 || PhoneTb.Text == "" || DNameTb.Text == "" || ModelTb.Text == "" || SpareCb.SelectedIndex == -1 || SpareCostTb.Text == "" || TotalTb.Text == "")
            {
                MessageBox.Show("Missing Data!!!");

            }
            else
            {
                try
                {
                    String RData = RepDateTb.Value.Date.ToString();
                    int Customer = Convert.ToInt32(CustCb.SelectedValue.ToString());
                    String CPhone = PhoneTb.Text;

                    string DeviceName = DNameTb.Text;
                    string DeviceModel = ModelTb.Text;
                    string problem = ProblemTb.Text;
                    int Spare = Convert.ToInt32(SpareCb.SelectedValue.ToString());
                    int Total = Convert.ToInt32(TotalTb.Text);
                    int GrdTotal = Convert.ToInt32(SpareCostTb.Text) + Total;
                    string Query = "insert into RepairTb1 values('{0}','{1}','{2}','{3}','{4}','{5}''{6}',{7},{8})";
                    Query = string.Format(Query, RData, Customer, CPhone, DeviceName, DeviceModel, problem, Spare, GrdTotal);
                    Con.setData(Query);
                    MessageBox.Show("Repairs Added!!!");
                    ShowRepairs();
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
            CustCb.SelectedIndex = -1;
            PhoneTb.Text = "";
            DNameTb.Text = "";
            ModelTb.Text = "";
            SpareCb.SelectedIndex = -1;
            SpareCostTb.Text = "";
            TotalTb.Text = "";
        }
        int Key = 0;

        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            if (Key == 0)
            {
                MessageBox.Show("Selected a Repairs!!!");

            }
            else
            {
                try
                {

                    string Query = "Delete from RepairTb1 where RepCode={0}";
                    Query = string.Format(Query, Key);
                    Con.setData(Query);
                    MessageBox.Show("Repairs Deleted!!!");
                    ShowRepairs();
                    Clear();

                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);

                }
            }
        }

        private void CustCb_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetCost();
        }

        private void SpareCostTb_SelectionChangeCommitted(object sender, EventArgs e)
        {

        }

        private void SparesList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            Key = Convert.ToInt32(SparesList.SelectedRows[0].Cells[0].Value.ToString());

        }
    }


}
