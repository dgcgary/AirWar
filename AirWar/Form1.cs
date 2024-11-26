using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace AirWar
{
    public partial class Form1 : Form
    {
        private int batterySpeed = 5; // Velocidad de la bater�a
        private bool movingRight = true; // Direcci�n inicial
        private int timeLeft = 60; // Tiempo en segundos
        private List<Panel> bullets = new List<Panel>(); // Lista para almacenar las balas
        private System.Windows.Forms.Timer bulletTimer; // Timer para mover las balas
        private Stopwatch mousePressStopwatch; // Cron�metro para medir el tiempo de presi�n del rat�n
        private int bulletSpeed = 10; // Velocidad base de la bala
        private Graph graph;
        private Dictionary<Airport, Point> airportLocations;
        private Dictionary<AircraftCarrier, Point> carrierLocations;

        public Form1()
        {
            InitializeComponent();
            this.Text = "AirWar";
            this.WindowState = FormWindowState.Maximized; // Pantalla completa
            this.FormBorderStyle = FormBorderStyle.Sizable; // Permitir cambiar el tama�o
            this.MaximizeBox = true; // Habilitar el bot�n de maximizar
            this.MinimizeBox = true; // Habilitar el bot�n de minimizar

            // Inicializar el timer para las balas
            bulletTimer = new System.Windows.Forms.Timer();
            bulletTimer.Interval = 20; // Intervalo de actualizaci�n en milisegundos
            bulletTimer.Tick += BulletTimer_Tick;

            // Inicializar el cron�metro
            mousePressStopwatch = new Stopwatch();

            // Generar el grafo con aeropuertos y portaaviones
            Random random = new Random();
            int numAirports = random.Next(3, 5); // Generar aleatoriamente entre 3 y 6 aeropuertos
            int numAircraftCarriers = random.Next(3, 5); // Generar aleatoriamente entre 3 y 6 portaaviones
            graph = new Graph(numAirports, numAircraftCarriers);
            airportLocations = new Dictionary<Airport, Point>();
            carrierLocations = new Dictionary<AircraftCarrier, Point>();
            DisplayGraph();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer.Start(); // Iniciar el timer del temporizador
            movementTimer.Start(); // Iniciar el timer de movimiento
            bulletTimer.Start(); // Iniciar el timer de las balas

            // Ajustar la posici�n del batteryPanel en la parte inferior de la pantalla
            batteryPanel.Location = new System.Drawing.Point(0, this.ClientSize.Height - batteryPanel.Height);

            // Manejar los eventos de clic del rat�n
            this.MouseDown += Form1_MouseDown;
            this.MouseUp += Form1_MouseUp;
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
                MessageBox.Show("Tu puntuaci�n fue de: ", "Tiempo terminado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void MovementTimer_Tick(object sender, EventArgs e)
        {
            // Mover la bater�a
            if (movingRight)
            {
                batteryPanel.Left += batterySpeed;
                if (batteryPanel.Right >= this.ClientSize.Width)
                {
                    movingRight = false;
                }
            }
            else
            {
                batteryPanel.Left -= batterySpeed;
                if (batteryPanel.Left <= 0)
                {
                    movingRight = true;
                }
            }
        }

        private void Form1_MouseDown(object? sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                // Iniciar el cron�metro cuando se presiona el bot�n del rat�n
                mousePressStopwatch.Restart();
            }
        }

        private void Form1_MouseUp(object? sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                // Detener el cron�metro cuando se suelta el bot�n del rat�n
                mousePressStopwatch.Stop();

                // Calcular la velocidad de la bala en funci�n del tiempo de presi�n
                int pressDuration = (int)mousePressStopwatch.ElapsedMilliseconds;
                int calculatedBulletSpeed = bulletSpeed + (pressDuration / 100); // Aumentar la velocidad en funci�n del tiempo

                // Crear una nueva bala
                Panel bullet = new Panel();
                bullet.Size = new Size(20, 20);
                bullet.BackColor = Color.Red;
                bullet.Location = new Point(batteryPanel.Left + (batteryPanel.Width / 2) - 10, batteryPanel.Top - 20);
                bullet.Tag = calculatedBulletSpeed; // Almacenar la velocidad de la bala en la propiedad Tag
                bullets.Add(bullet);
                this.Controls.Add(bullet);
            }
        }

        private void BulletTimer_Tick(object sender, EventArgs e)
        {
            // Mover las balas hacia arriba
            for (int i = bullets.Count - 1; i >= 0; i--)
            {
                int speed = (int)bullets[i].Tag; // Obtener la velocidad de la bala
                bullets[i].Top -= speed;
                if (bullets[i].Bottom < 0)
                {
                    this.Controls.Remove(bullets[i]);
                    bullets.RemoveAt(i);
                }
            }
        }

        private void DisplayGraph()
        {
            Random random = new Random();
            foreach (var airport in graph.Airports)
            {
                var location = new Point(random.Next(0, this.ClientSize.Width - 20), random.Next(0, this.ClientSize.Height - 20));
                airportLocations[airport] = location; // Almacenar la ubicaci�n del aeropuerto
                var panel = new Panel
                {
                    Size = new Size(50, 50),
                    BackColor = Color.Green,
                    Location = location
                };
                this.Controls.Add(panel);
            }

            foreach (var carrier in graph.AircraftCarriers)
            {
                var location = new Point(random.Next(0, this.ClientSize.Width - 20), random.Next(0, this.ClientSize.Height - 20));
                carrierLocations[carrier] = location; // Almacenar la ubicaci�n del portaaviones
                var panel = new Panel
                {
                    Size = new Size(50, 50),
                    BackColor = Color.Blue,
                    Location = location
                };
                this.Controls.Add(panel);
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;
            Pen pen = new Pen(Color.Black, 2);
            Font font = new Font("Arial", 10);
            Brush brush = new SolidBrush(Color.Black);

            // No dibujar rutas inicialmente
        }

        private void DrawRoute(Route route)
        {
            Graphics g = this.CreateGraphics();
            Pen pen = new Pen(Color.Black, 2);
            Font font = new Font("Arial", 10);
            Brush brush = new SolidBrush(Color.Black);

            Point start;
            Point end;

            if (route.Start is Airport && airportLocations.TryGetValue((Airport)route.Start, out start))
            {
                // Obtener la ubicaci�n del aeropuerto
            }
            else if (route.Start is AircraftCarrier && carrierLocations.TryGetValue((AircraftCarrier)route.Start, out start))
            {
                // Obtener la ubicaci�n del portaaviones
            }
            else
            {
                return; // Si no se encuentra la ubicaci�n, salir del m�todo
            }

            if (route.End is Airport && airportLocations.TryGetValue((Airport)route.End, out end))
            {
                // Obtener la ubicaci�n del aeropuerto
            }
            else if (route.End is AircraftCarrier && carrierLocations.TryGetValue((AircraftCarrier)route.End, out end))
            {
                // Obtener la ubicaci�n del portaaviones
            }
            else
            {
                return; // Si no se encuentra la ubicaci�n, salir del m�todo
            }

            // Dibujar la l�nea de la ruta
            g.DrawLine(pen, start, end);
            var midPoint = new Point((start.X + end.X) / 2, (start.Y + end.Y) / 2);
            g.DrawString(route.Distance.ToString(), font, brush, midPoint);
        }



    }
}
