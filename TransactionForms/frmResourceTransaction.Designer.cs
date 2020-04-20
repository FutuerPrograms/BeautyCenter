namespace PointOfSell.TransactionForms
{
    partial class frmResourceTransaction
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.materialLabel5 = new MaterialSkin.Controls.MaterialLabel();
            this.slkResourceName = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.grdItemView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.txtDebit = new DevExpress.XtraEditors.TextEdit();
            this.materialLabel7 = new MaterialSkin.Controls.MaterialLabel();
            this.txtCredit = new DevExpress.XtraEditors.TextEdit();
            this.materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.materialLabel11 = new MaterialSkin.Controls.MaterialLabel();
            this.dtFrom = new DevExpress.XtraEditors.DateEdit();
            this.materialLabel2 = new MaterialSkin.Controls.MaterialLabel();
            this.lblCredit = new MaterialSkin.Controls.MaterialLabel();
            this.lblResidual = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel6 = new MaterialSkin.Controls.MaterialLabel();
            this.lblRequired = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel4 = new MaterialSkin.Controls.MaterialLabel();
            this.materialContextMenuStrip1 = new MaterialSkin.Controls.MaterialContextMenuStrip();
            this.جديدToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.slkResourceName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdItemView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDebit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCredit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtFrom.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtFrom.Properties)).BeginInit();
            this.materialContextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // materialLabel5
            // 
            this.materialLabel5.AutoSize = true;
            this.materialLabel5.Depth = 0;
            this.materialLabel5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.materialLabel5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel5.Location = new System.Drawing.Point(342, 74);
            this.materialLabel5.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel5.Name = "materialLabel5";
            this.materialLabel5.Size = new System.Drawing.Size(61, 18);
            this.materialLabel5.TabIndex = 178;
            this.materialLabel5.Text = "اسم المورد";
            // 
            // slkResourceName
            // 
            this.slkResourceName.EditValue = "";
            this.slkResourceName.Location = new System.Drawing.Point(236, 96);
            this.slkResourceName.Name = "slkResourceName";
            this.slkResourceName.Properties.Appearance.BackColor = System.Drawing.Color.Gainsboro;
            this.slkResourceName.Properties.Appearance.Options.UseBackColor = true;
            this.slkResourceName.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.slkResourceName.Properties.NullText = "";
            this.slkResourceName.Properties.PopupView = this.grdItemView;
            this.slkResourceName.Size = new System.Drawing.Size(168, 20);
            this.slkResourceName.TabIndex = 177;
            this.slkResourceName.EditValueChanged += new System.EventHandler(this.slkResourceName_EditValueChanged);
            // 
            // grdItemView
            // 
            this.grdItemView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn7,
            this.gridColumn1});
            this.grdItemView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.grdItemView.Name = "grdItemView";
            this.grdItemView.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.grdItemView.OptionsView.ShowGroupPanel = false;
            // 
            // txtDebit
            // 
            this.txtDebit.EditValue = "0";
            this.txtDebit.Location = new System.Drawing.Point(236, 160);
            this.txtDebit.Name = "txtDebit";
            this.txtDebit.Properties.Appearance.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtDebit.Properties.Appearance.Options.UseBackColor = true;
            this.txtDebit.Properties.Appearance.Options.UseTextOptions = true;
            this.txtDebit.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.txtDebit.Properties.Mask.EditMask = "\\d+(\\R.\\d{0,2})?";
            this.txtDebit.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            this.txtDebit.Properties.Mask.ShowPlaceHolders = false;
            this.txtDebit.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtDebit.Size = new System.Drawing.Size(168, 20);
            this.txtDebit.TabIndex = 180;
            // 
            // materialLabel7
            // 
            this.materialLabel7.AutoSize = true;
            this.materialLabel7.Depth = 0;
            this.materialLabel7.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.materialLabel7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel7.Location = new System.Drawing.Point(328, 138);
            this.materialLabel7.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel7.Name = "materialLabel7";
            this.materialLabel7.Size = new System.Drawing.Size(75, 18);
            this.materialLabel7.TabIndex = 181;
            this.materialLabel7.Text = "مبلغ المستحق";
            // 
            // txtCredit
            // 
            this.txtCredit.EditValue = "0";
            this.txtCredit.Location = new System.Drawing.Point(10, 160);
            this.txtCredit.Name = "txtCredit";
            this.txtCredit.Properties.Appearance.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtCredit.Properties.Appearance.Options.UseBackColor = true;
            this.txtCredit.Properties.Appearance.Options.UseTextOptions = true;
            this.txtCredit.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.txtCredit.Properties.Mask.EditMask = "\\d+(\\R.\\d{0,2})?";
            this.txtCredit.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            this.txtCredit.Properties.Mask.ShowPlaceHolders = false;
            this.txtCredit.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtCredit.Size = new System.Drawing.Size(157, 20);
            this.txtCredit.TabIndex = 182;
            // 
            // materialLabel1
            // 
            this.materialLabel1.AutoSize = true;
            this.materialLabel1.Depth = 0;
            this.materialLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.materialLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel1.Location = new System.Drawing.Point(104, 138);
            this.materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel1.Name = "materialLabel1";
            this.materialLabel1.Size = new System.Drawing.Size(62, 18);
            this.materialLabel1.TabIndex = 183;
            this.materialLabel1.Text = "مبلغ السداد";
            // 
            // btnClose
            // 
            this.btnClose.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnClose.Appearance.Options.UseBackColor = true;
            this.btnClose.Location = new System.Drawing.Point(182, 279);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(104, 37);
            this.btnClose.TabIndex = 185;
            this.btnClose.Text = "اغلاق";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSave
            // 
            this.btnSave.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnSave.Appearance.Options.UseBackColor = true;
            this.btnSave.Location = new System.Drawing.Point(301, 279);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(100, 37);
            this.btnSave.TabIndex = 184;
            this.btnSave.Text = "حفظ";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // materialLabel11
            // 
            this.materialLabel11.AutoSize = true;
            this.materialLabel11.Depth = 0;
            this.materialLabel11.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.materialLabel11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel11.Location = new System.Drawing.Point(127, 74);
            this.materialLabel11.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel11.Name = "materialLabel11";
            this.materialLabel11.Size = new System.Drawing.Size(39, 18);
            this.materialLabel11.TabIndex = 192;
            this.materialLabel11.Text = " تاريخ";
            // 
            // dtFrom
            // 
            this.dtFrom.EditValue = null;
            this.dtFrom.Location = new System.Drawing.Point(10, 96);
            this.dtFrom.Name = "dtFrom";
            this.dtFrom.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtFrom.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtFrom.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.dtFrom.Size = new System.Drawing.Size(157, 20);
            this.dtFrom.TabIndex = 193;
            // 
            // materialLabel2
            // 
            this.materialLabel2.AutoSize = true;
            this.materialLabel2.Depth = 0;
            this.materialLabel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.materialLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel2.Location = new System.Drawing.Point(181, 203);
            this.materialLabel2.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel2.Name = "materialLabel2";
            this.materialLabel2.Size = new System.Drawing.Size(44, 18);
            this.materialLabel2.TabIndex = 194;
            this.materialLabel2.Text = "المدفوع";
            // 
            // lblCredit
            // 
            this.lblCredit.AutoSize = true;
            this.lblCredit.Depth = 0;
            this.lblCredit.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.lblCredit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblCredit.Location = new System.Drawing.Point(192, 225);
            this.lblCredit.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblCredit.Name = "lblCredit";
            this.lblCredit.Size = new System.Drawing.Size(16, 18);
            this.lblCredit.TabIndex = 195;
            this.lblCredit.Text = "0";
            // 
            // lblResidual
            // 
            this.lblResidual.AutoSize = true;
            this.lblResidual.Depth = 0;
            this.lblResidual.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.lblResidual.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblResidual.Location = new System.Drawing.Point(111, 226);
            this.lblResidual.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblResidual.Name = "lblResidual";
            this.lblResidual.Size = new System.Drawing.Size(16, 18);
            this.lblResidual.TabIndex = 197;
            this.lblResidual.Text = "0";
            // 
            // materialLabel6
            // 
            this.materialLabel6.AutoSize = true;
            this.materialLabel6.Depth = 0;
            this.materialLabel6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.materialLabel6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel6.Location = new System.Drawing.Point(100, 203);
            this.materialLabel6.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel6.Name = "materialLabel6";
            this.materialLabel6.Size = new System.Drawing.Size(42, 18);
            this.materialLabel6.TabIndex = 196;
            this.materialLabel6.Text = "المتبقي";
            // 
            // lblRequired
            // 
            this.lblRequired.AutoSize = true;
            this.lblRequired.Depth = 0;
            this.lblRequired.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.lblRequired.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblRequired.Location = new System.Drawing.Point(285, 225);
            this.lblRequired.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblRequired.Name = "lblRequired";
            this.lblRequired.Size = new System.Drawing.Size(16, 18);
            this.lblRequired.TabIndex = 199;
            this.lblRequired.Text = "0";
            // 
            // materialLabel4
            // 
            this.materialLabel4.AutoSize = true;
            this.materialLabel4.Depth = 0;
            this.materialLabel4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.materialLabel4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel4.Location = new System.Drawing.Point(272, 203);
            this.materialLabel4.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel4.Name = "materialLabel4";
            this.materialLabel4.Size = new System.Drawing.Size(50, 18);
            this.materialLabel4.TabIndex = 198;
            this.materialLabel4.Text = "المطلوب";
            // 
            // materialContextMenuStrip1
            // 
            this.materialContextMenuStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.materialContextMenuStrip1.Depth = 0;
            this.materialContextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.جديدToolStripMenuItem});
            this.materialContextMenuStrip1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialContextMenuStrip1.Name = "materialContextMenuStrip1";
            this.materialContextMenuStrip1.Size = new System.Drawing.Size(98, 26);
            // 
            // جديدToolStripMenuItem
            // 
            this.جديدToolStripMenuItem.Name = "جديدToolStripMenuItem";
            this.جديدToolStripMenuItem.Size = new System.Drawing.Size(97, 22);
            this.جديدToolStripMenuItem.Text = "جديد";
            this.جديدToolStripMenuItem.Click += new System.EventHandler(this.جديدToolStripMenuItem_Click);
            // 
            // gridColumn7
            // 
            this.gridColumn7.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn7.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn7.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn7.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn7.Caption = "الاسم";
            this.gridColumn7.FieldName = "Resource_Name";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 0;
            // 
            // gridColumn1
            // 
            this.gridColumn1.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn1.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn1.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn1.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn1.Caption = "الموبيل";
            this.gridColumn1.FieldName = "Resource_Mobile";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 1;
            // 
            // frmResourceTransaction
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(412, 325);
            this.ContextMenuStrip = this.materialContextMenuStrip1;
            this.ControlBox = false;
            this.Controls.Add(this.lblRequired);
            this.Controls.Add(this.materialLabel4);
            this.Controls.Add(this.lblResidual);
            this.Controls.Add(this.materialLabel6);
            this.Controls.Add(this.lblCredit);
            this.Controls.Add(this.materialLabel2);
            this.Controls.Add(this.materialLabel11);
            this.Controls.Add(this.dtFrom);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtCredit);
            this.Controls.Add(this.materialLabel1);
            this.Controls.Add(this.txtDebit);
            this.Controls.Add(this.materialLabel7);
            this.Controls.Add(this.materialLabel5);
            this.Controls.Add(this.slkResourceName);
            this.MaximumSize = new System.Drawing.Size(412, 325);
            this.MinimumSize = new System.Drawing.Size(412, 325);
            this.Name = "frmResourceTransaction";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "تعاملات الموردين";
            this.Load += new System.EventHandler(this.frmResourceTransaction_Load);
            ((System.ComponentModel.ISupportInitialize)(this.slkResourceName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdItemView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDebit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCredit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtFrom.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtFrom.Properties)).EndInit();
            this.materialContextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MaterialSkin.Controls.MaterialLabel materialLabel5;
        private DevExpress.XtraEditors.SearchLookUpEdit slkResourceName;
        private DevExpress.XtraGrid.Views.Grid.GridView grdItemView;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraEditors.TextEdit txtDebit;
        private MaterialSkin.Controls.MaterialLabel materialLabel7;
        private DevExpress.XtraEditors.TextEdit txtCredit;
        private MaterialSkin.Controls.MaterialLabel materialLabel1;
        private DevExpress.XtraEditors.SimpleButton btnClose;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private MaterialSkin.Controls.MaterialLabel materialLabel11;
        private DevExpress.XtraEditors.DateEdit dtFrom;
        private MaterialSkin.Controls.MaterialLabel materialLabel2;
        private MaterialSkin.Controls.MaterialLabel lblCredit;
        private MaterialSkin.Controls.MaterialLabel lblResidual;
        private MaterialSkin.Controls.MaterialLabel materialLabel6;
        private MaterialSkin.Controls.MaterialLabel lblRequired;
        private MaterialSkin.Controls.MaterialLabel materialLabel4;
        private MaterialSkin.Controls.MaterialContextMenuStrip materialContextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem جديدToolStripMenuItem;
    }
}