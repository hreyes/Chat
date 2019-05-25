namespace Cliente
{
    partial class Form1
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
            this.btnConecta = new System.Windows.Forms.Button();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.btnEnvia = new System.Windows.Forms.Button();
            this.txtInformacion = new System.Windows.Forms.TextBox();
            this.txtIP = new System.Windows.Forms.TextBox();
            this.btnColor = new System.Windows.Forms.Button();
            this.lstDatos = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // btnConecta
            // 
            this.btnConecta.Location = new System.Drawing.Point(373, 12);
            this.btnConecta.Name = "btnConecta";
            this.btnConecta.Size = new System.Drawing.Size(75, 23);
            this.btnConecta.TabIndex = 0;
            this.btnConecta.Text = "Conectar";
            this.btnConecta.UseVisualStyleBackColor = true;
            this.btnConecta.Click += new System.EventHandler(this.btnConecta_Click);
            // 
            // lblUsuario
            // 
            this.lblUsuario.AutoSize = true;
            this.lblUsuario.Location = new System.Drawing.Point(13, 15);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(35, 13);
            this.lblUsuario.TabIndex = 1;
            this.lblUsuario.Text = "label1";
            // 
            // btnEnvia
            // 
            this.btnEnvia.Location = new System.Drawing.Point(373, 296);
            this.btnEnvia.Name = "btnEnvia";
            this.btnEnvia.Size = new System.Drawing.Size(75, 23);
            this.btnEnvia.TabIndex = 3;
            this.btnEnvia.Text = "Enviar";
            this.btnEnvia.UseVisualStyleBackColor = true;
            this.btnEnvia.Click += new System.EventHandler(this.btnEnvia_Click);
            // 
            // txtInformacion
            // 
            this.txtInformacion.Location = new System.Drawing.Point(16, 296);
            this.txtInformacion.Name = "txtInformacion";
            this.txtInformacion.Size = new System.Drawing.Size(341, 20);
            this.txtInformacion.TabIndex = 4;
            // 
            // txtIP
            // 
            this.txtIP.Location = new System.Drawing.Point(242, 14);
            this.txtIP.Name = "txtIP";
            this.txtIP.Size = new System.Drawing.Size(125, 20);
            this.txtIP.TabIndex = 5;
            // 
            // btnColor
            // 
            this.btnColor.Location = new System.Drawing.Point(373, 267);
            this.btnColor.Name = "btnColor";
            this.btnColor.Size = new System.Drawing.Size(75, 23);
            this.btnColor.TabIndex = 6;
            this.btnColor.Text = "Color";
            this.btnColor.UseVisualStyleBackColor = true;
            this.btnColor.Click += new System.EventHandler(this.BtnColor_Click);
            // 
            // lstDatos
            // 
            this.lstDatos.FormattingEnabled = true;
            this.lstDatos.Location = new System.Drawing.Point(13, 54);
            this.lstDatos.Name = "lstDatos";
            this.lstDatos.Size = new System.Drawing.Size(435, 199);
            this.lstDatos.TabIndex = 2;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(460, 331);
            this.Controls.Add(this.btnColor);
            this.Controls.Add(this.txtIP);
            this.Controls.Add(this.txtInformacion);
            this.Controls.Add(this.btnEnvia);
            this.Controls.Add(this.lstDatos);
            this.Controls.Add(this.lblUsuario);
            this.Controls.Add(this.btnConecta);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnConecta;
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.Button btnEnvia;
        private System.Windows.Forms.TextBox txtInformacion;
        private System.Windows.Forms.TextBox txtIP;
        private System.Windows.Forms.Button btnColor;
        private System.Windows.Forms.ListBox lstDatos;
    }
}

