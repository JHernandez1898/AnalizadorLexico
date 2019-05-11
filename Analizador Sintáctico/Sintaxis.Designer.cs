namespace Analizador_Sintáctico
{
    partial class Sintaxis
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
            this.rtxtentrada = new System.Windows.Forms.RichTextBox();
            this.lblEntrada = new System.Windows.Forms.Label();
            this.btnleertodo = new System.Windows.Forms.Button();
            this.lblcodigointermedio = new System.Windows.Forms.Label();
            this.rtxtcodigointermedio = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // rtxtentrada
            // 
            this.rtxtentrada.Location = new System.Drawing.Point(12, 24);
            this.rtxtentrada.Name = "rtxtentrada";
            this.rtxtentrada.Size = new System.Drawing.Size(386, 66);
            this.rtxtentrada.TabIndex = 15;
            this.rtxtentrada.Text = "";
            // 
            // lblEntrada
            // 
            this.lblEntrada.AutoSize = true;
            this.lblEntrada.Location = new System.Drawing.Point(12, 8);
            this.lblEntrada.Name = "lblEntrada";
            this.lblEntrada.Size = new System.Drawing.Size(44, 13);
            this.lblEntrada.TabIndex = 14;
            this.lblEntrada.Text = "Entrada";
            // 
            // btnleertodo
            // 
            this.btnleertodo.Location = new System.Drawing.Point(411, 89);
            this.btnleertodo.Name = "btnleertodo";
            this.btnleertodo.Size = new System.Drawing.Size(145, 34);
            this.btnleertodo.TabIndex = 16;
            this.btnleertodo.Text = "Leer Todo";
            this.btnleertodo.UseVisualStyleBackColor = true;
            this.btnleertodo.Click += new System.EventHandler(this.btnleertodo_Click);
            // 
            // lblcodigointermedio
            // 
            this.lblcodigointermedio.AutoSize = true;
            this.lblcodigointermedio.Location = new System.Drawing.Point(9, 100);
            this.lblcodigointermedio.Name = "lblcodigointermedio";
            this.lblcodigointermedio.Size = new System.Drawing.Size(92, 13);
            this.lblcodigointermedio.TabIndex = 18;
            this.lblcodigointermedio.Text = "Codigo Intermedio";
            // 
            // rtxtcodigointermedio
            // 
            this.rtxtcodigointermedio.Location = new System.Drawing.Point(12, 116);
            this.rtxtcodigointermedio.Name = "rtxtcodigointermedio";
            this.rtxtcodigointermedio.Size = new System.Drawing.Size(386, 163);
            this.rtxtcodigointermedio.TabIndex = 17;
            this.rtxtcodigointermedio.Text = "";
            // 
            // Sintaxis
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(568, 290);
            this.Controls.Add(this.lblcodigointermedio);
            this.Controls.Add(this.rtxtcodigointermedio);
            this.Controls.Add(this.btnleertodo);
            this.Controls.Add(this.rtxtentrada);
            this.Controls.Add(this.lblEntrada);
            this.Name = "Sintaxis";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox rtxtentrada;
        private System.Windows.Forms.Label lblEntrada;
        private System.Windows.Forms.Button btnleertodo;
        private System.Windows.Forms.Label lblcodigointermedio;
        private System.Windows.Forms.RichTextBox rtxtcodigointermedio;
    }
}

