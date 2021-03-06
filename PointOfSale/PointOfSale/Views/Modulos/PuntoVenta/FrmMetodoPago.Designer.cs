﻿namespace PointOfSale.Views.Modulos.PuntoVenta
{
    partial class FrmMetodoPago
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
            this.BtnCancelar = new System.Windows.Forms.Button();
            this.BtnAceptar = new System.Windows.Forms.Button();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.TxtMetodoPagoId = new System.Windows.Forms.TextBox();
            this.TxtMetodoPago = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // BtnCancelar
            // 
            this.BtnCancelar.Location = new System.Drawing.Point(209, 131);
            this.BtnCancelar.Name = "BtnCancelar";
            this.BtnCancelar.Size = new System.Drawing.Size(148, 40);
            this.BtnCancelar.TabIndex = 3;
            this.BtnCancelar.Text = "SALIR";
            this.BtnCancelar.UseVisualStyleBackColor = true;
            this.BtnCancelar.Click += new System.EventHandler(this.BtnCancelar_Click);
            // 
            // BtnAceptar
            // 
            this.BtnAceptar.Location = new System.Drawing.Point(56, 131);
            this.BtnAceptar.Name = "BtnAceptar";
            this.BtnAceptar.Size = new System.Drawing.Size(148, 40);
            this.BtnAceptar.TabIndex = 2;
            this.BtnAceptar.Text = "ACEPTAR";
            this.BtnAceptar.UseVisualStyleBackColor = true;
            this.BtnAceptar.Click += new System.EventHandler(this.BtnAceptar_Click);
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.ForeColor = System.Drawing.Color.MidnightBlue;
            this.lblTitulo.Location = new System.Drawing.Point(-1, 6);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(174, 25);
            this.lblTitulo.TabIndex = 126;
            this.lblTitulo.Text = "Método de pago ";
            // 
            // label14
            // 
            this.label14.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label14.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.label14.Location = new System.Drawing.Point(1, 31);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(368, 10);
            this.label14.TabIndex = 125;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label1.Location = new System.Drawing.Point(50, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(165, 18);
            this.label1.TabIndex = 135;
            this.label1.Text = "♥MÉTODO DE PAGO";
            // 
            // TxtMetodoPagoId
            // 
            this.TxtMetodoPagoId.BackColor = System.Drawing.SystemColors.Window;
            this.TxtMetodoPagoId.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TxtMetodoPagoId.Enabled = false;
            this.TxtMetodoPagoId.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtMetodoPagoId.ForeColor = System.Drawing.Color.DimGray;
            this.TxtMetodoPagoId.Location = new System.Drawing.Point(12, 78);
            this.TxtMetodoPagoId.Name = "TxtMetodoPagoId";
            this.TxtMetodoPagoId.Size = new System.Drawing.Size(35, 24);
            this.TxtMetodoPagoId.TabIndex = 1;
            this.TxtMetodoPagoId.TabStop = false;
            this.TxtMetodoPagoId.Text = "PUE";
            // 
            // TxtMetodoPago
            // 
            this.TxtMetodoPago.BackColor = System.Drawing.SystemColors.Window;
            this.TxtMetodoPago.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TxtMetodoPago.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtMetodoPago.ForeColor = System.Drawing.Color.DimGray;
            this.TxtMetodoPago.Location = new System.Drawing.Point(53, 78);
            this.TxtMetodoPago.Name = "TxtMetodoPago";
            this.TxtMetodoPago.Size = new System.Drawing.Size(301, 24);
            this.TxtMetodoPago.TabIndex = 1;
            this.TxtMetodoPago.Text = "PAGO EN UNA SOLA EXHIBICIÓN";
            this.TxtMetodoPago.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtMetodoPago_KeyDown);
            // 
            // FrmMetodoPago
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(369, 183);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TxtMetodoPagoId);
            this.Controls.Add(this.TxtMetodoPago);
            this.Controls.Add(this.BtnCancelar);
            this.Controls.Add(this.BtnAceptar);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.label14);
            this.MaximumSize = new System.Drawing.Size(385, 222);
            this.Name = "FrmMetodoPago";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmMetodoPago";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button BtnCancelar;
        private System.Windows.Forms.Button BtnAceptar;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TxtMetodoPagoId;
        private System.Windows.Forms.TextBox TxtMetodoPago;
    }
}