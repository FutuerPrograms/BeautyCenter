using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PointOfSell.Cancel_Invoice
{
    public partial class frmCancelSalesInvoice : MaterialSkin.Controls.MaterialForm
    {
        DB con = new DB();
        public frmCancelSalesInvoice()
        {
            InitializeComponent();
            
        }

        public void FillGrid()
        {
            string ToDate = Convert.ToString(dteTo.DateTime.AddDays(1));
            DataTable dt = con.GetData("select * from Sales_View where IsDeleted = 0 and Invoice_Date between '" + dtFrom.EditValue + "' and '" + ToDate + "' ");
            gridControl1.DataSource = dt;
            
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
           
        }

        private void gridControl1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                foreach (int i in gvMain.GetSelectedRows())
                {
                    DataRow row = gvMain.GetDataRow(i);
                    lblInvoiceNumber.Text = row[5].ToString();

                }
            }
            catch
            {
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(lblInvoiceNumber.Text))
            {

                MessageBox.Show("برجاء اختيار فاتوره ليتم الحذف");
                return;
            }
            string ToDate = Convert.ToString(dteTo.DateTime.AddDays(1));
            DataTable dt = con.GetData("select Id from Sales_View where IsDeleted = 0 and Invoice_Number = "+lblInvoiceNumber.Text+" and Invoice_Date between '" + dtFrom.EditValue + "' and '" + ToDate + "' ");
            if (dt.Rows.Count > 0)
            {

                con.InsertData("Update Total_Invoice_Detail set IsDeleted = 1 where Id =" + Convert.ToInt32( dt.Rows[0][0]) + " ");
                con.InsertData("Update Transaction_Process set IsDeleted = 1 where Transaction_Code = "+lblInvoiceNumber.Text+ " and Transaction_Date between '" + dtFrom.EditValue + "' and '" + ToDate + "' ");

                MessageBox.Show("تم اللغاء الفاتورة");
                lblInvoiceNumber.Text = "";
                FillGrid();
            
            }
        }

        private void frmCancelSalesInvoice_Load(object sender, EventArgs e)
        {
            string DatatimeNow = Convert.ToString(DateTime.Now.ToString("MM/dd/yyyy"));
            dteTo.Text = DatatimeNow;
            dtFrom.Text = DatatimeNow;
            FillGrid();
        }
    }
}
