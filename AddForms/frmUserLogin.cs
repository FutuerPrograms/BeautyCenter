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
    public partial class frmUserLogin : MaterialSkin.Controls.MaterialForm
    {
        DB con = new DB();

        public frmUserLogin()
        {
            InitializeComponent();

        }



        private void ButOk_Click(object sender, EventArgs e)
        {
            
           
        }

        private void ButCancel_Click(object sender, EventArgs e)
        {
          
        }

        private void frmUserLogin_Load(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt = con.GetData("select * from UserLogin where  UserName Like '" + txtuserName.Text + "' and Password Like '" + txtPassword.Text + "' and IsDeleted = 0 ");
          
            if (dt.Rows.Count > 0)
            {
                this.Hide();
                con.UserName(Convert.ToInt32(dt.Rows[0][1]));
                frmMain frm = new frmMain();
                frm.ShowDialog();
                //return;
            }
            else
            {
                MessageBox.Show("برجاء التاكد من كلمة المرور");

            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
