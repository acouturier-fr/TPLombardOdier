namespace DistributeurBoissons
{
    partial class VendingMachineForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VendingMachineForm));
            this.databaseContextBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.beverageTypeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.vendingMachineToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.userWalletToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.portefeuilleMachineToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imgListBeverageType = new System.Windows.Forms.ImageList(this.components);
            this.lstViewBeverageTypes = new System.Windows.Forms.ListView();
            this.btnBuyBeverageFromListView = new System.Windows.Forms.Button();
            this.btnRefund = new System.Windows.Forms.Button();
            this.btnInsertCoin = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lblInserted = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.databaseContextBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.beverageTypeBindingSource)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // databaseContextBindingSource
            // 
            this.databaseContextBindingSource.DataSource = typeof(DistributeurBoissons.Class.DatabaseContext);
            // 
            // beverageTypeBindingSource
            // 
            this.beverageTypeBindingSource.DataSource = typeof(DistributeurBoissons.Model.BeverageType);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.vendingMachineToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(455, 24);
            this.menuStrip1.TabIndex = 9;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // vendingMachineToolStripMenuItem
            // 
            this.vendingMachineToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.settingsToolStripMenuItem,
            this.userWalletToolStripMenuItem,
            this.portefeuilleMachineToolStripMenuItem});
            this.vendingMachineToolStripMenuItem.Name = "vendingMachineToolStripMenuItem";
            this.vendingMachineToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.vendingMachineToolStripMenuItem.Text = "Menu";
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.settingsToolStripMenuItem.Text = "Parametres";
            this.settingsToolStripMenuItem.Click += new System.EventHandler(this.settingsToolStripMenuItem_Click);
            // 
            // userWalletToolStripMenuItem
            // 
            this.userWalletToolStripMenuItem.Name = "userWalletToolStripMenuItem";
            this.userWalletToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.userWalletToolStripMenuItem.Text = "Portefeuille Utilisateur";
            this.userWalletToolStripMenuItem.Click += new System.EventHandler(this.userWalletToolStripMenuItem_Click);
            // 
            // portefeuilleMachineToolStripMenuItem
            // 
            this.portefeuilleMachineToolStripMenuItem.Name = "portefeuilleMachineToolStripMenuItem";
            this.portefeuilleMachineToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.portefeuilleMachineToolStripMenuItem.Text = "Portefeuille Machine";
            this.portefeuilleMachineToolStripMenuItem.Click += new System.EventHandler(this.portefeuilleMachineToolStripMenuItem_Click);
            // 
            // imgListBeverageType
            // 
            this.imgListBeverageType.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imgListBeverageType.ImageSize = new System.Drawing.Size(16, 16);
            this.imgListBeverageType.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // lstViewBeverageTypes
            // 
            this.lstViewBeverageTypes.Location = new System.Drawing.Point(12, 27);
            this.lstViewBeverageTypes.MultiSelect = false;
            this.lstViewBeverageTypes.Name = "lstViewBeverageTypes";
            this.lstViewBeverageTypes.Size = new System.Drawing.Size(300, 303);
            this.lstViewBeverageTypes.TabIndex = 17;
            this.lstViewBeverageTypes.UseCompatibleStateImageBehavior = false;
            // 
            // btnBuyBeverageFromListView
            // 
            this.btnBuyBeverageFromListView.Location = new System.Drawing.Point(318, 93);
            this.btnBuyBeverageFromListView.Name = "btnBuyBeverageFromListView";
            this.btnBuyBeverageFromListView.Size = new System.Drawing.Size(114, 22);
            this.btnBuyBeverageFromListView.TabIndex = 18;
            this.btnBuyBeverageFromListView.Text = "Acheter Boisson";
            this.btnBuyBeverageFromListView.UseVisualStyleBackColor = true;
            this.btnBuyBeverageFromListView.Click += new System.EventHandler(this.btnBuyBeverageFromListView_Click);
            // 
            // btnRefund
            // 
            this.btnRefund.Location = new System.Drawing.Point(318, 64);
            this.btnRefund.Name = "btnRefund";
            this.btnRefund.Size = new System.Drawing.Size(114, 23);
            this.btnRefund.TabIndex = 19;
            this.btnRefund.Text = "Remboursement";
            this.btnRefund.UseVisualStyleBackColor = true;
            this.btnRefund.Click += new System.EventHandler(this.btnRefund_Click);
            // 
            // btnInsertCoin
            // 
            this.btnInsertCoin.Location = new System.Drawing.Point(318, 35);
            this.btnInsertCoin.Name = "btnInsertCoin";
            this.btnInsertCoin.Size = new System.Drawing.Size(114, 23);
            this.btnInsertCoin.TabIndex = 20;
            this.btnInsertCoin.Text = "Insérer Piece(s)";
            this.btnInsertCoin.UseVisualStyleBackColor = true;
            this.btnInsertCoin.Click += new System.EventHandler(this.btnInsertCoin_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(318, 138);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 15);
            this.label1.TabIndex = 21;
            this.label1.Text = "Montant total inséré :";
            // 
            // lblInserted
            // 
            this.lblInserted.AutoSize = true;
            this.lblInserted.Location = new System.Drawing.Point(360, 153);
            this.lblInserted.Name = "lblInserted";
            this.lblInserted.Size = new System.Drawing.Size(32, 15);
            this.lblInserted.TabIndex = 22;
            this.lblInserted.Text = "label";
            // 
            // VendingMachineForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(455, 342);
            this.Controls.Add(this.lblInserted);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnInsertCoin);
            this.Controls.Add(this.btnRefund);
            this.Controls.Add(this.btnBuyBeverageFromListView);
            this.Controls.Add(this.lstViewBeverageTypes);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "VendingMachineForm";
            this.Text = "Distributeur de Boisson";
            ((System.ComponentModel.ISupportInitialize)(this.databaseContextBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.beverageTypeBindingSource)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private BindingSource databaseContextBindingSource;
        private BindingSource beverageTypeBindingSource;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem vendingMachineToolStripMenuItem;
        private ToolStripMenuItem settingsToolStripMenuItem;
        private ToolStripMenuItem userWalletToolStripMenuItem;
        private ImageList imgListBeverageType;
        private ListView lstViewBeverageTypes;
        private Button btnBuyBeverageFromListView;
        private Button btnRefund;
        private Button btnInsertCoin;
        private ToolStripMenuItem portefeuilleMachineToolStripMenuItem;
        private Label label1;
        private Label lblInserted;
    }
}