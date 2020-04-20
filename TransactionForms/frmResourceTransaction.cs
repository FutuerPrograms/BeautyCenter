using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PointOfSell.TransactionForms
{
    public partial class frmResourceTransaction : MaterialSkin.Controls.MaterialForm
    {
        DB con = new DB();
        public frmResourceTransaction()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void FillRec()
        {

            DataTable dtEmployee = new DataTable();
            dtEmployee = con.GetData("Select Id,Resource_Name,Resource_Mobile  from Resource_Info where IsDeleted = 0 ");
            slkResourceName.Properties.DataSource = dtEmployee;
            slkResourceName.Properties.ValueMember = "Id";
            slkResourceName.Properties.DisplayMember = "Resource_Name";

        }

        private void frmResourceTransaction_Load(object sender, EventArgs e)
        {
            FillRec();
            string DatatimeNow = Convert.ToString(DateTime.Now.ToString("MM/dd/yyyy"));
            dtFrom.Text = DatatimeNow;

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(slkResourceName.Text))
            {
                MessageBox.Show("برجاء اختيار مورد");
                return;
            }
            else if (string.IsNullOrEmpty(dtFrom.Text))
            {
                MessageBox.Show("برجاء اختيار التاريخ");
                return;
            }
            else
            {
                con.InsertData("insert into Transaction_Resource (Resource_Person_Id,Resource_Credit,Resource_Debit,Resource_Date,Last_Modified_By,Last_Modified_Date)values(" + slkResourceName.EditValue + "," + txtCredit.Text + "," + txtDebit.Text + ",'" + DateTime.Now + "'," + con.UserId() + ",'" + DateTime.Now + "')");
                MessageBox.Show("تم الحفظ");
                Rest();
            }
        }
        public void Rest()
        {

            txtCredit.Text = "0";
            txtDebit.Text = "0";
            lblCredit.Text = "0";
            lblRequired.Text = "0";
            lblResidual.Text = "0";
            slkResourceName.Text ="";
        
        }
        private void slkResourceName_EditValueChanged(object sender, EventArgs e)
        {
            decimal Credit = con.ReturnDecimal(con.GetData("select sum(Resource_Credit) from Transaction_Resource where IsDeleted = 0 and Resource_Person_Id = " + slkResourceName.EditValue + " "));
            
            decimal Debit = con.ReturnDecimal(con.GetData("select sum(Resource_Debit) from Transaction_Resource where IsDeleted = 0 and Resource_Person_Id = "+slkResourceName.EditValue+" "));
            decimal Residual = Debit - Credit;
            lblCredit.Text = Credit.ToString();
            lblRequired.Text = Debit.ToString();
            lblResidual.Text = Residual.ToString();
        }

        private void جديدToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Rest();
        }
    }
}
