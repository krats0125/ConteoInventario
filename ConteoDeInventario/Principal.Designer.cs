namespace ConteoDeInventario
{
    partial class Principal
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Principal));
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbNombre = new System.Windows.Forms.ComboBox();
            this.btnAsignar = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.rbBodegaExterna = new System.Windows.Forms.RadioButton();
            this.rbBodegaInterna = new System.Windows.Forms.RadioButton();
            this.txtLeerCodigo = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.rbElegirProductos = new System.Windows.Forms.RadioButton();
            this.rbMercaderista = new System.Windows.Forms.RadioButton();
            this.rbEmpleado = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.flpProductos = new System.Windows.Forms.FlowLayoutPanel();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(131, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(322, 31);
            this.label1.TabIndex = 0;
            this.label1.Text = "CONTEO DE PRODUCTOS";
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.AutoScrollMinSize = new System.Drawing.Size(44, 0);
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(567, 48);
            this.panel1.TabIndex = 1;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(2, 1);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(48, 43);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.Control;
            this.label2.Location = new System.Drawing.Point(7, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 21);
            this.label2.TabIndex = 2;
            this.label2.Text = "Nombre:";
            // 
            // cbNombre
            // 
            this.cbNombre.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbNombre.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbNombre.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbNombre.FormattingEnabled = true;
            this.cbNombre.Location = new System.Drawing.Point(12, 50);
            this.cbNombre.Name = "cbNombre";
            this.cbNombre.Size = new System.Drawing.Size(426, 29);
            this.cbNombre.TabIndex = 3;
            this.cbNombre.SelectedValueChanged += new System.EventHandler(this.cbNombre_SelectedValueChanged);
            // 
            // btnAsignar
            // 
            this.btnAsignar.BackColor = System.Drawing.Color.AliceBlue;
            this.btnAsignar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAsignar.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAsignar.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnAsignar.Location = new System.Drawing.Point(468, 49);
            this.btnAsignar.Name = "btnAsignar";
            this.btnAsignar.Size = new System.Drawing.Size(84, 29);
            this.btnAsignar.TabIndex = 4;
            this.btnAsignar.Text = "Asignar";
            this.btnAsignar.UseVisualStyleBackColor = false;
            this.btnAsignar.Click += new System.EventHandler(this.btnAsignar_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Transparent;
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Controls.Add(this.txtLeerCodigo);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Controls.Add(this.rbMercaderista);
            this.panel2.Controls.Add(this.rbEmpleado);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.btnAsignar);
            this.panel2.Controls.Add(this.cbNombre);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Location = new System.Drawing.Point(0, 49);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(567, 142);
            this.panel2.TabIndex = 5;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.rbBodegaExterna);
            this.panel4.Controls.Add(this.rbBodegaInterna);
            this.panel4.Location = new System.Drawing.Point(12, 112);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(358, 30);
            this.panel4.TabIndex = 16;
            // 
            // rbBodegaExterna
            // 
            this.rbBodegaExterna.AutoSize = true;
            this.rbBodegaExterna.Font = new System.Drawing.Font("Microsoft YaHei", 11.25F);
            this.rbBodegaExterna.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.rbBodegaExterna.Location = new System.Drawing.Point(147, 3);
            this.rbBodegaExterna.Name = "rbBodegaExterna";
            this.rbBodegaExterna.Size = new System.Drawing.Size(142, 24);
            this.rbBodegaExterna.TabIndex = 3;
            this.rbBodegaExterna.TabStop = true;
            this.rbBodegaExterna.Text = "Bodega externa";
            this.rbBodegaExterna.UseVisualStyleBackColor = true;
            // 
            // rbBodegaInterna
            // 
            this.rbBodegaInterna.AutoSize = true;
            this.rbBodegaInterna.Font = new System.Drawing.Font("Microsoft YaHei", 11.25F);
            this.rbBodegaInterna.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.rbBodegaInterna.Location = new System.Drawing.Point(3, 1);
            this.rbBodegaInterna.Name = "rbBodegaInterna";
            this.rbBodegaInterna.Size = new System.Drawing.Size(138, 24);
            this.rbBodegaInterna.TabIndex = 2;
            this.rbBodegaInterna.TabStop = true;
            this.rbBodegaInterna.Text = "Bodega interna";
            this.rbBodegaInterna.UseVisualStyleBackColor = true;
            // 
            // txtLeerCodigo
            // 
            this.txtLeerCodigo.Font = new System.Drawing.Font("Microsoft YaHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLeerCodigo.Location = new System.Drawing.Point(11, 82);
            this.txtLeerCodigo.Name = "txtLeerCodigo";
            this.txtLeerCodigo.Size = new System.Drawing.Size(117, 25);
            this.txtLeerCodigo.TabIndex = 17;
            this.txtLeerCodigo.TextChanged += new System.EventHandler(this.txtLeerCodigo_TextChanged);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.rbElegirProductos);
            this.panel3.Location = new System.Drawing.Point(134, 78);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(189, 31);
            this.panel3.TabIndex = 15;
            // 
            // rbElegirProductos
            // 
            this.rbElegirProductos.AutoSize = true;
            this.rbElegirProductos.Font = new System.Drawing.Font("Microsoft YaHei", 11.25F);
            this.rbElegirProductos.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.rbElegirProductos.Location = new System.Drawing.Point(3, 5);
            this.rbElegirProductos.Name = "rbElegirProductos";
            this.rbElegirProductos.Size = new System.Drawing.Size(148, 24);
            this.rbElegirProductos.TabIndex = 1;
            this.rbElegirProductos.TabStop = true;
            this.rbElegirProductos.Text = "Elegir productos";
            this.rbElegirProductos.UseVisualStyleBackColor = true;
            this.rbElegirProductos.Visible = false;
            // 
            // rbMercaderista
            // 
            this.rbMercaderista.AutoSize = true;
            this.rbMercaderista.Font = new System.Drawing.Font("Microsoft YaHei", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbMercaderista.ForeColor = System.Drawing.SystemColors.Control;
            this.rbMercaderista.Location = new System.Drawing.Point(295, 3);
            this.rbMercaderista.Name = "rbMercaderista";
            this.rbMercaderista.Size = new System.Drawing.Size(123, 24);
            this.rbMercaderista.TabIndex = 9;
            this.rbMercaderista.TabStop = true;
            this.rbMercaderista.Text = "Mercaderista";
            this.rbMercaderista.UseVisualStyleBackColor = true;
            this.rbMercaderista.CheckedChanged += new System.EventHandler(this.rbMercaderista_CheckedChanged);
            // 
            // rbEmpleado
            // 
            this.rbEmpleado.AutoSize = true;
            this.rbEmpleado.Font = new System.Drawing.Font("Microsoft YaHei", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbEmpleado.ForeColor = System.Drawing.SystemColors.Control;
            this.rbEmpleado.Location = new System.Drawing.Point(189, 3);
            this.rbEmpleado.Name = "rbEmpleado";
            this.rbEmpleado.Size = new System.Drawing.Size(100, 24);
            this.rbEmpleado.TabIndex = 8;
            this.rbEmpleado.TabStop = true;
            this.rbEmpleado.Text = "Empleado";
            this.rbEmpleado.UseVisualStyleBackColor = true;
            this.rbEmpleado.CheckedChanged += new System.EventHandler(this.rbEmpleado_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.Control;
            this.label3.Location = new System.Drawing.Point(149, 3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 21);
            this.label3.TabIndex = 7;
            this.label3.Text = "Rol:";
            // 
            // flpProductos
            // 
            this.flpProductos.AutoScroll = true;
            this.flpProductos.Location = new System.Drawing.Point(0, 194);
            this.flpProductos.Name = "flpProductos";
            this.flpProductos.Size = new System.Drawing.Size(567, 482);
            this.flpProductos.TabIndex = 6;
            // 
            // Principal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(66)))), ((int)(((byte)(91)))));
            this.ClientSize = new System.Drawing.Size(564, 679);
            this.Controls.Add(this.flpProductos);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.MaximumSize = new System.Drawing.Size(580, 900);
            this.Name = "Principal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Principal_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbNombre;
        private System.Windows.Forms.Button btnAsignar;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.FlowLayoutPanel flpProductos;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.RadioButton rbMercaderista;
        private System.Windows.Forms.RadioButton rbEmpleado;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.RadioButton rbElegirProductos;
        private System.Windows.Forms.RadioButton rbBodegaExterna;
        private System.Windows.Forms.RadioButton rbBodegaInterna;
        private System.Windows.Forms.TextBox txtLeerCodigo;
    }
}

