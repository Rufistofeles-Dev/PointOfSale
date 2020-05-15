namespace PointOfSale.Views.Menus
{
    partial class FrmAlmacenes
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
            this.BtnProductos = new System.Windows.Forms.Button();
            this.BtnInventario = new System.Windows.Forms.Button();
            this.BtnImprimeEtiquetas = new System.Windows.Forms.Button();
            this.BtnSalir = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // BtnProductos
            // 
            this.BtnProductos.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnProductos.Location = new System.Drawing.Point(74, 49);
            this.BtnProductos.Name = "BtnProductos";
            this.BtnProductos.Size = new System.Drawing.Size(133, 49);
            this.BtnProductos.TabIndex = 2;
            this.BtnProductos.Text = "&PRODUCTOS";
            this.BtnProductos.UseVisualStyleBackColor = true;
            this.BtnProductos.Click += new System.EventHandler(this.BtnProductos_Click);
            // 
            // BtnInventario
            // 
            this.BtnInventario.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnInventario.Location = new System.Drawing.Point(337, 49);
            this.BtnInventario.Name = "BtnInventario";
            this.BtnInventario.Size = new System.Drawing.Size(133, 49);
            this.BtnInventario.TabIndex = 3;
            this.BtnInventario.Text = "&INVENTARIAR";
            this.BtnInventario.UseVisualStyleBackColor = true;
            this.BtnInventario.Click += new System.EventHandler(this.BtnInventario_Click);
            // 
            // BtnImprimeEtiquetas
            // 
            this.BtnImprimeEtiquetas.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnImprimeEtiquetas.Location = new System.Drawing.Point(73, 133);
            this.BtnImprimeEtiquetas.Name = "BtnImprimeEtiquetas";
            this.BtnImprimeEtiquetas.Size = new System.Drawing.Size(133, 49);
            this.BtnImprimeEtiquetas.TabIndex = 4;
            this.BtnImprimeEtiquetas.Text = "&IMPRIME ETIQUETAS X SUSTANCIA";
            this.BtnImprimeEtiquetas.UseVisualStyleBackColor = true;
            // 
            // BtnSalir
            // 
            this.BtnSalir.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSalir.Location = new System.Drawing.Point(493, 265);
            this.BtnSalir.Name = "BtnSalir";
            this.BtnSalir.Size = new System.Drawing.Size(86, 49);
            this.BtnSalir.TabIndex = 5;
            this.BtnSalir.Text = "&SALIDA";
            this.BtnSalir.UseVisualStyleBackColor = true;
            // 
            // FrmAlmacenes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::PointOfSale.Properties.Resources.inv;
            this.ClientSize = new System.Drawing.Size(591, 327);
            this.Controls.Add(this.BtnSalir);
            this.Controls.Add(this.BtnImprimeEtiquetas);
            this.Controls.Add(this.BtnInventario);
            this.Controls.Add(this.BtnProductos);
            this.MaximumSize = new System.Drawing.Size(607, 366);
            this.MinimumSize = new System.Drawing.Size(607, 366);
            this.Name = "FrmAlmacenes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmAlmacenes";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button BtnProductos;
        private System.Windows.Forms.Button BtnInventario;
        private System.Windows.Forms.Button BtnImprimeEtiquetas;
        private System.Windows.Forms.Button BtnSalir;
    }
}