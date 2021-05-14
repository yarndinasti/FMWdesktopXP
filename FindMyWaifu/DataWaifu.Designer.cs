
namespace FindMyWaifu
{
    partial class DataWaifu
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DataWaifu));
      this.groupBox1 = new System.Windows.Forms.GroupBox();
      this.button6 = new System.Windows.Forms.Button();
      this.button5 = new System.Windows.Forms.Button();
      this.button4 = new System.Windows.Forms.Button();
      this.catCombo = new System.Windows.Forms.ComboBox();
      this.WaifuList = new System.Windows.Forms.ListView();
      this.noWaifu = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.NameWaifu = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.groupBox2 = new System.Windows.Forms.GroupBox();
      this.toolStrip1 = new System.Windows.Forms.ToolStrip();
      this.addCatBtn = new System.Windows.Forms.ToolStripButton();
      this.editCatBtn = new System.Windows.Forms.ToolStripButton();
      this.deleteCatBtn = new System.Windows.Forms.ToolStripButton();
      this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
      this.addWaifuBtn = new System.Windows.Forms.ToolStripButton();
      this.editWaifuBtn = new System.Windows.Forms.ToolStripButton();
      this.deleteWaifuBtn = new System.Windows.Forms.ToolStripButton();
      this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
      this.ImportBtn = new System.Windows.Forms.ToolStripButton();
      this.ExportBtn = new System.Windows.Forms.ToolStripButton();
      this.StoreBtn = new System.Windows.Forms.ToolStripButton();
      this.searchWaifu = new System.Windows.Forms.ToolStripTextBox();
      this.DLimgBtn = new System.Windows.Forms.ToolStripButton();
      this.groupBox1.SuspendLayout();
      this.toolStrip1.SuspendLayout();
      this.SuspendLayout();
      // 
      // groupBox1
      // 
      this.groupBox1.Controls.Add(this.button6);
      this.groupBox1.Controls.Add(this.button5);
      this.groupBox1.Controls.Add(this.button4);
      this.groupBox1.Controls.Add(this.catCombo);
      this.groupBox1.Location = new System.Drawing.Point(12, 33);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Size = new System.Drawing.Size(370, 53);
      this.groupBox1.TabIndex = 0;
      this.groupBox1.TabStop = false;
      this.groupBox1.Text = "Filter";
      // 
      // button6
      // 
      this.button6.Location = new System.Drawing.Point(315, 17);
      this.button6.Name = "button6";
      this.button6.Size = new System.Drawing.Size(49, 23);
      this.button6.TabIndex = 3;
      this.button6.Text = "Edit";
      this.button6.UseVisualStyleBackColor = true;
      // 
      // button5
      // 
      this.button5.Location = new System.Drawing.Point(255, 17);
      this.button5.Name = "button5";
      this.button5.Size = new System.Drawing.Size(54, 23);
      this.button5.TabIndex = 2;
      this.button5.Text = "Delete";
      this.button5.UseVisualStyleBackColor = true;
      // 
      // button4
      // 
      this.button4.Location = new System.Drawing.Point(211, 17);
      this.button4.Name = "button4";
      this.button4.Size = new System.Drawing.Size(38, 23);
      this.button4.TabIndex = 1;
      this.button4.Text = "Add";
      this.button4.UseVisualStyleBackColor = true;
      // 
      // catCombo
      // 
      this.catCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.catCombo.FormattingEnabled = true;
      this.catCombo.Location = new System.Drawing.Point(6, 19);
      this.catCombo.Name = "catCombo";
      this.catCombo.Size = new System.Drawing.Size(199, 21);
      this.catCombo.TabIndex = 0;
      this.catCombo.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
      // 
      // WaifuList
      // 
      this.WaifuList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.noWaifu,
            this.NameWaifu,
            this.columnHeader1});
      this.WaifuList.FullRowSelect = true;
      this.WaifuList.GridLines = true;
      this.WaifuList.HideSelection = false;
      this.WaifuList.Location = new System.Drawing.Point(12, 93);
      this.WaifuList.Name = "WaifuList";
      this.WaifuList.Size = new System.Drawing.Size(370, 230);
      this.WaifuList.TabIndex = 6;
      this.WaifuList.UseCompatibleStateImageBehavior = false;
      this.WaifuList.View = System.Windows.Forms.View.Details;
      this.WaifuList.SelectedIndexChanged += new System.EventHandler(this.WaifuList_SelectedIndexChanged);
      // 
      // noWaifu
      // 
      this.noWaifu.Text = "#";
      this.noWaifu.Width = 30;
      // 
      // NameWaifu
      // 
      this.NameWaifu.Text = "Name";
      this.NameWaifu.Width = 180;
      // 
      // columnHeader1
      // 
      this.columnHeader1.Text = "Category";
      this.columnHeader1.Width = 150;
      // 
      // groupBox2
      // 
      this.groupBox2.Location = new System.Drawing.Point(12, 330);
      this.groupBox2.Name = "groupBox2";
      this.groupBox2.Size = new System.Drawing.Size(370, 45);
      this.groupBox2.TabIndex = 7;
      this.groupBox2.TabStop = false;
      this.groupBox2.Text = "groupBox2";
      // 
      // toolStrip1
      // 
      this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addCatBtn,
            this.editCatBtn,
            this.deleteCatBtn,
            this.toolStripSeparator1,
            this.addWaifuBtn,
            this.editWaifuBtn,
            this.deleteWaifuBtn,
            this.toolStripSeparator2,
            this.ImportBtn,
            this.ExportBtn,
            this.StoreBtn,
            this.searchWaifu,
            this.DLimgBtn});
      this.toolStrip1.Location = new System.Drawing.Point(0, 0);
      this.toolStrip1.Name = "toolStrip1";
      this.toolStrip1.Size = new System.Drawing.Size(395, 25);
      this.toolStrip1.TabIndex = 8;
      this.toolStrip1.Text = "toolStrip1";
      // 
      // addCatBtn
      // 
      this.addCatBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.addCatBtn.Image = global::FindMyWaifu.Properties.Resources.iconfinder_tag_blue_add_64792;
      this.addCatBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.addCatBtn.Name = "addCatBtn";
      this.addCatBtn.Size = new System.Drawing.Size(23, 22);
      this.addCatBtn.Text = "Add Category";
      this.addCatBtn.Click += new System.EventHandler(this.addCatBtn_Click);
      // 
      // editCatBtn
      // 
      this.editCatBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.editCatBtn.Image = global::FindMyWaifu.Properties.Resources.iconfinder_tag_blue_edit_64794;
      this.editCatBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.editCatBtn.Name = "editCatBtn";
      this.editCatBtn.Size = new System.Drawing.Size(23, 22);
      this.editCatBtn.Text = "Edit Category";
      this.editCatBtn.Click += new System.EventHandler(this.editCatBtn_Click);
      // 
      // deleteCatBtn
      // 
      this.deleteCatBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.deleteCatBtn.Image = global::FindMyWaifu.Properties.Resources.iconfinder_tag_blue_delete_64793;
      this.deleteCatBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.deleteCatBtn.Name = "deleteCatBtn";
      this.deleteCatBtn.Size = new System.Drawing.Size(23, 22);
      this.deleteCatBtn.Text = "Delete Category";
      this.deleteCatBtn.Click += new System.EventHandler(this.deleteCatBtn_Click);
      // 
      // toolStripSeparator1
      // 
      this.toolStripSeparator1.Name = "toolStripSeparator1";
      this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
      // 
      // addWaifuBtn
      // 
      this.addWaifuBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.addWaifuBtn.Image = global::FindMyWaifu.Properties.Resources.iconfinder_user_add_64936;
      this.addWaifuBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.addWaifuBtn.Name = "addWaifuBtn";
      this.addWaifuBtn.Size = new System.Drawing.Size(23, 22);
      this.addWaifuBtn.Text = "Add Waifu";
      this.addWaifuBtn.Click += new System.EventHandler(this.addWaifuBtn_Click);
      // 
      // editWaifuBtn
      // 
      this.editWaifuBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.editWaifuBtn.Image = global::FindMyWaifu.Properties.Resources.iconfinder_user_edit_64941;
      this.editWaifuBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.editWaifuBtn.Name = "editWaifuBtn";
      this.editWaifuBtn.Size = new System.Drawing.Size(23, 22);
      this.editWaifuBtn.Text = "Edit Waifu";
      this.editWaifuBtn.Click += new System.EventHandler(this.editWaifuBtn_Click);
      // 
      // deleteWaifuBtn
      // 
      this.deleteWaifuBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.deleteWaifuBtn.Image = global::FindMyWaifu.Properties.Resources.iconfinder_group_delete_36092;
      this.deleteWaifuBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.deleteWaifuBtn.Name = "deleteWaifuBtn";
      this.deleteWaifuBtn.Size = new System.Drawing.Size(23, 22);
      this.deleteWaifuBtn.Text = "Delete Waifu";
      this.deleteWaifuBtn.Click += new System.EventHandler(this.deleteWaifuBtn_Click);
      // 
      // toolStripSeparator2
      // 
      this.toolStripSeparator2.Name = "toolStripSeparator2";
      this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
      // 
      // ImportBtn
      // 
      this.ImportBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.ImportBtn.Image = global::FindMyWaifu.Properties.Resources.iconfinder_document_import_64094;
      this.ImportBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.ImportBtn.Name = "ImportBtn";
      this.ImportBtn.Size = new System.Drawing.Size(23, 22);
      this.ImportBtn.Text = "toolStripButton7";
      // 
      // ExportBtn
      // 
      this.ExportBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.ExportBtn.Image = global::FindMyWaifu.Properties.Resources.iconfinder_document_export_64088;
      this.ExportBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.ExportBtn.Name = "ExportBtn";
      this.ExportBtn.Size = new System.Drawing.Size(23, 22);
      this.ExportBtn.Text = "toolStripButton8";
      this.ExportBtn.Click += new System.EventHandler(this.ExportBtn_Click);
      // 
      // StoreBtn
      // 
      this.StoreBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.StoreBtn.Image = global::FindMyWaifu.Properties.Resources.iconfinder_legend_64438;
      this.StoreBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.StoreBtn.Name = "StoreBtn";
      this.StoreBtn.Size = new System.Drawing.Size(23, 22);
      this.StoreBtn.Text = "toolStripButton1";
      // 
      // searchWaifu
      // 
      this.searchWaifu.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
      this.searchWaifu.Font = new System.Drawing.Font("Segoe UI", 9F);
      this.searchWaifu.Name = "searchWaifu";
      this.searchWaifu.Size = new System.Drawing.Size(100, 25);
      this.searchWaifu.ToolTipText = "Search Waifu...";
      this.searchWaifu.TextChanged += new System.EventHandler(this.searchWaifu_TextChanged);
      // 
      // DLimgBtn
      // 
      this.DLimgBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.DLimgBtn.Image = ((System.Drawing.Image)(resources.GetObject("DLimgBtn.Image")));
      this.DLimgBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.DLimgBtn.Name = "DLimgBtn";
      this.DLimgBtn.Size = new System.Drawing.Size(23, 22);
      this.DLimgBtn.Text = "toolStripButton1";
      // 
      // DataWaifu
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(395, 396);
      this.Controls.Add(this.toolStrip1);
      this.Controls.Add(this.groupBox2);
      this.Controls.Add(this.WaifuList);
      this.Controls.Add(this.groupBox1);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
      this.MaximizeBox = false;
      this.Name = "DataWaifu";
      this.Text = "DataWaifu";
      this.Load += new System.EventHandler(this.DataWaifu_Load);
      this.groupBox1.ResumeLayout(false);
      this.toolStrip1.ResumeLayout(false);
      this.toolStrip1.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox catCombo;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.ListView WaifuList;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton addCatBtn;
        private System.Windows.Forms.ToolStripButton editCatBtn;
        private System.Windows.Forms.ToolStripButton deleteCatBtn;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton addWaifuBtn;
        private System.Windows.Forms.ToolStripButton editWaifuBtn;
        private System.Windows.Forms.ToolStripButton deleteWaifuBtn;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton ImportBtn;
        private System.Windows.Forms.ToolStripButton ExportBtn;
        private System.Windows.Forms.ToolStripButton StoreBtn;
        private System.Windows.Forms.ColumnHeader noWaifu;
        private System.Windows.Forms.ColumnHeader NameWaifu;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ToolStripTextBox searchWaifu;
    private System.Windows.Forms.ToolStripButton DLimgBtn;
  }
}