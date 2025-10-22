using Timer = System.Windows.Forms.Timer;

namespace MemoryGame_Supabase
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        private Label lblJugador;
        private TextBox txtJugador;
        private Label lblTiempo;
        private Label lblIntentos;
        private Button btnGuardar;
        private Button btnReiniciar;
        private Button btnVerResultados;
        private System.Windows.Forms.Timer timer1;
        private TableLayoutPanel tablaCartas;

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
            this.lblJugador = new Label();
            this.txtJugador = new TextBox();
            this.lblTiempo = new Label();
            this.lblIntentos = new Label();
            this.btnGuardar = new Button();
            this.btnReiniciar = new Button();
            this.btnVerResultados = new Button();
            this.timer1 = new Timer();
            this.tablaCartas = new TableLayoutPanel();

            SuspendLayout();

            // lblJugador
            this.lblJugador.Text = "Jugador:";
            this.lblJugador.Location = new Point(20, 20);
            this.lblJugador.AutoSize = true;

            // txtJugador
            this.txtJugador.Location = new Point(85, 18);
            this.txtJugador.Width = 120;

            // lblTiempo
            this.lblTiempo.Text = "Tiempo: 00:00";
            this.lblTiempo.Location = new Point(230, 20);
            this.lblTiempo.AutoSize = true;

            // lblIntentos
            this.lblIntentos.Text = "Intentos: 0";
            this.lblIntentos.Location = new Point(360, 20);
            this.lblIntentos.AutoSize = true;

            // tablaCartas
            this.tablaCartas.Location = new Point(20, 60);
            this.tablaCartas.Size = new Size(400, 300);
            this.tablaCartas.ColumnCount = 4;
            this.tablaCartas.RowCount = 4;
            this.tablaCartas.CellBorderStyle = TableLayoutPanelCellBorderStyle.OutsetDouble;
            this.tablaCartas.BackColor = Color.White;
            for (int i = 0; i < 4; i++)
            {
                this.tablaCartas.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
                this.tablaCartas.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            }

            // btnGuardar
            this.btnGuardar.Text = "Guardar Puntaje";
            this.btnGuardar.Location = new Point(20, 380);
            this.btnGuardar.Size = new Size(120, 30);
            this.btnGuardar.Click += new EventHandler(this.btnGuardar_Click);

            // btnReiniciar
            this.btnReiniciar.Text = "Reiniciar";
            this.btnReiniciar.Location = new Point(160, 380);
            this.btnReiniciar.Size = new Size(100, 30);
            this.btnReiniciar.Click += new EventHandler(this.btnReiniciar_Click);

            // btnVerResultados
            this.btnVerResultados.Text = "Ver Resultados";
            this.btnVerResultados.Location = new Point(280, 380);
            this.btnVerResultados.Size = new Size(120, 30);
            this.btnVerResultados.Click += new EventHandler(this.btnVerResultados_Click);

            // timer1
            this.timer1.Interval = 1000;
            this.timer1.Tick += new EventHandler(this.timer1_Tick);

            // Form1
            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(460, 430);
            this.Controls.Add(this.lblJugador);
            this.Controls.Add(this.txtJugador);
            this.Controls.Add(this.lblTiempo);
            this.Controls.Add(this.lblIntentos);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.btnReiniciar);
            this.Controls.Add(this.btnVerResultados);
            this.Controls.Add(this.tablaCartas);
            this.Text = "Juego de Memoria - Supabase";
            this.Load += new EventHandler(this.Form1_Load);

            ResumeLayout(false);
            PerformLayout();
        }
    }
}
