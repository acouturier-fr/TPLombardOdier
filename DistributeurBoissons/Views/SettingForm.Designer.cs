namespace DistributeurBoissons.Views
{
    partial class SettingForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingForm));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnEmptyBeverageStock = new System.Windows.Forms.Button();
            this.btnRndGenBoisson = new System.Windows.Forms.Button();
            this.lblTrackbarBoisson = new System.Windows.Forms.Label();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.btnAddBoisson = new System.Windows.Forms.Button();
            this.cbxBeverageType = new System.Windows.Forms.ComboBox();
            this.beverageTypeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnTenOfEach = new System.Windows.Forms.Button();
            this.btnEmptyWallet = new System.Windows.Forms.Button();
            this.btnWalletGenerate = new System.Windows.Forms.Button();
            this.btnWalletManage = new System.Windows.Forms.Button();
            this.cbxUser = new System.Windows.Forms.ComboBox();
            this.userBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btnCreateUser = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.beverageTypeBindingSource)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.userBindingSource)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnEmptyBeverageStock);
            this.groupBox1.Controls.Add(this.btnRndGenBoisson);
            this.groupBox1.Controls.Add(this.lblTrackbarBoisson);
            this.groupBox1.Controls.Add(this.trackBar1);
            this.groupBox1.Controls.Add(this.btnAddBoisson);
            this.groupBox1.Controls.Add(this.cbxBeverageType);
            this.groupBox1.Location = new System.Drawing.Point(8, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(190, 201);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Boissons";
            // 
            // btnEmptyBeverageStock
            // 
            this.btnEmptyBeverageStock.Location = new System.Drawing.Point(27, 168);
            this.btnEmptyBeverageStock.Name = "btnEmptyBeverageStock";
            this.btnEmptyBeverageStock.Size = new System.Drawing.Size(128, 23);
            this.btnEmptyBeverageStock.TabIndex = 5;
            this.btnEmptyBeverageStock.Text = "Vider Stock";
            this.btnEmptyBeverageStock.UseVisualStyleBackColor = true;
            this.btnEmptyBeverageStock.Click += new System.EventHandler(this.btnEmptyBeverageStock_Click);
            // 
            // btnRndGenBoisson
            // 
            this.btnRndGenBoisson.Location = new System.Drawing.Point(27, 139);
            this.btnRndGenBoisson.Name = "btnRndGenBoisson";
            this.btnRndGenBoisson.Size = new System.Drawing.Size(128, 23);
            this.btnRndGenBoisson.TabIndex = 4;
            this.btnRndGenBoisson.Text = "Génération Stock";
            this.btnRndGenBoisson.UseVisualStyleBackColor = true;
            this.btnRndGenBoisson.Click += new System.EventHandler(this.btnRndGenBoisson_Click);
            // 
            // lblTrackbarBoisson
            // 
            this.lblTrackbarBoisson.AutoSize = true;
            this.lblTrackbarBoisson.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblTrackbarBoisson.Location = new System.Drawing.Point(6, 59);
            this.lblTrackbarBoisson.Name = "lblTrackbarBoisson";
            this.lblTrackbarBoisson.Size = new System.Drawing.Size(54, 28);
            this.lblTrackbarBoisson.TabIndex = 3;
            this.lblTrackbarBoisson.Text = "label";
            // 
            // trackBar1
            // 
            this.trackBar1.Location = new System.Drawing.Point(44, 59);
            this.trackBar1.Maximum = 20;
            this.trackBar1.Minimum = 1;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(140, 45);
            this.trackBar1.TabIndex = 2;
            this.trackBar1.Value = 1;
            this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // btnAddBoisson
            // 
            this.btnAddBoisson.Location = new System.Drawing.Point(27, 110);
            this.btnAddBoisson.Name = "btnAddBoisson";
            this.btnAddBoisson.Size = new System.Drawing.Size(128, 23);
            this.btnAddBoisson.TabIndex = 1;
            this.btnAddBoisson.Text = "Ajouter Boissons";
            this.btnAddBoisson.UseVisualStyleBackColor = true;
            this.btnAddBoisson.Click += new System.EventHandler(this.btnAddBoisson_Click);
            // 
            // cbxBeverageType
            // 
            this.cbxBeverageType.DataSource = this.beverageTypeBindingSource;
            this.cbxBeverageType.DisplayMember = "Name";
            this.cbxBeverageType.FormattingEnabled = true;
            this.cbxBeverageType.Location = new System.Drawing.Point(6, 31);
            this.cbxBeverageType.Name = "cbxBeverageType";
            this.cbxBeverageType.Size = new System.Drawing.Size(178, 23);
            this.cbxBeverageType.TabIndex = 0;
            this.cbxBeverageType.ValueMember = "IdBeverageType";
            // 
            // beverageTypeBindingSource
            // 
            this.beverageTypeBindingSource.DataSource = typeof(DistributeurBoissons.Model.BeverageType);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnTenOfEach);
            this.groupBox2.Controls.Add(this.btnEmptyWallet);
            this.groupBox2.Controls.Add(this.btnWalletGenerate);
            this.groupBox2.Controls.Add(this.btnWalletManage);
            this.groupBox2.Controls.Add(this.cbxUser);
            this.groupBox2.Location = new System.Drawing.Point(204, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(190, 201);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Portefeuilles";
            // 
            // btnTenOfEach
            // 
            this.btnTenOfEach.Location = new System.Drawing.Point(27, 139);
            this.btnTenOfEach.Name = "btnTenOfEach";
            this.btnTenOfEach.Size = new System.Drawing.Size(128, 23);
            this.btnTenOfEach.TabIndex = 7;
            this.btnTenOfEach.Text = "10 pièces de chaque";
            this.btnTenOfEach.UseVisualStyleBackColor = true;
            this.btnTenOfEach.Click += new System.EventHandler(this.btnTenOfEach_Click);
            // 
            // btnEmptyWallet
            // 
            this.btnEmptyWallet.Location = new System.Drawing.Point(27, 168);
            this.btnEmptyWallet.Name = "btnEmptyWallet";
            this.btnEmptyWallet.Size = new System.Drawing.Size(128, 23);
            this.btnEmptyWallet.TabIndex = 6;
            this.btnEmptyWallet.Text = "Banqueroute";
            this.btnEmptyWallet.UseVisualStyleBackColor = true;
            this.btnEmptyWallet.Click += new System.EventHandler(this.btnEmptyWallet_Click);
            // 
            // btnWalletGenerate
            // 
            this.btnWalletGenerate.Location = new System.Drawing.Point(27, 110);
            this.btnWalletGenerate.Name = "btnWalletGenerate";
            this.btnWalletGenerate.Size = new System.Drawing.Size(128, 23);
            this.btnWalletGenerate.TabIndex = 2;
            this.btnWalletGenerate.Text = "Generation Aléatoire";
            this.btnWalletGenerate.UseVisualStyleBackColor = true;
            this.btnWalletGenerate.Click += new System.EventHandler(this.btnWalletGenerate_Click);
            // 
            // btnWalletManage
            // 
            this.btnWalletManage.Location = new System.Drawing.Point(27, 81);
            this.btnWalletManage.Name = "btnWalletManage";
            this.btnWalletManage.Size = new System.Drawing.Size(128, 23);
            this.btnWalletManage.TabIndex = 1;
            this.btnWalletManage.Text = "Gérer Manuellement";
            this.btnWalletManage.UseVisualStyleBackColor = true;
            this.btnWalletManage.Click += new System.EventHandler(this.btnWalletManage_Click);
            // 
            // cbxUser
            // 
            this.cbxUser.DataSource = this.userBindingSource;
            this.cbxUser.DisplayMember = "Name";
            this.cbxUser.FormattingEnabled = true;
            this.cbxUser.Location = new System.Drawing.Point(6, 31);
            this.cbxUser.Name = "cbxUser";
            this.cbxUser.Size = new System.Drawing.Size(178, 23);
            this.cbxUser.TabIndex = 0;
            this.cbxUser.ValueMember = "IdUser";
            this.cbxUser.SelectedIndexChanged += new System.EventHandler(this.cbxUser_SelectedIndexChanged);
            // 
            // userBindingSource
            // 
            this.userBindingSource.DataSource = typeof(DistributeurBoissons.Model.User);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.textBox1);
            this.groupBox3.Controls.Add(this.btnCreateUser);
            this.groupBox3.Location = new System.Drawing.Point(400, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(190, 201);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Utilisateurs";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(6, 31);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(178, 23);
            this.textBox1.TabIndex = 3;
            // 
            // btnCreateUser
            // 
            this.btnCreateUser.Location = new System.Drawing.Point(29, 110);
            this.btnCreateUser.Name = "btnCreateUser";
            this.btnCreateUser.Size = new System.Drawing.Size(128, 23);
            this.btnCreateUser.TabIndex = 1;
            this.btnCreateUser.Text = "Créer Utilisateur";
            this.btnCreateUser.UseVisualStyleBackColor = true;
            this.btnCreateUser.Click += new System.EventHandler(this.btnCreateUser_Click);
            // 
            // SettingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(603, 225);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SettingForm";
            this.Text = "Paramètres";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.beverageTypeBindingSource)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.userBindingSource)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private GroupBox groupBox1;
        private Label lblTrackbarBoisson;
        private TrackBar trackBar1;
        private Button btnAddBoisson;
        private ComboBox cbxBeverageType;
        private Button btnRndGenBoisson;
        private GroupBox groupBox2;
        private Button btnWalletGenerate;
        private Button btnWalletManage;
        private ComboBox cbxUser;
        private GroupBox groupBox3;
        private TextBox textBox1;
        private Button btnCreateUser;
        private BindingSource beverageTypeBindingSource;
        private Button btnEmptyBeverageStock;
        private Button btnTenOfEach;
        private Button btnEmptyWallet;
        private BindingSource userBindingSource;
    }
}