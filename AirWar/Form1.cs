using System;
using System.Windows.Forms;

namespace AirWar
{
    public partial class Form1 : Form
    {
        private int timeLeft = 60; // Tiempo en segundos

        public Form1()
        {
            InitializeComponent();
            this.Text = "AirWar";
            this.WindowState = FormWindowState.Maximized; // Pantalla completa
            this.FormBorderStyle = FormBorderStyle.FixedDialog; // No se puede cambiar el tamaño
            this.MaximizeBox = false; // Deshabilitar el botón de maximizar
            this.MinimizeBox = false; // Deshabilitar el botón de minimizar
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer.Start(); // Iniciar el timer cuando se carga el formulario
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (timeLeft > 0)
            {
                timeLeft--; // Decrementar el tiempo
                timerLabel.Text = $"Tiempo: {timeLeft}"; // Actualizar el texto del label
            }
            else
            {
                timer.Stop(); // Detener el timer
                MessageBox.Show("Tu puntuación fue de: ", "Tiempo terminado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
