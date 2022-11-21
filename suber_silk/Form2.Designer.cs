namespace suber_silk
{
    partial class Form2
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
            this.adminId = new System.Windows.Forms.Label();
            this.adminRole = new System.Windows.Forms.Label();
            this.adminName = new System.Windows.Forms.Label();
            this.adminUsername = new System.Windows.Forms.Label();
            this.adminPassword = new System.Windows.Forms.Label();
            this.panelMenu = new Guna.UI2.WinForms.Guna2GradientPanel();
            this.SuspendLayout();
            // 
            // adminId
            // 
            this.adminId.AutoSize = true;
            this.adminId.Location = new System.Drawing.Point(401, 108);
            this.adminId.Name = "adminId";
            this.adminId.Size = new System.Drawing.Size(35, 13);
            this.adminId.TabIndex = 0;
            this.adminId.Text = "label1";
            // 
            // adminRole
            // 
            this.adminRole.AutoSize = true;
            this.adminRole.Location = new System.Drawing.Point(401, 152);
            this.adminRole.Name = "adminRole";
            this.adminRole.Size = new System.Drawing.Size(35, 13);
            this.adminRole.TabIndex = 1;
            this.adminRole.Text = "label2";
            // 
            // adminName
            // 
            this.adminName.AutoSize = true;
            this.adminName.Location = new System.Drawing.Point(401, 194);
            this.adminName.Name = "adminName";
            this.adminName.Size = new System.Drawing.Size(35, 13);
            this.adminName.TabIndex = 2;
            this.adminName.Text = "label3";
            // 
            // adminUsername
            // 
            this.adminUsername.AutoSize = true;
            this.adminUsername.Location = new System.Drawing.Point(401, 236);
            this.adminUsername.Name = "adminUsername";
            this.adminUsername.Size = new System.Drawing.Size(35, 13);
            this.adminUsername.TabIndex = 3;
            this.adminUsername.Text = "label4";
            // 
            // adminPassword
            // 
            this.adminPassword.AutoSize = true;
            this.adminPassword.Location = new System.Drawing.Point(401, 285);
            this.adminPassword.Name = "adminPassword";
            this.adminPassword.Size = new System.Drawing.Size(35, 13);
            this.adminPassword.TabIndex = 4;
            this.adminPassword.Text = "label5";
            // 
            // panelMenu
            // 
            this.panelMenu.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelMenu.BackColor = System.Drawing.Color.Transparent;
            this.panelMenu.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(135)))), ((int)(((byte)(209)))));
            this.panelMenu.BorderRadius = 12;
            this.panelMenu.FillColor = System.Drawing.Color.White;
            this.panelMenu.FillColor2 = System.Drawing.Color.White;
            this.panelMenu.Location = new System.Drawing.Point(129, 23);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Padding = new System.Windows.Forms.Padding(10);
            this.panelMenu.ShadowDecoration.Parent = this.panelMenu;
            this.panelMenu.Size = new System.Drawing.Size(159, 32);
            this.panelMenu.TabIndex = 5;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 599);
            this.Controls.Add(this.panelMenu);
            this.Controls.Add(this.adminPassword);
            this.Controls.Add(this.adminUsername);
            this.Controls.Add(this.adminName);
            this.Controls.Add(this.adminRole);
            this.Controls.Add(this.adminId);
            this.Name = "Form2";
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label adminId;
        private System.Windows.Forms.Label adminRole;
        private System.Windows.Forms.Label adminName;
        private System.Windows.Forms.Label adminUsername;
        private System.Windows.Forms.Label adminPassword;
        private Guna.UI2.WinForms.Guna2GradientPanel panelMenu;
    }
}