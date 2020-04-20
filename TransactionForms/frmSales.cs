using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using PointOfSell.AddForms;
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
    public partial class frmSales : MaterialSkin.Controls.MaterialForm
    {
        DB con = new DB();
        public frmSales()
        {
            InitializeComponent();
            
        }

        private void materialLabel6_Click(object sender, EventArgs e)
        {

        }

        public void FillEmployee()
        {

            DataTable dtEmployee = new DataTable();
            dtEmployee = con.GetData("Select Code,Name  from Employee_Inf where IsDeleted = 0 ");
            slkEmployee.Properties.DataSource = dtEmployee;
            slkEmployee.Properties.ValueMember = "Code";
            slkEmployee.Properties.DisplayMember = "Name";



            DataTable dtJopCode = new DataTable();
            dtJopCode = con.GetData("Select JopCode,JopName  from Jop_Info where IsDeleted = 0 ");
            slkJops.Properties.DataSource = dtJopCode;
            slkJops.Properties.ValueMember = "JopCode";
            slkJops.Properties.DisplayMember = "JopName";



            DataTable dtPaymentType = new DataTable();
            dtPaymentType = con.GetData("Select Code,PaymentType  from Payment_Type where IsDeleted = 0 ");
            slkPaymentType.Properties.DataSource = dtPaymentType;
            slkPaymentType.Properties.ValueMember = "Code";
            slkPaymentType.Properties.DisplayMember = "PaymentType";
        }
     
        private void frmSales_Load(object sender, EventArgs e)
        {

            Rest();
            string DatatimeNow = Convert.ToString(DateTime.Now.ToString("MM/dd/yyyy"));
            slkCustomerBirthDay.Text = DatatimeNow;
        }


        public void Rest()

        {
            try
            {
                txtAmount.Text = "";
                txtMob.Text = "";
                txtName.Text = "";
                txtName.BackColor = Color.White;
                slkCustomerBirthDay.BackColor = Color.White;
                txtPrice.BackColor = Color.White;
                txtPrice.Text = "0";
                slkEmployee.Text = "";
                slkJops.Text = "";
                slkPaymentType.Text = "";
                lblAmount.Text = "0";
                lblCustomerCode.Text = "";
                slkPaymentType.BackColor = Color.White;
                string DatatimeNow = Convert.ToString(DateTime.Now.ToString("MM/dd/yyyy"));
                dtFrom.Text = DatatimeNow;
                string ToDate = Convert.ToString(dtFrom.DateTime.AddDays(1));
                decimal Not_Code = con.ReturnDecimal(con.GetData("select max(Notebook_Code) from Notebook_Info where Notebook_State = 0 and IsDeleted = 0"));
                decimal Check_Invoice_by_Not_Code = con.ReturnDecimal(con.GetData("select count(Invoice_Number)+1 from Total_Invoice_Detail where Notebook_Code = " + Not_Code + ""));
                if (Not_Code == 0 || Check_Invoice_by_Not_Code > 100)
                {

                    frmAddNotebook frm = new frmAddNotebook();
                    frm.ShowDialog();
                    DataTable GetlastNoteInfo = con.GetData("select   max(Notebook_Code) as  Notebook_Code , max(Notebook_Number) as Notebook_Number  from Notebook_Info  where Notebook_State = 0 and IsDeleted = 0");
                    Not_Code = Convert.ToDecimal(GetlastNoteInfo.Rows[0][0]);
                    lblNote_Sequence.Text = GetlastNoteInfo.Rows[0][1].ToString();

                    lblNotebook.Text = Not_Code.ToString();
                    Check_Invoice_by_Not_Code = con.ReturnDecimal(con.GetData("select count(Invoice_Number)+1 from Total_Invoice_Detail where Notebook_Code = " + Not_Code + " "));
                    lblInvoicceNumber.Text = Check_Invoice_by_Not_Code.ToString();
                }
                else
                {

                    Check_Invoice_by_Not_Code = con.ReturnDecimal(con.GetData("select count(Invoice_Number)+1 from Total_Invoice_Detail where Notebook_Code = " + Not_Code + ""));
                    lblInvoicceNumber.Text = Check_Invoice_by_Not_Code.ToString();
                    lblNotebook.Text = Not_Code.ToString();
                    DataTable getNotebook_Number = con.GetData("select Notebook_Number from  Notebook_Info where Notebook_State = 0");
                    lblNote_Sequence.Text = getNotebook_Number.Rows[0][0].ToString();
                }
                FillEmployee();
            }
            catch
            { 
            }
            
            
        }
        DataTable GetDataTable(GridView view)
        {
            DataTable dt = new DataTable();
            foreach (GridColumn c in view.Columns)
                dt.Columns.Add(c.FieldName, c.ColumnType);
            for (int r = 0; r < view.RowCount; r++)
            {
                object[] rowValues = new object[dt.Columns.Count];
                for (int c = 0; c < dt.Columns.Count; c++)
                    rowValues[c] = view.GetRowCellValue(r, dt.Columns[c].ColumnName);
                dt.Rows.Add(rowValues);
            }
            return dt;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            #region To Get User ID Info
            ////////////////// To Get User ID Info///////////////////
            int UserCashCode = con.UserId();
            #endregion

            #region   to Get Transaction Id
            ////////////////// to Get Transaction Id ////////////////
              decimal  TransactionCode = Convert.ToDecimal(lblInvoicceNumber.Text);
            
            #endregion
            DataTable dtCheckGvMain = new DataTable();
            dtCheckGvMain = GetDataTable(gvMain);
            if (dtCheckGvMain.Rows.Count == 0)
            {
                MessageBox.Show("برجاء اضافة عملية");
                return;

            }
            else if (string.IsNullOrEmpty( slkPaymentType.Text))
            {
                slkPaymentType.BackColor = Color.Red;
                MessageBox.Show("برجاء اختيار طريقة الدفع");
                return;
            }
            #region  Save Or Update  CustomerDate
           
            
            DataTable dtGetCustomerDataByMob = con.GetData("select * from Customer_Info where IsDeleted = 0 and CustomerMop = '"+txtMob.Text+"' ");
            if (dtGetCustomerDataByMob.Rows.Count > 0)
            {
                con.GetData("update  Customer_Info set CustomerName = '" + txtName.Text + "', CustomerMop = '" + txtMob.Text + "', Customer_Birthday = '" + slkCustomerBirthDay.Text + "', Last_Modified_Date = '" + DateTime.Now + "', Last_Modified_By = " + UserCashCode + " where CustomerMop = '" + txtMob.Text + "' ");
            }
            else
            {
                // Get New EmployeeCode
                DataTable dtMaxCode = new DataTable();
                int MaxCode;
                dtMaxCode = con.GetData("select max(Code) from Customer_Info where IsDeleted = 0  ");
                if (string.IsNullOrEmpty(dtMaxCode.Rows[0][0].ToString()))
                {
                    MaxCode = 1;

                }

                else if (dtMaxCode.Rows.Count > 0)
                {
                    MaxCode = Convert.ToInt32(dtMaxCode.Rows[0][0]);
                }
                else
                {
                    MaxCode = 1;
                }
                    con.GetData("insert  into Customer_Info (Code,CustomerName,CustomerMop,Customer_Birthday,Last_Modified_Date,Last_Modified_By) values ("+MaxCode+",'" + txtName.Text + "','" + txtMob.Text + "', '" + slkCustomerBirthDay.Text + "','" + DateTime.Now + "'," + UserCashCode + " )");
            }
            #endregion

            #region Save Invoice
            DataTable GridViewData = new DataTable();
            GridViewData = GetDataTable(gvMain);
            for (int i = 0; i < GridViewData.Rows.Count; i++)
            {
                decimal Employee_Code = Convert.ToDecimal(GridViewData.Rows[i][0]);
                decimal  Jop_Code  = Convert.ToDecimal(GridViewData.Rows[i][2]);
                decimal Transaction_Amount = Convert.ToDecimal(GridViewData.Rows[i][5]);
                decimal Payment_Type = Convert.ToDecimal( slkPaymentType.EditValue);
                decimal Customer_Code = Convert.ToDecimal( lblCustomerCode.Text);
                con.InsertData("insert into  Transaction_Process (Transaction_Code,Employee_Code,Customer_Code,Jop_Code,Operation_Code,Transaction_Date,Transaction_Amount,Payment_Type,Last_Modified_Date,Last_Modified_By,Notebook_Code)values(" + TransactionCode + ","+Employee_Code+"," + Customer_Code + "," + Jop_Code + ",2,'" + DateTime.Now + "',"+Transaction_Amount+" ,"+Payment_Type+",'" + DateTime.Now + "'," + UserCashCode + ","+lblNotebook.Text+")");
            }

            con.InsertData("insert into  Total_Invoice_Detail (Payment_Type,User_Code,Invoice_Number,Invoice_Date,Customer_Code,Invoice_Amount,Operation_Code,Last_Modified_By,Last_Modified_Date,Notebook_Code)values(" + slkPaymentType.EditValue+"," + UserCashCode+"," + TransactionCode + ",'" + DateTime.Now + "',"+Convert.ToDecimal( lblCustomerCode.Text)+","+Convert.ToDecimal(lblAmount.Text)+",2," + UserCashCode + ",'" + DateTime.Now + "',"+lblNotebook.Text+")");

            decimal Not_Code = con.ReturnDecimal(con.GetData("select max(Notebook_Code) from Notebook_Info where Notebook_State = 0 and IsDeleted = 0"));
            decimal Check_Invoice_by_Not_Code = con.ReturnDecimal(con.GetData("select count(Invoice_Number)+1 from Total_Invoice_Detail where Notebook_Code = " + Not_Code + " and IsDeleted = 0"));
            if (Check_Invoice_by_Not_Code > 100)
            {

                con.InsertData("update  Notebook_Info set Notebook_State = 1 where Notebook_Code = "+Not_Code+" ");

            }

            MessageBox.Show("تم الحفظ");
            Rest();
                #endregion

        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt = con.GetData("select * from Customer_Info where IsDeleted = 0 and CustomerMop  =  " + txtMob.EditValue + "");
            if (dt.Rows.Count > 0)
            {
                txtName.Text = dt.Rows[0][2].ToString();
                string DatatimeNow = Convert.ToString(DateTime.Now.ToString("MM/dd/yyyy"));
                slkCustomerBirthDay.Text = dt.Rows[0][4].ToString(); ;
            }
            else
            {
                txtName.Text = "";
                slkCustomerBirthDay.Text = "";
            }
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMob.Text) )
            {
                MessageBox.Show("برجاء ادخال رقم الموبيل");
                return;
            
            }

            if (string.IsNullOrEmpty(txtName.Text))
            {
                MessageBox.Show("برجاء ادخال اسم العميل");
                return;

            }

         
            #region  Save Or Update  CustomerDate

            int UserCashCode = con.UserId();
            DataTable dtGetCustomerDataByMob = con.GetData("select * from Customer_Info where IsDeleted = 0 and CustomerMop = '" + txtMob.Text + "' ");
            if (dtGetCustomerDataByMob.Rows.Count > 0)
            {
                con.GetData("update  Customer_Info set CustomerName = '" + txtName.Text + "', CustomerMop = '" + txtMob.Text + "', Customer_Birthday = '" + slkCustomerBirthDay.Text + "', Last_Modified_Date = '" + DateTime.Now + "', Last_Modified_By = " + UserCashCode + " where CustomerMop = '" + txtMob.Text + "' ");
            }
            else
            {
                // Get New EmployeeCode
                DataTable dtMaxCode = new DataTable();
                int MaxCode;
                dtMaxCode = con.GetData("select max(Code)+1 from Customer_Info where IsDeleted = 0  ");
                if (string.IsNullOrEmpty(dtMaxCode.Rows[0][0].ToString()))
                {
                    MaxCode = 1;

                }

                else if (dtMaxCode.Rows.Count > 0)
                {
                    MaxCode = Convert.ToInt32(dtMaxCode.Rows[0][0]);
                }
                else
                {
                    MaxCode = 1;
                }
                con.GetData("insert  into Customer_Info (Code,CustomerName,CustomerMop,Customer_Birthday,Last_Modified_Date,Last_Modified_By) values (" + MaxCode + ",'" + txtName.Text + "','" + txtMob.Text + "', '" + slkCustomerBirthDay.Text + "','" + DateTime.Now + "'," + UserCashCode + " )");
                DataTable dtGetCustomerDataToLblId = con.GetData("select Code from Customer_Info where IsDeleted = 0 and CustomerMop = '" + txtMob.Text + "' ");
                lblCustomerCode.Text = dtGetCustomerDataToLblId.Rows[0][0].ToString();
            }
            #endregion
            try
            {
                DataTable dt = new DataTable();
                DataTable dtt = new DataTable();
                dtt = GetDataTable(gvMain);
                if (dtt.Rows.Count == 0)
                {
                    dt.Columns.Add("كود الموظف", typeof(int));
                    dt.Columns.Add("اسم الموظف", typeof(string));
                    dt.Columns.Add("كود الوظيفة", typeof(int));
                    dt.Columns.Add("اسم الوظيفة", typeof(string));
                    dt.Columns.Add("كود العميل", typeof(int));
                    dt.Columns.Add(" المبلغ", typeof(float));
                    object GetJopsId = slkJops.EditValue;
                    object GetEmployeeID = slkEmployee.EditValue;
                    DataRow drr = dt.NewRow();
                    drr[0] = GetEmployeeID;
                    drr[1] = slkEmployee.Text.ToString();
                    drr[2] = GetJopsId;
                    drr[3] = slkJops.Text.ToString();
                    drr[4] = Convert.ToInt32(lblCustomerCode.Text) ;
                    drr[5] = Convert.ToDecimal(txtAmount.Text);
                    lblAmount.Text = con.ReternFromString (txtAmount.Text);

                    dt.Rows.Add(drr);
                    gridControl1.DataSource = dt;
                    foreach (GridColumn Column in gvMain.Columns)
                    {
                        Column.OptionsColumn.AllowEdit = false;
                    }
                    gvMain.Columns["كود الموظف"].Visible = false;
                    gvMain.Columns["كود الوظيفة"].Visible = false;
                    gvMain.Columns["كود العميل"].Visible = false;
                    gvMain.RefreshData();
                    txtAmount.Text = "";
                }
                else if (dtt.Rows.Count > 0)
                {
                    object GetJopsId = slkJops.EditValue;
                    object GetEmployeeID = slkEmployee.EditValue;
                    DataRow drr = dtt.NewRow();
                    drr[0] = GetEmployeeID;
                    drr[1] = slkEmployee.Text.ToString();
                    drr[2] = GetJopsId;
                    drr[3] = slkJops.Text.ToString();
                    drr[4] = Convert.ToInt32(lblCustomerCode.Text);
                    drr[5] = Convert.ToDecimal(txtAmount.Text);
                    lblAmount.Text = Convert.ToString(Convert.ToDecimal(con.ReternFromString(lblAmount.Text)) + Convert.ToDecimal(con.ReternFromString(txtAmount.Text)));
                    dtt.Rows.Add(drr);
                    gridControl1.DataSource = dtt;
                    foreach (GridColumn Column in gvMain.Columns)
                    {
                        Column.OptionsColumn.AllowEdit = false;
                    }
                    gvMain.Columns["كود الموظف"].Visible = false;
                    gvMain.Columns["كود الوظيفة"].Visible = false;
                    gvMain.Columns["كود العميل"].Visible = false;
                    gvMain.RefreshData();
                    txtAmount.Text = "";
                }
            }
            catch
            {
                MessageBox.Show("عملية اضافة خاطئة");
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void مسحToolStripMenuItem_Click(object sender, EventArgs e)
        {
            gvMain.DeleteSelectedRows();
            var c = GetDataTable(gvMain);
            decimal x = 0;
            foreach (DataRow row in c.Rows)
            {
                    x += Convert.ToDecimal(row[5]);
            }
            gridControl1.RefreshDataSource();
            lblAmount.Text = x.ToString();
        }

        private void txtMob_EditValueChanged(object sender, EventArgs e)
        {
          DataTable  dtt = GetDataTable(gvMain);
            if (dtt.Rows.Count > 0)
            {
                gridControl1.DataSource = "";
                gridControl1.RefreshDataSource();

            }
            DataTable dt = new DataTable();
            dt = con.GetData("select * from Customer_Info where IsDeleted = 0 and CustomerMop  like  '" + txtMob.EditValue + "'");
            if (dt.Rows.Count > 0)
            {
                lblCustomerCode.Text = dt.Rows[0][1].ToString();
                txtName.Text = dt.Rows[0][2].ToString();
                string DatatimeNow = Convert.ToString(DateTime.Now.ToString("MM/dd/yyyy"));
                slkCustomerBirthDay.Text = dt.Rows[0][4].ToString();
                DataTable dtgettotalinvoce  = con.GetData("select sum(Invoice_Amount) from Total_Invoice_Detail where Customer_Code = " + lblCustomerCode.Text+ " and IsDeleted = 0 ");
                txtPrice.Text = dtgettotalinvoce.Rows[0][0].ToString();
                
                txtName.BackColor = Color.Gainsboro;
                slkCustomerBirthDay.BackColor = Color.Gainsboro;
                txtPrice.BackColor = Color.Gainsboro;
            }
            else
            {
                txtName.Text = "";
                lblCustomerCode.Text = "";
                txtPrice.Text = "0";
                slkCustomerBirthDay.Text = "";
                txtName.BackColor = Color.White;
                slkCustomerBirthDay.BackColor = Color.White;
                txtPrice.BackColor = Color.White;

            }
        }

        private void slkJops_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = con.GetData("select JopPrice from Jop_Info where IsDeleted = 0 and JopCode = " + slkJops.EditValue + " ");
                if (dt.Rows.Count > 0 && !string.IsNullOrEmpty(dt.Rows[0][0].ToString()))
                {
                    txtAmount.Text = dt.Rows[0][0].ToString();
                }
                else
                {
                    txtAmount.Text = "";
                }
            }
            catch
            {
                txtAmount.Text = "";
            }
           
        }
    }
}
