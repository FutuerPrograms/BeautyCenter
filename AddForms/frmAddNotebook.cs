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

namespace PointOfSell.AddForms
{
    public partial class frmAddNotebook : MaterialSkin.Controls.MaterialForm
    {
        DB con = new DB();
        public frmAddNotebook()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
            frmSales obj = (frmSales)Application.OpenForms["frmSales"];
            obj.Close();

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtNotebook.Text))
            {
                MessageBox.Show("برجاء ادخال رقم دفتر");
                return;
            
            }
            decimal CheckNoteName = con.ReturnDecimal(con.GetData("select count(*) from Notebook_Info where Notebook_Number like '"+txtNotebook.Text+"'"));
            if (CheckNoteName > 0)
            {

                MessageBox.Show("هذا الدفتر مضاف من قبل");
                return;

            }
            int UserCode = con.UserId();
          decimal CheckNoteBook =   con.ReturnDecimal(con.GetData("select count(*) from Notebook_Info where IsDeleted = 0 and Notebook_State = 0"));
            if (CheckNoteBook == 0)
            {
                decimal NewNoteCode = con.ReturnDecimal( con.GetData("select count(Notebook_Code)+1 from  Notebook_Info where IsDeleted = 0 "));
                con.InsertData("insert into Notebook_Info (Notebook_Code,Notebook_Number,Last_Modified_Date,Last_Modified_By)values(" + NewNoteCode+ ",'" + txtNotebook.Text+"','"+DateTime.Now+ "',"+UserCode+") ");
                MessageBox.Show("تم اضافة الدفتر بنجاح");
               DataTable dt =  con.GetData("select * from  Notebook_Info where IsDeleted = 0 ");
                gridControl1.DataSource = dt;
                this.Close();
            }
            else
            {

                MessageBox.Show("هذا الدفتر مضاف من قبل");
                return;
            }
        }

        private void frmAddNotebook_Load(object sender, EventArgs e)
        {
            DataTable dt = con.GetData("select * from  Notebook_Info where IsDeleted = 0 ");
            gridControl1.DataSource = dt;
        }
    }
}
