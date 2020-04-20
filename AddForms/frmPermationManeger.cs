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
    public partial class frmPermationManeger : MaterialSkin.Controls.MaterialForm
    {
        DB con = new DB();
        public frmPermationManeger()
        {
            InitializeComponent();
        }

     

     
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt = con.GetData("select * from UserLogin where  UserName Like '" + txtuserName.Text + "' and UserPassword Like '" + txtPassword.Text + "' and IsDeleted = 0 and LoginType = 1 ");
            if (dt.Rows.Count > 0)
            {

                if (con.FormLoginState() == 1)
                {
                    //frmAddUnits AddUnits = new frmAddUnits();
                    //this.Close();
                    //AddUnits.ShowDialog();


                }
                //else if (con.FormLoginState() == 2)
                //{

                //    frmAddItems AddItems = new frmAddItems();
                //    AddItems.Show();
                //}
                else if (con.FormLoginState() == 3)
                {

                    frmAddUser AddUser = new frmAddUser();
                    AddUser.Show();
                }

                else if (con.FormLoginState() == 4)
                {

                    //frmInventory Inventory = new frmInventory();
                    //Inventory.Show();
                }
                //else if (con.FormLoginState() == 5)
                //{
                //    frmInTransaction frm = new frmInTransaction();
                //    frm.Show();
                //}
                else if (con.FormLoginState() == 6)
                {
                    //frmExpenses frm = new frmExpenses();
                    //frm.Show();
                }





                this.Close();

            }
            else
            {
                MessageBox.Show("برجاء التاكد من كلمة المرور");

            }
        }
    }
}
