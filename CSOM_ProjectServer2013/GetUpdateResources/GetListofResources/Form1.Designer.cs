namespace UpdateResourceName
{
    partial class Form1
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtPWAURL = new System.Windows.Forms.TextBox();
            this.txtFieldName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtResource = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtFieldVaue = new System.Windows.Forms.TextBox();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.lblError = new System.Windows.Forms.Label();
            this.chkLookupField = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(0, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "PWA URL";
            // 
            // txtPWAURL
            // 
            this.txtPWAURL.Location = new System.Drawing.Point(79, 6);
            this.txtPWAURL.Name = "txtPWAURL";
            this.txtPWAURL.Size = new System.Drawing.Size(225, 20);
            this.txtPWAURL.TabIndex = 1;
            this.txtPWAURL.Text = "https://radev.support.cps.co.uk/PWA/";
            // 
            // txtFieldName
            // 
            this.txtFieldName.Location = new System.Drawing.Point(90, 65);
            this.txtFieldName.Name = "txtFieldName";
            this.txtFieldName.Size = new System.Drawing.Size(214, 20);
            this.txtFieldName.TabIndex = 2;
            this.txtFieldName.Text = "Cost Centre";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(0, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Resource Name";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(0, 65);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Field To Update";
            // 
            // txtResource
            // 
            this.txtResource.Location = new System.Drawing.Point(90, 35);
            this.txtResource.Name = "txtResource";
            this.txtResource.Size = new System.Drawing.Size(214, 20);
            this.txtResource.TabIndex = 5;
            this.txtResource.Text = "Reshmee Auckloo";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 92);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Field Value";
            // 
            // txtFieldVaue
            // 
            this.txtFieldVaue.Location = new System.Drawing.Point(90, 92);
            this.txtFieldVaue.Name = "txtFieldVaue";
            this.txtFieldVaue.Size = new System.Drawing.Size(214, 20);
            this.txtFieldVaue.TabIndex = 7;
            this.txtFieldVaue.Text = "TM-22";
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(314, 152);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(75, 23);
            this.btnUpdate.TabIndex = 8;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // lblError
            // 
            this.lblError.AutoSize = true;
            this.lblError.Location = new System.Drawing.Point(0, 131);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(0, 13);
            this.lblError.TabIndex = 9;
            // 
            // chkLookupField
            // 
            this.chkLookupField.AutoSize = true;
            this.chkLookupField.Checked = true;
            this.chkLookupField.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkLookupField.Location = new System.Drawing.Point(13, 139);
            this.chkLookupField.Name = "chkLookupField";
            this.chkLookupField.Size = new System.Drawing.Size(113, 21);
            this.chkLookupField.TabIndex = 10;
            this.chkLookupField.Text = "Is LookUp Field?";
            this.chkLookupField.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(609, 244);
            this.Controls.Add(this.chkLookupField);
            this.Controls.Add(this.lblError);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.txtFieldVaue);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtResource);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtFieldName);
            this.Controls.Add(this.txtPWAURL);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "UpdateResourceName";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPWAURL;
        private System.Windows.Forms.TextBox txtFieldName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtResource;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtFieldVaue;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Label lblError;
        private System.Windows.Forms.CheckBox chkLookupField;
    }
}

