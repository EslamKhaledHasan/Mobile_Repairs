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

    
    public partial class Spares : Form
    {
        internal Functions Con { get; }

        public Spares()
        {
            InitializeComponent();
            Con = new Functions();
            ShowSpares();
        }
        private void ShowSpares()
        {
            String Query = "Select * from SpareTb1";
            PartList.DataSource = Con.GetData(Query);
        }
        private void Spares_Load(object sender, EventArgs e)
        {

        }
        private void Clear()
        {
            PartNameTb.Text = "";
            PartCostTb.Text = "";
            key = 0;

        }
        private void SaveBtn_Click(object sender, EventArgs e)
        {

            if (PartNameTb.Text == "" || PartCostTb.Text == "")
            {
                MessageBox.Show("Missing Data!!!");

            }
            else
            {
                try
                {
                    string SName = PartNameTb.Text;
                    int SCost = Convert.ToInt32(PartCostTb.Text);
                    string Query = "insert into SpareTb1 values('{0}',{1})";
                    Query = string.Format(Query, SName, SCost);
                    Con.setData(Query);
                    MessageBox.Show("Spare Added!!!");
                    ShowSpares();
                    Clear();

                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);

                }
            }

        }
        int key = 0;

        private void UpdateBtn_Click(object sender, EventArgs e)
        {
            if (PartNameTb.Text == "" || PartCostTb.Text == "")
            {
                MessageBox.Show("Missing Data!!!");

            }
            else
            {
                try
                {
                    string SName = PartNameTb.Text;
                    int SCost = Convert.ToInt32(PartCostTb.Text);
                    string Query = "Update SpareTb1 set SpName ='{0}',SpCost ='{1}' Where SpCode={2}";
                    Query = string.Format(Query, SName, SCost, key);
                    Con.setData(Query);
                    MessageBox.Show("Spare UpDeted!!!");
                    ShowSpares();
                    Clear();

                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);

                }
            }
        }

        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            if (key == 0)
            {
                MessageBox.Show(" Selected a Spares !!!");

            }
            else
            {
                try
                {

                    string Query = "Delete from SpareTb1  Where SpCode={0}";
                    Query = string.Format(Query, key);
                    Con.setData(Query);
                    MessageBox.Show("Spare Deleted!!!");
                    ShowSpares();
                    Clear();

                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);

                }
            }
        }

        private void PartList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            PartNameTb.Text = PartList.SelectedRows[0].Cells[1].Value.ToString();
            PartCostTb.Text = PartList.SelectedRows[0].Cells[2].Value.ToString();

            if (PartNameTb.Text == "")
            {
                key = 0;

            }
            else
            {
                key = Convert.ToInt32(PartList.SelectedRows[0].Cells[0].Value.ToString());

            }
        }


    }
}
