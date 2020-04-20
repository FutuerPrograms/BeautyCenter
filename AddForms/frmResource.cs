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
    public partial class frmResource : MaterialSkin.Controls.MaterialForm
    {
        DB con = new DB();
        public frmResource()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmResource_Load(object sender, EventArgs e)
        {
            DataTable dt = con.GetData("select * from Resource_Info where IsDeleted = 0 ");
            gridControl1.DataSource = dt;
        }

        private void gridControl1_DoubleClick(object sender, EventArgs e)
        {
            if (gvMain.RowCount > 0)
            {
                try
                {
                    foreach (int i in gvMain.GetSelectedRows())
                    {
                        DataRow row = gvMain.GetDataRow(i);
                        lblCode.Text = row[0].ToString();
                        txtName.Text = row[2].ToString();
                        txtCompany.Text = row[3].ToString();
                        txtMob.Text = row[4].ToString();
                        txtAddress.Text = row[5].ToString();
                        txtMob.ReadOnly = true;
                        txtMob.BackColor = Color.DarkGray;
                    }
                }
                catch
                {
                }

            }
            else
            { 
            
            
            }
           
        }
        void Rest()
        {
            txtAddress.Text = "";
            txtCompany.Text = "";
            txtMob.Text = "";
            txtName.Text = "";
            lblCode.Text = "";

            txtMob.BackColor = Color.White;
            txtMob.ReadOnly = false;
            DataTable dt = con.GetData("select * from Resource_Info where IsDeleted = 0 ");
            gridControl1.DataSource = dt;
            gridControl1.RefreshDataSource();

        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                
                if (string.IsNullOrEmpty(txtName.Text) || string.IsNullOrEmpty(txtAddress.Text) || string.IsNullOrEmpty(txtCompany.Text) || string.IsNullOrEmpty(txtMob.Text))

                {

                    MessageBox.Show("برجاء ادخال جميع الحقول");
                    return;
                }
                 decimal checkNumber = con.ReturnDecimal( con.GetData("select Count(*) from  Resource_Info where Resource_Mobile like '" + txtMob.Text+"' and IsDeleted = 0 "));
                 if (checkNumber > 0&&string.IsNullOrEmpty(lblCode.Text))
                {
                    MessageBox.Show("هذا الرقم مستخدم من قبل");
                    return;
                
                }
                else
                {
                    decimal ResourceCode = con.ReturnDecimal(con.GetData("select count(*) from  Resource_Info where IsDeleted = 0 "));
                    if (ResourceCode == 0)
                    {
                        ResourceCode = 1;
                    }
                    else
                    {

                        ResourceCode = con.ReturnDecimal(con.GetData("select max(Resource_Code)+1 from  Resource_Info where IsDeleted = 0 "));
                    }

                    if (string.IsNullOrEmpty(lblCode.Text))
                    {

                        con.InsertData("insert into Resource_Info(Resource_Code,Resource_Name,Company_Name,Resource_Mobile,Resource_Address,Last_Modified_By,Last_Modified_Date)Values(" + ResourceCode + ",'" + txtName.Text + "','" + txtCompany.Text + "','" + txtMob.Text + "','" + txtAddress.Text + "'," + con.UserId() + ",'" + DateTime.Now + "')");
                        MessageBox.Show("تم الحفظ");
                        Rest();


                    }
                    else
                    {

                        con.InsertData("Update  Resource_Info set Resource_Name = '" + txtName.Text + "',Company_Name= '" + txtCompany.Text + "',Resource_Mobile= '" + txtMob.Text + "',Resource_Address= '" + txtAddress.Text + "',Last_Modified_By = " + con.UserId() + ",Last_Modified_Date= '" + DateTime.Now + "' where Id = " + lblCode.Text + "");
                        MessageBox.Show("تم التعديل");
                        Rest();


                    }



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
                MessageBox.Show("برجاء اختيار مورد ليتم حذفه");
                return;
            }
            else
            {
                con.InsertData("Update Resource_Info set  IsDeleted = 1 where Id = " + lblCode.Text + " ");
                MessageBox.Show("تم الحذف");
                Rest();
            }

        }

        private void جديدToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Rest();
        }
    }
}
