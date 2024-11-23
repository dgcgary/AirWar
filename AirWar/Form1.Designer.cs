namespace AirWar
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.Label timerLabel;
        private System.Windows.Forms.Timer movementTimer;
        private System.Windows.Forms.Panel batteryPanel;

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
            this.movementTimer = new System.Windows.Forms.Timer(this.components);
            this.batteryPanel = new System.Windows.Forms.Panel();
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
            // movementTimer
            // 
            this.movementTimer.Interval = 20; // Intervalo de actualización en milisegundos
            this.movementTimer.Tick += new System.EventHandler(this.MovementTimer_Tick);
            // 
            // batteryPanel
            // 
            this.batteryPanel.BackColor = System.Drawing.Color.Black;
            this.batteryPanel.Size = new System.Drawing.Size(50, 50);
            this.batteryPanel.Location = new System.Drawing.Point(0, this.ClientSize.Height - 50); // Posición inicial en la parte inferior
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1920, 1080);
            Controls.Add(this.timerLabel);
            Controls.Add(this.batteryPanel);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
