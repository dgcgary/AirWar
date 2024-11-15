namespace AirWar
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.Label timerLabel;

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
            this.components = new System.ComponentModel.Container();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.timerLabel = new System.Windows.Forms.Label();
            SuspendLayout();
            // 
            // timer
            // 
            this.timer.Interval = 1000; // 1 segundo en milisegundos
            this.timer.Tick += new System.EventHandler(this.Timer_Tick);
            // 
            // timerLabel
            // 
            this.timerLabel.AutoSize = true;
            this.timerLabel.Font = new Font("Arial", 24F, FontStyle.Bold, GraphicsUnit.Point);
            this.timerLabel.Location = new Point(10, 10);
            this.timerLabel.Name = "timerLabel";
            this.timerLabel.Size = new Size(200, 37);
            this.timerLabel.TabIndex = 0;
            this.timerLabel.Text = "Tiempo: 60";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(this.timerLabel);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
