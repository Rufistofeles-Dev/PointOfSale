namespace PointOfSale.Views.Modulos.Finanzas
{
    partial class FrmInvetarioAut
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.Malla = new System.Windows.Forms.DataGridView();
            this.TxtSituacion = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.TxtUsuarioCaptura = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.TxtFechaDoc = new System.Windows.Forms.TextBox();
            this.TxtInventario = new System.Windows.Forms.TextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.TxtUsuarioAut = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.TxtFechaBloqueo = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.BtnCancelar = new System.Windows.Forms.Button();
            this.BtnAceptar = new System.Windows.Forms.Button();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.BtnStockCeros = new System.Windows.Forms.Button();
            this.BtnBorrarPartida = new System.Windows.Forms.Button();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.Malla)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // Malla
            // 
            this.Malla.AllowUserToAddRows = false;
            this.Malla.BackgroundColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Malla.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.Malla.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Malla.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column4,
            this.Column2,
            this.Column3,
            this.Column5,
            this.Column6,
            this.Column7});
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.Malla.DefaultCellStyle = dataGridViewCellStyle5;
            this.Malla.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Malla.Location = new System.Drawing.Point(3, 16);
            this.Malla.Name = "Malla";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Malla.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.Malla.Size = new System.Drawing.Size(953, 306);
            this.Malla.TabIndex = 260;
            this.Malla.TabStop = false;
            this.Malla.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.Malla_CellEndEdit);
            this.Malla.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.Malla_EditingControlShowing);
            this.Malla.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Malla_KeyDown);
            // 
            // TxtSituacion
            // 
            this.TxtSituacion.BackColor = System.Drawing.SystemColors.Window;
            this.TxtSituacion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TxtSituacion.Enabled = false;
            this.TxtSituacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtSituacion.ForeColor = System.Drawing.Color.Black;
            this.TxtSituacion.Location = new System.Drawing.Point(846, 30);
            this.TxtSituacion.Name = "TxtSituacion";
            this.TxtSituacion.Size = new System.Drawing.Size(110, 24);
            this.TxtSituacion.TabIndex = 2;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label7.Location = new System.Drawing.Point(843, 9);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(87, 18);
            this.label7.TabIndex = 236;
            this.label7.Text = "SITUACIÓN";
            // 
            // TxtUsuarioCaptura
            // 
            this.TxtUsuarioCaptura.BackColor = System.Drawing.SystemColors.Window;
            this.TxtUsuarioCaptura.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TxtUsuarioCaptura.Enabled = false;
            this.TxtUsuarioCaptura.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtUsuarioCaptura.ForeColor = System.Drawing.Color.Black;
            this.TxtUsuarioCaptura.Location = new System.Drawing.Point(432, 30);
            this.TxtUsuarioCaptura.Name = "TxtUsuarioCaptura";
            this.TxtUsuarioCaptura.Size = new System.Drawing.Size(201, 24);
            this.TxtUsuarioCaptura.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label2.Location = new System.Drawing.Point(432, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(174, 18);
            this.label2.TabIndex = 236;
            this.label2.Text = "USUARIO DE CAPTURA";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label1.Location = new System.Drawing.Point(165, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 18);
            this.label1.TabIndex = 226;
            this.label1.Text = "FECHA DOC.";
            // 
            // TxtFechaDoc
            // 
            this.TxtFechaDoc.BackColor = System.Drawing.SystemColors.Window;
            this.TxtFechaDoc.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TxtFechaDoc.Enabled = false;
            this.TxtFechaDoc.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtFechaDoc.ForeColor = System.Drawing.Color.Black;
            this.TxtFechaDoc.Location = new System.Drawing.Point(168, 30);
            this.TxtFechaDoc.Name = "TxtFechaDoc";
            this.TxtFechaDoc.Size = new System.Drawing.Size(124, 24);
            this.TxtFechaDoc.TabIndex = 0;
            this.TxtFechaDoc.TabStop = false;
            // 
            // TxtInventario
            // 
            this.TxtInventario.BackColor = System.Drawing.SystemColors.Window;
            this.TxtInventario.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TxtInventario.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtInventario.ForeColor = System.Drawing.Color.Black;
            this.TxtInventario.Location = new System.Drawing.Point(6, 30);
            this.TxtInventario.Name = "TxtInventario";
            this.TxtInventario.Size = new System.Drawing.Size(156, 24);
            this.TxtInventario.TabIndex = 2;
            this.TxtInventario.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtInventario_KeyDown);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.Malla);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox4.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.groupBox4.Location = new System.Drawing.Point(0, 123);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(959, 325);
            this.groupBox4.TabIndex = 266;
            this.groupBox4.TabStop = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label6.Location = new System.Drawing.Point(3, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(156, 18);
            this.label6.TabIndex = 224;
            this.label6.Text = "♥DOC. INVENTARIO";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.TxtUsuarioAut);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.TxtSituacion);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.TxtUsuarioCaptura);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.TxtFechaBloqueo);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.TxtFechaDoc);
            this.groupBox3.Controls.Add(this.TxtInventario);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox3.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.groupBox3.Location = new System.Drawing.Point(0, 48);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(959, 75);
            this.groupBox3.TabIndex = 264;
            this.groupBox3.TabStop = false;
            // 
            // TxtUsuarioAut
            // 
            this.TxtUsuarioAut.BackColor = System.Drawing.SystemColors.Window;
            this.TxtUsuarioAut.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TxtUsuarioAut.Enabled = false;
            this.TxtUsuarioAut.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtUsuarioAut.ForeColor = System.Drawing.Color.Black;
            this.TxtUsuarioAut.Location = new System.Drawing.Point(639, 30);
            this.TxtUsuarioAut.Name = "TxtUsuarioAut";
            this.TxtUsuarioAut.Size = new System.Drawing.Size(201, 24);
            this.TxtUsuarioAut.TabIndex = 237;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label3.Location = new System.Drawing.Point(636, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(189, 18);
            this.label3.TabIndex = 238;
            this.label3.Text = "USUARIO AUTORIZACIÓN";
            // 
            // TxtFechaBloqueo
            // 
            this.TxtFechaBloqueo.BackColor = System.Drawing.SystemColors.Window;
            this.TxtFechaBloqueo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TxtFechaBloqueo.Enabled = false;
            this.TxtFechaBloqueo.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtFechaBloqueo.ForeColor = System.Drawing.Color.Black;
            this.TxtFechaBloqueo.Location = new System.Drawing.Point(298, 30);
            this.TxtFechaBloqueo.Name = "TxtFechaBloqueo";
            this.TxtFechaBloqueo.Size = new System.Drawing.Size(128, 24);
            this.TxtFechaBloqueo.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label4.Location = new System.Drawing.Point(293, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(137, 18);
            this.label4.TabIndex = 236;
            this.label4.Text = "FECHA BLOQUEO";
            // 
            // BtnCancelar
            // 
            this.BtnCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnCancelar.Location = new System.Drawing.Point(852, 19);
            this.BtnCancelar.Name = "BtnCancelar";
            this.BtnCancelar.Size = new System.Drawing.Size(95, 38);
            this.BtnCancelar.TabIndex = 247;
            this.BtnCancelar.Text = "SALIR";
            this.BtnCancelar.UseVisualStyleBackColor = true;
            this.BtnCancelar.Click += new System.EventHandler(this.BtnCancelar_Click);
            // 
            // BtnAceptar
            // 
            this.BtnAceptar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnAceptar.Location = new System.Drawing.Point(751, 19);
            this.BtnAceptar.Name = "BtnAceptar";
            this.BtnAceptar.Size = new System.Drawing.Size(95, 39);
            this.BtnAceptar.TabIndex = 246;
            this.BtnAceptar.Text = "&AUTORIZAR";
            this.BtnAceptar.UseVisualStyleBackColor = true;
            this.BtnAceptar.Click += new System.EventHandler(this.BtnAceptar_Click);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label13.Location = new System.Drawing.Point(6, 9);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(219, 25);
            this.label13.TabIndex = 262;
            this.label13.Text = "Atorización Inventario";
            // 
            // label14
            // 
            this.label14.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label14.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.label14.Location = new System.Drawing.Point(8, 34);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(945, 10);
            this.label14.TabIndex = 261;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(959, 48);
            this.groupBox1.TabIndex = 265;
            this.groupBox1.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.BtnStockCeros);
            this.groupBox2.Controls.Add(this.BtnBorrarPartida);
            this.groupBox2.Controls.Add(this.BtnCancelar);
            this.groupBox2.Controls.Add(this.BtnAceptar);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox2.Location = new System.Drawing.Point(0, 448);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(959, 63);
            this.groupBox2.TabIndex = 267;
            this.groupBox2.TabStop = false;
            // 
            // BtnStockCeros
            // 
            this.BtnStockCeros.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnStockCeros.Location = new System.Drawing.Point(549, 18);
            this.BtnStockCeros.Name = "BtnStockCeros";
            this.BtnStockCeros.Size = new System.Drawing.Size(95, 39);
            this.BtnStockCeros.TabIndex = 249;
            this.BtnStockCeros.Text = "&STOCK A CERO";
            this.BtnStockCeros.UseVisualStyleBackColor = true;
            this.BtnStockCeros.Click += new System.EventHandler(this.BtnStockCeros_Click);
            // 
            // BtnBorrarPartida
            // 
            this.BtnBorrarPartida.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnBorrarPartida.Location = new System.Drawing.Point(650, 18);
            this.BtnBorrarPartida.Name = "BtnBorrarPartida";
            this.BtnBorrarPartida.Size = new System.Drawing.Size(95, 39);
            this.BtnBorrarPartida.TabIndex = 248;
            this.BtnBorrarPartida.Text = "&BORRAR ITEM";
            this.BtnBorrarPartida.UseVisualStyleBackColor = true;
            this.BtnBorrarPartida.Click += new System.EventHandler(this.BtnBorrarPartida_Click);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "ARTICULO";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "DESCRIPCIÓN";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Width = 310;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "TEORICO";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "FISICO";
            this.Column3.Name = "Column3";
            // 
            // Column5
            // 
            this.Column5.HeaderText = "DIFERENCIA";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            // 
            // Column6
            // 
            this.Column6.HeaderText = "COSTO";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            // 
            // Column7
            // 
            this.Column7.HeaderText = "IMPORTE";
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            // 
            // FrmInvetarioAut
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(959, 511);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.MaximumSize = new System.Drawing.Size(975, 550);
            this.MinimumSize = new System.Drawing.Size(975, 550);
            this.Name = "FrmInvetarioAut";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmInvetarioAut";
            ((System.ComponentModel.ISupportInitialize)(this.Malla)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView Malla;
        private System.Windows.Forms.TextBox TxtSituacion;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox TxtUsuarioCaptura;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TxtFechaDoc;
        private System.Windows.Forms.TextBox TxtInventario;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button BtnCancelar;
        private System.Windows.Forms.Button BtnAceptar;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button BtnStockCeros;
        private System.Windows.Forms.Button BtnBorrarPartida;
        private System.Windows.Forms.TextBox TxtUsuarioAut;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TxtFechaBloqueo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
    }
}