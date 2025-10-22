using System;
using System.Collections.Generic;
using System.Drawing;
using System.Net.Http;
using System.Text.Json;
using System.Windows.Forms;

namespace MemoryGame_Supabase
{
    public class FormResultados : Form
    {
        private const string SUPABASE_URL = "https://wohhwcvrvwogmfnqrxwy.supabase.co";
        private const string SUPABASE_KEY = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpc3MiOiJzdXBhYmFzZSIsInJlZiI6IndvaGh3Y3ZydndvZ21mbnFyeHd5Iiwicm9sZSI6ImFub24iLCJpYXQiOjE3NjA5NzQzMDcsImV4cCI6MjA3NjU1MDMwN30.d-X1cA3PXaqAS5VnPWsTOLZEO16ajBIsrN_aggr9nQs";

        private DataGridView dataGridView1;

        public FormResultados()
        {
            InitializeComponent();
            this.Load += FormResultados_Load;
        }

        // 🔹 Crear interfaz manualmente
        private void InitializeComponent()
        {
            Text = "Resultados Globales - Supabase";
            Size = new Size(700, 400);
            StartPosition = FormStartPosition.CenterScreen;
            dataGridView1 = new DataGridView();
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Location = new Point(20, 20);
            dataGridView1.Size = new Size(640, 300);
            dataGridView1.ReadOnly = true;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dataGridView1.RowHeadersVisible = false;
            Controls.Add(dataGridView1);
        }

        // 🔹 Cargar datos desde Supabase
        private async void FormResultados_Load(object sender, EventArgs e)
        {
            try
            {
                var http = new HttpClient();
                http.DefaultRequestHeaders.Add("apikey", SUPABASE_KEY);
                http.DefaultRequestHeaders.Add("Authorization", $"Bearer {SUPABASE_KEY}");

                var res = await http.GetStringAsync($"{SUPABASE_URL}/rest/v1/resultados?select=*");
                var lista = JsonSerializer.Deserialize<List<Resultado>>(res);

                dataGridView1.DataSource = lista;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar datos desde Supabase:\n{ex.Message}");
            }
        }

        public class Resultado
        {
            public string jugador { get; set; }
            public int intentos { get; set; }
            public string tiempo { get; set; }
            public DateTime fecha { get; set; }
        }
    }
}
