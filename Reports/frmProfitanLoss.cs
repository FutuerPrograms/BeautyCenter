using FastReport;
using System;
using System.Data;
using System.Windows.Forms;

namespace PointOfSell
{
    public partial class frmProfitanLoss : MaterialSkin.Controls.MaterialForm
    {
        DB con = new DB();
        public frmProfitanLoss()
        {
            InitializeComponent();
        }

        private void frmProfitanLoss_Load(object sender, EventArgs e)
        {
            string DatatimeNow = Convert.ToString(DateTime.Now.ToString("MM/dd/yyyy"));
            dteTo.Text = DatatimeNow;
            dtFrom.Text = DatatimeNow;


        }





        private void btnPrint_Click(object sender, EventArgs e)
        {
            
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
                string ToDate = Convert.ToString(dteTo.DateTime.AddDays(1));
                DataTable dtToDateTime = new DataTable();
                dtToDateTime.Columns.Add("FromDate", typeof(string));
                dtToDateTime.Columns.Add("ToDate", typeof(string));
                DataRow drr = dtToDateTime.NewRow();
                drr[0] = dtFrom.Text;
                drr[1] = dteTo.Text;
                dtToDateTime.Rows.Add(drr);
                #endregion
                #region Property
                decimal Sales = 0;
                decimal Purchases = 0;
                decimal Expenses = 0;
                decimal Salary = 0;
                #endregion




                DataTable dtSales = new DataTable();

                
                DataTable dtPurchases = new DataTable();


             






                #region ToGetFinlLines
                //المبيعات
                dtSales = con.GetData(" SELECT sum(Invoice_Amount) FROM Total_Invoice_Detail  where IsDeleted = 0 and   Invoice_Date between '" + dtFrom.EditValue + "' and '" + ToDate + "'");
                Sales = con.ReturnDecimal(dtSales);



                //المشتريات 
                dtPurchases = con.GetData("select (sum(Resource_Credit )) as Purchases from Transaction_Resource where IsDeleted = 0 and    Resource_Date between '" + dtFrom.EditValue + "' and '" + ToDate + "' ");
                Purchases = con.ReturnDecimal(dtPurchases);



                



                /////المصروفات
                DataTable dtExpenses = new DataTable();
                dtExpenses = con.GetData("select sum(ExpensesQT) As Expenses from  ExpensesTransaction where IsDeleted = 0  and  Date between '" + dtFrom.EditValue + "' and '" + ToDate + "'");
                Expenses = con.ReturnDecimal(dtExpenses);


                /////المرتبات
                DataTable dtSalary = new DataTable();
                dtSalary = con.GetData("select sum(Salary_Amount) from  Salary_View where IsDeleted = 0 and  Tran_Date between '" + dtFrom.EditValue + "' and '" + ToDate + "' ");
                Salary = con.ReturnDecimal(dtSalary);





                DataTable dtFinlLines = new DataTable();
                dtFinlLines.Columns.Add("Sales", typeof(decimal));
                dtFinlLines.Columns.Add("Purchases", typeof(decimal));
                dtFinlLines.Columns.Add("Expenses", typeof(decimal));
                dtFinlLines.Columns.Add("Salary", typeof(decimal));
                dtFinlLines.Columns.Add("Total", typeof(decimal));

                //  Row تجميع الكل في واحد
                DataRow drLines = dtFinlLines.NewRow();
                drLines[0] = Sales;
                drLines[1] = Purchases;
                drLines[2] = Expenses;
                drLines[3] = Salary;
                drLines[4] = Sales - (Purchases + Expenses+ Salary);

                dtFinlLines.Rows.Add(drLines);
                #endregion

                Report rpt = new Report();
                rpt.Load(@"ReportsForms\ProfitandLossReport.frx");
                rpt.RegisterData(dtFinlLines, "Lines");
                rpt.RegisterData(dtToDateTime, "HeaderDate");
                rpt.Show();
            }
            catch
            {
                MessageBox.Show("لايوجد نتائج لهذه الفترة");

            }
        }
    }
}
