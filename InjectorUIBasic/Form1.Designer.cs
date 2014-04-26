namespace TestScreenshot
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
        	this.btnInject = new System.Windows.Forms.Button();
        	this.textBox1 = new System.Windows.Forms.TextBox();
        	this.label6 = new System.Windows.Forms.Label();
        	this.SuspendLayout();
        	// 
        	// btnInject
        	// 
        	this.btnInject.Location = new System.Drawing.Point(287, 23);
        	this.btnInject.Name = "btnInject";
        	this.btnInject.Size = new System.Drawing.Size(74, 23);
        	this.btnInject.TabIndex = 0;
        	this.btnInject.Text = "Inject";
        	this.btnInject.UseVisualStyleBackColor = true;
        	this.btnInject.Click += new System.EventHandler(this.btnInject_Click);
        	// 
        	// textBox1
        	// 
        	this.textBox1.Location = new System.Drawing.Point(12, 26);
        	this.textBox1.Name = "textBox1";
        	this.textBox1.Size = new System.Drawing.Size(269, 20);
        	this.textBox1.TabIndex = 6;
        	// 
        	// label6
        	// 
        	this.label6.AutoSize = true;
        	this.label6.Location = new System.Drawing.Point(12, 10);
        	this.label6.Name = "label6";
        	this.label6.Size = new System.Drawing.Size(174, 13);
        	this.label6.TabIndex = 17;
        	this.label6.Text = "EXE Name of Direct3D Application:";
        	// 
        	// Form1
        	// 
        	this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        	this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        	this.ClientSize = new System.Drawing.Size(369, 56);
        	this.Controls.Add(this.label6);
        	this.Controls.Add(this.textBox1);
        	this.Controls.Add(this.btnInject);
        	this.Name = "Form1";
        	this.Text = "Direct3D9 3DEnforcer Injector System Thing";
        	this.ResumeLayout(false);
        	this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Button btnInject;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label6;
    }
}

