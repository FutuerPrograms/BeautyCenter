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
    public partial class frmEmployeeSalary : MaterialSkin.Controls.MaterialForm
    {
        DB con = new DB();
        public frmEmployeeSalary()
        {
            InitializeComponent();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmEmployeeSalary_Load(object sender, EventArgs e)
        {
            FillSlkItem();
            string DatatimeNow = Convert.ToString(DateTime.Now.ToString("MM/dd/yyyy"));
            dtFrom.Text = DatatimeNow;
        }

        public void FillSlkItem()
        {
            DataTable dt = new DataTable();
            DataTable dtEmployee = new DataTable();
            dtEmployee = con.GetData("Select Code,Name  from Employee_Inf where IsDeleted = 0 ");
            slkEmployee.Properties.DataSource = dtEmployee;
            slkEmployee.Properties.ValueMember = "Code";
            slkEmployee.Properties.DisplayMember = "Name";

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            decimal UserCode = con.UserId();
            if (string.IsNullOrEmpty(slkEmployee.Text))
            {
                MessageBox.Show("برجاء اختيار موظف");
                return;
            }
            else if (string.IsNullOrEmpty(txtQuntaty.Text))
            {
                MessageBox.Show("برجاء ادخال قيمة الراتب");
                return;
            }
            else
            {

                con.InsertData("Insert Into Salary (Employee_Code,Salary_Amount,Salary_Note,Tran_Date,Last_Modified_Date,Last_Modified_By) values (" + slkEmployee.EditValue + ",'" + txtQuntaty.Text + "','" + txtNote.Text + "','" + dtFrom.EditValue + "','" + DateTime.Now + "'," + con.UserId() + ") ");
                txtNote.Text = "";
                txtQuntaty.Text = "";
                slkEmployee.Text = "";
                MessageBox.Show("تم الحفظ");

            }
        }
    }
}
