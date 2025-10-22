// ## 🧠 Código principal del juego — `Form1.cs`
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Timer = System.Windows.Forms.Timer;

namespace MemoryGame_Supabase
{
    public partial class Form1 : Form
    {
        List<string> icons = new List<string>()
        {
            "🐶","🐱","🐭","🐹",
            "🐰","🦊","🐻","🐼",
            "🐶","🐱","🐭","🐹",
            "🐰","🦊","🐻","🐼"
        };

        Random random = new Random();
        Button firstClicked = null;
        Button secondClicked = null;
        int intentos = 0;
        DateTime startTime;
        System.Windows.Forms.Timer gameTimer = new System.Windows.Forms.Timer();
        public Form1()
        {
            InitializeComponent();
            AsignarCartas();
            gameTimer.Interval = 1000; // 1 segundo
            gameTimer.Tick += GameTimer_Tick;
            startTime = DateTime.Now;
            gameTimer.Start();
        }

        private void AsignarCartas()
        {
            foreach (Button boton in Controls.OfType<Button>().Where(b => b.Name.StartsWith("btnCard")))
            {
                int index = random.Next(icons.Count);
                boton.Tag = icons[index];
                boton.Text = "?";
                boton.Click += Card_Click;
                icons.RemoveAt(index);
            }
        }

        private void Card_Click(object sender, EventArgs e)
        {
            Button clicked = sender as Button;
            if (clicked == null || clicked == firstClicked) return;

            clicked.Text = clicked.Tag.ToString();

            if (firstClicked == null)
            {
                firstClicked = clicked;
                return;
            }

            secondClicked = clicked;
            intentos++;
            lblIntentos.Text = $"Intentos: {intentos}";

            if (firstClicked.Tag.ToString() == secondClicked.Tag.ToString())
            {
                firstClicked.Enabled = false;
                secondClicked.Enabled = false;
                firstClicked = null;
                secondClicked = null;
                VerificarGanador();
            }
            else
            {
                Timer t = new Timer { Interval = 800 };
                t.Tick += (s, ev) =>
                {
                    t.Stop();
                    firstClicked.Text = "?";
                    secondClicked.Text = "?";
                    firstClicked = null;
                    secondClicked = null;
                };
                t.Start();
            }
        }

        private void VerificarGanador()
        {
            bool todosEncontrados = Controls.OfType<Button>()
                .Where(b => b.Name.StartsWith("btnCard"))
                .All(b => !b.Enabled);

            if (todosEncontrados)
            {
                gameTimer.Stop();
                MessageBox.Show("¡Has completado el juego!");
            }
        }

        private void GameTimer_Tick(object sender, EventArgs e)
        {
            TimeSpan tiempo = DateTime.Now - startTime;
            lblTiempo.Text = $"Tiempo: {tiempo.Minutes:D2}:{tiempo.Seconds:D2}";
        }

        private async void btnGuardarPuntaje_Click(object sender, EventArgs e)
        {
            string jugador = txtJugador.Text;
            string tiempo = lblTiempo.Text.Replace("Tiempo: ", "");
            var supabase = new SupabaseService();
            await supabase.GuardarResultado(jugador, intentos, tiempo);
            MessageBox.Show("Puntaje guardado en Supabase ✅");
        }

        private void btnVerResultados_Click(object sender, EventArgs e)
        {
            // 🔹 Abre la ventana con los resultados desde Supabase
            FormResultados formResultados = new FormResultados();
            formResultados.ShowDialog();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
