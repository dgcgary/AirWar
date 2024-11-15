namespace AirWar
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            this.Text = "AirWar";
            InitializeComponent();
            this.Text = "AirWar";
            this.WindowState = FormWindowState.Maximized; // Pantalla completa
            this.FormBorderStyle = FormBorderStyle.FixedDialog; // No se puede cambiar el tamaño
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
