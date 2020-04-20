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
    public partial class frmAddJop :MaterialSkin.Controls.MaterialForm
    {
        DB con = new DB();
        public frmAddJop()
        {
            InitializeComponent();
        }
        public void RestAll()
        {
            txtName.Text = "";
            txtPrice.Text = "";
            lblCode.Text = "";
            gridControl1.DataSource = con.GetData("select * from Jop_Info where IsDeleted =0");
        }
        private void SlkItem_Properties_EditValueChanged(object sender, EventArgs e)
        {

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
                    lblCode.Text = row[1].ToString();
                    txtName.Text = row[2].ToString();
                    txtPrice.Text = row[3].ToString();
                   


                   
                }
            }
            catch
            {
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            DataTable dtcheckUserName = new DataTable();
            int UserLogCode = Convert.ToInt32(con.UserId());


            int NewJopCode = 0;
            DataTable dtGetNewCode = new DataTable();
            dtGetNewCode = con.GetData("select max(JopCode)+1 from Jop_Info where IsDeleted = 0");
            if (dtGetNewCode.Rows.Count == 0)
            {

                NewJopCode = 1;


            }
            else if (string.IsNullOrEmpty(dtGetNewCode.Rows[0][0].ToString()))
            {
                NewJopCode = 1;

            }
            else
            {
                NewJopCode = Convert.ToInt32(dtGetNewCode.Rows[0][0]);

            }



            if (string.IsNullOrEmpty(txtName.Text))
            {
                MessageBox.Show("برجاء ادخال اسم الوظية ");
                return;
            }
            else if (string.IsNullOrEmpty(txtPrice.Text))
            {
                MessageBox.Show("برجاء ادخال السعر ");
                return;
            }
          

            else
            {
                if (!string.IsNullOrEmpty(lblCode.Text))
                {

                    DataTable dt = con.GetData("select * from Jop_Info where JopCode = " + lblCode.Text + " and IsDeleted = 0 ");
                    if (dt.Rows.Count > 0)
                    {
                        con.InsertData("Update  Jop_Info set   JopName ='" + txtName.Text + "' ,  JopPrice ='" + txtPrice.Text + "' ,  Last_Modified_Date ='" + DateTime.Now + "' ,  Last_Modified_By =" + UserLogCode + "  where JopCode = " + lblCode.Text + " ");
                        MessageBox.Show("تم التعديل");
                        RestAll();
                       
                    }

                }



                else
                {
                    dtcheckUserName = con.GetData("select * from Jop_Info where  JopName Like '" + txtName.Text + "'  IsDeleted = 0   ");
                    if (dtcheckUserName.Rows.Count > 0)
                    {
                        MessageBox.Show("هذا الاسم مستخدم من قبل");
                        return;
                    }
                    else
                    {

                        con.InsertData("insert into Jop_Info (JopCode,JopName,JopPrice,Last_Modified_By,Last_Modified_Date) Values(" + NewJopCode + ",'" + txtName.Text + "','" + txtPrice.Text + "'," + UserLogCode + ",'"+ DateTime.Now + "')");
                        MessageBox.Show("تم الحفظ");
                        RestAll();
                      
                    }
                }

            }
        }

        private void frmAddJop_Load(object sender, EventArgs e)
        {
            RestAll();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(lblCode.Text))
            {

                MessageBox.Show("برجاء اختيار وظيفة ");

            }
            else
            {
                con.InsertData("Update Jop_Info set IsDeleted = 1 where JopCode = " + Convert.ToInt32(lblCode.Text) + " ");
                MessageBox.Show("تم المسح");
                RestAll();

            }
        }

        private void جديدToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RestAll();
        }
    }
}
