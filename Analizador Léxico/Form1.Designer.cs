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
            this.dgvIDE = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvConstatesNumericas = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvConstantesExpo = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvIDE)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvConstatesNumericas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvConstantesExpo)).BeginInit();
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
            this.txtnumrenglon.Location = new System.Drawing.Point(445, 25);
            this.txtnumrenglon.Name = "txtnumrenglon";
            this.txtnumrenglon.Size = new System.Drawing.Size(138, 20);
            this.txtnumrenglon.TabIndex = 7;
            // 
            // lblnumrenglon
            // 
            this.lblnumrenglon.AutoSize = true;
            this.lblnumrenglon.Location = new System.Drawing.Point(442, 8);
            this.lblnumrenglon.Name = "lblnumrenglon";
            this.lblnumrenglon.Size = new System.Drawing.Size(67, 13);
            this.lblnumrenglon.TabIndex = 6;
            this.lblnumrenglon.Text = "# de renglon";
            // 
            // txttoken
            // 
            this.txttoken.Location = new System.Drawing.Point(445, 70);
            this.txttoken.Name = "txttoken";
            this.txttoken.Size = new System.Drawing.Size(138, 20);
            this.txttoken.TabIndex = 9;
            // 
            // lbltoken
            // 
            this.lbltoken.AutoSize = true;
            this.lbltoken.Location = new System.Drawing.Point(442, 53);
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
            this.btnleersiguiente.Location = new System.Drawing.Point(466, 113);
            this.btnleersiguiente.Name = "btnleersiguiente";
            this.btnleersiguiente.Size = new System.Drawing.Size(98, 34);
            this.btnleersiguiente.TabIndex = 11;
            this.btnleersiguiente.Text = "Leer Siguiente";
            this.btnleersiguiente.UseVisualStyleBackColor = true;
            // 
            // btnleertodo
            // 
            this.btnleertodo.Location = new System.Drawing.Point(466, 157);
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
            // dgvIDE
            // 
            this.dgvIDE.AllowUserToAddRows = false;
            this.dgvIDE.AllowUserToDeleteRows = false;
            this.dgvIDE.AllowUserToResizeColumns = false;
            this.dgvIDE.AllowUserToResizeRows = false;
            this.dgvIDE.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvIDE.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4});
            this.dgvIDE.Location = new System.Drawing.Point(12, 403);
            this.dgvIDE.Name = "dgvIDE";
            this.dgvIDE.RowHeadersVisible = false;
            this.dgvIDE.Size = new System.Drawing.Size(200, 163);
            this.dgvIDE.TabIndex = 15;
            // 
            // Column1
            // 
            this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column1.HeaderText = "No.";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column2.HeaderText = "Nombre";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column3.HeaderText = "Tipo";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column4.HeaderText = "Cont.";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 387);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 13);
            this.label1.TabIndex = 16;
            this.label1.Text = "Identificadores";
            // 
            // dgvConstatesNumericas
            // 
            this.dgvConstatesNumericas.AllowUserToAddRows = false;
            this.dgvConstatesNumericas.AllowUserToDeleteRows = false;
            this.dgvConstatesNumericas.AllowUserToResizeColumns = false;
            this.dgvConstatesNumericas.AllowUserToResizeRows = false;
            this.dgvConstatesNumericas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvConstatesNumericas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.Column5});
            this.dgvConstatesNumericas.Location = new System.Drawing.Point(218, 403);
            this.dgvConstatesNumericas.Name = "dgvConstatesNumericas";
            this.dgvConstatesNumericas.RowHeadersVisible = false;
            this.dgvConstatesNumericas.Size = new System.Drawing.Size(200, 163);
            this.dgvConstatesNumericas.TabIndex = 17;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(218, 387);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(113, 13);
            this.label2.TabIndex = 18;
            this.label2.Text = "Constantes Numericas";
            // 
            // dgvConstantesExpo
            // 
            this.dgvConstantesExpo.AllowUserToAddRows = false;
            this.dgvConstantesExpo.AllowUserToDeleteRows = false;
            this.dgvConstantesExpo.AllowUserToResizeColumns = false;
            this.dgvConstantesExpo.AllowUserToResizeRows = false;
            this.dgvConstantesExpo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvConstantesExpo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn8,
            this.Column6});
            this.dgvConstantesExpo.Location = new System.Drawing.Point(424, 403);
            this.dgvConstantesExpo.Name = "dgvConstantesExpo";
            this.dgvConstantesExpo.RowHeadersVisible = false;
            this.dgvConstantesExpo.Size = new System.Drawing.Size(200, 163);
            this.dgvConstantesExpo.TabIndex = 19;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(421, 387);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(132, 13);
            this.label3.TabIndex = 20;
            this.label3.Text = "Constantes Exponenciales";
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn1.HeaderText = "No.";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Contenido";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn5.HeaderText = "No.";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn8.HeaderText = "Contenido";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.ReadOnly = true;
            // 
            // Column6
            // 
            this.Column6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column6.HeaderText = "Exponente";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(628, 570);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dgvConstantesExpo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dgvConstatesNumericas);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvIDE);
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
            ((System.ComponentModel.ISupportInitialize)(this.dgvIDE)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvConstatesNumericas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvConstantesExpo)).EndInit();
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
        private System.Windows.Forms.DataGridView dgvIDE;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridView dgvConstatesNumericas;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgvConstantesExpo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
    }
}

