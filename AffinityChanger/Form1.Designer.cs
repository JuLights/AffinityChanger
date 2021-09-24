
namespace AffinityChanger
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
            this.csgoLabel = new System.Windows.Forms.Label();
            this.faceitLabel = new System.Windows.Forms.Label();
            this.csgoCheck = new System.Windows.Forms.CheckBox();
            this.faceitCheck = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // csgoLabel
            // 
            this.csgoLabel.AutoSize = true;
            this.csgoLabel.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.csgoLabel.ForeColor = System.Drawing.Color.White;
            this.csgoLabel.Location = new System.Drawing.Point(74, 59);
            this.csgoLabel.Name = "csgoLabel";
            this.csgoLabel.Size = new System.Drawing.Size(64, 32);
            this.csgoLabel.TabIndex = 0;
            this.csgoLabel.Text = "csgo";
            // 
            // faceitLabel
            // 
            this.faceitLabel.AutoSize = true;
            this.faceitLabel.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.faceitLabel.ForeColor = System.Drawing.Color.White;
            this.faceitLabel.Location = new System.Drawing.Point(75, 100);
            this.faceitLabel.Name = "faceitLabel";
            this.faceitLabel.Size = new System.Drawing.Size(73, 32);
            this.faceitLabel.TabIndex = 1;
            this.faceitLabel.Text = "faceit";
            // 
            // csgoCheck
            // 
            this.csgoCheck.AutoSize = true;
            this.csgoCheck.ForeColor = System.Drawing.Color.White;
            this.csgoCheck.Location = new System.Drawing.Point(160, 73);
            this.csgoCheck.Name = "csgoCheck";
            this.csgoCheck.Size = new System.Drawing.Size(112, 17);
            this.csgoCheck.TabIndex = 2;
            this.csgoCheck.Text = "deactivate core 0";
            this.csgoCheck.UseVisualStyleBackColor = true;
            this.csgoCheck.CheckedChanged += new System.EventHandler(this.csgoCheck_CheckedChanged);
            // 
            // faceitCheck
            // 
            this.faceitCheck.AutoSize = true;
            this.faceitCheck.ForeColor = System.Drawing.Color.White;
            this.faceitCheck.Location = new System.Drawing.Point(160, 114);
            this.faceitCheck.Name = "faceitCheck";
            this.faceitCheck.Size = new System.Drawing.Size(95, 17);
            this.faceitCheck.TabIndex = 3;
            this.faceitCheck.Text = "run on core 0";
            this.faceitCheck.UseVisualStyleBackColor = true;
            this.faceitCheck.CheckedChanged += new System.EventHandler(this.faceitCheck_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(113, 154);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 13);
            this.label1.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(197, 154);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 13);
            this.label2.TabIndex = 5;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(393, 205);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.faceitCheck);
            this.Controls.Add(this.csgoCheck);
            this.Controls.Add(this.faceitLabel);
            this.Controls.Add(this.csgoLabel);
            this.Font = new System.Drawing.Font("Nirmala UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Opacity = 0.9D;
            this.ShowIcon = false;
            this.Text = "AffinityController";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label csgoLabel;
        private System.Windows.Forms.Label faceitLabel;
        private System.Windows.Forms.CheckBox csgoCheck;
        private System.Windows.Forms.CheckBox faceitCheck;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}

