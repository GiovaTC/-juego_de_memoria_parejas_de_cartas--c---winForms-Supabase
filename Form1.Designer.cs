namespace MemoryGame_Supabase
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        // 🔹 Declaración de controles
        private Label lblIntentos;
        private Label lblTiempo;
        private Label lblJugador;
        private TextBox txtJugador;
        private Button btnGuardarPuntaje;
        private Button btnReiniciar;
        private DataGridView dataGridView1;
        private Button btnVerResultados;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code
        private void InitializeComponent()
        {
            lblIntentos = new Label();
            lblTiempo = new Label();
            lblJugador = new Label();
            txtJugador = new TextBox();
            btnGuardarPuntaje = new Button();
            btnReiniciar = new Button();
            dataGridView1 = new DataGridView();
            btnVerResultados = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // lblIntentos
            // 
            lblIntentos.AutoSize = true;
            lblIntentos.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblIntentos.Location = new Point(20, 20);
            lblIntentos.Name = "lblIntentos";
            lblIntentos.Size = new Size(78, 19);
            lblIntentos.TabIndex = 1;
            lblIntentos.Text = "Intentos: 0";
            // 
            // lblTiempo
            // 
            lblTiempo.AutoSize = true;
            lblTiempo.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblTiempo.Location = new Point(20, 50);
            lblTiempo.Name = "lblTiempo";
            lblTiempo.Size = new Size(82, 19);
            lblTiempo.TabIndex = 2;
            lblTiempo.Text = "Tiempo: 0s";
            // 
            // lblJugador
            // 
            lblJugador.AutoSize = true;
            lblJugador.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblJugador.Location = new Point(20, 85);
            lblJugador.Name = "lblJugador";
            lblJugador.Size = new Size(69, 19);
            lblJugador.TabIndex = 3;
            lblJugador.Text = "Jugador:";
            // 
            // txtJugador
            // 
            txtJugador.Location = new Point(100, 83);
            txtJugador.Name = "txtJugador";
            txtJugador.Size = new Size(150, 23);
            txtJugador.TabIndex = 4;
            // 
            // btnGuardarPuntaje
            // 
            btnGuardarPuntaje.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnGuardarPuntaje.Location = new Point(20, 120);
            btnGuardarPuntaje.Name = "btnGuardarPuntaje";
            btnGuardarPuntaje.Size = new Size(230, 30);
            btnGuardarPuntaje.TabIndex = 5;
            btnGuardarPuntaje.Text = "Guardar Puntaje en Supabase";
            btnGuardarPuntaje.UseVisualStyleBackColor = true;
            btnGuardarPuntaje.Click += btnGuardarPuntaje_Click;
            // 
            // btnReiniciar
            // 
            btnReiniciar.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnReiniciar.Location = new Point(20, 160);
            btnReiniciar.Name = "btnReiniciar";
            btnReiniciar.Size = new Size(230, 30);
            btnReiniciar.TabIndex = 6;
            btnReiniciar.Text = "Reiniciar Juego";
            btnReiniciar.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(280, 20);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.Size = new Size(480, 170);
            dataGridView1.TabIndex = 7;
            // 
            // btnVerResultados
            // 
            btnVerResultados.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnVerResultados.Location = new Point(20, 200);
            btnVerResultados.Name = "btnVerResultados";
            btnVerResultados.Size = new Size(230, 30);
            btnVerResultados.TabIndex = 0;
            btnVerResultados.Text = "Ver Resultados Globales";
            btnVerResultados.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnVerResultados);
            Controls.Add(lblIntentos);
            Controls.Add(lblTiempo);
            Controls.Add(lblJugador);
            Controls.Add(txtJugador);
            Controls.Add(btnGuardarPuntaje);
            Controls.Add(btnReiniciar);
            Controls.Add(dataGridView1);
            Name = "Form1";
            Text = "Juego de Memoria - Supabase";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
        #endregion
    }
}
