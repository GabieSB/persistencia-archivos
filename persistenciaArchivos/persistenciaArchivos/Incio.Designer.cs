namespace persistenciaArchivos
{
    partial class Incio
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
            this.CrearChequesButton = new System.Windows.Forms.Button();
            this.VerChequesButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // CrearChequesButton
            // 
            this.CrearChequesButton.Location = new System.Drawing.Point(164, 52);
            this.CrearChequesButton.Name = "CrearChequesButton";
            this.CrearChequesButton.Size = new System.Drawing.Size(273, 83);
            this.CrearChequesButton.TabIndex = 0;
            this.CrearChequesButton.Text = "Crear Cheques";
            this.CrearChequesButton.UseVisualStyleBackColor = true;
            this.CrearChequesButton.Click += new System.EventHandler(this.CrearChequesButton_Click);
            // 
            // VerChequesButton
            // 
            this.VerChequesButton.Location = new System.Drawing.Point(164, 165);
            this.VerChequesButton.Name = "VerChequesButton";
            this.VerChequesButton.Size = new System.Drawing.Size(273, 83);
            this.VerChequesButton.TabIndex = 1;
            this.VerChequesButton.Text = "Ver Cheques";
            this.VerChequesButton.UseVisualStyleBackColor = true;
            this.VerChequesButton.Click += new System.EventHandler(this.VerChequesButton_Click);
            // 
            // Incio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(594, 343);
            this.Controls.Add(this.VerChequesButton);
            this.Controls.Add(this.CrearChequesButton);
            this.Name = "Incio";
            this.Text = "Incio";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button CrearChequesButton;
        private System.Windows.Forms.Button VerChequesButton;
    }
}