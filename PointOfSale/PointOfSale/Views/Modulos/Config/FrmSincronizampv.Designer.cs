namespace PointOfSale.Views.Modulos.Config
{
    partial class FrmSincronizampv
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.Malla = new System.Windows.Forms.DataGridView();
            this.panel8 = new System.Windows.Forms.Panel();
            this.LblModificadoPor = new System.Windows.Forms.Label();
            this.LblCreadoPor = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.CboTabla = new System.Windows.Forms.ComboBox();
            this.BtnSalvarCampos = new System.Windows.Forms.LinkLabel();
            this.BtnBorrarCampo = new System.Windows.Forms.LinkLabel();
            this.BtnAddCampo = new System.Windows.Forms.LinkLabel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.panel2 = new System.Windows.Forms.Panel();
            this.BtnSincProdImp = new System.Windows.Forms.LinkLabel();
            this.BtnSincProdcomp = new System.Windows.Forms.LinkLabel();
            this.BtnSincProds = new System.Windows.Forms.LinkLabel();
            this.BtnSincComponentes = new System.Windows.Forms.LinkLabel();
            this.BtnSincCategorias = new System.Windows.Forms.LinkLabel();
            this.BtnSincFabricantes = new System.Windows.Forms.LinkLabel();
            this.BtnSincPresentaciones = new System.Windows.Forms.LinkLabel();
            this.BtnGuardar = new System.Windows.Forms.Button();
            this.BtnCancelar = new System.Windows.Forms.Button();
            this.LblUpdatedBy = new System.Windows.Forms.Label();
            this.LblUllSincronizacion = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.BtnSincronizaTodo = new System.Windows.Forms.LinkLabel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.BtnSincLotes = new System.Windows.Forms.LinkLabel();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Malla)).BeginInit();
            this.panel8.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel6.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.panel5);
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(10, 10);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(470, 428);
            this.panel1.TabIndex = 0;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.Malla);
            this.panel5.Controls.Add(this.panel8);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(0, 57);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(470, 371);
            this.panel5.TabIndex = 249;
            // 
            // Malla
            // 
            this.Malla.AllowUserToAddRows = false;
            this.Malla.AllowUserToDeleteRows = false;
            this.Malla.AllowUserToOrderColumns = true;
            this.Malla.AllowUserToResizeRows = false;
            this.Malla.BackgroundColor = System.Drawing.Color.White;
            this.Malla.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Malla.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.ScrollBar;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowFrame;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Malla.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.Malla.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Malla.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4});
            this.Malla.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Malla.EnableHeadersVisualStyles = false;
            this.Malla.Location = new System.Drawing.Point(0, 0);
            this.Malla.Margin = new System.Windows.Forms.Padding(4);
            this.Malla.Name = "Malla";
            this.Malla.Size = new System.Drawing.Size(470, 314);
            this.Malla.TabIndex = 248;
            this.Malla.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.Malla_CellEndEdit);
            // 
            // panel8
            // 
            this.panel8.BackColor = System.Drawing.Color.White;
            this.panel8.Controls.Add(this.LblModificadoPor);
            this.panel8.Controls.Add(this.LblCreadoPor);
            this.panel8.Controls.Add(this.label8);
            this.panel8.Controls.Add(this.label9);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel8.Location = new System.Drawing.Point(0, 314);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(470, 57);
            this.panel8.TabIndex = 250;
            // 
            // LblModificadoPor
            // 
            this.LblModificadoPor.AutoSize = true;
            this.LblModificadoPor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblModificadoPor.ForeColor = System.Drawing.SystemColors.Desktop;
            this.LblModificadoPor.Location = new System.Drawing.Point(103, 32);
            this.LblModificadoPor.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LblModificadoPor.Name = "LblModificadoPor";
            this.LblModificadoPor.Size = new System.Drawing.Size(124, 15);
            this.LblModificadoPor.TabIndex = 272;
            this.LblModificadoPor.Text = "lgromero 19-03-2020";
            // 
            // LblCreadoPor
            // 
            this.LblCreadoPor.AutoSize = true;
            this.LblCreadoPor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblCreadoPor.ForeColor = System.Drawing.SystemColors.Desktop;
            this.LblCreadoPor.Location = new System.Drawing.Point(83, 14);
            this.LblCreadoPor.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LblCreadoPor.Name = "LblCreadoPor";
            this.LblCreadoPor.Size = new System.Drawing.Size(145, 15);
            this.LblCreadoPor.TabIndex = 271;
            this.LblCreadoPor.Text = "jmendozaj el 22-01-2020";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label8.Location = new System.Drawing.Point(15, 32);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(89, 15);
            this.label8.TabIndex = 270;
            this.label8.Text = "Modificado por";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label9.Location = new System.Drawing.Point(15, 14);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(68, 15);
            this.label9.TabIndex = 269;
            this.label9.Text = "Creado por";
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.CboTabla);
            this.panel4.Controls.Add(this.BtnSalvarCampos);
            this.panel4.Controls.Add(this.BtnBorrarCampo);
            this.panel4.Controls.Add(this.BtnAddCampo);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(470, 57);
            this.panel4.TabIndex = 248;
            // 
            // CboTabla
            // 
            this.CboTabla.BackColor = System.Drawing.Color.White;
            this.CboTabla.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CboTabla.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CboTabla.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CboTabla.FormattingEnabled = true;
            this.CboTabla.Items.AddRange(new object[] {
            "Selecciona una tabla de migración"});
            this.CboTabla.Location = new System.Drawing.Point(3, 16);
            this.CboTabla.Name = "CboTabla";
            this.CboTabla.Size = new System.Drawing.Size(289, 26);
            this.CboTabla.TabIndex = 273;
            this.CboTabla.SelectedIndexChanged += new System.EventHandler(this.CboTabla_SelectedIndexChanged);
            // 
            // BtnSalvarCampos
            // 
            this.BtnSalvarCampos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnSalvarCampos.AutoSize = true;
            this.BtnSalvarCampos.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSalvarCampos.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.BtnSalvarCampos.LinkColor = System.Drawing.Color.Blue;
            this.BtnSalvarCampos.Location = new System.Drawing.Point(353, 19);
            this.BtnSalvarCampos.Name = "BtnSalvarCampos";
            this.BtnSalvarCampos.Size = new System.Drawing.Size(49, 18);
            this.BtnSalvarCampos.TabIndex = 250;
            this.BtnSalvarCampos.TabStop = true;
            this.BtnSalvarCampos.Text = "Salvar";
            this.BtnSalvarCampos.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.BtnSalvarCampos_LinkClicked);
            // 
            // BtnBorrarCampo
            // 
            this.BtnBorrarCampo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnBorrarCampo.AutoSize = true;
            this.BtnBorrarCampo.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnBorrarCampo.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.BtnBorrarCampo.LinkColor = System.Drawing.Color.Blue;
            this.BtnBorrarCampo.Location = new System.Drawing.Point(409, 19);
            this.BtnBorrarCampo.Name = "BtnBorrarCampo";
            this.BtnBorrarCampo.Size = new System.Drawing.Size(50, 18);
            this.BtnBorrarCampo.TabIndex = 249;
            this.BtnBorrarCampo.TabStop = true;
            this.BtnBorrarCampo.Text = "Borrar";
            this.BtnBorrarCampo.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.BtnBorrarCampo_LinkClicked);
            // 
            // BtnAddCampo
            // 
            this.BtnAddCampo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnAddCampo.AutoSize = true;
            this.BtnAddCampo.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnAddCampo.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.BtnAddCampo.LinkColor = System.Drawing.Color.Blue;
            this.BtnAddCampo.Location = new System.Drawing.Point(298, 19);
            this.BtnAddCampo.Name = "BtnAddCampo";
            this.BtnAddCampo.Size = new System.Drawing.Size(49, 18);
            this.BtnAddCampo.TabIndex = 248;
            this.BtnAddCampo.TabStop = true;
            this.BtnAddCampo.Text = "Añadir";
            this.BtnAddCampo.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.BtnAddCampo_LinkClicked);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.splitContainer1.Panel1.Controls.Add(this.panel1);
            this.splitContainer1.Panel1.Padding = new System.Windows.Forms.Padding(10);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.splitContainer1.Panel2.Controls.Add(this.panel2);
            this.splitContainer1.Panel2.Padding = new System.Windows.Forms.Padding(10);
            this.splitContainer1.Size = new System.Drawing.Size(992, 448);
            this.splitContainer1.SplitterDistance = 490;
            this.splitContainer1.TabIndex = 253;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.BtnSincLotes);
            this.panel2.Controls.Add(this.BtnSincProdImp);
            this.panel2.Controls.Add(this.BtnSincProdcomp);
            this.panel2.Controls.Add(this.BtnSincProds);
            this.panel2.Controls.Add(this.BtnSincComponentes);
            this.panel2.Controls.Add(this.BtnSincCategorias);
            this.panel2.Controls.Add(this.BtnSincFabricantes);
            this.panel2.Controls.Add(this.BtnSincPresentaciones);
            this.panel2.Controls.Add(this.BtnGuardar);
            this.panel2.Controls.Add(this.BtnCancelar);
            this.panel2.Controls.Add(this.LblUpdatedBy);
            this.panel2.Controls.Add(this.LblUllSincronizacion);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(10, 10);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(478, 428);
            this.panel2.TabIndex = 2;
            // 
            // BtnSincProdImp
            // 
            this.BtnSincProdImp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnSincProdImp.AutoSize = true;
            this.BtnSincProdImp.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSincProdImp.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.BtnSincProdImp.LinkColor = System.Drawing.Color.Blue;
            this.BtnSincProdImp.Location = new System.Drawing.Point(17, 317);
            this.BtnSincProdImp.Name = "BtnSincProdImp";
            this.BtnSincProdImp.Size = new System.Drawing.Size(316, 18);
            this.BtnSincProdImp.TabIndex = 276;
            this.BtnSincProdImp.TabStop = true;
            this.BtnSincProdImp.Text = "Click aquí para sincronizar existencias micropv";
            this.BtnSincProdImp.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.BtnSincProdImp_LinkClicked);
            // 
            // BtnSincProdcomp
            // 
            this.BtnSincProdcomp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnSincProdcomp.AutoSize = true;
            this.BtnSincProdcomp.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSincProdcomp.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.BtnSincProdcomp.LinkColor = System.Drawing.Color.Blue;
            this.BtnSincProdcomp.Location = new System.Drawing.Point(17, 285);
            this.BtnSincProdcomp.Name = "BtnSincProdcomp";
            this.BtnSincProdcomp.Size = new System.Drawing.Size(341, 18);
            this.BtnSincProdcomp.TabIndex = 275;
            this.BtnSincProdcomp.TabStop = true;
            this.BtnSincProdcomp.Text = "Click aquí para sincronizar prod-sustancia micropv";
            this.BtnSincProdcomp.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.BtnSincProdcomp_LinkClicked);
            // 
            // BtnSincProds
            // 
            this.BtnSincProds.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnSincProds.AutoSize = true;
            this.BtnSincProds.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSincProds.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.BtnSincProds.LinkColor = System.Drawing.Color.Blue;
            this.BtnSincProds.Location = new System.Drawing.Point(17, 218);
            this.BtnSincProds.Name = "BtnSincProds";
            this.BtnSincProds.Size = new System.Drawing.Size(310, 18);
            this.BtnSincProds.TabIndex = 273;
            this.BtnSincProds.TabStop = true;
            this.BtnSincProds.Text = "Click aquí para sincronizar productos micropv";
            this.BtnSincProds.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.BtnSincProds_LinkClicked);
            // 
            // BtnSincComponentes
            // 
            this.BtnSincComponentes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnSincComponentes.AutoSize = true;
            this.BtnSincComponentes.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSincComponentes.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.BtnSincComponentes.LinkColor = System.Drawing.Color.Blue;
            this.BtnSincComponentes.Location = new System.Drawing.Point(17, 185);
            this.BtnSincComponentes.Name = "BtnSincComponentes";
            this.BtnSincComponentes.Size = new System.Drawing.Size(314, 18);
            this.BtnSincComponentes.TabIndex = 272;
            this.BtnSincComponentes.TabStop = true;
            this.BtnSincComponentes.Text = "Click aquí para sincronizar sustancias micropv";
            this.BtnSincComponentes.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.BtnSincComponentes_LinkClicked);
            // 
            // BtnSincCategorias
            // 
            this.BtnSincCategorias.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnSincCategorias.AutoSize = true;
            this.BtnSincCategorias.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSincCategorias.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.BtnSincCategorias.LinkColor = System.Drawing.Color.Blue;
            this.BtnSincCategorias.Location = new System.Drawing.Point(17, 148);
            this.BtnSincCategorias.Name = "BtnSincCategorias";
            this.BtnSincCategorias.Size = new System.Drawing.Size(312, 18);
            this.BtnSincCategorias.TabIndex = 271;
            this.BtnSincCategorias.TabStop = true;
            this.BtnSincCategorias.Text = "Click aquí para sincronizar categorías micropv";
            this.BtnSincCategorias.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.BtnSincCategorias_LinkClicked);
            // 
            // BtnSincFabricantes
            // 
            this.BtnSincFabricantes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnSincFabricantes.AutoSize = true;
            this.BtnSincFabricantes.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSincFabricantes.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.BtnSincFabricantes.LinkColor = System.Drawing.Color.Blue;
            this.BtnSincFabricantes.Location = new System.Drawing.Point(17, 113);
            this.BtnSincFabricantes.Name = "BtnSincFabricantes";
            this.BtnSincFabricantes.Size = new System.Drawing.Size(315, 18);
            this.BtnSincFabricantes.TabIndex = 270;
            this.BtnSincFabricantes.TabStop = true;
            this.BtnSincFabricantes.Text = "Click aquí para sincronizar fabricantes micropv";
            this.BtnSincFabricantes.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.BtnSincFabricantes_LinkClicked);
            // 
            // BtnSincPresentaciones
            // 
            this.BtnSincPresentaciones.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnSincPresentaciones.AutoSize = true;
            this.BtnSincPresentaciones.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSincPresentaciones.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.BtnSincPresentaciones.LinkColor = System.Drawing.Color.Blue;
            this.BtnSincPresentaciones.Location = new System.Drawing.Point(17, 80);
            this.BtnSincPresentaciones.Name = "BtnSincPresentaciones";
            this.BtnSincPresentaciones.Size = new System.Drawing.Size(344, 18);
            this.BtnSincPresentaciones.TabIndex = 269;
            this.BtnSincPresentaciones.TabStop = true;
            this.BtnSincPresentaciones.Text = "Click aquí para sincronizar presentaciones micropv";
            this.BtnSincPresentaciones.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.BtnSincPresentaciones_LinkClicked);
            // 
            // BtnGuardar
            // 
            this.BtnGuardar.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.BtnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BtnGuardar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnGuardar.ForeColor = System.Drawing.Color.White;
            this.BtnGuardar.Location = new System.Drawing.Point(374, 382);
            this.BtnGuardar.Name = "BtnGuardar";
            this.BtnGuardar.Size = new System.Drawing.Size(88, 33);
            this.BtnGuardar.TabIndex = 268;
            this.BtnGuardar.Text = "Guardar";
            this.BtnGuardar.UseVisualStyleBackColor = false;
            this.BtnGuardar.Click += new System.EventHandler(this.BtnGuardar_Click);
            // 
            // BtnCancelar
            // 
            this.BtnCancelar.BackColor = System.Drawing.SystemColors.Control;
            this.BtnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BtnCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnCancelar.ForeColor = System.Drawing.SystemColors.MenuText;
            this.BtnCancelar.Location = new System.Drawing.Point(280, 382);
            this.BtnCancelar.Name = "BtnCancelar";
            this.BtnCancelar.Size = new System.Drawing.Size(88, 32);
            this.BtnCancelar.TabIndex = 267;
            this.BtnCancelar.Text = "Cancelar";
            this.BtnCancelar.UseVisualStyleBackColor = false;
            this.BtnCancelar.Click += new System.EventHandler(this.BtnCancelar_Click);
            // 
            // LblUpdatedBy
            // 
            this.LblUpdatedBy.AutoSize = true;
            this.LblUpdatedBy.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblUpdatedBy.ForeColor = System.Drawing.SystemColors.Desktop;
            this.LblUpdatedBy.Location = new System.Drawing.Point(115, 394);
            this.LblUpdatedBy.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LblUpdatedBy.Name = "LblUpdatedBy";
            this.LblUpdatedBy.Size = new System.Drawing.Size(124, 15);
            this.LblUpdatedBy.TabIndex = 265;
            this.LblUpdatedBy.Text = "lgromero 19-03-2020";
            // 
            // LblUllSincronizacion
            // 
            this.LblUllSincronizacion.AutoSize = true;
            this.LblUllSincronizacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblUllSincronizacion.ForeColor = System.Drawing.SystemColors.Desktop;
            this.LblUllSincronizacion.Location = new System.Drawing.Point(141, 372);
            this.LblUllSincronizacion.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LblUllSincronizacion.Name = "LblUllSincronizacion";
            this.LblUllSincronizacion.Size = new System.Drawing.Size(71, 15);
            this.LblUllSincronizacion.TabIndex = 264;
            this.LblUllSincronizacion.Text = "22-01-2020";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label7.Location = new System.Drawing.Point(17, 394);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(100, 15);
            this.label7.TabIndex = 263;
            this.label7.Text = "Sincronizado por";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label6.Location = new System.Drawing.Point(17, 372);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(125, 15);
            this.label6.TabIndex = 262;
            this.label6.Text = "Última sincronización";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.BtnSincronizaTodo);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(478, 57);
            this.panel3.TabIndex = 0;
            // 
            // BtnSincronizaTodo
            // 
            this.BtnSincronizaTodo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnSincronizaTodo.AutoSize = true;
            this.BtnSincronizaTodo.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSincronizaTodo.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.BtnSincronizaTodo.LinkColor = System.Drawing.Color.Blue;
            this.BtnSincronizaTodo.Location = new System.Drawing.Point(345, 19);
            this.BtnSincronizaTodo.Name = "BtnSincronizaTodo";
            this.BtnSincronizaTodo.Size = new System.Drawing.Size(117, 18);
            this.BtnSincronizaTodo.TabIndex = 2;
            this.BtnSincronizaTodo.TabStop = true;
            this.BtnSincronizaTodo.Text = "Sincronizar todo";
            this.BtnSincronizaTodo.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.BtnSincronizaTodo_LinkClicked);
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.splitContainer1);
            this.panel7.Cursor = System.Windows.Forms.Cursors.Default;
            this.panel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel7.Location = new System.Drawing.Point(0, 66);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(992, 448);
            this.panel7.TabIndex = 256;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label13.Location = new System.Drawing.Point(12, 15);
            this.label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(400, 25);
            this.label13.TabIndex = 253;
            this.label13.Text = "Configuración de sincronización micropv";
            // 
            // label14
            // 
            this.label14.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label14.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.label14.Location = new System.Drawing.Point(4, 40);
            this.label14.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(987, 10);
            this.label14.TabIndex = 252;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.label13);
            this.panel6.Controls.Add(this.label14);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel6.Location = new System.Drawing.Point(0, 0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(992, 66);
            this.panel6.TabIndex = 255;
            // 
            // BtnSincLotes
            // 
            this.BtnSincLotes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnSincLotes.AutoSize = true;
            this.BtnSincLotes.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSincLotes.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.BtnSincLotes.LinkColor = System.Drawing.Color.Blue;
            this.BtnSincLotes.Location = new System.Drawing.Point(17, 252);
            this.BtnSincLotes.Name = "BtnSincLotes";
            this.BtnSincLotes.Size = new System.Drawing.Size(275, 18);
            this.BtnSincLotes.TabIndex = 277;
            this.BtnSincLotes.TabStop = true;
            this.BtnSincLotes.Text = "Click aquí para sincronizar lotes micropv";
            this.BtnSincLotes.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.BtnSincLotes_LinkClicked);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "CampoId";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 70;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "TablaId";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 70;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Campo";
            this.Column3.Name = "Column3";
            this.Column3.Width = 70;
            // 
            // Column4
            // 
            this.Column4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column4.HeaderText = "Expresión";
            this.Column4.Name = "Column4";
            // 
            // FrmSincronizampv
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(992, 514);
            this.Controls.Add(this.panel7);
            this.Controls.Add(this.panel6);
            this.Name = "FrmSincronizampv";
            this.Text = "FrmSincronizampv";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmSincronizampv_FormClosing);
            this.panel1.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Malla)).EndInit();
            this.panel8.ResumeLayout(false);
            this.panel8.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel7.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.DataGridView Malla;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Label LblModificadoPor;
        private System.Windows.Forms.Label LblCreadoPor;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.LinkLabel BtnBorrarCampo;
        private System.Windows.Forms.LinkLabel BtnAddCampo;
        private System.Windows.Forms.LinkLabel BtnSalvarCampos;
        private System.Windows.Forms.ComboBox CboTabla;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.LinkLabel BtnSincProdImp;
        private System.Windows.Forms.LinkLabel BtnSincProdcomp;
        private System.Windows.Forms.LinkLabel BtnSincProds;
        private System.Windows.Forms.LinkLabel BtnSincComponentes;
        private System.Windows.Forms.LinkLabel BtnSincCategorias;
        private System.Windows.Forms.LinkLabel BtnSincFabricantes;
        private System.Windows.Forms.LinkLabel BtnSincPresentaciones;
        private System.Windows.Forms.Button BtnGuardar;
        private System.Windows.Forms.Button BtnCancelar;
        private System.Windows.Forms.Label LblUpdatedBy;
        private System.Windows.Forms.Label LblUllSincronizacion;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.LinkLabel BtnSincronizaTodo;
        private System.Windows.Forms.LinkLabel BtnSincLotes;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
    }
}