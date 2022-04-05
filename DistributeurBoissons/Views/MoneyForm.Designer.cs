namespace DistributeurBoissons.Views
{
    partial class MoneyForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MoneyForm));
            this.lstViewMoney = new System.Windows.Forms.ListView();
            this.btnValidateMoney = new System.Windows.Forms.Button();
            this.imgListMoney = new System.Windows.Forms.ImageList(this.components);
            this.lstViewMoneyToInsert = new System.Windows.Forms.ListView();
            this.btnTakeFromWallet = new System.Windows.Forms.Button();
            this.btnPutBackInWallet = new System.Windows.Forms.Button();
            this.lblModeExchance = new System.Windows.Forms.Label();
            this.lblExchangeMode2 = new System.Windows.Forms.Label();
            this.lblSettingMode = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lstViewMoney
            // 
            this.lstViewMoney.Location = new System.Drawing.Point(12, 25);
            this.lstViewMoney.MultiSelect = false;
            this.lstViewMoney.Name = "lstViewMoney";
            this.lstViewMoney.Size = new System.Drawing.Size(324, 232);
            this.lstViewMoney.TabIndex = 0;
            this.lstViewMoney.UseCompatibleStateImageBehavior = false;
            this.lstViewMoney.SelectedIndexChanged += new System.EventHandler(this.lstViewMoney_SelectedIndexChanged);
            // 
            // btnValidateMoney
            // 
            this.btnValidateMoney.Location = new System.Drawing.Point(315, 263);
            this.btnValidateMoney.Name = "btnValidateMoney";
            this.btnValidateMoney.Size = new System.Drawing.Size(75, 23);
            this.btnValidateMoney.TabIndex = 1;
            this.btnValidateMoney.Text = "Valider";
            this.btnValidateMoney.UseVisualStyleBackColor = true;
            this.btnValidateMoney.Click += new System.EventHandler(this.btnValidateMoney_Click);
            // 
            // imgListMoney
            // 
            this.imgListMoney.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imgListMoney.ImageSize = new System.Drawing.Size(16, 16);
            this.imgListMoney.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // lstViewMoneyToInsert
            // 
            this.lstViewMoneyToInsert.Location = new System.Drawing.Point(377, 25);
            this.lstViewMoneyToInsert.MultiSelect = false;
            this.lstViewMoneyToInsert.Name = "lstViewMoneyToInsert";
            this.lstViewMoneyToInsert.Size = new System.Drawing.Size(324, 232);
            this.lstViewMoneyToInsert.TabIndex = 2;
            this.lstViewMoneyToInsert.UseCompatibleStateImageBehavior = false;
            this.lstViewMoneyToInsert.SelectedIndexChanged += new System.EventHandler(this.lstViewMoneyToInsert_SelectedIndexChanged);
            // 
            // btnTakeFromWallet
            // 
            this.btnTakeFromWallet.Enabled = false;
            this.btnTakeFromWallet.Location = new System.Drawing.Point(342, 100);
            this.btnTakeFromWallet.Name = "btnTakeFromWallet";
            this.btnTakeFromWallet.Size = new System.Drawing.Size(29, 23);
            this.btnTakeFromWallet.TabIndex = 3;
            this.btnTakeFromWallet.Text = ">";
            this.btnTakeFromWallet.UseVisualStyleBackColor = true;
            this.btnTakeFromWallet.Click += new System.EventHandler(this.btnTakeFromWallet_Click);
            // 
            // btnPutBackInWallet
            // 
            this.btnPutBackInWallet.Enabled = false;
            this.btnPutBackInWallet.Location = new System.Drawing.Point(342, 138);
            this.btnPutBackInWallet.Name = "btnPutBackInWallet";
            this.btnPutBackInWallet.Size = new System.Drawing.Size(29, 23);
            this.btnPutBackInWallet.TabIndex = 4;
            this.btnPutBackInWallet.Text = "<";
            this.btnPutBackInWallet.UseVisualStyleBackColor = true;
            this.btnPutBackInWallet.Click += new System.EventHandler(this.btnPutBackInWallet_Click);
            // 
            // lblModeExchance
            // 
            this.lblModeExchance.AutoSize = true;
            this.lblModeExchance.Location = new System.Drawing.Point(12, 7);
            this.lblModeExchance.Name = "lblModeExchance";
            this.lblModeExchance.Size = new System.Drawing.Size(117, 15);
            this.lblModeExchance.TabIndex = 5;
            this.lblModeExchance.Text = "Votre Porte-Monnaie";
            // 
            // lblExchangeMode2
            // 
            this.lblExchangeMode2.AutoSize = true;
            this.lblExchangeMode2.Location = new System.Drawing.Point(546, 7);
            this.lblExchangeMode2.Name = "lblExchangeMode2";
            this.lblExchangeMode2.Size = new System.Drawing.Size(155, 15);
            this.lblExchangeMode2.TabIndex = 6;
            this.lblExchangeMode2.Text = "Pièces qui vont être insérées";
            // 
            // lblSettingMode
            // 
            this.lblSettingMode.AutoSize = true;
            this.lblSettingMode.Location = new System.Drawing.Point(377, 7);
            this.lblSettingMode.Name = "lblSettingMode";
            this.lblSettingMode.Size = new System.Drawing.Size(117, 15);
            this.lblSettingMode.TabIndex = 7;
            this.lblSettingMode.Text = "Votre Porte-Monnaie";
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(315, 292);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 8;
            this.btnClose.Text = "Fermer";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // MoneyForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(712, 319);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lblSettingMode);
            this.Controls.Add(this.lblExchangeMode2);
            this.Controls.Add(this.lblModeExchance);
            this.Controls.Add(this.btnPutBackInWallet);
            this.Controls.Add(this.btnTakeFromWallet);
            this.Controls.Add(this.lstViewMoneyToInsert);
            this.Controls.Add(this.btnValidateMoney);
            this.Controls.Add(this.lstViewMoney);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MoneyForm";
            this.Text = "Portefeuille";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ListView lstViewMoney;
        private Button btnValidateMoney;
        private ImageList imgListMoney;
        private ListView lstViewMoneyToInsert;
        private Button btnTakeFromWallet;
        private Button btnPutBackInWallet;
        private Label lblModeExchance;
        private Label lblExchangeMode2;
        private Label lblSettingMode;
        private Button btnClose;
    }
}