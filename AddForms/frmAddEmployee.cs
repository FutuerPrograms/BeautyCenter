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
    public partial class frmAddEmployee : MaterialSkin.Controls.MaterialForm
    {
        DB con = new DB();
        public frmAddEmployee()
        {
            InitializeComponent();
        }

        private void SlkItem_Properties_EditValueChanged(object sender, EventArgs e)
        {

        }


        public void RestAll()
        {
            txtName.Text = "";
            txtNationalId.Text = "";
            
           
            txtMob.Text = "";
            JopStartDate.EditValue = "";
            lblCode.Text = "";

        }



        public void FillGridView()
        {

            gridControl1.DataSource = con.GetData("select * from Employee_Inf where IsDeleted =0");
            RestAll();
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            DataTable dtcheckUserName = new DataTable();
            int UserLogCode = Convert.ToInt32(con.UserId());


            int NewUserCode = 0;
            DataTable dtGetNewCode = new DataTable();
            dtGetNewCode = con.GetData("select max(Code)+1 from Employee_Inf where IsDeleted = 0");
            if (dtGetNewCode.Rows.Count == 0)
            {

                NewUserCode = 1;


            }
            else if (string.IsNullOrEmpty(dtGetNewCode.Rows[0][0].ToString()))
            {
                NewUserCode = 1;

            }
            else
            {
                NewUserCode = Convert.ToInt32(dtGetNewCode.Rows[0][0]);

            }



            if (string.IsNullOrEmpty(txtName.Text))
            {
                MessageBox.Show("برجاء ادخال اسم الموظف ");
                return;
            }
            else if (string.IsNullOrEmpty(txtMob.Text))
            {
                MessageBox.Show("برجاء ادخال الموبيل ");
                return;
            }
            else if (string.IsNullOrEmpty(txtNationalId.Text))
            {
                MessageBox.Show("برجاء ادخال الرقم القومي ");
                return;
            }
         
            else if (string.IsNullOrEmpty(JopStartDate.Text))
            {
                MessageBox.Show("برجاء اختيار تاريخ بداية العمل ");
                return;
            }


            else
            {
                if (!string.IsNullOrEmpty(lblCode.Text))
                {

                    DataTable dt = con.GetData("select * from Employee_Inf where Code = " + lblCode.Text + " and IsDeleted = 0 ");
                    if (dt.Rows.Count > 0)
                    {
                        con.InsertData("Update  Employee_Inf set   Name ='" + txtName.Text + "' ,  NationalId ='" + txtNationalId.Text + "' , Phone ='" + txtMob.Text + "', Start_Jop_Date ='" + JopStartDate.EditValue+ "',  Last_Modified_Date ='" + DateTime.Now + "' ,  Last_Modified_By =" + UserLogCode + "  where Code = " + lblCode.Text + " ");
                        MessageBox.Show("تم التعديل");
                        RestAll();
                        gridControl1.DataSource = con.GetData("select * from Employee_Inf where IsDeleted =0");
                    }

                }
                
                
                
                else
                {
                    dtcheckUserName = con.GetData("select * from Employee_Inf where  Name Like '" + txtName.Text + "' or NationalId Like '" + txtNationalId.Text + "' and IsDeleted = 0   ");
                    if (dtcheckUserName.Rows.Count > 0)
                    {
                        MessageBox.Show("هذا الاسم مستخدم من قبل");
                        return;
                    }
                    else
                    {

                        con.InsertData("insert into Employee_Inf (Code,Name,NationalId,Phone,Start_Jop_Date,Last_Modified_By) Values(" + NewUserCode + ",'" + txtName.Text + "','" + txtNationalId.Text + "','" + txtMob.Text + "','" + JopStartDate.EditValue + "'," + UserLogCode + ")");
                        MessageBox.Show("تم الحفظ");
                        RestAll();
                        gridControl1.DataSource = con.GetData("select * from Employee_Inf where IsDeleted =0");
                    }
                }

            }
        }

        private void gridControl1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                foreach (int i in gvMain.GetSelectedRows())
                {
                    DataRow row = gvMain.GetDataRow(i);
                    lblCode.Text = row[1].ToString();
                    txtName.Text = row[2].ToString();
                    txtMob.Text = row[3].ToString();
                    txtNationalId.Text = row[4].ToString();
                    JopStartDate.EditValue = row[5].ToString();
                 
                }
            }
            catch
            {
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(lblCode.Text))
            {

                MessageBox.Show("برجاء اختيار موظف ");

            }
            else
            {
                con.InsertData("Update Employee_Inf set IsDeleted = 1 where Code = " + Convert.ToInt32(lblCode.Text) + " ");
                MessageBox.Show("تم المسح");
                FillGridView();

            }
        }

        private void frmAddEmployee_Load(object sender, EventArgs e)
        {
            FillGridView();
        }
    }
}
