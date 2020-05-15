namespace PointOfSale.Views.Modulos.Logistica
{
    partial class FrmInventario
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.BtnAceptar = new System.Windows.Forms.Button();
            this.BtnCancelar = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.TxtFechaBloqueo = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.TxtTipoInv = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.TxtFechaDoc = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.TxtAprobadoPor = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.TxtSituacion = new System.Windows.Forms.TextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.NCantidad = new System.Windows.Forms.NumericUpDown();
            this.label9 = new System.Windows.Forms.Label();
            this.BtnAgregar = new System.Windows.Forms.Button();
            this.TxtLote = new System.Windows.Forms.TextBox();
            this.Malla = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.TxtDescrip = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.TxtProducto = new System.Windows.Forms.TextBox();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NCantidad)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Malla)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(888, 48);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label13.Location = new System.Drawing.Point(6, 9);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(162, 25);
            this.label13.TabIndex = 262;
            this.label13.Text = "Inventario fisico";
            // 
            // label14
            // 
            this.label14.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label14.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.label14.Location = new System.Drawing.Point(8, 34);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(874, 10);
            this.label14.TabIndex = 261;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.BtnCancelar);
            this.groupBox2.Controls.Add(this.BtnAceptar);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox2.Location = new System.Drawing.Point(0, 455);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(888, 63);
            this.groupBox2.TabIndex = 263;
            this.groupBox2.TabStop = false;
            // 
            // BtnAceptar
            // 
            this.BtnAceptar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnAceptar.Location = new System.Drawing.Point(787, 18);
            this.BtnAceptar.Name = "BtnAceptar";
            this.BtnAceptar.Size = new System.Drawing.Size(95, 39);
            this.BtnAceptar.TabIndex = 246;
            this.BtnAceptar.Text = "&ACEPTAR";
            this.BtnAceptar.UseVisualStyleBackColor = true;
            this.BtnAceptar.Click += new System.EventHandler(this.BtnAceptar_Click);
            // 
            // BtnCancelar
            // 
            this.BtnCancelar.Location = new System.Drawing.Point(686, 18);
            this.BtnCancelar.Name = "BtnCancelar";
            this.BtnCancelar.Size = new System.Drawing.Size(95, 39);
            this.BtnCancelar.TabIndex = 247;
            this.BtnCancelar.Text = "SALIR";
            this.BtnCancelar.UseVisualStyleBackColor = true;
            this.BtnCancelar.Click += new System.EventHandler(this.BtnCancelar_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.TxtSituacion);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.TxtAprobadoPor);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.TxtFechaBloqueo);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.TxtFechaDoc);
            this.groupBox3.Controls.Add(this.TxtTipoInv);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox3.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.groupBox3.Location = new System.Drawing.Point(0, 48);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(888, 75);
            this.groupBox3.TabIndex = 264;
            this.groupBox3.TabStop = false;
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
            // TxtTipoInv
            // 
            this.TxtTipoInv.BackColor = System.Drawing.SystemColors.Window;
            this.TxtTipoInv.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TxtTipoInv.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtTipoInv.ForeColor = System.Drawing.Color.Black;
            this.TxtTipoInv.Location = new System.Drawing.Point(6, 30);
            this.TxtTipoInv.Name = "TxtTipoInv";
            this.TxtTipoInv.Size = new System.Drawing.Size(156, 24);
            this.TxtTipoInv.TabIndex = 0;
            this.TxtTipoInv.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtTipoInv_KeyDown);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label6.Location = new System.Drawing.Point(3, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(152, 18);
            this.label6.TabIndex = 224;
            this.label6.Text = "♥TIPO INVENTARIO";
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
            this.TxtFechaDoc.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtCategoria_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label2.Location = new System.Drawing.Point(432, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(129, 18);
            this.label2.TabIndex = 236;
            this.label2.Text = "APROBADO POR";
            // 
            // TxtAprobadoPor
            // 
            this.TxtAprobadoPor.BackColor = System.Drawing.SystemColors.Window;
            this.TxtAprobadoPor.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TxtAprobadoPor.Enabled = false;
            this.TxtAprobadoPor.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtAprobadoPor.ForeColor = System.Drawing.Color.Black;
            this.TxtAprobadoPor.Location = new System.Drawing.Point(432, 30);
            this.TxtAprobadoPor.Name = "TxtAprobadoPor";
            this.TxtAprobadoPor.Size = new System.Drawing.Size(327, 24);
            this.TxtAprobadoPor.TabIndex = 2;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label7.Location = new System.Drawing.Point(762, 9);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(87, 18);
            this.label7.TabIndex = 236;
            this.label7.Text = "SITUACIÓN";
            // 
            // TxtSituacion
            // 
            this.TxtSituacion.BackColor = System.Drawing.SystemColors.Window;
            this.TxtSituacion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TxtSituacion.Enabled = false;
            this.TxtSituacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtSituacion.ForeColor = System.Drawing.Color.Black;
            this.TxtSituacion.Location = new System.Drawing.Point(765, 30);
            this.TxtSituacion.Name = "TxtSituacion";
            this.TxtSituacion.Size = new System.Drawing.Size(114, 24);
            this.TxtSituacion.TabIndex = 2;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.NCantidad);
            this.groupBox4.Controls.Add(this.label9);
            this.groupBox4.Controls.Add(this.BtnAgregar);
            this.groupBox4.Controls.Add(this.TxtLote);
            this.groupBox4.Controls.Add(this.Malla);
            this.groupBox4.Controls.Add(this.label3);
            this.groupBox4.Controls.Add(this.TxtDescrip);
            this.groupBox4.Controls.Add(this.label5);
            this.groupBox4.Controls.Add(this.label10);
            this.groupBox4.Controls.Add(this.TxtProducto);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox4.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.groupBox4.Location = new System.Drawing.Point(0, 123);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(888, 332);
            this.groupBox4.TabIndex = 265;
            this.groupBox4.TabStop = false;
            // 
            // NCantidad
            // 
            this.NCantidad.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NCantidad.Location = new System.Drawing.Point(712, 32);
            this.NCantidad.Maximum = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            this.NCantidad.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NCantidad.Name = "NCantidad";
            this.NCantidad.Size = new System.Drawing.Size(79, 26);
            this.NCantidad.TabIndex = 6;
            this.NCantidad.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label9.Location = new System.Drawing.Point(667, 14);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(82, 18);
            this.label9.TabIndex = 263;
            this.label9.Text = "CANTIDAD";
            // 
            // BtnAgregar
            // 
            this.BtnAgregar.Location = new System.Drawing.Point(797, 33);
            this.BtnAgregar.Name = "BtnAgregar";
            this.BtnAgregar.Size = new System.Drawing.Size(82, 26);
            this.BtnAgregar.TabIndex = 7;
            this.BtnAgregar.Text = "Agregar";
            this.BtnAgregar.UseVisualStyleBackColor = true;
            this.BtnAgregar.Click += new System.EventHandler(this.BtnAgregar_Click);
            // 
            // TxtLote
            // 
            this.TxtLote.BackColor = System.Drawing.SystemColors.Window;
            this.TxtLote.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TxtLote.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtLote.ForeColor = System.Drawing.Color.Black;
            this.TxtLote.Location = new System.Drawing.Point(500, 34);
            this.TxtLote.Name = "TxtLote";
            this.TxtLote.Size = new System.Drawing.Size(206, 24);
            this.TxtLote.TabIndex = 5;
            this.TxtLote.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtLote_KeyDown);
            // 
            // Malla
            // 
            this.Malla.AllowUserToAddRows = false;
            this.Malla.BackgroundColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Malla.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle10;
            this.Malla.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Malla.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column4,
            this.Column7});
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.Malla.DefaultCellStyle = dataGridViewCellStyle11;
            this.Malla.Location = new System.Drawing.Point(6, 65);
            this.Malla.Name = "Malla";
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Malla.RowHeadersDefaultCellStyle = dataGridViewCellStyle12;
            this.Malla.Size = new System.Drawing.Size(873, 261);
            this.Malla.TabIndex = 260;
            this.Malla.TabStop = false;
            this.Malla.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.Malla_CellEndEdit);
            this.Malla.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.Malla_EditingControlShowing);
            this.Malla.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Malla_KeyDown);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label3.Location = new System.Drawing.Point(497, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 18);
            this.label3.TabIndex = 244;
            this.label3.Text = "♥LOTE";
            // 
            // TxtDescrip
            // 
            this.TxtDescrip.BackColor = System.Drawing.SystemColors.Window;
            this.TxtDescrip.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TxtDescrip.Enabled = false;
            this.TxtDescrip.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtDescrip.ForeColor = System.Drawing.Color.Black;
            this.TxtDescrip.Location = new System.Drawing.Point(169, 35);
            this.TxtDescrip.Name = "TxtDescrip";
            this.TxtDescrip.Size = new System.Drawing.Size(325, 24);
            this.TxtDescrip.TabIndex = 241;
            this.TxtDescrip.TabStop = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label5.Location = new System.Drawing.Point(4, 14);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(113, 18);
            this.label5.TabIndex = 240;
            this.label5.Text = "♥PRODUCTO";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label10.Location = new System.Drawing.Point(166, 14);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(111, 18);
            this.label10.TabIndex = 242;
            this.label10.Text = "DESCRIPCIÓN";
            // 
            // TxtProducto
            // 
            this.TxtProducto.BackColor = System.Drawing.SystemColors.Window;
            this.TxtProducto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TxtProducto.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtProducto.ForeColor = System.Drawing.Color.Black;
            this.TxtProducto.Location = new System.Drawing.Point(7, 35);
            this.TxtProducto.Name = "TxtProducto";
            this.TxtProducto.Size = new System.Drawing.Size(156, 24);
            this.TxtProducto.TabIndex = 4;
            this.TxtProducto.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtProducto_KeyDown);
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
            this.Column4.Width = 580;
            // 
            // Column7
            // 
            this.Column7.HeaderText = "CANT. CONTEO";
            this.Column7.Name = "Column7";
            this.Column7.Width = 150;
            // 
            // FrmInventario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(888, 518);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "FrmInventario";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmInventario";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NCantidad)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Malla)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button BtnCancelar;
        private System.Windows.Forms.Button BtnAceptar;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox TxtSituacion;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox TxtAprobadoPor;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TxtFechaBloqueo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TxtFechaDoc;
        private System.Windows.Forms.TextBox TxtTipoInv;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.NumericUpDown NCantidad;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button BtnAgregar;
        private System.Windows.Forms.TextBox TxtLote;
        private System.Windows.Forms.DataGridView Malla;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TxtDescrip;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox TxtProducto;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
    }
}