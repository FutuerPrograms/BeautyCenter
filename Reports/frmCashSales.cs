using FastReport;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PointOfSell.Reports
{
    public partial class frmCashSales : MaterialSkin.Controls.MaterialForm
    {
        DB con = new DB();
        public frmCashSales()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public void FillEmployeeComp()
        {

            DataTable dtEmployee = new DataTable();
            dtEmployee = con.GetData("Select Code,Name  from UserLogin where IsDeleted = 0 ");
            slkEmployee.Properties.DataSource = dtEmployee;
            slkEmployee.Properties.ValueMember = "Code";
            slkEmployee.Properties.DisplayMember = "Name";

        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            
        }

        private void frmCashSales_Load(object sender, EventArgs e)
        {
            FillEmployeeComp();
            string DatatimeNow = Convert.ToString(DateTime.Now.ToString("MM/dd/yyyy"));
            dteTo.Text = DatatimeNow;
            dtFrom.Text = DatatimeNow;
        }

        private void btnPrint_Click_1(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(slkEmployee.Text))
            {
                MessageBox.Show("برجاء اختيار موظف ");
                return;

            }
            else if (string.IsNullOrEmpty(dtFrom.Text) || string.IsNullOrEmpty(dteTo.Text))
            {

                MessageBox.Show("برجاء اختيار تاريخ ");
                return;

            }
            string ToDate = Convert.ToString(dteTo.DateTime.AddDays(1));
            DataTable dtGetEmployeeWork = new DataTable();
            dtGetEmployeeWork = con.GetData("select * from Sales_View where IsDeleted = 0 and User_Code = " + slkEmployee.EditValue + " and  Invoice_Date between '" + dtFrom.EditValue + "' and '" + ToDate + "'");

            Report rpt = new Report();
            rpt.Load(@"ReportsForms\SalesReport.frx");
            rpt.RegisterData(dtGetEmployeeWork, "Lines");
            rpt.Show();
        }

        private void btnClose_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
