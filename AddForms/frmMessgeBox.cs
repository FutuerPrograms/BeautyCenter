using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaterialSkin;

namespace PointOfSell.AddForms
{
    public partial class frmMessgeBox : MaterialSkin.Controls.MaterialForm
    {
        MaterialSkin.MaterialSkinManager SkinManager;
        public frmMessgeBox()
        {
            InitializeComponent();
            SkinManager = MaterialSkinManager.Instance;
            SkinManager.AddFormToManage(this);
            SkinManager.Theme = MaterialSkinManager.Themes.DARK;
            SkinManager.ColorScheme = new ColorScheme(Primary.Green600,Primary.Grey600,Primary.Grey900,Accent.LightBlue200, TextShade.WHITE);
        }
    }
}
