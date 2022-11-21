namespace suber_silk
{
    partial class profile
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

        #region Component Designer generated code

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
            this.SuspendLayout();
            // 
            // adminId
            // 
            this.adminId.AutoSize = true;
            this.adminId.Location = new System.Drawing.Point(143, 109);
            this.adminId.Name = "adminId";
            this.adminId.Size = new System.Drawing.Size(19, 17);
            this.adminId.TabIndex = 0;
            this.adminId.Text = "Id";
            this.adminId.Click += new System.EventHandler(this.AdminId_Click);
            // 
            // adminRole
            // 
            this.adminRole.AutoSize = true;
            this.adminRole.Location = new System.Drawing.Point(143, 151);
            this.adminRole.Name = "adminRole";
            this.adminRole.Size = new System.Drawing.Size(34, 17);
            this.adminRole.TabIndex = 1;
            this.adminRole.Text = "Role";
            // 
            // adminName
            // 
            this.adminName.AutoSize = true;
            this.adminName.Location = new System.Drawing.Point(143, 191);
            this.adminName.Name = "adminName";
            this.adminName.Size = new System.Drawing.Size(43, 17);
            this.adminName.TabIndex = 2;
            this.adminName.Text = "Name";
            // 
            // adminUsername
            // 
            this.adminUsername.AutoSize = true;
            this.adminUsername.Location = new System.Drawing.Point(143, 235);
            this.adminUsername.Name = "adminUsername";
            this.adminUsername.Size = new System.Drawing.Size(67, 17);
            this.adminUsername.TabIndex = 3;
            this.adminUsername.Text = "Username";
            // 
            // adminPassword
            // 
            this.adminPassword.AutoSize = true;
            this.adminPassword.Location = new System.Drawing.Point(143, 278);
            this.adminPassword.Name = "adminPassword";
            this.adminPassword.Size = new System.Drawing.Size(64, 17);
            this.adminPassword.TabIndex = 4;
            this.adminPassword.Text = "Password";
            // 
            // profile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.adminPassword);
            this.Controls.Add(this.adminUsername);
            this.Controls.Add(this.adminName);
            this.Controls.Add(this.adminRole);
            this.Controls.Add(this.adminId);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "profile";
            this.Size = new System.Drawing.Size(835, 554);
            this.Load += new System.EventHandler(this.Profile_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label adminId;
        private System.Windows.Forms.Label adminRole;
        private System.Windows.Forms.Label adminName;
        private System.Windows.Forms.Label adminUsername;
        private System.Windows.Forms.Label adminPassword;
    }
}
