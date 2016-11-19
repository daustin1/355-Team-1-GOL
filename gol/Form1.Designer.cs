namespace gol
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
            this.step_Button = new System.Windows.Forms.Button();
            this.run_Button = new System.Windows.Forms.Button();
            this.clear_Button = new System.Windows.Forms.Button();
            this.stop_Button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // step_Button
            // 
            this.step_Button.Location = new System.Drawing.Point(283, 380);
            this.step_Button.Name = "step_Button";
            this.step_Button.Size = new System.Drawing.Size(75, 23);
            this.step_Button.TabIndex = 0;
            this.step_Button.Text = "Step";
            this.step_Button.UseVisualStyleBackColor = true;
            this.step_Button.Click += new System.EventHandler(this.step_Button_Click);
            // 
            // run_Button
            // 
            this.run_Button.Location = new System.Drawing.Point(364, 380);
            this.run_Button.Name = "run_Button";
            this.run_Button.Size = new System.Drawing.Size(75, 23);
            this.run_Button.TabIndex = 1;
            this.run_Button.Text = "Run";
            this.run_Button.UseVisualStyleBackColor = true;
            this.run_Button.Click += new System.EventHandler(this.run_Button_Click);
            // 
            // clear_Button
            // 
            this.clear_Button.Location = new System.Drawing.Point(445, 380);
            this.clear_Button.Name = "clear_Button";
            this.clear_Button.Size = new System.Drawing.Size(75, 23);
            this.clear_Button.TabIndex = 2;
            this.clear_Button.Text = "Clear";
            this.clear_Button.UseVisualStyleBackColor = true;
            this.clear_Button.Click += new System.EventHandler(this.clear_Button_Click);
            // 
            // stop_Button
            // 
            this.stop_Button.Location = new System.Drawing.Point(526, 380);
            this.stop_Button.Name = "stop_Button";
            this.stop_Button.Size = new System.Drawing.Size(75, 23);
            this.stop_Button.TabIndex = 3;
            this.stop_Button.Text = "Stop";
            this.stop_Button.UseVisualStyleBackColor = true;
            this.stop_Button.Click += new System.EventHandler(this.stop_Button_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(871, 415);
            this.Controls.Add(this.stop_Button);
            this.Controls.Add(this.clear_Button);
            this.Controls.Add(this.run_Button);
            this.Controls.Add(this.step_Button);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button step_Button;
        private System.Windows.Forms.Button run_Button;
        private System.Windows.Forms.Button clear_Button;
        private System.Windows.Forms.Button stop_Button;
    }
}