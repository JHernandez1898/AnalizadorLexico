namespace Analizador_Léxico
{
    partial class Form1
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
            this.lblEntrada = new System.Windows.Forms.Label();
            this.lblSubcadenaEvaluar = new System.Windows.Forms.Label();
            this.txtSubcadena = new System.Windows.Forms.TextBox();
            this.txtcadenatokens = new System.Windows.Forms.TextBox();
            this.lblcadenatokens = new System.Windows.Forms.Label();
            this.txtnumrenglon = new System.Windows.Forms.TextBox();
            this.lblnumrenglon = new System.Windows.Forms.Label();
            this.txttoken = new System.Windows.Forms.TextBox();
            this.lbltoken = new System.Windows.Forms.Label();
            this.rtxtcodigointermedio = new System.Windows.Forms.RichTextBox();
            this.btnleersiguiente = new System.Windows.Forms.Button();
            this.btnleertodo = new System.Windows.Forms.Button();
            this.rtxtentrada = new System.Windows.Forms.RichTextBox();
            this.lblcodigointermedio = new System.Windows.Forms.Label();
            this.txtEstadoAnt = new System.Windows.Forms.TextBox();
            this.lblEstado = new System.Windows.Forms.Label();
            this.btnCaracterXCaracter = new System.Windows.Forms.Button();
            this.txtEstadoActual = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCaracter = new System.Windows.Forms.TextBox();
            this.lblChar = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblEntrada
            // 
            this.lblEntrada.AutoSize = true;
            this.lblEntrada.Location = new System.Drawing.Point(12, 9);
            this.lblEntrada.Name = "lblEntrada";
            this.lblEntrada.Size = new System.Drawing.Size(44, 13);
            this.lblEntrada.TabIndex = 0;
            this.lblEntrada.Text = "Entrada";
            // 
            // lblSubcadenaEvaluar
            // 
            this.lblSubcadenaEvaluar.AutoSize = true;
            this.lblSubcadenaEvaluar.Location = new System.Drawing.Point(9, 105);
            this.lblSubcadenaEvaluar.Name = "lblSubcadenaEvaluar";
            this.lblSubcadenaEvaluar.Size = new System.Drawing.Size(109, 13);
            this.lblSubcadenaEvaluar.TabIndex = 2;
            this.lblSubcadenaEvaluar.Text = "Subcadena a evaluar";
            // 
            // txtSubcadena
            // 
            this.txtSubcadena.Location = new System.Drawing.Point(12, 121);
            this.txtSubcadena.Name = "txtSubcadena";
            this.txtSubcadena.Size = new System.Drawing.Size(386, 20);
            this.txtSubcadena.TabIndex = 3;
            // 
            // txtcadenatokens
            // 
            this.txtcadenatokens.Location = new System.Drawing.Point(12, 165);
            this.txtcadenatokens.Name = "txtcadenatokens";
            this.txtcadenatokens.Size = new System.Drawing.Size(386, 20);
            this.txtcadenatokens.TabIndex = 5;
            // 
            // lblcadenatokens
            // 
            this.lblcadenatokens.AutoSize = true;
            this.lblcadenatokens.Location = new System.Drawing.Point(9, 149);
            this.lblcadenatokens.Name = "lblcadenatokens";
            this.lblcadenatokens.Size = new System.Drawing.Size(83, 13);
            this.lblcadenatokens.TabIndex = 4;
            this.lblcadenatokens.Text = "Cadena Tokens";
            // 
            // txtnumrenglon
            // 
            this.txtnumrenglon.Location = new System.Drawing.Point(468, 26);
            this.txtnumrenglon.Name = "txtnumrenglon";
            this.txtnumrenglon.Size = new System.Drawing.Size(138, 20);
            this.txtnumrenglon.TabIndex = 7;
            // 
            // lblnumrenglon
            // 
            this.lblnumrenglon.AutoSize = true;
            this.lblnumrenglon.Location = new System.Drawing.Point(465, 9);
            this.lblnumrenglon.Name = "lblnumrenglon";
            this.lblnumrenglon.Size = new System.Drawing.Size(67, 13);
            this.lblnumrenglon.TabIndex = 6;
            this.lblnumrenglon.Text = "# de renglon";
            // 
            // txttoken
            // 
            this.txttoken.Location = new System.Drawing.Point(468, 149);
            this.txttoken.Name = "txttoken";
            this.txttoken.Size = new System.Drawing.Size(138, 20);
            this.txttoken.TabIndex = 9;
            // 
            // lbltoken
            // 
            this.lbltoken.AutoSize = true;
            this.lbltoken.Location = new System.Drawing.Point(465, 128);
            this.lbltoken.Name = "lbltoken";
            this.lbltoken.Size = new System.Drawing.Size(38, 13);
            this.lbltoken.TabIndex = 8;
            this.lbltoken.Text = "Token";
            // 
            // rtxtcodigointermedio
            // 
            this.rtxtcodigointermedio.Location = new System.Drawing.Point(12, 218);
            this.rtxtcodigointermedio.Name = "rtxtcodigointermedio";
            this.rtxtcodigointermedio.Size = new System.Drawing.Size(386, 163);
            this.rtxtcodigointermedio.TabIndex = 10;
            this.rtxtcodigointermedio.Text = "";
            // 
            // btnleersiguiente
            // 
            this.btnleersiguiente.Location = new System.Drawing.Point(485, 244);
            this.btnleersiguiente.Name = "btnleersiguiente";
            this.btnleersiguiente.Size = new System.Drawing.Size(98, 34);
            this.btnleersiguiente.TabIndex = 11;
            this.btnleersiguiente.Text = "Leer Siguiente";
            this.btnleersiguiente.UseVisualStyleBackColor = true;
            // 
            // btnleertodo
            // 
            this.btnleertodo.Location = new System.Drawing.Point(485, 297);
            this.btnleertodo.Name = "btnleertodo";
            this.btnleertodo.Size = new System.Drawing.Size(98, 34);
            this.btnleertodo.TabIndex = 12;
            this.btnleertodo.Text = "Leer Todo";
            this.btnleertodo.UseVisualStyleBackColor = true;
            this.btnleertodo.Click += new System.EventHandler(this.btnleertodo_Click);
            // 
            // rtxtentrada
            // 
            this.rtxtentrada.Location = new System.Drawing.Point(12, 25);
            this.rtxtentrada.Name = "rtxtentrada";
            this.rtxtentrada.Size = new System.Drawing.Size(386, 66);
            this.rtxtentrada.TabIndex = 13;
            this.rtxtentrada.Text = "";
            // 
            // lblcodigointermedio
            // 
            this.lblcodigointermedio.AutoSize = true;
            this.lblcodigointermedio.Location = new System.Drawing.Point(9, 202);
            this.lblcodigointermedio.Name = "lblcodigointermedio";
            this.lblcodigointermedio.Size = new System.Drawing.Size(92, 13);
            this.lblcodigointermedio.TabIndex = 14;
            this.lblcodigointermedio.Text = "Codigo Intermedio";
            // 
            // txtEstadoAnt
            // 
            this.txtEstadoAnt.Location = new System.Drawing.Point(469, 65);
            this.txtEstadoAnt.Name = "txtEstadoAnt";
            this.txtEstadoAnt.Size = new System.Drawing.Size(37, 20);
            this.txtEstadoAnt.TabIndex = 16;
            // 
            // lblEstado
            // 
            this.lblEstado.AutoSize = true;
            this.lblEstado.Location = new System.Drawing.Point(466, 49);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(79, 13);
            this.lblEstado.TabIndex = 15;
            this.lblEstado.Text = "Estado Anterior";
            // 
            // btnCaracterXCaracter
            // 
            this.btnCaracterXCaracter.Location = new System.Drawing.Point(485, 191);
            this.btnCaracterXCaracter.Name = "btnCaracterXCaracter";
            this.btnCaracterXCaracter.Size = new System.Drawing.Size(98, 34);
            this.btnCaracterXCaracter.TabIndex = 17;
            this.btnCaracterXCaracter.Text = "Leer Caracter";
            this.btnCaracterXCaracter.UseVisualStyleBackColor = true;
            this.btnCaracterXCaracter.Click += new System.EventHandler(this.btnCaracterXCaracter_Click);
            // 
            // txtEstadoActual
            // 
            this.txtEstadoActual.Location = new System.Drawing.Point(560, 65);
            this.txtEstadoActual.Name = "txtEstadoActual";
            this.txtEstadoActual.Size = new System.Drawing.Size(37, 20);
            this.txtEstadoActual.TabIndex = 19;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(557, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 13);
            this.label1.TabIndex = 18;
            this.label1.Text = "Estado Actual";
            // 
            // txtCaracter
            // 
            this.txtCaracter.Location = new System.Drawing.Point(469, 105);
            this.txtCaracter.Name = "txtCaracter";
            this.txtCaracter.Size = new System.Drawing.Size(37, 20);
            this.txtCaracter.TabIndex = 21;
            // 
            // lblChar
            // 
            this.lblChar.AutoSize = true;
            this.lblChar.Location = new System.Drawing.Point(466, 88);
            this.lblChar.Name = "lblChar";
            this.lblChar.Size = new System.Drawing.Size(80, 13);
            this.lblChar.TabIndex = 20;
            this.lblChar.Text = "Caracter Actual";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(633, 398);
            this.Controls.Add(this.txtCaracter);
            this.Controls.Add(this.lblChar);
            this.Controls.Add(this.txtEstadoActual);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCaracterXCaracter);
            this.Controls.Add(this.txtEstadoAnt);
            this.Controls.Add(this.lblEstado);
            this.Controls.Add(this.lblcodigointermedio);
            this.Controls.Add(this.rtxtentrada);
            this.Controls.Add(this.btnleertodo);
            this.Controls.Add(this.btnleersiguiente);
            this.Controls.Add(this.rtxtcodigointermedio);
            this.Controls.Add(this.txttoken);
            this.Controls.Add(this.lbltoken);
            this.Controls.Add(this.txtnumrenglon);
            this.Controls.Add(this.lblnumrenglon);
            this.Controls.Add(this.txtcadenatokens);
            this.Controls.Add(this.lblcadenatokens);
            this.Controls.Add(this.txtSubcadena);
            this.Controls.Add(this.lblSubcadenaEvaluar);
            this.Controls.Add(this.lblEntrada);
            this.Name = "Form1";
            this.Text = "Analizador Léxico";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblEntrada;
        private System.Windows.Forms.Label lblSubcadenaEvaluar;
        private System.Windows.Forms.TextBox txtSubcadena;
        private System.Windows.Forms.TextBox txtcadenatokens;
        private System.Windows.Forms.Label lblcadenatokens;
        private System.Windows.Forms.TextBox txtnumrenglon;
        private System.Windows.Forms.Label lblnumrenglon;
        private System.Windows.Forms.TextBox txttoken;
        private System.Windows.Forms.Label lbltoken;
        private System.Windows.Forms.RichTextBox rtxtcodigointermedio;
        private System.Windows.Forms.Button btnleersiguiente;
        private System.Windows.Forms.Button btnleertodo;
        private System.Windows.Forms.RichTextBox rtxtentrada;
        private System.Windows.Forms.Label lblcodigointermedio;
        private System.Windows.Forms.TextBox txtEstadoAnt;
        private System.Windows.Forms.Label lblEstado;
        private System.Windows.Forms.Button btnCaracterXCaracter;
        private System.Windows.Forms.TextBox txtEstadoActual;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCaracter;
        private System.Windows.Forms.Label lblChar;
    }
}

