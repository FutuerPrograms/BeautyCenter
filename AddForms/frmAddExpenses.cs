using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PointOfSell.AddForms
{
    public partial class frmAddExpenses : MaterialSkin.Controls.MaterialForm
    {
        DB con = new DB();
        public frmAddExpenses()
        {
            InitializeComponent();
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public void FillGrid()
        {

            DataTable dt = con.GetData("select * from Expenses where IsDeleted = 0");
            gridControl1.DataSource = dt;



        }
        private void frmAddExpenses_Load(object sender, EventArgs e)
        {
            FillGrid();
        }

        private void gridControl1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                foreach (int i in gvMain.GetSelectedRows())
                {
                    DataRow row = gvMain.GetDataRow(i);
                    lblCode.Text = row[0].ToString();
                    txtName.Text = row[1].ToString();
                 



                }
            }
            catch
            {
            }
        }
        public void RestAll()
        {
            txtName.Text = "";
            lblCode.Text = "";
            FillGrid();
        
        
        }
        private void simpleButton4_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(lblCode.Text))
            {

                DataTable dt = con.GetData("select * from Expenses where ExpensesName like '" + txtName.Text + "' and IsDeleted = 0 ");
                if (dt.Rows.Count > 0)
                {
                    MessageBox.Show("هذا المصروف مسجل من قبل");
                    return;

                }
                con.InsertData("insert into Expenses (ExpensesName)Values('" + txtName.Text + "')");
                MessageBox.Show("تم الحفظ");
                RestAll();
            }
            else
            {

                con.InsertData("Update  Expenses set   ExpensesName ='" + txtName.Text + "'   where Id = " + lblCode.Text + " ");
                MessageBox.Show("تم التعديل");
                RestAll();

            }
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(lblCode.Text))
            {
                MessageBox.Show("برجاء اختيار مصروف ليتم تعديله");
                return;

            }
            else
            {

                con.InsertData("Update  Expenses set   IsDeleted = 1   where Id = " + lblCode.Text + " ");
                MessageBox.Show("تم المسح");
                RestAll();

            }
        }
    }
}
