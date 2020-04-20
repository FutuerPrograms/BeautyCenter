using FastReport;
using PointOfSell.AddForms;
using PointOfSell.Cancel_Invoice;
using PointOfSell.Reports;
using PointOfSell.TransactionForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace PointOfSell
{
    public partial class frmMain : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        DB con = new DB();

        public frmMain()
        {

            InitializeComponent();

            //DataTable CheckTransRows = new DataTable();
            //CheckTransRows = con.GetData("select * from Transaction_Process");
            //if (DateTime.Now.Date >= Convert.ToDateTime("5/1/2020"))
            //{
            //    MessageBox.Show("Erorr");
            //    this.Close();

            //}



            //try
            //{

            //    frmUserLogin frm = new frmUserLogin();
            //    frm.ShowDialog();
            //    DataTable dtToGetUserName = new DataTable();
            //    int UserId = con.UserId();
            //    dtToGetUserName = con.GetData("Select Name from UserLogin where Id = " + UserId + "");
            //    string UserName = dtToGetUserName.Rows[0][0].ToString();
            //    lblUserName.Text = Convert.ToString(UserName);
            //}
            //catch
            //{
            //}



        }



        private void AccordionControlElement5_Click(object sender, EventArgs e)
        {
            //frmTransactionOut frm = new frmTransactionOut();
            //frm.Show();
        }



        private void AccordionControlElement7_Click(object sender, EventArgs e)
        {

            //DataTable dt = con.GetData("select * from UserLogin where Id = " + con.UserId() + " and IsDeleted = 0 and LoginType = 1 ");
            //if (dt.Rows.Count > 0)
            //{
            //    frmPurchasesReport frm = new frmPurchasesReport();
            //    frm.Show();
            //}
            //else
            //{

            //    con.FormId(15);
            //    frmPermationManeger frm = new frmPermationManeger();
            //    frm.Show();
            //}

        }

        private void AccordionControlElement8_Click(object sender, EventArgs e)
        {

            //DataTable dt = con.GetData("select * from UserLogin where Id = " + con.UserId() + " and IsDeleted = 0 and LoginType = 1 ");
            //if (dt.Rows.Count > 0)
            //{
            //    frmSalesReport frm = new frmSalesReport();
            //    frm.Show();
            //}
            //else
            //{

            //    con.FormId(14);
            //    frmPermationManeger frm = new frmPermationManeger();
            //    frm.Show();
            //}

        }

        private void AccordionControlElement9_Click(object sender, EventArgs e)
        {


            //DataTable dt = con.GetData("select * from UserLogin where Id = " + con.UserId() + " and IsDeleted = 0 and LoginType = 1 ");
            //if (dt.Rows.Count > 0)
            //{
            //    frmStoreBalance frm = new frmStoreBalance();
            //    frm.Show();
            //}
            //else
            //{

            //    con.FormId(16);
            //    frmPermationManeger frm = new frmPermationManeger();
            //    frm.Show();
            //}

        }
        private void AccordionControlElement2_Click(object sender, EventArgs e)
        {


            con.FormId(1);
            frmPermationManeger frm = new frmPermationManeger();
            frm.Show();
        }

        private void ا_Click(object sender, EventArgs e)
        {

            //DataTable dt = con.GetData("select * from UserLogin where Id = " + con.UserId() + " and IsDeleted = 0 and LoginType = 1 ");
            //if (dt.Rows.Count > 0)
            //{
            //    frmAddItems AddItems = new frmAddItems();
            //    AddItems.Show();
            //}
            //else
            //{

            //    con.FormId(2);
            //    frmPermationManeger frm = new frmPermationManeger();
            //    frm.Show();
            //}

        }

        private void accordionControlElement11_Click(object sender, EventArgs e)
        {
            //DataTable dt = con.GetData("select * from UserLogin where Id = " + con.UserId() + " and IsDeleted = 0 and LoginType = 1 ");
            //if (dt.Rows.Count > 0)
            //{
            //    frmAddUser AddUser = new frmAddUser();
            //    AddUser.Show();
            //}
            //else
            //{

            //    con.FormId(3);
            //    frmPermationManeger frm = new frmPermationManeger();
            //    frm.Show();
            //}
            frmAddUser frm = new frmAddUser();
            frm.ShowDialog();
        }
        private void AccordionControlElement10_Click(object sender, EventArgs e)
        {
            //DataTable dt = con.GetData("select * from UserLogin where Id = " + con.UserId() + " and IsDeleted = 0 and LoginType = 1 ");
            //if (dt.Rows.Count > 0)
            //{
            //    frmInventory Inventory = new frmInventory();
            //    Inventory.Show();
            //}
            //else
            //{

            //    con.FormId(4);
            //    frmPermationManeger frm = new frmPermationManeger();
            //    frm.Show();
            //}

        }
        private void AccordionControlElement4_Click(object sender, EventArgs e)
        {


            //DataTable dt = con.GetData("select * from UserLogin where Id = " + con.UserId() + " and IsDeleted = 0 and LoginType = 1 ");
            //if (dt.Rows.Count > 0)
            //{
            //    frmInTransaction frm = new frmInTransaction();
            //    frm.Show();
            //}
            //else
            //{

            //    con.FormId(13);
            //    frmPermationManeger frm = new frmPermationManeger();
            //    frm.Show();
            //}





        }


        private void accordionControlElement13_Click(object sender, EventArgs e)
        {
            //DataTable dt = con.GetData("select * from UserLogin where Id = "+con.UserId()+ " and IsDeleted = 0 and LoginType = 1 ");
            //if (dt.Rows.Count > 0)
            //{
            //    frmExpenses frm = new frmExpenses();
            //    frm.Show();
            //}
            //else
            //{ 

            //con.FormId(6);
            //frmPermationManeger frm = new frmPermationManeger();
            //frm.Show();
            //}


        }
        private void accordionControlElement2_Click_1(object sender, EventArgs e)
        {


            //DataTable dt = con.GetData("select * from UserLogin where Id = " + con.UserId() + " and IsDeleted = 0 and LoginType = 1 ");
            //if (dt.Rows.Count > 0)
            //{
            //    frmProfitanLoss frm = new frmProfitanLoss();
            //    frm.Show();
            //}
            //else
            //{

            //    con.FormId(7);
            //    frmPermationManeger frm = new frmPermationManeger();
            //    frm.Show();
            //}


        }


        private void accordionControlElement14_Click(object sender, EventArgs e)
        {

            //DataTable dt = con.GetData("select * from UserLogin where Id = " + con.UserId() + " and IsDeleted = 0 and LoginType = 1 ");
            //if (dt.Rows.Count > 0)
            //{
            //    frmExpensesReport frm = new frmExpensesReport();
            //    frm.Show();
            //}
            //else
            //{

            //    con.FormId(8);
            //    frmPermationManeger frm = new frmPermationManeger();
            //    frm.Show();
            //}




        }



        private void accordionControlElement15_Click(object sender, EventArgs e)
        {

            //DataTable dt = con.GetData("select * from UserLogin where Id = " + con.UserId() + " and IsDeleted = 0 and LoginType = 1 ");
            //if (dt.Rows.Count > 0)
            //{
            //    frmAdjustmentinsalestransactions frm = new frmAdjustmentinsalestransactions();
            //    frm.Show();
            //}
            //else
            //{

            //    con.FormId(9);
            //    frmPermationManeger frm = new frmPermationManeger();
            //    frm.Show();
            //}

        }

        private void accordionControlElement16_Click(object sender, EventArgs e)
        {

            //DataTable dt = con.GetData("select * from UserLogin where Id = " + con.UserId() + " and IsDeleted = 0 and LoginType = 1 ");
            //if (dt.Rows.Count > 0)
            //{
            //    frmPrizeReport frm = new frmPrizeReport();
            //    frm.Show();
            //}
            //else
            //{

            //    con.FormId(10);
            //    frmPermationManeger frm = new frmPermationManeger();
            //    frm.Show();
            //}

        }

        private void accordionControlElement17_Click(object sender, EventArgs e)
        {
            //DataTable dt = con.GetData("select * from UserLogin where Id = " + con.UserId() + " and IsDeleted = 0 and LoginType = 1 ");
            //if (dt.Rows.Count > 0)
            //{
            //    frmAddLosses frm = new frmAddLosses();
            //    frm.Show();
            //}
            //else
            //{

            //    con.FormId(11);
            //    frmPermationManeger frm = new frmPermationManeger();
            //    frm.Show();
            //}

        }

        private void accordionControlElement18_Click(object sender, EventArgs e)
        {

            //DataTable dt = con.GetData("select * from UserLogin where Id = " + con.UserId() + " and IsDeleted = 0 and LoginType = 1 ");
            //if (dt.Rows.Count > 0)
            //{
            //    frmLossesReport frm = new frmLossesReport();
            //    frm.Show();
            //}
            //else
            //{

            //    con.FormId(12);
            //    frmPermationManeger frm = new frmPermationManeger();
            //    frm.Show();
            //}

        }

        private void accordionControlElement20_Click(object sender, EventArgs e)
        {
            //    DataTable dt = con.GetData("select * from UserLogin where Id = " + con.UserId() + " and IsDeleted = 0 and LoginType = 1 ");
            //    if (dt.Rows.Count > 0)
            //    {
            //        frmProfitsandexpensesReport frm = new frmProfitsandexpensesReport();
            //        frm.Show();
            //    }
            //    else
            //    {

            //        con.FormId(17);
            //        frmPermationManeger frm = new frmPermationManeger();
            //        frm.Show();
            //    }
        }

        private void accordionControlElement21_Click(object sender, EventArgs e)
        {

            //DataTable dt = con.GetData("select * from UserLogin where Id = " + con.UserId() + " and IsDeleted = 0 and LoginType = 1 ");
            //if (dt.Rows.Count > 0)
            //{
            //   frmPurchaseReturns frm = new frmPurchaseReturns();
            //    frm.Show();
            //}
            //else
            //{

            //    con.FormId(18);
            //    frmPermationManeger frm = new frmPermationManeger();
            //    frm.Show();
            //}
        }

        private void accordionControlElement2_Click_2(object sender, EventArgs e)
        {
            frmAddEmployee frm = new frmAddEmployee();
            frm.ShowDialog();
        }

        private void accordionControlElement4_Click_1(object sender, EventArgs e)
        {
            frmAddJop frm = new frmAddJop();
            frm.ShowDialog();
        }

        private void accordionControlElement5_Click_1(object sender, EventArgs e)
        {
            frmSales frm = new frmSales();
            frm.ShowDialog();
        }

        private void accordionControlElement7_Click_1(object sender, EventArgs e)
        {
            frmEmployeeWorksReport frm = new frmEmployeeWorksReport();
            frm.ShowDialog();
        }

        private void accordionControlElement8_Click_1(object sender, EventArgs e)
        {
            frmCashSales frm = new frmCashSales();
            frm.ShowDialog();
        }

        private void ribbonControl1_Click(object sender, EventArgs e)
        {

        }

        private void accordionControlElement10_Click_1(object sender, EventArgs e)
        {
            frmCancelSalesInvoice frm = new frmCancelSalesInvoice();
            frm.ShowDialog();
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Application.Exit();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            DataTable dt = con.GetData("select * from UserLogin where Id = " + con.UserId() + " and IsDeleted = 0 and LoginType = 1 ");
            if (dt.Rows.Count > 0)
            {

                accordionControlElement1.Visible = true;
                accordionControlElement6.Visible = true;
                accordionControlElement9.Visible = true;
                accordionControlElement16.Visible = true;
                accordionControlElement21.Visible = true;
                accordionControlElement24.Visible = true;


            }
            int UserId = con.UserId();
            DataTable dtToGetUserName = new DataTable();
            dtToGetUserName = con.GetData("Select Name from UserLogin where Code = " + UserId + "");
            string UserName = dtToGetUserName.Rows[0][0].ToString();
            lblUserName.Text = Convert.ToString(UserName);
            lblUserName.Text = Convert.ToString(UserName);

        }

        private void accordionControlElement13_Click_1(object sender, EventArgs e)
        {
            frmResource frm = new frmResource();
            frm.ShowDialog();



        }

        private void accordionControlElement14_Click_1(object sender, EventArgs e)
        {
            frmResourceTransaction frm = new frmResourceTransaction();
            frm.ShowDialog();
        }

        private void accordionControlElement9_Click_1(object sender, EventArgs e)
        {

        }

        private void accordionControlElement16_Click_1(object sender, EventArgs e)
        {
           

        }

        private void accordionControlElement16_Click_2(object sender, EventArgs e)
        {
            frmResourceTransaction frm = new frmResourceTransaction();
            frm.ShowDialog();
        }

        private void accordionControlElement18_Click_1(object sender, EventArgs e)
        {

            string ToDate = Convert.ToString(DateTime.Today.AddDays(1));

            DataTable dt = con.GetData("select * from Employee_Inf where IsDeleted = 0 ");
            dt.Columns.Add("Works", typeof(decimal));
            for (int i = 0; dt.Rows.Count > i; i++)
            {
                decimal EmployeeWork = con.ReturnDecimal(con.GetData("select count (*) from Transaction_Process where Employee_Code = "+dt.Rows[i][1]+ " and Operation_Code = 2 and Transaction_Date between '" + DateTime.Today + "' and '"+ ToDate + "' and IsDeleted = 0"));

                dt.Rows[i][9] = EmployeeWork;


            }

            Report rpt = new Report();
            rpt.Load(@"ReportsForms\EmployeeWorksNumberReport.frx");
            rpt.RegisterData(dt, "Lines");
            rpt.Show();


        }

        private void accordionControlElement20_Click_1(object sender, EventArgs e)
        {
            frmProfitanLoss frm = new frmProfitanLoss();
            frm.ShowDialog();
        }

        private void accordionControlElement21_Click_1(object sender, EventArgs e)
        {
            frmExpenses frm = new frmExpenses();
            frm.ShowDialog();
        }

        private void accordionControlElement22_Click(object sender, EventArgs e)
        {
            frmAddExpenses frm = new frmAddExpenses();
            frm.ShowDialog();
        }

        private void accordionControlElement23_Click(object sender, EventArgs e)
        {
            frmExpensesReport frm = new frmExpensesReport();
            frm.Show();
        }

        private void accordionControlElement24_Click(object sender, EventArgs e)
        {
            frmEmployeeSalary frm = new frmEmployeeSalary();
            frm.ShowDialog();
        }

        private void accordionControlElement25_Click(object sender, EventArgs e)
        {
            frmSalaryReport frm = new frmSalaryReport();
            frm.ShowDialog();
        }
    }
}
