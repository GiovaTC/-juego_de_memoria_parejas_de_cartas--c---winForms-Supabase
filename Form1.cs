using System;
using System.Collections.Generic;
using System.Drawing;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Windows.Forms;

namespace MemoryGame_Supabase
{
    public partial class Form1 : Form
    {
        private List<string> cartas = new List<string>() { "A", "B", "C", "D", "E", "F", "G", "H",
                                                          "A", "B", "C", "D", "E", "F", "G", "H" };
        private List<Label> seleccionadas = new List<Label>();
        private int intentos = 0;
        private int segundos = 0;

        private const string SUPABASE_URL = "https://wohhwcvrvwogmfnqrxwy.supabase.co";
        private const string SUPABASE_KEY = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpc3MiOiJzdXBhYmFzZSIsInJlZiI6IndvaGh3Y3ZydndvZ21mbnFyeHd5Iiwicm9sZSI6ImFub24iLCJpYXQiOjE3NjA5NzQzMDcsImV4cCI6MjA3NjU1MDMwN30.d-X1cA3PXaqAS5VnPWsTOLZEO16ajBIsrN_aggr9nQs";

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            IniciarJuego();
        }

        private void IniciarJuego()
        {
            var rand = new Random();
            var temp = new List<string>(cartas);
            tablaCartas.Controls.Clear();
            intentos = 0;
            segundos = 0;
            lblIntentos.Text = "Intentos: 0";
            lblTiempo.Text = "Tiempo: 00:00";
            timer1.Start();

            for (int i = 0; i < 16; i++)
            {
                int index = rand.Next(temp.Count);
                string letra = temp[index];
                temp.RemoveAt(index);

                Label lbl = new Label
                {
                    Text = "?",
                    Dock = DockStyle.Fill,
                    Font = new Font("Segoe UI", 18, FontStyle.Bold),
                    TextAlign = ContentAlignment.MiddleCenter,
                    BackColor = Color.LightGray,
                    Tag = letra
                };

                lbl.Click += Carta_Click;
                tablaCartas.Controls.Add(lbl);
            }
        }

        private async void btnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtJugador.Text))
            {
                MessageBox.Show("Ingrese el nombre del jugador antes de guardar.");
                return;
            }

            var http = new HttpClient();
            http.DefaultRequestHeaders.Add("apikey", SUPABASE_KEY);
            http.DefaultRequestHeaders.Add("Authorization", $"Bearer {SUPABASE_KEY}");

            var data = new
            {
                jugador = txtJugador.Text,
                intentos = intentos,
                tiempo = lblTiempo.Text.Replace("Tiempo: ", ""),
                fecha = DateTime.Now
            };

            var json = JsonSerializer.Serialize(data);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            await http.PostAsync($"{SUPABASE_URL}/rest/v1/resultados", content);

            MessageBox.Show("✅ Puntaje guardado correctamente en Supabase.");
        }

        private void btnReiniciar_Click(object sender, EventArgs e)
        {
            IniciarJuego();
        }

        private void btnVerResultados_Click(object sender, EventArgs e)
        {
            FormResultados f = new FormResultados();
            f.ShowDialog();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            segundos++;
            int min = segundos / 60;
            int seg = segundos % 60;
            lblTiempo.Text = $"Tiempo: {min:00}:{seg:00}";
        }

        private void Carta_Click(object sender, EventArgs e)
        {
            if (seleccionadas.Count >= 2) return;

            Label lbl = sender as Label;
            if (lbl.Text != "?") return;

            lbl.Text = lbl.Tag.ToString();
            seleccionadas.Add(lbl);

            if (seleccionadas.Count == 2)
            {
                intentos++;
                lblIntentos.Text = $"Intentos: {intentos}";
                Application.DoEvents();
                System.Threading.Thread.Sleep(500);

                if (seleccionadas[0].Tag.ToString() == seleccionadas[1].Tag.ToString())
                {
                    seleccionadas[0].BackColor = Color.LightGreen;
                    seleccionadas[1].BackColor = Color.LightGreen;
                }
                else
                {
                    seleccionadas[0].Text = "?";
                    seleccionadas[1].Text = "?";
                }

                seleccionadas.Clear();
            }
        }
    }
}
