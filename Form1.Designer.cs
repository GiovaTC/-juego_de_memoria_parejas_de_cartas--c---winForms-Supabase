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
            this.lblIntentos = new System.Windows.Forms.Label();
            this.lblTiempo = new System.Windows.Forms.Label();
            this.lblJugador = new System.Windows.Forms.Label();
            this.txtJugador = new System.Windows.Forms.TextBox();
            this.btnGuardarPuntaje = new System.Windows.Forms.Button();
            this.btnReiniciar = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();

            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();

            // 
            // lblIntentos
            // 
            this.lblIntentos.AutoSize = true;
            this.lblIntentos.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.lblIntentos.Location = new Point(20, 20);
            this.lblIntentos.Name = "lblIntentos";
            this.lblIntentos.Size = new Size(93, 19);
            this.lblIntentos.Text = "Intentos: 0";
            // 
            // lblTiempo
            // 
            this.lblTiempo.AutoSize = true;
            this.lblTiempo.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.lblTiempo.Location = new Point(20, 50);
            this.lblTiempo.Name = "lblTiempo";
            this.lblTiempo.Size = new Size(92, 19);
            this.lblTiempo.Text = "Tiempo: 0s";
            // 
            // lblJugador
            // 
            this.lblJugador.AutoSize = true;
            this.lblJugador.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.lblJugador.Location = new Point(20, 85);
            this.lblJugador.Name = "lblJugador";
            this.lblJugador.Size = new Size(69, 19);
            this.lblJugador.Text = "Jugador:";
            // 
            // txtJugador
            // 
            this.txtJugador.Location = new Point(100, 83);
            this.txtJugador.Name = "txtJugador";
            this.txtJugador.Size = new Size(150, 23);
            // 
            // btnGuardarPuntaje
            // 
            this.btnGuardarPuntaje.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            this.btnGuardarPuntaje.Location = new Point(20, 120);
            this.btnGuardarPuntaje.Name = "btnGuardarPuntaje";
            this.btnGuardarPuntaje.Size = new Size(230, 30);
            this.btnGuardarPuntaje.Text = "Guardar Puntaje en Supabase";
            this.btnGuardarPuntaje.UseVisualStyleBackColor = true;
            this.btnGuardarPuntaje.Click += new EventHandler(this.btnGuardarPuntaje_Click);
            // 
            // btnReiniciar
            // 
            this.btnReiniciar.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            this.btnReiniciar.Location = new Point(20, 160);
            this.btnReiniciar.Name = "btnReiniciar";
            this.btnReiniciar.Size = new Size(230, 30);
            this.btnReiniciar.Text = "Reiniciar Juego";
            this.btnReiniciar.UseVisualStyleBackColor = true;
     //       this.btnReiniciar.Click += new EventHandler(this.btnReiniciar_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new Point(280, 20);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new Size(480, 170);
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(800, 450);
            this.Controls.Add(this.lblIntentos);
            this.Controls.Add(this.lblTiempo);
            this.Controls.Add(this.lblJugador);
            this.Controls.Add(this.txtJugador);
            this.Controls.Add(this.btnGuardarPuntaje);
            this.Controls.Add(this.btnReiniciar);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Form1";
            this.Text = "Juego de Memoria - Supabase";

            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
        #endregion
    }
}
