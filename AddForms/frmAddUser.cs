using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraGrid.Columns;

namespace PointOfSell
{
    public partial class frmAddUser : MaterialSkin.Controls.MaterialForm
    {
        DB con = new DB();
        public frmAddUser()
        {
            InitializeComponent();
        }

        private void ButCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       
        public void RestAll()
        {
            txtName.Text = "";
            txtuserName.Text = "";
            txtPassword.Text = "";
            slkLoginType.Text = "";
            txtMob.Text = "";
            JopStartDate.EditValue = "";
            lblCode.Text = "";
            gridControl1.DataSource = con.GetData("select * from Users_View where IsDeleted =0");

        }
       




        public void FillCombo()
        {

            DataTable dt = new DataTable();
            dt = con.GetData("Select Code,Type_Name  from LoginType");
            slkLoginType.Properties.DataSource = dt;
            slkLoginType.Properties.ValueMember = "Code";
            slkLoginType.Properties.DisplayMember = "Type_Name";
        }

        private void frmAddUser_Load(object sender, EventArgs e)
        {
            FillCombo();
            RestAll();
           

        }

        private void SlkItem_Properties_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void materialLabel3_Click(object sender, EventArgs e)
        {

        }
       
        private void btnSave_Click(object sender, EventArgs e)
        {
            DataTable dtcheckUserName = new DataTable();
            int UserLogCode = Convert.ToInt32(con.UserId());


            int NewUserCode = 0; 
            DataTable dtGetNewCode = new DataTable();
            dtGetNewCode = con.GetData("select max(Code)+1 from UserLogin");
            if (dtGetNewCode.Rows.Count == 0)
            {

                NewUserCode = 1;


            }
            else
            {
                NewUserCode =  Convert.ToInt32(dtGetNewCode.Rows[0][0]);

            }

          

             if (string.IsNullOrEmpty(txtName.Text))
            {
                MessageBox.Show("برجاء ادخال اسم الدخول ");
                return;
            }
            else if (string.IsNullOrEmpty(txtMob.Text))
            {
                MessageBox.Show("برجاء ادخال الموبيل ");
                return;
            }
            else if (string.IsNullOrEmpty(txtuserName.Text))
            {
                MessageBox.Show("برجاء ادخال كلمة المرور ");
                return;
            }
            else if (string.IsNullOrEmpty(txtPassword.Text))
            {
                MessageBox.Show("برجاء ادخال الباسورد ");
                return;
            }
            //else if (string.IsNullOrEmpty(slkLoginType.Text))
            //{
            //    MessageBox.Show("برجاء اختيار الصلاحيات ");
            //    return;
            //}
            else if (string.IsNullOrEmpty(JopStartDate.Text))
            {
                MessageBox.Show("برجاء اختيار تاريخ بداية العمل ");
                return;
            }
            
            
            else
            {
                object LoginTypeCode = slkLoginType.EditValue;
                DataTable dt =  con.GetData("select * from UserLogin where Code = "+lblCode.Text+" and IsDeleted = 0 ");
                if (dt.Rows.Count > 0)
                {
                    con.InsertData("Update  UserLogin set   Name ='" + txtName.Text + "' ,  UserName ='" + txtuserName.Text + "' , Password ='" + txtPassword.Text + "', Phone ='" + txtMob.Text + "',  Start_Jop_Date ='" + JopStartDate.EditValue + "' ,  LoginType =" + slkLoginType.EditValue + " , Last_Modified_Date ='" + DateTime.Now + "' ,Last_Modified_By = "+ UserLogCode + " where Code = " + lblCode.Text + " ");
                    MessageBox.Show("تم التعديل");
                    RestAll();
                    gridControl1.DataSource = con.GetData("select * from Users_View where IsDeleted =0");
                }
                else
                {
                    dtcheckUserName = con.GetData("select * from UserLogin where  Name Like '" + txtName.Text + "' or UserName Like '" + txtuserName.Text + "' and IsDeleted = 0   ");
                    if (dtcheckUserName.Rows.Count > 0)
                    {
                        MessageBox.Show("هذا الاسم مستخدم من قبل");
                        return;
                    }
                    else
                    { 
                    
                    con.InsertData("insert into UserLogin (Code,Name,UserName,Password,Phone,Start_Jop_Date,LoginType,Last_Modified_By) Values(" + NewUserCode + ",'" + txtName.Text + "','" + txtuserName.Text + "','" + txtPassword.Text + "','" + txtMob.Text + "','" + JopStartDate.EditValue + "'," + slkLoginType.EditValue + "," + UserLogCode + ")");
                    MessageBox.Show("تم الحفظ");
                    RestAll();
                    gridControl1.DataSource = con.GetData("select * from Users_View where IsDeleted =0");
                    }
                }
                
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

      

      

        private void gridControl1_DoubleClick(object sender, EventArgs e)
        {
            
            try
            {
                foreach (int i in gvMain.GetSelectedRows())
                {
                    DataRow row = gvMain.GetDataRow(i);
                    lblCode.Text = row[0].ToString();
                    txtName.Text = row[1].ToString();
                    txtMob.Text = row[2].ToString();
                    JopStartDate.EditValue = row[3].ToString();
                    txtPassword.Text = row[6].ToString();
                    txtuserName.Text = row[7].ToString();
                    slkLoginType.Text = Convert.ToString(row[8].ToString());


                    //cmdDiscountPercentage.Text = row[10].ToString();
                }
            }
            catch
            {
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(lblCode.Text))
            {

                MessageBox.Show("برجاء اختيار مستخدم ");

            }
            else
            {
                con.InsertData("Update UserLogin set IsDeleted = 1 where Code = "+Convert.ToInt32(lblCode.Text)+" ");
                MessageBox.Show("تم المسح");
                RestAll();

            }
        }
    }
}
