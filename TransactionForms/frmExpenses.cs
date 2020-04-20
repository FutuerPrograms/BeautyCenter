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
    public partial class frmExpenses : MaterialSkin.Controls.MaterialForm
    {
        DB con = new DB();
        public frmExpenses()
        {
            InitializeComponent();
        }

        private void slkItem_Properties_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void frmExpenses_Load(object sender, EventArgs e)
        {
            FillSlkItem();
            string DatatimeNow = Convert.ToString(DateTime.Now.ToString("hh:mm:ss MM/dd/yyyy "));
            dtFrom.Text = DatatimeNow;
        }
        public void FillSlkItem()
        {
            DataTable dt = new DataTable();
            dt = con.GetData("Select Id,ExpensesName From Expenses where IsDeleted = 0");
            slkExpensesType.Properties.DataSource = dt;
            slkExpensesType.Properties.ValueMember = "Id";
            slkExpensesType.Properties.DisplayMember = "ExpensesName";
           
        }

       
        

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            decimal UserId = con.UserId();
            if (string.IsNullOrEmpty(slkExpensesType.Text))
            {
                MessageBox.Show("برجاء اختيار مصروف");
                return;
            }
            else if (string.IsNullOrEmpty(slkExpensesType.Text) || slkExpensesType.Text == "0")
            {
                MessageBox.Show("برجاء ادخال قيمة المصروف");
                return;
            }
            else
            {

                con.InsertData("Insert Into ExpensesTransaction (ExpensesCode,ExpensesNeme,ExpensesQT,ExpensesNotes,Date,Last_Modified_By,Last_Modified_Date,Operation_Type_Id) values (" + slkExpensesType.EditValue + ",'" + slkExpensesType.Text + "'," + txtQuntaty.Text + ",'" + txtNote.Text + "','" + dtFrom.EditValue + "'," + con.UserId() + ",'" + DateTime.Now + "',3 ) ");
                txtNote.Text = "";
                txtQuntaty.Text = "";
                slkExpensesType.Text = "";
                MessageBox.Show("تم الحفظ");

            }
        }
    }
}
