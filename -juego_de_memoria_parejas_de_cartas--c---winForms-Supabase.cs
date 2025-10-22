🎯 Juego de Memoria (Parejas de Cartas) con C# WinForms + Supabase

Incluye:

Descripción general

Instalación

Código completo (Form, conexión y SQL)

Instrucciones paso a paso

Script Supabase

Estructura del proyecto

Logo y créditos

📘 Archivo: README.md

# 🧠 Juego de Memoria (Parejas de Cartas) — C# WinForms + Supabase

![Logo](https://i.imgur.com/a31tZ1U.png)

## 🎯 Descripción

Este proyecto implementa un **Juego de Memoria (Parejas de Cartas)** desarrollado en **Visual Studio 2022 (C# WinForms)**, que guarda los resultados de las partidas (jugador, intentos, tiempo y fecha) en una base de datos **Supabase** (PostgreSQL en la nube).

Ideal para aprender:
- Programación con **Windows Forms (WinForms)**  
- Manejo de **listas y eventos en C#**  
- Consumo de **API REST Supabase**  
- Registro y consulta de datos en la nube  

---

## ⚙️ Tecnologías utilizadas

- Visual Studio 2022  
- .NET 6 (C# WinForms)  
- Supabase (PostgreSQL + REST API)  
- JSON + HttpClient  

---

## 🧩 Características

✅ Interfaz gráfica tipo tablero (4x4)  
✅ Cronómetro y contador de intentos  
✅ Registro de jugador y puntaje  
✅ Guarda resultados en Supabase  
✅ Visualización global de resultados  
✅ (Opcional) modo multijugador local  

---

## 🗂️ Estructura del proyecto



MemoryGame_Supabase/
├─ Form1.cs
├─ FormResultados.cs
├─ SupabaseService.cs
├─ Program.cs
└─ App.config


---

## 🖥️ Interfaz visual


| Jugador: [_________] Tiempo: 00:00 Intentos: 0 |
| [A] [B] [A] [B] |
| [C] [D] [C] [D] |
| [E] [F] [E] [F] |
| [G] [H] [G] [H] |
| [Guardar Puntaje] [Reiniciar] [Ver Resultados] |

---

## 🧠 Código principal del juego — `Form1.cs`

```csharp
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

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
        Timer gameTimer = new Timer();

        public Form1()
        {
            InitializeComponent();
            AsignarCartas();
            gameTimer.Interval = 1000;
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
    }
}

☁️ Conexión con Supabase — SupabaseService.cs
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace MemoryGame_Supabase
{
    public class SupabaseService
    {
        private readonly HttpClient _client = new HttpClient();
        private const string SUPABASE_URL = "https://TU_PROYECTO.supabase.co";
        private const string SUPABASE_KEY = "TU_API_KEY";

        public async Task GuardarResultado(string jugador, int intentos, string tiempo)
        {
            var data = new
            {
                jugador = jugador,
                intentos = intentos,
                tiempo = tiempo
            };

            var content = new StringContent(JsonSerializer.Serialize(data), Encoding.UTF8, "application/json");
            _client.DefaultRequestHeaders.Clear();
            _client.DefaultRequestHeaders.Add("apikey", SUPABASE_KEY);
            _client.DefaultRequestHeaders.Add("Authorization", $"Bearer {SUPABASE_KEY}");

            var response = await _client.PostAsync($"{SUPABASE_URL}/rest/v1/resultados", content);
            response.EnsureSuccessStatusCode();
        }
    }
}

🧾 Guardar puntaje — botón Guardar Puntaje
private async void btnGuardarPuntaje_Click(object sender, EventArgs e)
{
    string jugador = txtJugador.Text;
    string tiempo = lblTiempo.Text.Replace("Tiempo: ", "");
    var supabase = new SupabaseService();
    await supabase.GuardarResultado(jugador, intentos, tiempo);
    MessageBox.Show("Puntaje guardado en Supabase ✅");
}

🏆 Mostrar tabla global — FormResultados.cs
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MemoryGame_Supabase
{
    public partial class FormResultados : Form
    {
        private const string SUPABASE_URL = "https://TU_PROYECTO.supabase.co";
        private const string SUPABASE_KEY = "TU_API_KEY";

        public FormResultados()
        {
            InitializeComponent();
        }

        private async void FormResultados_Load(object sender, EventArgs e)
        {
            var http = new HttpClient();
            http.DefaultRequestHeaders.Add("apikey", SUPABASE_KEY);
            http.DefaultRequestHeaders.Add("Authorization", $"Bearer {SUPABASE_KEY}");
            var res = await http.GetStringAsync($"{SUPABASE_URL}/rest/v1/resultados?select=*");
            var lista = JsonSerializer.Deserialize<List<Resultado>>(res);
            dataGridView1.DataSource = lista;
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

🧱 Script SQL — Tabla resultados
CREATE TABLE resultados (
  id serial PRIMARY KEY,
  jugador varchar(50),
  intentos int,
  tiempo varchar(10),
  fecha timestamptz default now()
);

🧩 (Opcional) Modo multijugador local

Dos jugadores alternan turnos.

Cada uno gana puntos por pareja correcta.

Se guardan ambos resultados en Supabase.

🚀 Instrucciones de instalación

Clonar o descargar este repositorio.

Abrir Visual Studio 2022 → Abrir proyecto existente.

Configurar:

.NET 6

Supabase URL y API Key en SupabaseService.cs

Crear la tabla resultados en tu proyecto Supabase.

Ejecutar el proyecto y probar el juego.

Ver puntajes globales desde el formulario de resultados.

🌐 Enlaces útiles

Supabase Dashboard

Documentación Supabase REST API

Descargar Visual Studio 2022

📸 Captura de ejemplo

(Puedes añadir tu captura del juego aquí)

👨‍💻 Autor

Giovanny Alejandro Tapiero Cataño (GiovaTC)
Proyecto educativo desarrollado con ❤️ para prácticas de integración .NET + nube.

📄 Licencia

MIT License — Libre para usar y modificar con fines educativos.