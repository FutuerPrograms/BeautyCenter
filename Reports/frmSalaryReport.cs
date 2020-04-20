using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FastReport;

namespace PointOfSell
{
    public partial class frmSalaryReport : MaterialSkin.Controls.MaterialForm
    {
        DB con = new DB();
        public frmSalaryReport()
        {
            InitializeComponent();
        }

        

        private void frmExpensesReport_Load(object sender, EventArgs e)
        {
            string DatatimeNow = Convert.ToString(DateTime.Now.ToString("MM/dd/yyyy"));
            dteTo.Text = DatatimeNow;
            dtFrom.Text = DatatimeNow;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnPrint_Click_1(object sender, EventArgs e)
        {
            try
            {

                #region ToGetDateAndTime
                DataTable dtToDateTime = new DataTable();
                dtToDateTime.Columns.Add("FromDate", typeof(string));
                dtToDateTime.Columns.Add("ToDate", typeof(string));
                DataRow drr = dtToDateTime.NewRow();
                drr[0] = dtFrom.Text;
                drr[1] = dteTo.Text;
                dtToDateTime.Rows.Add(drr);
                #endregion
                DataTable dtLines = new DataTable();
                string ToDate = Convert.ToString(dteTo.DateTime.AddDays(1));
                dtLines = con.GetData("select * from  Salary_View where IsDeleted = 0 and  Tran_Date between '" + dtFrom.EditValue + "' and '" + ToDate + "' ");


                Report rpt = new Report();
                rpt.Load(@"ReportsForms\SalaryReport.frx");
                rpt.RegisterData(dtLines, "Lines");
                rpt.RegisterData(dtToDateTime, "HeaderDate");
                rpt.Show();
            }
            catch
            {
            
            }
          
        }
    }
}
