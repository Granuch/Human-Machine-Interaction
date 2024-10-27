namespace ESP8266ControlApp
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.btnLed1On = new System.Windows.Forms.Button();
            this.btnLed1Off = new System.Windows.Forms.Button();
            this.btnLed2On = new System.Windows.Forms.Button();
            this.btnLed2Off = new System.Windows.Forms.Button();
            this.btnCheckButtonState = new System.Windows.Forms.Button();
            this.lblButtonState = new System.Windows.Forms.Label();
            this.SuspendLayout();

            // 
            // btnLed1On
            // 
            this.btnLed1On.Location = new System.Drawing.Point(12, 12);
            this.btnLed1On.Name = "btnLed1On";
            this.btnLed1On.Size = new System.Drawing.Size(100, 30);
            this.btnLed1On.TabIndex = 0;
            this.btnLed1On.Text = "LED 1 ON";
            this.btnLed1On.UseVisualStyleBackColor = true;
            this.btnLed1On.Click += new System.EventHandler(this.btnLed1On_Click);

            // 
            // btnLed1Off
            // 
            this.btnLed1Off.Location = new System.Drawing.Point(12, 48);
            this.btnLed1Off.Name = "btnLed1Off";
            this.btnLed1Off.Size = new System.Drawing.Size(100, 30);
            this.btnLed1Off.TabIndex = 1;
            this.btnLed1Off.Text = "LED 1 OFF";
            this.btnLed1Off.UseVisualStyleBackColor = true;
            this.btnLed1Off.Click += new System.EventHandler(this.btnLed1Off_Click);

            // 
            // btnLed2On
            // 
            this.btnLed2On.Location = new System.Drawing.Point(12, 84);
            this.btnLed2On.Name = "btnLed2On";
            this.btnLed2On.Size = new System.Drawing.Size(100, 30);
            this.btnLed2On.TabIndex = 2;
            this.btnLed2On.Text = "LED 2 ON";
            this.btnLed2On.UseVisualStyleBackColor = true;
            this.btnLed2On.Click += new System.EventHandler(this.btnLed2On_Click);

            // 
            // btnLed2Off
            // 
            this.btnLed2Off.Location = new System.Drawing.Point(12, 120);
            this.btnLed2Off.Name = "btnLed2Off";
            this.btnLed2Off.Size = new System.Drawing.Size(100, 30);
            this.btnLed2Off.TabIndex = 3;
            this.btnLed2Off.Text = "LED 2 OFF";
            this.btnLed2Off.UseVisualStyleBackColor = true;
            this.btnLed2Off.Click += new System.EventHandler(this.btnLed2Off_Click);

            // 
            // btnCheckButtonState
            // 
            this.btnCheckButtonState.Location = new System.Drawing.Point(12, 156);
            this.btnCheckButtonState.Name = "btnCheckButtonState";
            this.btnCheckButtonState.Size = new System.Drawing.Size(150, 30);
            this.btnCheckButtonState.TabIndex = 4;
            this.btnCheckButtonState.Text = "Check Button State";
            this.btnCheckButtonState.UseVisualStyleBackColor = true;
            this.btnCheckButtonState.Click += new System.EventHandler(this.btnCheckButtonState_Click);

            // 
            // lblButtonState
            // 
            this.lblButtonState.AutoSize = true;
            this.lblButtonState.Location = new System.Drawing.Point(12, 200);
            this.lblButtonState.Name = "lblButtonState";
            this.lblButtonState.Size = new System.Drawing.Size(92, 17);
            this.lblButtonState.TabIndex = 5;
            this.lblButtonState.Text = "Button state: ";

            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.lblButtonState);
            this.Controls.Add(this.btnCheckButtonState);
            this.Controls.Add(this.btnLed2Off);
            this.Controls.Add(this.btnLed2On);
            this.Controls.Add(this.btnLed1Off);
            this.Controls.Add(this.btnLed1On);
            this.Name = "Form1";
            this.Text = "ESP8266 Control";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Button btnLed1On;
        private System.Windows.Forms.Button btnLed1Off;
        private System.Windows.Forms.Button btnLed2On;
        private System.Windows.Forms.Button btnLed2Off;
        private System.Windows.Forms.Button btnCheckButtonState;
        private System.Windows.Forms.Label lblButtonState;
    }
}
